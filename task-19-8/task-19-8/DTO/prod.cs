using task_19_8.Models;

namespace task_19_8.DTO
{
    public class prod
    {

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public int? Price { get; set; }

        public int? CategoryId { get; set; }

        public  IFormFile? ProductImage { get; set; }

    }
}
