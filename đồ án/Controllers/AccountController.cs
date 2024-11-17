using đồ_án.Models.View_Model;
using đồ_án.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace đồ_án.Controllers
{
    public class AccountController : Controller
    {
        doanStoreEntities db = new doanStoreEntities();
        // GET: Account/Register

        public ActionResult Register()
        {
            return View();

        }
        // POST: Account/Register

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.User.SingleOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập này đã tồn tại!");
                    return View(model);
                }
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    UserRole = "Customer"
                };
                db.User.Add(user);
                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    CustomerAddress = model.CustomerAddress,
                    Username = model.Username,
                };
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // POST: Account/Login
        public ActionResult Login()
        {
            return View();

        }
        // POST: Account/Register

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = db.User.SingleOrDefault(u => u.Username == model.Username
                    && u.Password == model.Password
                    && u.UserRole == "Customer");
                if (user != null)
                {
                    //Lưu trạng thái đăng nhập vào session
                    Session["Username"] = user.Username;
                    Session["UserRole"] = user.UserRole;

                    //Lưu thông tin xác thực người dùng vào cookie
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToActionPermanent("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }
        //Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}