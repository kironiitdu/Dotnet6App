namespace SwaggerWebAPIApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string? Email { get; set; }
    }
}
