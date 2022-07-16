namespace DotNet6MVCWebApp.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string AppFirstName { get; set; }
        public string AppLastName { get; set; }
        public DateTime AppDateOfBirth { get; set; }
        public int AppTotalPersonsOccupy { get; set; }
        public bool AppAgreeToTerms { get; set; }

        public int StateId { get; set; }
        
    }
}
