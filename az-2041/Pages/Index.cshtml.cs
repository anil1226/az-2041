using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using az_2041.Models;
using az_2041.Services;

namespace az_2041.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public List<Product> products;
        ProductService ProductService= new ProductService();

        public void OnGet()
        {
            products = ProductService.GetProducts();
        }
    }
}