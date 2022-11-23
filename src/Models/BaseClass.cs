namespace UniversityHelperApp.Models
{
    public class BaseClass : ICloneable
    {
        public string ID { get; set; } = "";
        public string Path { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
