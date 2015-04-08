using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CodingChallenge.Models;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private CodingChallengeModel ReadData()
        {
            var dto = new List<CodingChallengeDto>();

            using (TextReader reader = System.IO.File.OpenText(HttpContext.Server.MapPath("~/App_Data/CodeChallenge_Data.csv")))
            {
                var csv = new CsvReader(reader);
                dto = csv.GetRecords<CodingChallengeDto>().ToList();
            }

            return new CodingChallengeModel(dto);
        }

        public ActionResult Index()
        {
            var model = ReadData();

            return View("Index", model);
        }

    }
}