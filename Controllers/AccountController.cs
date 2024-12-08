using GlobalShop.Entity;
using GlobalShop.Identity;
using GlobalShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalShop.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);
        }


        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total,
                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length>50? a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }


        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Model doğrulama hatası varsa, formu yeniden göster.
            }

            // Yeni kullanıcı oluşturma
            var user = new ApplicationUser
            {
                Name = model.Name,
                Surname = model.SurName,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = _userManager.Create(user, model.Password);

            if (result.Succeeded)
            {
                // Kullanıcı başarıyla oluşturuldu.
                AddUserToRole(user);

                // Başarı mesajını TempData'ya ekle
                TempData["SuccessMessage"] = "Kullanıcı başarıyla oluşturuldu.";

                // Kullanıcıyı hemen oturum açmak için giriş yap
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false // Oturumun kalıcı olup olmayacağını belirler.
                };
                authManager.SignIn(authProperties, identityClaims);

                // Giriş yaptıktan sonra ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            // Hata durumunda hata mesajlarını ekle
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşmadı: " );
            }

            return View(model);
        }



        // Kullanıcıyı role ekleme
        private void AddUserToRole(ApplicationUser user)
        {
            if (_roleManager.RoleExists("user"))
            {
                _userManager.AddToRole(user.Id, "user");
            }
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userManager.Find(model.UserName, model.Password);

            if (user != null)
            {
                // Var olan sisteme dahil et
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };
                authManager.SignIn(authProperties, identityClaims);

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl); // Kullanıcı giriş yaptıktan sonra ReturnUrl'e yönlendirilir.
                }

                return RedirectToAction("Index", "Home"); // ReturnUrl yoksa ana sayfaya yönlendir
            }

            ModelState.AddModelError("LoginError", "Geçersiz kullanıcı adı veya şifre.");
            return View(model);
        }


        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
