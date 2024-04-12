using Microsoft.AspNetCore.Mvc;
using WebsiteBanHang.Data;
using WebsiteBanHang.Infrastructure;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class CheckoutController : Controller
    {
        public Checkout? checkout { get; set; }
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart"));
        }

        /*public IActionResult Checkout(int productId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                checkout = HttpContext.Session.GetJson<Checkout>("checkout") ?? new Checkout();
                checkout.AddItem(product, 1);
                HttpContext.Session.SetJson("checkout", checkout);
            }
            return View("Checkout", checkout);
        }*/

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetJson<Cart>("cart");
            if (cart == null || cart.Lines.Count == 0)
            {
                // Xử lý khi cart trống
                // Ví dụ: Chuyển hướng đến trang giỏ hàng nếu cart trống
                return RedirectToAction("Index", "Cart");
            }

            checkout = HttpContext.Session.GetJson<Checkout>("checkout") ?? new Checkout();
            // Truyền dữ liệu từ cart vào checkout
            foreach (var line in cart.Lines)
            {
                checkout.AddItem(line.Product, line.Quantity);
            }

            HttpContext.Session.SetJson("checkout", checkout);

            return View("Checkout", checkout);
        }

        [HttpPost]
        public IActionResult ConfirmPayment()
        {
            // Xử lý việc xác nhận thanh toán ở đây
            // Ví dụ: Xóa thông tin checkout sau khi thanh toán thành công
            

            // Lấy thông tin đơn hàng từ session
            var checkout = HttpContext.Session.GetJson<Checkout>("checkout");
            HttpContext.Session.Remove("checkout");
            // Chuyển hướng người dùng đến trang cảm ơn và truyền thông tin đơn hàng
            return RedirectToAction("ThankYou", "Checkout", new { checkout });
        }

        public IActionResult ThankYou(Checkout checkout)
        {
            // Hiển thị trang cảm ơn đơn hàng và truyền thông tin đơn hàng
            return View("ThankYou", checkout);
        }


    }
}
