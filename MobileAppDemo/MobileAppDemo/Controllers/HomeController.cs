using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MobileAppDemo.Models;
using System.Data.Objects;


namespace MobileAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private TestDBContext _db = new TestDBContext();
     
        
        public ActionResult Manifest()
        {
            Response.ContentType = "text/cache-manifest";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache);
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

        public ActionResult CRUDdemo()
        {
            List<SelectListItem> templateItems = new List<SelectListItem>();
          
            List<Template> templates = _db.Templates.ToList();

            ViewData.Model = templates;           

            return View();
        }


        public ActionResult PDFdemo()
        {
            ViewBag.Message = "Create a PDF Mobile App";

            List<SelectListItem> templateItems = new List<SelectListItem>();
            List<SelectListItem> optionItems = new List<SelectListItem>();
           
            List<Template> temp_items = _db.Templates.ToList();
            List<Option> option_items = _db.Options.ToList();
           
            //populate templates select dropdown with db data
            int i = 1;
            foreach (Template t in temp_items)
            {
                templateItems.Add(new SelectListItem() { Text = t.type, Value = i.ToString() });    
                i++;
                Debug.WriteLine(t.type);
            }
            ViewData.Add("TemplateItems", templateItems);

            //populate options select dropdown with db data
            i = 1;
            foreach (Option o in option_items)
            {
                optionItems.Add(new SelectListItem() { Text = o.name, Value = i.ToString() });
                i++;
                Debug.WriteLine(o.name);
            }
            ViewData.Add("OptionItems", optionItems);

            //populate template select dropdown with hard-coded
            //templateItems.AddRange(new[]{
            //                new SelectListItem() { Text = "Template One", Value = "1" },
            //                new SelectListItem() { Text = "Template Two", Value = "2" },
            //                new SelectListItem() { Text = "Template Three", Value = "3" }});
            //ViewData.Add("TemplateItems", templateItems);

            //populate option select dropdown with hard-coded
            //optionItems.AddRange(new[]{
            //                new SelectListItem() { Text = "Option One", Value = "1" },
            //                new SelectListItem() { Text = "Option Two", Value = "2" },
            //                new SelectListItem() { Text = "Option Three", Value = "3" },
            //                new SelectListItem() { Text = "Option Four", Value = "4" }});
            //ViewData.Add("OptionItems", optionItems);


            Response.Cache.SetCacheability(
              System.Web.HttpCacheability.NoCache);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a demo app that shows PDFs created with MVC 4 mobile app.";

            Response.Cache.SetCacheability(
            System.Web.HttpCacheability.NoCache);

            return View();
        }

        public ActionResult Widgets()
        {

            ViewBag.Message = "This is a demo of User Interface Widgets.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult ajaxCreateNewPDF(String items){
            var jsonresult = "";
            if (items != null)
            {
                Console.WriteLine("Recieved from view: " + items.ToString());
                String [] vals = items.Split(';');
                String template = "";
                String option = "";
                String docName = "Undefined";

                  List<Template> temp_items = _db.Templates.ToList();
            List<Option> option_items = _db.Options.ToList();

                foreach (String s in vals)
                {
                    Debug.WriteLine(s);
                }
                
                //template type
                if (vals[0].Equals("1"))
                {
                    template = temp_items[0].type;
                }
                else if (vals[0].Equals("2"))
                {
                    template = temp_items[1].type;
                   // template = "Template Two";
                }
                else if (vals[0].Equals("3"))
                {
                    template = temp_items[2].type;
                    //template = "Template Three";
                }

                //option type
                if (vals[1].Equals("1"))
                {
                    option = option_items[0].name;
                  //  option = "Option One";
                }
                else if (vals[1].Equals("2"))
                {
                    option = option_items[1].name;
                    //option = "Option Two";
                }
                else if (vals[1].Equals("3"))
                {
                    option = option_items[2].name;
                    //option = "Option Three";
                }
                else if (vals[1].Equals("4"))
                {
                    option = option_items[3].name;
                  //  option = "Option Four";
                }

                docName = vals[2];

                jsonresult = docName +  " ; " + template + " ; " + option;
              
                //create the pdf document
                createDocument(template, option, docName);

            }
            else
            {
                Console.WriteLine("Received: NULL");
                jsonresult = "recieved NULL";
            }

            return Json(jsonresult);
         
        }

        public void createDocument(String template, String option, String docName)
        {
            var doc1 = new Document();
            string path = Server.MapPath("~/App_Data/PDFs");
            PdfWriter.GetInstance(doc1, new FileStream(path + "/" + docName + ".pdf" , FileMode.Create));

            doc1.Open();
            doc1.Add(new Paragraph("Document Name:" + docName + " ; Template: " + template + " ; Option: " + option));
            doc1.Close();
        }

        public FileResult Download(string fileName)
        {
            fileName += ".pdf";
            fileName = Regex.Replace(fileName, @"\s+", "");
            Debug.WriteLine("recieved file: " + fileName);
            Debug.WriteLine("length: " + fileName.Length);

            if (fileName != "")
            {
                string fName = "~/App_Data/PDFs/" + fileName;
                string path = Server.MapPath(fName);
                System.IO.FileInfo file = new System.IO.FileInfo(path);

                if (file.Exists)
                {
                    Debug.WriteLine("Found the file!");
                    return File(Path.Combine(Server.MapPath("~/App_Data/PDFs"), fileName), "attachment; filename=", fileName);
                }

                //  Response.Write("The file requested does not exists");
                Debug.WriteLine("the file does not exists");
            }

           // TempData["alertError"] = "An error occurred.  The file requested does not exists.  For more assistance please contact the website administrator: jesse.elfalan@tetratech.com"; //redirect to view all
            PDFdemo();

            return null;

        }

    }
}
