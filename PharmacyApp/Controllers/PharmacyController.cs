using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Data;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IProductService<ProductViewModel> _productService;
        private readonly IPaymentService<PaymentViewModel> _paymentService;
        private readonly ICartService<CartViewModel>   _cartService;
        public PharmacyController(IProductService<ProductViewModel> productService, 
            IPaymentService<PaymentViewModel> paymentService,
            ICartService<CartViewModel> cartService)
        {
            _productService = productService;
            _paymentService = paymentService;
            _cartService = cartService; 
        }
        public async Task<IActionResult> Index()
        {
            var hotproducts = await _productService.GetTop3Products();
            return View(hotproducts);
        }

        public async Task<IActionResult> Search(string productName)
        { 
            var productname = await _productService.SearchForProductByName(productName);
            return PartialView("_ProductListPartial", productname);
        }
        public async Task<IActionResult> filter(string productCategory)
        {
            var filteredProducts = await _productService.GetAllProductsByCategory(productCategory);
            return PartialView("_ProductListPartial", filteredProducts); 
        }



        public async Task<IActionResult> QuickView(string productName)
        {
            var QuickViewProduct = await _productService.getProductByName(productName);
            return PartialView("_QuickViewPartial", QuickViewProduct);

        }

        public async Task<IActionResult> QuickBuy(string productName)
        {
            var QuickViewProduct = await _productService.getProductByName(productName);
            return PartialView("_QuickBuyPartial", QuickViewProduct);
        }

        public async Task<IActionResult> QuickPurchase(string productName, string customerDetails)
        {
            var buyProduct = await _productService.purchaseProduct(productName);
            var CreatePayment = await _paymentService.CreatePaymentEntry(productName, customerDetails);
            return Json(new { success = true, message = "Product purchased successfully!" });

        }
    }
}
