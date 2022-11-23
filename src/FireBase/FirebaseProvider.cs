using Firebase.Auth;
using Google.Api;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Data;
using System.IO;
using UniversityHelperApp.Models;

namespace UniversityHelperApp.FireBase
{
    public class FirebaseProvider
    {

        private FirebaseAuthProvider _authProvider;
        private Models.User _user;
        private FirestoreDb _db;
        private const string API_KEY = "AIzaSyC8yGG-yziPsuRoIqr8xmX0vWbUpCNS0pU\r\n";

        private int _currentYear = 1;


        List<Module> _modules = new List<Module>();
        public FirebaseProvider()
        {
            try
            {
                _authProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            }
            catch(Exception ex)
            {

            }
           
            
        }

        public async Task SignIn()
        {
            try
            {
                FirebaseAuthLink firebaseAuthLink = await _authProvider.SignInWithEmailAndPasswordAsync("joshualukereynolds67@gmail.com", "Josh12345");
                //System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"unihelper-c9895\",\r\n  \"private_key_id\": \"2e84df4a216fec6210c4b899eb5dc7b62e33cde5\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCsCTOlDjtORrDY\\n2Wil/NYx+ZFOGa241QA9mURz8PF25thB3sqmcifKwscVG8QLLlgTOHmvUPx/hqum\\nXaQ0Yb+CQdP65sTvdrl0XnLMB2UzV96BDQRQeJVvvFT+IR3OU4pfVhJ4odJHI1at\\nPzlSmJIHXdRbd9z/SgQdjfBJJ5sFUHh4YwAxxFo1gi2D24MRx66XDt3e+m0PAang\\nqCi1wxn6+LwIFNZ5cDUJtAbgkLenliHMsmjUS9Hd9QFOKhO+C9ihBXMH4pE9v935\\naiBPNjfQeDDntEi+wkFEhNel/baegExTjP/eVxQsFAjFfG0+8WM6KQz0tDbUEYPM\\nW+McWdFvAgMBAAECggEAAvRXgDap2xLIt7ioHO2mKg6Mqcg0HQ//ZI9sxwb0xqN5\\nRExUs54TQ96rd5fV+pEtrwrRwCqGY5RG/2DtUH77QHvr7YuoByrFTZPPqeRYnxSb\\nvCCimdUwT85usTyVW/VAU5nRUGQLDfCz7N7Al8QKAflhC78XuwSk5HMLFN6KwYEU\\nk0Mx806u/nlLLZpBQQK1jiF6SYxqJQuTiasLAx7ApbGz2CrpAyX1gKD8qJUjAzTf\\nPBy7H3oT5XxJghPKq5S/UIxuf501UNje/2VZp+rRBs78PMHZGrwolNPwoOP8/jwQ\\nbgBY43dg9phBd+mj/ozFvAMuxyrk3CNwGtEZW3Ci3QKBgQDSk5GtKhaezmUcsxYA\\n5x98e9rxQm6R7zHeMOlJ7m8zkZP5yjXAQveYRIaCxTsYe91aDQxMtZPp3xHyb1H+\\nak/m8t+hTe0uW7rd9S20v37OivgoVEtGtWTAtVLbswje3S1SvaltGq9dYFrbEG4j\\niF57pkLIyjkzoqmuJnl6rHZa9QKBgQDRJVpuUu+C9VIkSVZt+f1555As+aSaw4dV\\nIItsrFBtawUa+nyr+m4AYBOidMVHwAxiFH9GfjQgDH4R27SLSop/FvK+uTqpfrFy\\nI1FyqlW7d8PN832CpKgmJjhc4hkl8uVrEgQf1BW0TMEC6FJuhHkjOEERekclh/99\\nyunCukSEUwKBgQCqGrVKSj6dqKL7bRuwPQQtXiv+SqjhUHVbRO2fYHIKGWaNGTEU\\nj8RNB8YVK1hSrfSgwvuVl/TVrvJjglOdDqpfKQFH35hio40vsdhrM2ovVQmkInvw\\nsaWjGpbFjTn0Nn1fYoDT9wOEjcq3Pe2K3KVeg29dniZZNOSXHtNxKpItZQKBgDbV\\n41rvtcqRRaMr81RMalAvDZctMSI+x9ni+YtZtpCpsaH8MPnqZDMG/b7nfN4uFVEV\\n7LTv2/zXKarG/xRSS/O8cZLd/+p2xFGXvwAgdu/7G8SA5dR+FXRDKx33Tf6sK8ih\\n5aDuu24VfbmkbhB5/UTlt/G8LLFDchJqRFYA/nvvAoGAJNRngzVllIidEVUrmwFK\\nGoPG7EWRgSZp8k4MATNFggpGcn7bBp/O6iCDCd+MmE30nragak3Z1D+R1IGzEDK+\\nReI3oUp78gUGuSiic1opJaogqqCo6YwInFlbm2APqwivxuTcvfEozJ8ZoE3iJqMd\\nGc2oMk8R3rfjdhq1uWf9oqQ=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-nda28@unihelper-c9895.iam.gserviceaccount.com\",\r\n  \"client_id\": \"112642948862884186306\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-nda28%40unihelper-c9895.iam.gserviceaccount.com\"\r\n}\r\n"
                //);
                var builder = new FirestoreClientBuilder
                {
                    JsonCredentials = "{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"unihelper-c9895\",\r\n  \"private_key_id\": \"2e84df4a216fec6210c4b899eb5dc7b62e33cde5\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCsCTOlDjtORrDY\\n2Wil/NYx+ZFOGa241QA9mURz8PF25thB3sqmcifKwscVG8QLLlgTOHmvUPx/hqum\\nXaQ0Yb+CQdP65sTvdrl0XnLMB2UzV96BDQRQeJVvvFT+IR3OU4pfVhJ4odJHI1at\\nPzlSmJIHXdRbd9z/SgQdjfBJJ5sFUHh4YwAxxFo1gi2D24MRx66XDt3e+m0PAang\\nqCi1wxn6+LwIFNZ5cDUJtAbgkLenliHMsmjUS9Hd9QFOKhO+C9ihBXMH4pE9v935\\naiBPNjfQeDDntEi+wkFEhNel/baegExTjP/eVxQsFAjFfG0+8WM6KQz0tDbUEYPM\\nW+McWdFvAgMBAAECggEAAvRXgDap2xLIt7ioHO2mKg6Mqcg0HQ//ZI9sxwb0xqN5\\nRExUs54TQ96rd5fV+pEtrwrRwCqGY5RG/2DtUH77QHvr7YuoByrFTZPPqeRYnxSb\\nvCCimdUwT85usTyVW/VAU5nRUGQLDfCz7N7Al8QKAflhC78XuwSk5HMLFN6KwYEU\\nk0Mx806u/nlLLZpBQQK1jiF6SYxqJQuTiasLAx7ApbGz2CrpAyX1gKD8qJUjAzTf\\nPBy7H3oT5XxJghPKq5S/UIxuf501UNje/2VZp+rRBs78PMHZGrwolNPwoOP8/jwQ\\nbgBY43dg9phBd+mj/ozFvAMuxyrk3CNwGtEZW3Ci3QKBgQDSk5GtKhaezmUcsxYA\\n5x98e9rxQm6R7zHeMOlJ7m8zkZP5yjXAQveYRIaCxTsYe91aDQxMtZPp3xHyb1H+\\nak/m8t+hTe0uW7rd9S20v37OivgoVEtGtWTAtVLbswje3S1SvaltGq9dYFrbEG4j\\niF57pkLIyjkzoqmuJnl6rHZa9QKBgQDRJVpuUu+C9VIkSVZt+f1555As+aSaw4dV\\nIItsrFBtawUa+nyr+m4AYBOidMVHwAxiFH9GfjQgDH4R27SLSop/FvK+uTqpfrFy\\nI1FyqlW7d8PN832CpKgmJjhc4hkl8uVrEgQf1BW0TMEC6FJuhHkjOEERekclh/99\\nyunCukSEUwKBgQCqGrVKSj6dqKL7bRuwPQQtXiv+SqjhUHVbRO2fYHIKGWaNGTEU\\nj8RNB8YVK1hSrfSgwvuVl/TVrvJjglOdDqpfKQFH35hio40vsdhrM2ovVQmkInvw\\nsaWjGpbFjTn0Nn1fYoDT9wOEjcq3Pe2K3KVeg29dniZZNOSXHtNxKpItZQKBgDbV\\n41rvtcqRRaMr81RMalAvDZctMSI+x9ni+YtZtpCpsaH8MPnqZDMG/b7nfN4uFVEV\\n7LTv2/zXKarG/xRSS/O8cZLd/+p2xFGXvwAgdu/7G8SA5dR+FXRDKx33Tf6sK8ih\\n5aDuu24VfbmkbhB5/UTlt/G8LLFDchJqRFYA/nvvAoGAJNRngzVllIidEVUrmwFK\\nGoPG7EWRgSZp8k4MATNFggpGcn7bBp/O6iCDCd+MmE30nragak3Z1D+R1IGzEDK+\\nReI3oUp78gUGuSiic1opJaogqqCo6YwInFlbm2APqwivxuTcvfEozJ8ZoE3iJqMd\\nGc2oMk8R3rfjdhq1uWf9oqQ=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-nda28@unihelper-c9895.iam.gserviceaccount.com\",\r\n  \"client_id\": \"112642948862884186306\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-nda28%40unihelper-c9895.iam.gserviceaccount.com\"\r\n}\r\n"
               };
            
                _db = await FirestoreDb.CreateAsync("unihelper-c9895",await builder.BuildAsync());

               _user = await FireBaseHandlerServices<Models.User>.GetDocument("Users/" + firebaseAuthLink.User.LocalId, _db);
                _modules = await FireBaseHandlerServices<Module>.GetAllDocuments(Combine(
             "Users",
             _user.ID,
             "Years",
             "1",
             "Modules"),
             _db);
                foreach(Module module in _modules)
                {
                    Console.WriteLine(module.Name);
                }

                // string s = await Http.GetStringAsync("Resources/unihelper-c9895-firebase-adminsdk-nda28-2e84df4a21.json");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }


            /*DocumentReference query = _db.Document(path);
            DocumentSnapshot documentSnapshot = await query.GetSnapshotAsync();
            _user = documentSnapshot.ConvertTo<Models.User>();


            //_user = await FireBaseHandlerServices<Models.User>.GetDocument("Users/" + firebaseAuthLink.User.LocalId, db);

            _currentYear = _user.CurrentYear;
            _user.ID = firebaseAuthLink.User.LocalId;*/

        }
        public static string Combine(params string[] stringToCombine)
        {
            string outputString = "";
            foreach (string x in stringToCombine)
            {
                outputString = outputString + x + "/";
            }
            return outputString.Substring(0, outputString.Length - 1);
        }



    }
}
