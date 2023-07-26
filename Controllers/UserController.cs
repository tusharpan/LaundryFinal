using LaundryFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaundryFinal.Controllers
{   
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor context;

        public UserController(IHttpContextAccessor httpContextAccessor) { 
        
                 context = httpContextAccessor;
        }
        // GET: UserController
        public ActionResult Register()

        {
            HttpContext.Session.Clear();
            return View();
        }
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {    
                DAO.Register(user.Name,user.Email,user.Password);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController
        public ActionResult Login() //orders(Index name hai)
        {
            //int ids = HttpContext.Session.GetInt32("UserId") ?? 0;
            return View();
        }
        // GET: UserController/Create
        public ActionResult Logout()
        {
            return RedirectToAction(nameof(Login));
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                User users = DAO.Login(user.Email, user.Password);
                if (users != null)
                {

                    bool is_admin = users.is_admin;
                    int admin = 0;
                        
                    HttpContext.Session.SetInt32("IsLoggedIn", 1);
                    
                   // HttpContext.Session.SetInt32("IsLoggedIn", 1);
                     //TempData["UserId"] = users.User_id;
                    HttpContext.Session.SetInt32("UserId", users.User_id);
                    if (is_admin)
                    {   
                        return RedirectToAction("Index", "Admin");
                        
                    }
                     return RedirectToAction(nameof(Index));
                    //return RedirectToAction("Index", new { ids = users.User_id });
                }
                else
                {
                    Console.WriteLine("aya");
                    HttpContext.Session.SetInt32("IsLoggedIn", 0);
                    return RedirectToAction(nameof(Register));
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: UserController
        public ActionResult Index() //orders(Index name hai)
        {
           // int ids = TempData.TryGetValue("UserId", out int userId)
            int ids = HttpContext.Session.GetInt32("UserId") ?? 0;
            Console.WriteLine(ids);
            List<Order>orders = DAO.GetOrders(ids);
            return View(orders);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order  order)
        {  //id = order.User_Id;
            try
            {
                int ids = HttpContext.Session.GetInt32("UserId") ?? 0;
                DAO.PlaceOrder(order.Shirts, order.Pants, order.Shirts, order.Del_Address, ids);
                  return RedirectToAction(nameof(Index));
               // return RedirectToAction("Index", new { ids = id });

            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {    
            Order order = DAO.GetOrder(id);   
            
            return View(order);
        }

        // POST: UserController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection,Order order)
            {
           
                try
                {
                
                        
                    Console.WriteLine(order.Order_Id);
                    Console.WriteLine(order.Del_Address+"address");
                    Console.WriteLine(id);
                    DAO.cancelOrder(id);
                    //return RedirectToAction("Index", new { ids = id });
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

        }


    }
