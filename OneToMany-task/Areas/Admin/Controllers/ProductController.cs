using System;
using Microsoft.AspNetCore.Mvc;
using OneToMany_task.Helpers;
using OneToMany_task.Models;
using OneToMany_task.Services.Interfaces;
using OneToMany_task.ViewModels.Products;
using OneToMany_task.ViewModels.Products.ProductVM;


namespace OneToMany_task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
	{
		private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;


        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
		{
			_productService = productService;
            _categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int page = 1)
		{
			var paginateDatas = await _productService.GetAllPaginateAsync(page);
            var mappedDatas = _productService.GetMappedDatas(paginateDatas);

			int pageCount = await GetPageCountAsync(4);
			Paginate<ProductVM> model = new(mappedDatas, pageCount, page);

            return View(mappedDatas);
		}

		private async Task<int> GetPageCountAsync(int take)
		{
            int count = await _productService.GetCountAsync();
			return (int)Math.Ceiling((decimal)count / take);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdAsync((int)id);

            if (product is null) return NotFound();

            List<ProductImageVM> productImages = new();

            foreach (var item in product.ProductImage)
            {
                productImages.Add(new ProductImageVM
                {
                    Image = item.Name,
                    IsMain = item.IsMain
                });
            }

            ProductDetailVM model = new()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name,
                Images = productImages
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _categoryService.GetAllBySelectAsync();
            return View();
        }

    }
}

