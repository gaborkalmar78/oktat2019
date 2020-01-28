
using Microsoft.AspNetCore.Mvc;
using _017.Models;
using System.Collections.Generic;

namespace _017.Controllers
{
    public class DataController : Controller
    {
        public DataController()
        {
            //records = new DataModel[10];
            records = new DataModel[] {
                new DataModel(1,"alma"),
                new DataModel(2,"barack"),
                new DataModel(3,"cékla"),
                new DataModel(4,"datolya"),
                new DataModel(5,"eper"),
                new DataModel(6,"füge"),
                new DataModel(7,"gabona"),
                new DataModel(8,"megy"),
                new DataModel(9,"dinnye"),
                new DataModel(10,"szilva")
             };
        }
        private DataModel[] records;
        public IActionResult Index(int min, int max, bool inv)
        {
            if (min > 0 && min < max && max <= 100)
            {
                return View(Filter(records, min, max, inv));
            }
            return RedirectToAction("Index", "Query");
        }
        private DataModel[] Filter(DataModel[] records, int min, int max, bool inv)
        {
            List<DataModel> filtered = new List<DataModel>();
            for (int i = 0; i < records.Length; i++)
            {
                if (inv ^ (records[i].Value >= min && records[i].Value <= max))
                {
                    filtered.Add(records[i]);
                }
            }
            return filtered.ToArray();
        }
    }
}
