namespace AppCrudEFCoreApi.Api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        //relazione
        public List<Order> Orders { get; set; }

    }
}
