namespace AppCrudEFCoreApi.Api.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
