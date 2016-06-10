using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautySalon.Models;

namespace BeautySalon.Controllers
{
    //public class Container
    //{
    //    public List<Заявка> заявка { get; set; }
    //    public List<ЗаписьЗапрос> запись { get; set; }
    //}
    public class AdminController : Controller
    {
        private AnastasiaEntities1 db = new AnastasiaEntities1();

        //[Authorize(Roles = "Admin")]
        public ActionResult AdminMenu()
        {
            ViewBag.Message = "Меню";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Администратор";

            return View();
        }
        public ActionResult Master()
        {
            ViewBag.Message = "Мастер";

            return View();
        }

//--------------------------------------УСЛУГИ------------
       
        [Authorize(Roles = "Admin")]
        public ActionResult Service() // список услуг
        {
            var services = (from service in db.Услуга select service).ToList();
            return View(services);
        }

        // GET: Admin/CreateService
        [Authorize(Roles = "Admin")]
        public ActionResult CreateService() // создать услугу
        {
            Услуга service = new Услуга();
            ViewBag.КодКатегория = new SelectList(db.КатегорияУслуги, "КодКатегория", "НаименованиеКатегория");

            return View(service);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateService(Услуга service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Услуга.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Service");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(service);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditService(int id) // изменить услугу
        {
            var servicesEdit = (from service in db.Услуга where service.КодУслуга == id select service).First();

            var category = db.КатегорияУслуги.Find(servicesEdit.КодКатегория);


           ViewBag.КодКатегория = new SelectList(db.КатегорияУслуги, "КодКатегория", "НаименованиеКатегория", category.КодКатегория);

            return View(servicesEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditService(int id, FormCollection collection)
        {
            var servicesEdit = (from service in db.Услуга where service.КодУслуга == id select service).First();
            try
            {
                UpdateModel(servicesEdit);
                db.SaveChanges();
                return RedirectToAction("Service");
            }
            catch
            {
                return View(servicesEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteService(int id) // удалить услугу
        {
            var servicesDelete = (from service in db.Услуга where service.КодУслуга == id select service).First();
            ViewBag.КодКатегория = new SelectList(db.КатегорияУслуги, "КодКатегория", "НаименованиеКатегория");

            return View(servicesDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteService(int id, FormCollection collection)
        {
            var servicesDelete = (from service in db.Услуга where service.КодУслуга == id select service).First();
            try
            {
                db.Услуга.Remove(servicesDelete);
                db.SaveChanges();
                return RedirectToAction("Service");
            }
            catch
            {
                return View(servicesDelete);
            }
        }


 //--------------------------------------АКЦИИ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Discount()
        {
            var discounts = (from discount in db.Акция select discount).ToList();
            return View(discounts);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDiscount() // создать акцию
        {
            Акция discount = new Акция();
            return View(discount);
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDiscount(Акция discount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Акция.Add(discount);
                    db.SaveChanges();
                    return RedirectToAction("Discount");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(discount);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditDiscount(int id) // изменить акцию
        {
            var discountsEdit = (from discount in db.Акция where discount.КодАкция == id select discount).First();
            return View(discountsEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditDiscount(int id, FormCollection collection)
        {
            var discountsEdit = (from discount in db.Акция where discount.КодАкция == id select discount).First();
            try
            {
                UpdateModel(discountsEdit);
                db.SaveChanges();
                return RedirectToAction("Discount");
            }
            catch
            {
                return View(discountsEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDiscount(int id) // удалить акцию
        {
            var discountsDelete = (from discount in db.Акция where discount.КодАкция == id select discount).First();

            return View(discountsDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDiscount(int id, FormCollection collection)
        {
            var discountsDelete = (from discount in db.Акция where discount.КодАкция == id select discount).First();
            try
            {
                db.Акция.Remove(discountsDelete);
                db.SaveChanges();
                return RedirectToAction("Discount");
            }
            catch
            {
                return View(discountsDelete);
            }
        }


 //--------------------------------------ЗВОНОК------------
        [Authorize(Roles = "Admin")]
        public ActionResult Call() // список звонков
        {
            var cal = (from call in db.Calls select call).ToList();
            return View(cal);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCall(int id) // удалить звонок
        {
            var callDelete = (from call in db.Calls where call.IdCall == id select call).First();

            return View(callDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCall(int id, FormCollection collection)
        {
            var callDelete = (from call in db.Calls where call.IdCall == id select call).First();
            try
            {
                db.Calls.Remove(callDelete);
                db.SaveChanges();
                return RedirectToAction("Call");
            }
            catch
            {
                return View(callDelete);
            }
        }


//--------------------------------------КЛИЕНТЫ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Client() // список клиентов
        {
            var clients = (from client in db.Клиент select client).ToList();
            return View(clients);
        }

        // GET: Admin/CreateClient
        [Authorize(Roles = "Admin")]
        public ActionResult CreateClient() // создать клиента
        {
            Клиент client = new Клиент();
            return View(client);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateClient(Клиент client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Клиент.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Client");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(client);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditClient(int id) // изменить клиента
        {
            var clientsEdit = (from client in db.Клиент where client.КодКлиент == id select client).First();
            return View(clientsEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditClient(int id, FormCollection collection)
        {
            var clientsEdit = (from client in db.Клиент where client.КодКлиент == id select client).First();
            try
            {
                UpdateModel(clientsEdit);
                db.SaveChanges();
                return RedirectToAction("Client");
            }
            catch
            {
                return View(clientsEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteClient(int id) // удалить клиента
        {
            var clientsDelete = (from client in db.Клиент where client.КодКлиент == id select client).First();

            return View(clientsDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteClient(int id, FormCollection collection)
        {
            var clientsDelete = (from client in db.Клиент where client.КодКлиент == id select client).First();
            try
            {
                db.Клиент.Remove(clientsDelete);
                db.SaveChanges();
                return RedirectToAction("Client");
            }
            catch
            {
                return View(clientsDelete);
            }
        }


 //--------------------------------------ЗАЯВКИ------------

        [Authorize(Roles = "Admin")]
        public ActionResult MaybeVisit() // список заявок
        {
            var visits = (from visit in db.Заявка select visit).ToList();
           // return PartialView("_MaybeVisit",visits);
            return View(visits);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditMaybeVisit(int id) // изменить заявку
        {
            var mvisitsEdit = (from visit in db.Заявка where visit.КодЗаявки == id select visit).First();

            var service = db.Услуга.Find(mvisitsEdit.КодУслуга);
            ViewBag.КодУслуга = new SelectList(db.Услуга, "КодУслуга", "НаименованиеУслуга", service.КодУслуга);
            
            return View(mvisitsEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditMaybeVisit(int id, FormCollection collection)
        {
            var mvisitsEdit = (from visit in db.Заявка where visit.КодЗаявки == id select visit).First();
            try
            {
                UpdateModel(mvisitsEdit);
                db.SaveChanges();
                return RedirectToAction("Visit");
            }
            catch
            {
                return View(mvisitsEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMaybeVisit(int id) // удалить заявку
        {
            var mvisitsDelete = (from visit in db.Заявка where visit.КодЗаявки == id select visit).First();
            ViewBag.КодУслуга = new SelectList(db.Услуга, "КодУслуга", "НаименованиеУслуга");

            return View(mvisitsDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMaybeVisit(int id, FormCollection collection)
        {
            var mvisitsDelete = (from visit in db.Заявка where visit.КодЗаявки == id select visit).First();
            try
            {
                db.Заявка.Remove(mvisitsDelete);
                db.SaveChanges();
                return RedirectToAction("Visit");
            }
            catch
            {
                return View(mvisitsDelete);
            }
        }

 //--------------------------------------ЗАПИСИ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Visit() // список записей
        {
            //var visits = (from visit in db.ЗаписьЗапрос select visit).ToList();
           // ViewBag.MaybeVisit = (new AnastasiaEntities1()).Заявка.ToList();
           // ViewBag.MaybeVisit = (from visit in db.Заявка select visit).ToList();

            var container = new ClassVisit();
            container.заявка = (from visit in db.Заявка select visit).ToList();
            container.запись = (from visit in db.ЗаписьЗапрос select visit).ToList();

            return View(container);

          //  return View(visits);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult CreateVisit() // создать запись
        {
            Запись visit = new Запись();
            ViewBag.КодВремя = new SelectList(db.ТаблицаВремени, "КодВремя", "ЗначениеВремя");
            ViewBag.КодКлиент = new SelectList(db.Клиент, "КодКлиент", "ФИОклиент");
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");
            ViewBag.КодАкция = new SelectList(db.Акция, "КодАкция", "Скидка");
            ViewBag.КодУслуга = new SelectList(db.Услуга, "КодУслуга", "НаименованиеУслуга");

            return View(visit);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateVisit(Запись visit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Запись.Add(visit);
                    db.SaveChanges();
                    return RedirectToAction("Visit");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(visit);
        }


        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditVisit(int id) // изменить запись
        {
            var visitsEdit = (from visit in db.Запись where visit.КодЗапись == id select visit).First();

            var time = db.ТаблицаВремени.Find(visitsEdit.КодВремя);
            ViewBag.КодВремя = new SelectList(db.ТаблицаВремени, "КодВремя", "ЗначениеВремя", time.КодВремя);

            var client = db.Клиент.Find(visitsEdit.КодКлиент);
            ViewBag.КодКлиент = new SelectList(db.Клиент, "КодКлиент", "ФИОклиент", client.КодКлиент);

            var sotr = db.Сотрудник.Find(visitsEdit.КодСотрудник);
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник", sotr.КодСотрудник);

            var disc = db.Акция.Find(visitsEdit.КодАкция);
            ViewBag.КодАкция = new SelectList(db.Акция, "КодАкция", "Скидка", disc.КодАкция);

            return View(visitsEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditVisit(int id, FormCollection collection)
        {
            var visitsEdit = (from visit in db.Запись where visit.КодЗапись == id select visit).First();
            try
            {
                UpdateModel(visitsEdit);
                db.SaveChanges();
                return RedirectToAction("Visit");
            }
            catch
            {
                return View(visitsEdit);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteVisit(int id) // удалить запись
        {
            var visitsDelete = (from visit in db.Запись where visit.КодЗапись == id select visit).First();
            ViewBag.КодВремя = new SelectList(db.ТаблицаВремени, "КодВремя", "ЗначениеВремя");
            ViewBag.КодКлиент = new SelectList(db.Клиент, "КодКлиент", "ФИОклиент");
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");
            ViewBag.КодАкция = new SelectList(db.Акция, "КодАкция", "Скидка");

            return View(visitsDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteVisit(int id, FormCollection collection)
        {
            var visitsDelete = (from visit in db.Запись where visit.КодЗапись == id select visit).First();
            try
            {
                db.Запись.Remove(visitsDelete);
                db.SaveChanges();
                return RedirectToAction("Visit");
            }
            catch
            {
                return View(visitsDelete);
            }
        }

//--------------------------------------МАТЕРИАЛЫ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Material() // список материалов
        {
            var materials = (from material in db.Материал select material).ToList();
            return View(materials);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateMaterial() // создать материал
        {
            Материал material = new Материал();
            ViewBag.КодГруппа = new SelectList(db.ГруппаМатериалов, "КодГруппа", "НаименованиеГруппа");

            return View(material);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateMaterial(Материал material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Материал.Add(material);
                    db.SaveChanges();
                    return RedirectToAction("Material");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(material);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditMaterial(int id) // изменить материал
        {
            var materialsEdit = (from material in db.Материал where material.КодМатериал == id select material).First();

            var category = db.ГруппаМатериалов.Find(materialsEdit.КодГруппа);


            ViewBag.КодГруппа = new SelectList(db.ГруппаМатериалов, "КодГруппа", "НаименованиеГруппа", category.КодГруппа);

            return View(materialsEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditMaterial(int id, FormCollection collection)
        {
            var materialsEdit = (from material in db.Материал where material.КодМатериал == id select material).First();
            try
            {
                UpdateModel(materialsEdit);
                db.SaveChanges();
                return RedirectToAction("Material");
            }
            catch
            {
                return View(materialsEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMaterial(int id) // удалить материал
        {
            var materialsDelete = (from material in db.Материал where material.КодМатериал == id select material).First();
            ViewBag.КодГруппа = new SelectList(db.ГруппаМатериалов, "КодГруппа", "НаименованиеГруппа");

            return View(materialsDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMaterial(int id, FormCollection collection)
        {
            var materialsDelete = (from material in db.Материал where material.КодМатериал == id select material).First();
            try
            {
                db.Материал.Remove(materialsDelete);
                db.SaveChanges();
                return RedirectToAction("Material");
            }
            catch
            {
                return View(materialsDelete);
            }
        }


//--------------------------------------ПРИХОД МАТЕРИАЛОВ------------

        [Authorize(Roles = "Admin")]
        public ActionResult BoxComing() // список приходов
        {
            var boxes = (from box in db.Приход select box).ToList();
            return View(boxes);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateBox() // создать
        {
            Приход box = new Приход();
            ViewBag.КодПоставщик = new SelectList(db.Поставщик, "КодПоставщик", "НаименованиеПоставщик");

            return View(box);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateBox(Приход box)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Приход.Add(box);
                    db.SaveChanges();
                    return RedirectToAction("BoxComing");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(box);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditBox(int id) // изменить 
        {
            var boxesEdit = (from box in db.Приход where box.КодПриход == id select box).First();

            var category = db.Поставщик.Find(boxesEdit.КодПоставщик);


            ViewBag.КодПоставщик = new SelectList(db.Поставщик, "КодПоставщик", "НаименованиеПоставщик", category.КодПоставщик);

            return View(boxesEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditBox(int id, FormCollection collection)
        {
            var boxesEdit = (from box in db.Приход where box.КодПриход == id select box).First();
            try
            {
                UpdateModel(boxesEdit);
                db.SaveChanges();
                return RedirectToAction("BoxComing");
            }
            catch
            {
                return View(boxesEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBox(int id) // удалить 
        {
            var boxesDelete = (from box in db.Приход where box.КодПриход == id select box).First();
            ViewBag.КодПоставщик = new SelectList(db.Поставщик, "КодПоставщик", "НаименованиеПоставщик");

            return View(boxesDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBox(int id, FormCollection collection)
        {
            var boxesDelete = (from box in db.Приход where box.КодПриход == id select box).First();
            try
            {
                db.Приход.Remove(boxesDelete);
                db.SaveChanges();
                return RedirectToAction("BoxComing");
            }
            catch
            {
                return View(boxesDelete);
            }
        }


//--------------------------------------СОСТАВ ПРИХОДА------------

        [Authorize(Roles = "Admin")]
        public ActionResult InBox() // список состава
        {
            var inboxes = (from inbox in db.СоставПрихода select inbox).ToList();
            return View(inboxes);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateInBox() // создать состав
        {
            СоставПрихода inbox = new СоставПрихода();
            ViewBag.КодПриход = new SelectList(db.Приход, "КодПриход", "КодПриход");
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал");

            return View(inbox);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateInBox(СоставПрихода inbox)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.СоставПрихода.Add(inbox);
                    db.SaveChanges();
                    return RedirectToAction("InBox");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(inbox);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditInBox(int id) // изменить состав
        {
            var inboxesEdit = (from inbox in db.СоставПрихода where inbox.КодЕдиницы == id select inbox).First();

            var prihod = db.Приход.Find(inboxesEdit.КодПриход);
            ViewBag.КодПриход = new SelectList(db.Приход, "КодПриход", "КодПриход", prihod.КодПриход);

            var material = db.Материал.Find(inboxesEdit.КодМатериал);
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал", material.КодМатериал);

            return View(inboxesEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditInBox(int id, FormCollection collection)
        {
            var inboxesEdit = (from inbox in db.СоставПрихода where inbox.КодЕдиницы == id select inbox).First();
            try
            {
                UpdateModel(inboxesEdit);
                db.SaveChanges();
                return RedirectToAction("InBox");
            }
            catch
            {
                return View(inboxesEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteInBox(int id) // удалить состав
        {
            var inboxesDelete = (from inbox in db.СоставПрихода where inbox.КодЕдиницы == id select inbox).First();

            ViewBag.КодПриход = new SelectList(db.Приход, "КодПриход", "КодПриход");
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал");

            return View(inboxesDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteInBox(int id, FormCollection collection)
        {
            var inboxesDelete = (from inbox in db.СоставПрихода where inbox.КодЕдиницы == id select inbox).First();
            try
            {
                db.СоставПрихода.Remove(inboxesDelete);
                db.SaveChanges();
                return RedirectToAction("InBox");
            }
            catch
            {
                return View(inboxesDelete);
            }
        }


//--------------------------------------РАСХОД------------

        [Authorize(Roles = "Admin")]
        public ActionResult Rashod() // список расход
        {
            var rashods = (from rashod in db.Расход select rashod).ToList();
            return View(rashods);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRashod() // создать расход
        {
            Расход rashod = new Расход();
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал");

            return View(rashod);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRashod(Расход rashod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Расход.Add(rashod);
                    db.SaveChanges();
                    return RedirectToAction("Rashod");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(rashod);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditRashod(int id) // изменить расход
        {
            var rashodEdit = (from rashod in db.Расход where rashod.КодРасход == id select rashod).First();

            var sotr = db.Сотрудник.Find(rashodEdit.КодСотрудник);
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник", sotr.КодСотрудник);

            var material = db.Материал.Find(rashodEdit.КодМатериал);
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал", material.КодМатериал);

            return View(rashodEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditRashod(int id, FormCollection collection)
        {
            var rashodEdit = (from rashod in db.Расход where rashod.КодРасход == id select rashod).First();
            try
            {
                UpdateModel(rashodEdit);
                db.SaveChanges();
                return RedirectToAction("Rashod");
            }
            catch
            {
                return View(rashodEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRashod(int id) // удалить расход
        {
            var rashodDelete = (from rashod in db.Расход where rashod.КодРасход == id select rashod).First();

            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");
            ViewBag.КодМатериал = new SelectList(db.Материал, "КодМатериал", "НаименованиеМатериал");

            return View(rashodDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRashod(int id, FormCollection collection)
        {
            var rashodDelete = (from rashod in db.Расход where rashod.КодРасход == id select rashod).First();
            try
            {
                db.Расход.Remove(rashodDelete);
                db.SaveChanges();
                return RedirectToAction("Rashod");
            }
            catch
            {
                return View(rashodDelete);
            }
        }


//--------------------------------------ПОСТАВЩИК------------

        [Authorize(Roles = "Admin")]
        public ActionResult Provider()
        {
            var providers = (from provider in db.Поставщик select provider).ToList();
            return View(providers);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProvider() // создать 
        {
            Поставщик provider = new Поставщик();
            return View(provider);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProvider(Поставщик provider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Поставщик.Add(provider);
                    db.SaveChanges();
                    return RedirectToAction("Provider");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(provider);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditProvider(int id) // изменить 
        {
            var providerEdit = (from provider in db.Поставщик where provider.КодПоставщик == id select provider).First();
            return View(providerEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProvider(int id, FormCollection collection)
        {
            var providerEdit = (from provider in db.Поставщик where provider.КодПоставщик == id select provider).First();
            try
            {
                UpdateModel(providerEdit);
                db.SaveChanges();
                return RedirectToAction("Provider");
            }
            catch
            {
                return View(providerEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProvider(int id) // удалить 
        {
            var providerDelete = (from provider in db.Поставщик where provider.КодПоставщик == id select provider).First();

            return View(providerDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProvider(int id, FormCollection collection)
        {
            var providerDelete = (from provider in db.Поставщик where provider.КодПоставщик == id select provider).First();
            try
            {
                db.Поставщик.Remove(providerDelete);
                db.SaveChanges();
                return RedirectToAction("Provider");
            }
            catch
            {
                return View(providerDelete);
            }
        }


 //-------------------------------------- ТАБЛИЦА ВРЕМЕНИ ------------
        [Authorize(Roles = "Admin")]
        public ActionResult Time()
        {
            var times = (from time in db.ТаблицаВремени select time).ToList();
            return View(times);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTime() // создать 
        {
            ТаблицаВремени time = new ТаблицаВремени();
            return View(time);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTime(ТаблицаВремени time)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ТаблицаВремени.Add(time);
                    db.SaveChanges();
                    return RedirectToAction("Time");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(time);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditTime(int id) // изменить 
        {
            var timeEdit = (from time in db.ТаблицаВремени where time.КодВремя == id select time).First();
            return View(timeEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTime(int id, FormCollection collection)
        {
            var timeEdit = (from time in db.ТаблицаВремени where time.КодВремя == id select time).First();
            try
            {
                UpdateModel(timeEdit);
                db.SaveChanges();
                return RedirectToAction("Time");
            }
            catch
            {
                return View(timeEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTime(int id) // удалить 
        {
            var timeDelete = (from time in db.ТаблицаВремени where time.КодВремя == id select time).First();

            return View(timeDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTime(int id, FormCollection collection)
        {
            var timeDelete = (from time in db.ТаблицаВремени where time.КодВремя == id select time).First();
            try
            {
                db.ТаблицаВремени.Remove(timeDelete);
                db.SaveChanges();
                return RedirectToAction("Time");
            }
            catch
            {
                return View(timeDelete);
            }
        }


//--------------------------------------РАЗРЯД ------------
        [Authorize(Roles = "Admin")]
        public ActionResult Razr()
        {
            var razrs = (from razr in db.Разряды select razr).ToList();
            return View(razrs);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRazr() // создать 
        {
            Разряды razr = new Разряды();
            return View(razr);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRazr(Разряды razr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Разряды.Add(razr);
                    db.SaveChanges();
                    return RedirectToAction("Razr");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(razr);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditRazr(int id) // изменить 
        {
            var razrEdit = (from razr in db.Разряды where razr.КодРазряд == id select razr).First();
            return View(razrEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditRazr(int id, FormCollection collection)
        {
            var razrEdit = (from razr in db.Разряды where razr.КодРазряд == id select razr).First();
            try
            {
                UpdateModel(razrEdit);
                db.SaveChanges();
                return RedirectToAction("Razr");
            }
            catch
            {
                return View(razrEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRazr(int id) // удалить 
        {
            var razrDelete = (from razr in db.Разряды where razr.КодРазряд == id select razr).First();

            return View(razrDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRazr(int id, FormCollection collection)
        {
            var razrDelete = (from razr in db.Разряды where razr.КодРазряд == id select razr).First();
            try
            {
                db.Разряды.Remove(razrDelete);
                db.SaveChanges();
                return RedirectToAction("Razr");
            }
            catch
            {
                return View(razrDelete);
            }
        }


//--------------------------------------ДОЛЖНОСТИ ------------
        [Authorize(Roles = "Admin")]
        public ActionResult Dol()
        {
            var dols = (from dol in db.Должность select dol).ToList();
            return View(dols);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDol() // создать 
        {
            Должность dol = new Должность();
            return View(dol);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDol(Должность dol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Должность.Add(dol);
                    db.SaveChanges();
                    return RedirectToAction("Dol");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(dol);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditDol(int id) // изменить 
        {
            var dolEdit = (from dol in db.Должность where dol.КодДолжность == id select dol).First();
            return View(dolEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditDol(int id, FormCollection collection)
        {
            var dolEdit = (from dol in db.Должность where dol.КодДолжность == id select dol).First();
            try
            {
                UpdateModel(dolEdit);
                db.SaveChanges();
                return RedirectToAction("Dol");
            }
            catch
            {
                return View(dolEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDol(int id) // удалить 
        {
            var dolDelete = (from dol in db.Должность where dol.КодДолжность == id select dol).First();

            return View(dolDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDol(int id, FormCollection collection)
        {
            var dolDelete = (from dol in db.Должность where dol.КодДолжность == id select dol).First();
            try
            {
                db.Должность.Remove(dolDelete);
                db.SaveChanges();
                return RedirectToAction("Dol");
            }
            catch
            {
                return View(dolDelete);
            }
        }

//--------------------------------------ТАБЕЛЬ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Tabel() // список 
        {
            var tabs = (from tab in db.Табель select tab).ToList();
            return View(tabs);
        }

        // GET: Admin/CreateService
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTabel() // создать 
        {
            Табель tab = new Табель();
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");

            return View(tab);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTabel(Табель tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Табель.Add(tab);
                    db.SaveChanges();
                    return RedirectToAction("Tabel");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(tab);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditTabel(int id) // изменить 
        {
            var tabEdit = (from tab in db.Табель where tab.КодТабель == id select tab).First();

            var sotr = db.Сотрудник.Find(tabEdit.КодСотрудник);


            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник", sotr.КодСотрудник);

            return View(tabEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTabel(int id, FormCollection collection)
        {
            var tabEdit = (from tab in db.Табель where tab.КодТабель == id select tab).First();
            try
            {
                UpdateModel(tabEdit);
                db.SaveChanges();
                return RedirectToAction("Tabel");
            }
            catch
            {
                return View(tabEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTabel(int id) // удалить 
        {
            var tabDelete = (from tab in db.Табель where tab.КодТабель == id select tab).First();
            ViewBag.КодСотрудник = new SelectList(db.Сотрудник, "КодСотрудник", "ФИОсотрудник");

            return View(tabDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTabel(int id, FormCollection collection)
        {
            var tabDelete = (from tab in db.Табель where tab.КодТабель == id select tab).First();
            try
            {
                db.Табель.Remove(tabDelete);
                db.SaveChanges();
                return RedirectToAction("Tabel");
            }
            catch
            {
                return View(tabDelete);
            }
        }


//--------------------------------------ТАРИФЫ------------

        [Authorize(Roles = "Admin")]
        public ActionResult Tarif() // список 
        {
            var tars = (from tar in db.Тариф select tar).ToList();
            return View(tars);
        }

        // GET: Admin/CreateService
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTarif() // создать 
        {
            Тариф tar = new Тариф();
            ViewBag.КодРазряд = new SelectList(db.Разряды, "КодРазряд", "Разряд");
            ViewBag.КодДолжность = new SelectList(db.Должность, "КодДолжность", "Должность1");

            return View(tar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTarif(Тариф tar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Тариф.Add(tar);
                    db.SaveChanges();
                    return RedirectToAction("Tarif");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(tar);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditTarif(int id) // изменить 
        {
            var tarEdit = (from tar in db.Тариф where tar.КодТариф == id select tar).First();

            var razr = db.Разряды.Find(tarEdit.КодРазряд);
            var dol = db.Должность.Find(tarEdit.КодДолжность);

            ViewBag.КодРазряд = new SelectList(db.Разряды, "КодРазряд", "Разряд", razr.КодРазряд);
            ViewBag.КодДолжность = new SelectList(db.Должность, "КодДолжность", "Должность1", dol.КодДолжность);


            return View(tarEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTarif(int id, FormCollection collection)
        {
            var tarEdit = (from tar in db.Тариф where tar.КодТариф == id select tar).First();
            try
            {
                UpdateModel(tarEdit);
                db.SaveChanges();
                return RedirectToAction("Tarif");
            }
            catch
            {
                return View(tarEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTarif(int id) // удалить 
        {
            var tarDelete = (from tar in db.Тариф where tar.КодТариф == id select tar).First();

            ViewBag.КодРазряд = new SelectList(db.Разряды, "КодРазряд", "Разряд");
            ViewBag.КодДолжность = new SelectList(db.Должность, "КодДолжность", "Должность1");

            return View(tarDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTarif(int id, FormCollection collection)
        {
            var tarDelete = (from tar in db.Тариф where tar.КодТариф == id select tar).First();
            try
            {
                db.Тариф.Remove(tarDelete);
                db.SaveChanges();
                return RedirectToAction("Tarif");
            }
            catch
            {
                return View(tarDelete);
            }
        }

//--------------------------------------ГРУППЫ МАТЕРИАЛОВ ------------
        [Authorize(Roles = "Admin")]
        public ActionResult Group()
        {
            var grs = (from gr in db.ГруппаМатериалов select gr).ToList();
            return View(grs);
        }

        // GET: Admin/CreateDiscount
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup() // создать 
        {
            ГруппаМатериалов gr = new ГруппаМатериалов();
            return View(gr);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup(ГруппаМатериалов gr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ГруппаМатериалов.Add(gr);
                    db.SaveChanges();
                    return RedirectToAction("Group");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(gr);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditGroup(int id) // изменить 
        {
            var grEdit = (from gr in db.ГруппаМатериалов where gr.КодГруппа == id select gr).First();
            return View(grEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditGroup(int id, FormCollection collection)
        {
            var grEdit = (from gr in db.ГруппаМатериалов where gr.КодГруппа == id select gr).First();
            try
            {
                UpdateModel(grEdit);
                db.SaveChanges();
                return RedirectToAction("Group");
            }
            catch
            {
                return View(grEdit);
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroup(int id) // удалить 
        {
            var grDelete = (from gr in db.ГруппаМатериалов where gr.КодГруппа == id select gr).First();

            return View(grDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroup(int id, FormCollection collection)
        {
            var grDelete = (from gr in db.ГруппаМатериалов where gr.КодГруппа == id select gr).First();
            try
            {
                db.ГруппаМатериалов.Remove(grDelete);
                db.SaveChanges();
                return RedirectToAction("Group");
            }
            catch
            {
                return View(grDelete);
            }
        }

    }
}