namespace AppCrudEFCoreApi.Api.DTO
{
    public class ProductUpdateDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }
}
