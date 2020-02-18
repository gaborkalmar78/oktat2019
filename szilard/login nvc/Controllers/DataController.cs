using System.Collections.Generic;
using login_nvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace login_nvc.Controllers
{
    public class DataController : Controller
    {

        private DataModel[] data;

        public IActionResult Index(QueryModel query)
        {
            List<DataModel> resault = new List<DataModel>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Value <= query.Max && data[i].Value > query.Min)
                {
                    resault.Add(data[i]);

                }
            }



            return View(resault.ToArray());
        }

        public DataController()
        {
            data = new DataModel[]
            {
            new DataModel("alma",1),
            new DataModel("körte",2),
            new DataModel("banán",3),
            new DataModel("cseresznye",4),
            new DataModel("ananász",5),
            new DataModel("mandarin",6),
            new DataModel("dio",7),
            new DataModel("zöldalma",8),
            new DataModel("paprika",9),
            new DataModel("eper",10)


            };
        }
    }
}
