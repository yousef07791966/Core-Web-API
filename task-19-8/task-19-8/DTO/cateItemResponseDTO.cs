using task_19_8.Models;

namespace task_19_8.DTO
{
    public  class cateItemResponseDTO
    {

        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        public int Quantity { get; set; }

        public productDTO Product { get; set; }
      
    }

    public class productDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public int? Price { get; set; }

    }
}
