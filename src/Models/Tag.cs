using Google.Cloud.Firestore;

namespace UniversityHelperApp.Models
{
    [FirestoreData]
    public class Tag : BaseClass
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Colour { get; set; }
        [FirestoreProperty]
        public List<string> Lectures { get; set; } = new List<string>();
        [FirestoreProperty]
        public List<string> Seminars { get; set; } = new List<string>();
    }
}
