using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelperApp.Models
{
    [FirestoreData]
    public class Module : BaseClass
    {

        [Required]
        [FirestoreProperty]
        public string Code { get; set; }
        [FirestoreProperty]
        [Required]
        public string Name { get; set; }
        [FirestoreProperty]
        [Required]
        public string Colour { get; set; } = "#FFFFFF";
        [FirestoreProperty]
        public List<Tag> LectureTags { get; set; }
        [FirestoreProperty]
        public List<Tag> SeminarTags { get; set; }

       /* public List<RichContent> Lectures { get; set; } = new List<RichContent>();

        public List<Seminar> Seminas { get; set; } = new List<Seminar>();

        public List<Deadline> Deadlines { get; set; } = new List<Deadline>();

        public List<ReadingMaterial> ReadingList { get; set; } = new List<ReadingMaterial>();*/

        public List<Task> Tasks { get; set; } = new List<Task>();
        public string Title { get { return Code.ToUpper() + ": " + Name; } }

        public Module Clone()
        {
            return this.MemberwiseClone() as Module;
        }
    }
}
