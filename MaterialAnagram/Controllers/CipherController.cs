using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CipherLibrary.Techniques;

namespace MaterialAnagram.Controllers
{
    public class CipherController : Controller
    {
        // GET: Cipher
        public ActionResult Index()
        {
            return View();
        }
        public HtmlString CaeserEncryption(string givenText)
        {
            Caeser encryptor=new Caeser();
            return new HtmlString(encryptor.Encrypt(givenText));
        }

        public HtmlString GetAESResult(string givenText)
        {
            AES encryptor = new AES();
            return new HtmlString(encryptor.EncryptText( givenText));
        }

    }
}