using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelperApp.Models
{
    [FirestoreData]
    public class User : BaseClass
    {
        [Required]
        [FirestoreProperty]
        public string FirstName { get; set; }

        [Required]
        [FirestoreProperty]
        public string SecondName { get; set; }

        [Required]
        [FirestoreProperty]
        public string University { get; set; }

        [FirestoreProperty]
        public bool IsPaying { get; set; }

        [Required]
        [FirestoreProperty]
        public int CurrentYear { get; set; } = 1;

        [Required]
        [FirestoreProperty]
        public int NoOfYears { get; set; } = 3;

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [FirestoreProperty]
        public string Country { get; set; }

        [Required]
        [FirestoreProperty]
        public string Colour { get; set; }

        [Required]
        [FirestoreProperty]
        public string Gender { get; set; }

    }
}
