using BeautySalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        private AnastasiaEntities1 db = new AnastasiaEntities1();

        public ActionResult Index()
        {
            var entries = db.Guestbooks;
            return View(entries);

        }
        // Получаем введенную запись
        [HttpPost]
        public ActionResult CreateGuest(Guestbook entry)
        {
            entry.Дата = DateTime.Now;
            db.Guestbooks.Add(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "О салоне";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }

        public ActionResult Service()
        {
            var services = (from service in db.Услуга select service).ToList();
            return View(services);
        }

        public ActionResult Discount()
        {
            var discounts = (from discount in db.Акция select discount).ToList();
            return View(discounts);
        }

        public ActionResult Call() // заказать звонок
        {
            Call call = new Call();
            return View(call);
        }

        [HttpPost]
        public ActionResult Call(Call call)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Calls.Add(call);
                    db.SaveChanges();
                    return RedirectToAction("Success", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(call);
        }


        public ActionResult MaybeVisit() // записаться на услугу
        {
            Заявка visit = new Заявка();
            ViewBag.КодУслуга = new SelectList(db.Услуга, "КодУслуга", "НаименованиеУслуга");

            return View(visit);
        }

        [HttpPost]
        public ActionResult MaybeVisit(Заявка visit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Заявка.Add(visit);
                    db.SaveChanges();
                    return RedirectToAction("Success", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(visit);
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Успешно";
            return View();
        }
    }
}