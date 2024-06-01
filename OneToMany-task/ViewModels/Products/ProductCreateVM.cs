using System;
namespace OneToMany_task.ViewModels.Products
{
	public class ProductCreateVM
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Image { get; set; }
    }

}

