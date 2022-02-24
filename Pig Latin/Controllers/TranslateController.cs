using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pig_Latin.Models;

namespace Pig_Latin.Controllers
{
    
    public class TranslateController : Controller
    {
        [HttpGet]

        public ActionResult Translate()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Translate (English_PigLatin model)
        {
            if(ModelState.IsValid)
            {
                TranslatePigLatin translate = new TranslatePigLatin();

                string english = model.English_text;

                string pigLatin = translate.Translate(english);

                model.PigLatin_text = pigLatin;

                return View("DisplayPigLatin", model);
            }
            return View(model);
        }
    }
}