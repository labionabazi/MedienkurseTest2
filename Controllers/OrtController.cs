using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MedienkurseTest2.Models;
using MedienkurseTest2.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedienkurseTest2.Controllers
{
    [Authorize]
    public class OrtController : Controller
    {
        public ApplicationDbContext context;
        public OrtController(ApplicationDbContext db)
        {
            this.context = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var orte = context.Ort.AsEnumerable();

            List<OrtViewModel> models = new List<OrtViewModel>();

            foreach (var ort in orte)
            {
                OrtViewModel model = new OrtViewModel()
                {
                    Id = ort.Id,
                    Name = ort.Name,
                    PLZ = ort.PLZ,
                    Kanton = ort.Kanton
                };

                models.Add(model);

            }

            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(OrtViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            Ort ort = new Ort()
            {
                Name = model.Name,
                PLZ = model.PLZ,
                Kanton = model.Kanton
            };

            context.Ort.Add(ort);
            context.SaveChanges();

            return RedirectToAction("Show", new { ort.Id });
        }

        public IActionResult Show(int id)
        {
            var ort = context.Ort.FirstOrDefault(i => i.Id == id);

            if (ort == null)
            {
                return RedirectToAction("Index");
            }

            OrtViewModel model = new OrtViewModel()
            {
                Name = ort.Name,
                PLZ = ort.PLZ,
                Kanton = ort.Kanton
            };

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var ort = context.Ort.FirstOrDefault(i => i.Id == id);

            if (ort == null)
            {
                return RedirectToAction("Index");
            }

            OrtViewModel model = new OrtViewModel()
            {
                Id = ort.Id,
                Name = ort.Name,
                PLZ = ort.PLZ,
                Kanton = ort.Kanton
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(OrtViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var ort = context.Ort.FirstOrDefault(i => i.Id == id);

            if (ort == null)
            {
                return RedirectToAction("Index");
            }

            ort.PLZ = model.PLZ;
            ort.Name = model.Name;
            ort.Kanton = model.Kanton;

            context.Ort.Update(ort);
            context.SaveChanges();

            return RedirectToAction("Show", new { id });
        }

        [HttpPost]
        public IActionResult Destroy(int id)
        {
            var ort = context.Ort.FirstOrDefault(i => i.Id == id);

            if (ort == null)
            {
                return RedirectToAction("Index");
            }

            context.Ort.Remove(ort);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
