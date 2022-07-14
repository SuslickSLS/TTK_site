using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TTK.Model;
using TTK.ViewModels;
using TTK.ViewModels.Detail;

namespace TTK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TTKDbContext _db;

        public HomeController(ILogger<HomeController> logger,TTKDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        
        public IActionResult Index()
        {

           
            var tariff = _db.Tariffs.ToList();
            var equipment = _db.Equipments.ToList();
             

            return View((tariff,equipment, new AddClient()));
        }

        [HttpGet]
        public IActionResult addClient()
        {
            return View(); 

        }

        [HttpPost]
        public ActionResult addClient(AddClient client)
        {

            Client _client = new Client();


            _client.Fullname = client.FIO;
            _client.Birthday = client.date;
            _client.Passport = client.passport;
            _client.Phone = client.phone;
            _client.Balance = 0;
            _client.Status = true;

            _db.Clients.Add(_client);

            _db.SaveChanges();

            var user = new TTK.Model.User();

            user.Client = _client.ClientId;
            user.Password = client.password;
            user.Role = 2;


            _db.Users.Add(user);


            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult AboutUs()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModels());
        }

        

        public string GetPasswordHash(string password)
        {
            var secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Secrets")["PasswordHashSecretCode"];
            SHA256 sha = SHA256.Create();

            byte[] stringData = Encoding.UTF8.GetBytes(password + secret);

            byte[] hashData = sha.ComputeHash(stringData);
            return string.Join("", hashData.Select(b => b.ToString("X2")));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModels model)
        {


            if (ModelState.IsValid)
            {
                string password = GetPasswordHash(model.Password);

                //var user = _db.Users;
                

                if (_db.Users.FirstOrDefault(x=>x.Login == model.UserName) != null)
                {
                    User user = await _db.Users.FirstOrDefaultAsync(u => u.Password == password && u.Login == model.UserName);
                    //Client clients = _db.Clients.Find(user.Client);
                    if (user != null)
                    {
                        await Authenticate(user.RoleNavigation.Role1, user.RoleNavigation.Role1);
                        if (user.Role == 1)
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                else
                {
                    var contract = await _db.Contracts.Where(x => x.ContractNumber == long.Parse(model.UserName)).FirstAsync();

                    Client clients = await _db.Clients.FindAsync(contract.Client);

                    User user = await _db.Users.Where(x => x.Client == clients.ClientId && x.Password == password).FirstAsync();
                    
                    if (user != null)
                    {
                        await Authenticate(contract.ContractNumber.ToString(),user.RoleNavigation.Role1);

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                
                
            }
            return View(model);
        }


        private async Task Authenticate(string userName,string role)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType); ;
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public  IActionResult UpdateTariff(string id,int id_tariff)
        {
            var contract = _db.Contracts.Where(x => x.ContractNumber == long.Parse(id)).ToList().First();

            contract.Tariff = id_tariff;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}

