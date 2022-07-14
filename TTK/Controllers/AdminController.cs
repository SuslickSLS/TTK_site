using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;
using TTK.ViewModels;
using TTK.ViewModels.Admin;

namespace TTK.Controllers
{
    public class AdminController : Controller
    {
        private readonly TTKDbContext _db;

        public AdminController(TTKDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                var tariff = _db.Tariffs.ToList();

                return View(tariff);
            }
            return NotFound();

        }
        
        [Authorize]
        public IActionResult UseTariff(int id)
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                var _contract = _db.Contracts.Find(id);

                var user_history = new ClientHistory();

                user_history.historyTraffic = _db.ClientHistoryTraffics.Where(x => x.Contract == _contract.ContractId).ToList();
                user_history.dataTariff = _db.DataTariffs.ToList();

                user_history.tariffName = _db.Tariffs.Find(_contract.Tariff).Name;


                return View(user_history);
            }
            return NotFound();

        }

     


        [Authorize]
        public IActionResult Clients()
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                var Contracts = _db.Contracts.ToList();
                var Tariffs = _db.Tariffs.ToList();
                var Clients = _db.Clients.ToList();

                var result = new ClientsController();

                result.clients = Clients;
                result.contracts = Contracts;
                result.tariff = Tariffs;

                return View(result);
            }
            return NotFound();

        }

        [Authorize]
        public IActionResult Game()
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                return View();
            }
            return NotFound();

        }

        [Authorize]
        public IActionResult ClientOFF()
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                return View(_db.Clients.Where(x => x.Status == false).ToList());
            }
            return NotFound();

        }

        [Authorize]
        public IActionResult Detailed(int id)
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                var tariff = _db.Tariffs.Find(id);

                var users = _db.Contracts.Where(x => x.Tariff == tariff.TariffId).ToList();

                var client = new List<Client>();

                for (int i = 0; i < users.Count; i++)
                {
                    client.Add(_db.Clients.Where(x => x.ClientId == users[i].Client).First());
                }

                var result = new DetailController();

                result.tariff = tariff;
            
                result.users = users;
                result.client = client;

                return View(result);
            }
            return NotFound();

        }

        [HttpGet]
        public JsonResult GetDrawPieChaert()
        {


            var list_Tariff = _db.Tariffs.ToList();
            var list_Tariff_name = _db.Tariffs.Select(x => x.Name).ToList();

            var list_count = new List<int>();

            var count = _db.Contracts.Select(x => x.ContractId).Distinct();

            var contract = _db.Contracts.ToList();


            foreach (var tariff in list_Tariff)
            {
                if (contract.Count(x => x.Tariff == tariff.TariffId) > 0)
                {
                    list_count.Add(contract.Count(x => x.Tariff == tariff.TariffId));

                }
                else
                {
                    list_count.Add(0);
                }
            }

            List<StatistickAdminController> statistickAdminControllers = new List<StatistickAdminController>();

            for (int i = 0; i < list_count.Count; i++)
            {
                var result = new StatistickAdminController();
                result.Conunt_tariff = list_count[i];
                result.tariff_name = list_Tariff_name[i];
                statistickAdminControllers.Add(result);
            }

            return Json(new { JSONList = statistickAdminControllers });
        }


        [HttpGet]
        public JsonResult GetDrawLineChart()
        {

            var contract = _db.Contracts.ToList();
            var now = DateTime.Now;

            List<DrawLineChart> drawLines = new List<DrawLineChart>();

            drawLines.Add(new DrawLineChart
            {
                Date = now.ToString("d"),
                count = contract.Count
            });

            for (int i = 1; i < 31; i++)
            {
                var day = now.AddDays(i * -1);

                drawLines.Add(new DrawLineChart
                {
                    Date = day.ToString("d"),
                    count = contract.Where(x => x.Date < day).ToList().Count
                });               
            }
            

            return Json(new { JSONList = drawLines });
        }


        [HttpGet]
        public JsonResult GetDrawTotalMouth(int id)
        {

            //GetDrawTotalMouth
            var list_Tariff = _db.Tariffs.Find(id);

            var a = _db.CountConnections.ToList();
            var con = _db.CountConnections.Where(x => x.Tariff == id).Where(x => x.Date.Year >= DateTime.Now.Year - 1).ToList();
            var CountConnection = con.Select(x => x.Count).ToList();
            var dataCountConnection = con.Select(x => x.Date).ToList();




            //var count = _db.Contracts.Select(x => x.ContractId).Distinct();

            //var contract = _db.Contracts.ToList();



            List<DetailAdminController> detailAdminControllers = new List<DetailAdminController>();

            for (int i = 0; i < con.Count; i++)
            {
                detailAdminControllers.Add(new DetailAdminController()
                {
                    count = CountConnection[i],
                    Date = dataCountConnection[i].ToString("D")
                });
            }

            return Json(new { JSONList = detailAdminControllers });
        }




        [Authorize]
        [HttpGet]
        public IActionResult AddTariff()
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {

                return View();
            }
            return NotFound();

        }

        [Authorize]
        [HttpPost]
        public ActionResult AddTariff(TTK.ViewModels.Detail.Tariff tariff)
        {
            var _tariff = new TTK.Model.Tariff();


            _tariff.Name = tariff.Name;
            _tariff.Price = tariff.price;

            _db.Tariffs.Add(_tariff);

            _db.SaveChanges();


            var dataTariffs = _db.DataTariffs.ToList();

            for (int i = 0; i < dataTariffs.Count; i++)
            {
                if(tariff.component[i] !=0)
                {

                    var data = new TariffDataTariff();

                    data.IdTariff = _tariff.TariffId;
                    data.IdDataTariff = dataTariffs[i].IdDataTariff;
                    data.Count = tariff.component[i].ToString();

                    _db.TariffDataTariffs.Add(data);
                }
            }


            _db.SaveChanges();

            return RedirectToAction("Index");

        }


        [Authorize]
        [HttpGet]
        public IActionResult UpdateTariff(int id)
        {

            if (HttpContext.User.Identity.Name == "Manager")
            {
                var tariff = new TTK.ViewModels.Detail.TariffUpdate();
                var _tariff = _db.Tariffs.Find(id);

                tariff.id = id;
                tariff.Name = _tariff.Name;
                tariff.price = _tariff.Price;

                tariff.component = new List<int>();

                tariff.component.Add(0);
                tariff.component.Add(0);
                tariff.component.Add(0);
                tariff.component.Add(0);
                tariff.component.Add(0);

                var a = _db.TariffDataTariffs.Where(x => x.IdTariff == id).ToList();

                foreach (var item in a)
                {
                    if(item.IdDataTariff == 1)
                    {
                        tariff.component[0] = int.Parse(item.Count);
                    }
                    if (item.IdDataTariff == 2)
                    {
                        tariff.component[1] = int.Parse(item.Count);
                    }
                    if (item.IdDataTariff == 3)
                    {
                        tariff.component[2] = int.Parse(item.Count);
                    }

                    if (item.IdDataTariff == 4)
                    {
                        tariff.component[3] = int.Parse(item.Count);
                    }
                    if (item.IdDataTariff == 5)
                    {
                        tariff.component[4] = int.Parse(item.Count);
                    }
                    
                }

                
                return View(tariff);
            }
            return NotFound();

        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateTariff(TTK.ViewModels.Detail.TariffUpdate tariff)
        {
            var _tariff = _db.Tariffs.Find(tariff.id);


            _tariff.Name = tariff.Name;
            _tariff.Price = tariff.price;

            

            _db.SaveChanges();

            var a = _db.TariffDataTariffs.Where(x => x.IdTariff == _tariff.TariffId).ToList();
            foreach (var item in a)
            {
                _db.TariffDataTariffs.Remove(item);
            }


            var dataTariffs = _db.DataTariffs.ToList();

            for (int i = 0; i < dataTariffs.Count; i++)
            {
                if (tariff.component[i] != 0)
                {

                    var data = new TariffDataTariff();

                    data.IdTariff = _tariff.TariffId;
                    data.IdDataTariff = dataTariffs[i].IdDataTariff;
                    data.Count = tariff.component[i].ToString();

                    _db.TariffDataTariffs.Add(data);
                }
            }


            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        //Для просмотра клиента

        [Authorize]
        public IActionResult ClientInfo(int id)
        {
            if (HttpContext.User.Identity.Name == "Manager")
            {
                var client = _db.Clients.Find(id);

                var contracts = _db.Contracts.Where(x => x.Client == id).ToList();
                List<string> tariff = new List<string>();
                List<Tariff> tariffs = new List<Tariff>();

                foreach (var contract in contracts)
                {
                    tariff.Add(_db.Tariffs.Find(contract.Tariff).Name);
                    tariffs.Add(_db.Tariffs.Find(contract.Tariff));
                }


                var result = new ClientInfoAdmin();

                result.Client = client;
                result.Contract = contracts;
                result.Tariff = tariff;
                result.tariffs = tariffs;

                return View(result);

                
            }
            return NotFound();
        }
          
      

        

        [HttpGet]
        public JsonResult GetDrawUseResuorse(int id)
        {

            

            //узнаем сколько он использовал 
            var contract = _db.Contracts.Find(id);
            var tarrif = _db.Tariffs.Find(contract.Tariff);



            DateTime data_start = new DateTime(DateTime.Now.Year,DateTime.Now.Month, contract.Date.Value.Day);
            
            if (data_start > DateTime.Now)
            {
                data_start.AddMonths(-1);
                //data_start.AddYears(-1);
            }

            var History = _db.ClientHistoryTraffics.Where(x => x.Date >= data_start && x.Contract == contract.ContractId).ToList();

         

            List<DrawChartUseResuorse> chartUseResuorses = new List<DrawChartUseResuorse>();
            foreach (var item in tarrif.TariffDataTariffs)
            {
               
                int count = 0;
                foreach (var component in History)
                {
                    if(component.DataTariff == item.IdDataTariff)
                    {
                        count += (int)component.Count;
                    }
                }
                
                chartUseResuorses.Add(new DrawChartUseResuorse
                {
                    component_count = int.Parse(item.Count) - count,
                    component_name = item.IdDataTariffNavigation.DataTariffName,
                    count_use = count
                });

            }

          
            return Json(new { JSONList = chartUseResuorses});
        }

        
        //public void ConverPDF(int but)
        //{
            
        //    iTextSharp.text.Document doc = new iTextSharp.text.Document();

        //    //Создаем объект записи пдф-документа в файл
        //    PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

        //    //Открываем документ
        //    doc.Open();

        //    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        //    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
        //    PdfPTable pdf = new PdfPTable(1);
        //    PdfPCell cell = new PdfPCell(new Phrase("Получилось!!!", font));
        //    pdf.AddCell(cell);
        //    doc.Add(pdf);

        //    doc.Close();
        //    string a = "Pdf-документ сохранен";
        //}

    }
}
