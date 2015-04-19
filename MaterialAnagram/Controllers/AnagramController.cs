using MaterialAnagram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaterialAnagram.Controllers
{
    public class AnagramController : Controller
    {
        // GET: Anagram
        public ActionResult Index()
        {
            return View();
        }
        //public MvcHtmlString MakeQrCode(string givenUrl)
        //{
        //    return QRCodeGenerator.GenerateQrCode(givenUrl);
        //}

        public ActionResult AnagramGen(string givenText)
        {
            AnagramService anagramService = new AnagramService();
            //return Content(JsonGenerator.ToJSON(anagramService.getResults(givenText).Trim('\"').Split(',')));
            return Content(anagramService.getResults(givenText).Trim('\"').Split(',').ToJSON());
        }

    }
}