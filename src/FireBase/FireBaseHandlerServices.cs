using Firebase.Auth;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using UniversityHelperApp.Models;

namespace UniversityHelperApp.FireBase
{
    public class FireBaseHandlerServices<T> where T : BaseClass
    {

        /// <summary>
        /// Use the db from the FireBaseHandler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetAllDocuments(string path, FirestoreDb db)
        {
            List<T> modules = new List<T>();
            try
            {
                Query allModules = db.Collection(path);
                QuerySnapshot allModulesSnapchot = await allModules.GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in allModulesSnapchot)
                {
                    T en = documentSnapshot.ConvertTo<T>();
                    en.ID = documentSnapshot.Id;
                    en.Path = path + "/" + documentSnapshot.Id;

                    //entity mo = documentSnapshot.ConvertTo<entity>();
                    modules.Add(en);
                }
                return modules;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return modules;
        }

        public static async Task<T> GetDocument(string path, FirestoreDb db)
        {
            DocumentReference query = db.Document(path);
            DocumentSnapshot documentSnapshot = await query.GetSnapshotAsync();
            return documentSnapshot.ConvertTo<T>();
        }
        public static async Task<T> CreateDocument(T entity, string path, FirestoreDb db)
        {
            try
            {
                DocumentReference docRef = db.Collection(path).Document();

                await docRef.SetAsync(entity);
                entity.ID = docRef.Id;
                entity.Path = path + "/" + docRef.Id;
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return entity;
            }
        }
        public static async Task<T> UpdateDocument(T entity, string docID, string docCollectionPath, FirestoreDb db)
        {
            try
            {
                DocumentReference docRef = db.Collection(docCollectionPath).Document(docID);

                await docRef.SetAsync(entity);
                entity.ID = docRef.Id;
                entity.Path = docCollectionPath + "/" + docRef.Id;
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return entity;
            }
        }
        public static async Task<T> DeleteDocument(T entity, FirestoreDb db)
        {
            try
            {
                DocumentReference docRef = db.Document(entity.Path);
                await docRef.DeleteAsync();
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return entity;
            }
        }
        public static async Task DeleteDocument(string path, FirestoreDb db)
        {
            try
            {
                DocumentReference docRef = db.Document(path);
                await docRef.DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        private static AuthErrorReason GetFailureReason(string responseData)
        {
            AuthErrorReason authErrorReason = AuthErrorReason.Undefined;
            try
            {
                if (!string.IsNullOrEmpty(responseData))
                {
                    if (responseData != "N/A")
                    {
                        var anonymousTypeObject = new
                        {
                            error = new
                            {
                                code = 0,
                                message = "errorid"
                            }
                        };
                        anonymousTypeObject = JsonConvert.DeserializeAnonymousType(responseData, anonymousTypeObject);
                        switch (anonymousTypeObject?.error?.message)
                        {
                            case "invalid access_token, error code 43.":
                                authErrorReason = AuthErrorReason.InvalidAccessToken;
                                break;
                            case "CREDENTIAL_TOO_OLD_LOGIN_AGAIN":
                                authErrorReason = AuthErrorReason.LoginCredentialsTooOld;
                                break;
                            case "OPERATION_NOT_ALLOWED":
                                authErrorReason = AuthErrorReason.OperationNotAllowed;
                                break;
                            case "INVALID_PROVIDER_ID : Provider Id is not supported.":
                                authErrorReason = AuthErrorReason.InvalidProviderID;
                                break;
                            case "MISSING_REQUEST_URI":
                                authErrorReason = AuthErrorReason.MissingRequestURI;
                                break;
                            case "A system error has occurred - missing or invalid postBody":
                                authErrorReason = AuthErrorReason.SystemError;
                                break;
                            case "MISSING_OR_INVALID_NONCE : Duplicate credential received. Please try again with a new credential.":
                                authErrorReason = AuthErrorReason.DuplicateCredentialUse;
                                break;
                            case "INVALID_EMAIL":
                                authErrorReason = AuthErrorReason.InvalidEmailAddress;
                                break;
                            case "MISSING_PASSWORD":
                                authErrorReason = AuthErrorReason.MissingPassword;
                                break;
                            case "EMAIL_EXISTS":
                                authErrorReason = AuthErrorReason.EmailExists;
                                break;
                            case "USER_NOT_FOUND":
                                authErrorReason = AuthErrorReason.UserNotFound;
                                break;
                            case "INVALID_PASSWORD":
                                authErrorReason = AuthErrorReason.WrongPassword;
                                break;
                            case "EMAIL_NOT_FOUND":
                                authErrorReason = AuthErrorReason.UnknownEmailAddress;
                                break;
                            case "USER_DISABLED":
                                authErrorReason = AuthErrorReason.UserDisabled;
                                break;
                            case "MISSING_EMAIL":
                                authErrorReason = AuthErrorReason.MissingEmail;
                                break;
                            case "RESET_PASSWORD_EXCEED_LIMIT":
                                authErrorReason = AuthErrorReason.ResetPasswordExceedLimit;
                                break;
                            case "MISSING_REQ_TYPE":
                                authErrorReason = AuthErrorReason.MissingRequestType;
                                break;
                            case "INVALID_ID_TOKEN":
                                authErrorReason = AuthErrorReason.InvalidIDToken;
                                break;
                            case "INVALID_IDENTIFIER":
                                authErrorReason = AuthErrorReason.InvalidIdentifier;
                                break;
                            case "MISSING_IDENTIFIER":
                                authErrorReason = AuthErrorReason.MissingIdentifier;
                                break;
                            case "FEDERATED_USER_ID_ALREADY_LINKED":
                                authErrorReason = AuthErrorReason.AlreadyLinked;
                                break;
                        }

                        if (authErrorReason == AuthErrorReason.Undefined)
                        {
                            if ((anonymousTypeObject?.error?.message?.StartsWith("WEAK_PASSWORD :")).GetValueOrDefault())
                            {
                                authErrorReason = AuthErrorReason.WeakPassword;
                                return authErrorReason;
                            }

                            if ((anonymousTypeObject?.error?.message?.StartsWith("TOO_MANY_ATTEMPTS_TRY_LATER :")).GetValueOrDefault())
                            {
                                authErrorReason = AuthErrorReason.TooManyAttemptsTryLater;
                                return authErrorReason;
                            }

                            if ((anonymousTypeObject?.error?.message?.StartsWith("ERROR_INVALID_CREDENTIAL")).GetValueOrDefault())
                            {
                                authErrorReason = AuthErrorReason.StaleIDToken;
                                return authErrorReason;
                            }

                            return authErrorReason;
                        }

                        return authErrorReason;
                    }

                    return authErrorReason;
                }

                return authErrorReason;
            }
            catch (JsonReaderException)
            {
                return authErrorReason;
            }
            catch (Exception)
            {
                return authErrorReason;
            }
        }
    
    }
}
