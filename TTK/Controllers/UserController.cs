using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;
using TTK.ViewModels;
using TTK.ViewModels.Admin;

namespace TTK.Controllers
{

    public class UserController : Controller
    {
        private readonly TTKDbContext _db;
        private Contract _contract;
        public UserController(TTKDbContext db)
        {
            _db = db;


        }


        [Authorize]
        public IActionResult Index()
        {
            string ContractNumber = HttpContext.User.Identity.Name;
            _contract = _db.Contracts.Where(x => x.ContractNumber == long.Parse(ContractNumber)).First();
            var client = _db.Clients.Find(_contract.Client);

            var User = _db.Users.Where(x => x.Client == client.ClientId).First().Role;


            if (_contract != null && User == 2)
            {
                var user_info = new Client_Info();
                user_info.contract = _contract;

                user_info.tariffName = _db.Tariffs.Find(_contract.Tariff).Name;

                user_info.UserName = client.Fullname;
                user_info.Phone = client.Phone;
                user_info.status = true;/*(bool)client.Status;*/
                user_info.ClientId = (client.ClientId * 100000).ToString();
                user_info.Balance = (decimal)client.Balance;
                user_info.date = DateTime.Now.ToString("D");

                return View(user_info);
            }
            return NotFound();
        }

        [Authorize]
        public IActionResult UserHistory()
        {
            string ContractNumber = HttpContext.User.Identity.Name;
            _contract = _db.Contracts.Where(x => x.ContractNumber == long.Parse(ContractNumber)).First();
            var client = _db.Clients.Find(_contract.Client);
            var User = _db.Users.Where(x => x.Client == client.ClientId).First().Role;


            if (_contract != null && User == 2)
            {
                var user_history = new ClientHistory();

                user_history.historyTraffic = _db.ClientHistoryTraffics.Where(x => x.Contract == _contract.ContractId).ToList();
                user_history.dataTariff = _db.DataTariffs.ToList();

                user_history.tariffName = _db.Tariffs.Find(_contract.Tariff).Name;



                return View(user_history);
            }
            return NotFound();
        }
        [Authorize]
        public IActionResult UserEquipment()
        {
            string ContractNumber = HttpContext.User.Identity.Name;
            _contract = _db.Contracts.Where(x => x.ContractNumber == long.Parse(ContractNumber)).First();
            var client = _db.Clients.Find(_contract.Client);
            var User = _db.Users.Where(x => x.Client == client.ClientId).First().Role;

            if (_contract != null && User == 2)
            {
                var user_equipment = new ClientEquipment();

                
                List<Equipment> equipmentList = new List<Equipment>();
                foreach(var equipment in _db.ContractEquipments.Where(x => x.Contract == _contract.ContractId).ToList())
                {
                    equipmentList.Add(_db.Equipments.Find(equipment.Equipment));
                }
                user_equipment.equipment = equipmentList;


                return View(user_equipment);
            }
            return NotFound();
        } 
        
        [Authorize]
        public IActionResult UseContent()
        {
            string ContractNumber = HttpContext.User.Identity.Name;
            _contract = _db.Contracts.Where(x => x.ContractNumber == long.Parse(ContractNumber)).First();
            var client = _db.Clients.Find(_contract.Client);
            var User = _db.Users.Where(x => x.Client == client.ClientId).First().Role;

            if (_contract != null && User == 2)
            {
                var result = new UseContent();
                var tariff = _db.Tariffs.Find(_contract.Tariff);

                result.componets = tariff.TariffDataTariffs.Count;
                result.contract = _contract;

                return View(result);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult StatusUpdate(int id)
        {
            var contract = _db.Contracts.Find(id);

            contract.Status = false;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        
    }
}
