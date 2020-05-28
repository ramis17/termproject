using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProject.Models;


namespace TermProject.Controllers
{
    public class HomeController : Controller
    {
        

        DataClasses1DataContext dc = new DataClasses1DataContext();



        public ActionResult ViewItems()
        {
            var a = dc.records.ToList();
            return View(a);
        }

        public ActionResult AddItems()
        {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult EditInfo(int id)
        {
            var obj1 = dc.records.First(x => x.Id == id);
            return View(obj1);
        }

        public ActionResult Add()
        {
            string name = Request["title"];
            string description = Request["description"];
            string price = Request["price"];
            string category = Request["category"];
            record obj = new record();
            obj.title = name;
            obj.description = description;
            obj.price = int.Parse(price);
            obj.category = category;

            dc.records.InsertOnSubmit(obj);

            dc.SubmitChanges();
            return RedirectToAction("ViewItems");
        }

        public ActionResult Delete(int id)
        {
            var obj3 = dc.records.First(x => x.Id == id);
            dc.records.DeleteOnSubmit(obj3);
            dc.SubmitChanges();

            return RedirectToAction("ViewItems");
        }
       

        public ActionResult Edit(int id)
        {
            var obj2 = dc.records.First(x => x.Id == id);
            obj2.title = Request["title"];
            obj2.description = Request["description"];
            obj2.price = int.Parse(Request["price"]);
            obj2.category = Request["category"];
            dc.SubmitChanges();
            return RedirectToAction("ViewItems");
        }

     

        public ActionResult ShowNameDetail()
        {
            string obj6 = Request["title"];
            var obj7 = dc.records.Where(x => x.title == obj6);

            return View(obj7);

        }
        

        public ActionResult ShowCategoryDetail()
        {
            string obj4 = Request["category"];
            var obj5 = dc.records.Where(x => x.category == obj4); 

            return View(obj5);

        }
      

    }
}
