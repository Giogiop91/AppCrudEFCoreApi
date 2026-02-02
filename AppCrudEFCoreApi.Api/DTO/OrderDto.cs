namespace AppCrudEFCoreApi.Api.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public UserDto User { get; set; } = new();
        public ProductDto Product { get; set; } = new();
    }
}
