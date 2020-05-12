using TravelEurope.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelEurope.ViewModels;

namespace TravelEurope.Util
{
    public class UserManagementHelper
    {
        private ApplicationDbContext _db;

        public UserManagementHelper(ApplicationDbContext db)
        {
            _db = db;
        }

        public KorisniciVM prepAdmina()
        {

            KorisniciVM model = new KorisniciVM();

            model.DatumRodjenja = DateTime.Now;
            model.Spolovi = new List<SelectListItem>();

            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Muško",
                Text = "Muško"
            });

            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Žensko",
                Text = "Žensko"
            });


            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem()
            {
                Value = x.GradId.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv
            }).ToList();

            return model;
        }
        public KorisniciVM prepRadnika()
        {
            KorisniciVM model = new KorisniciVM();

            model.DatumRodjenja = DateTime.Now;
            model.Spolovi = new List<SelectListItem>();

            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Muško",
                Text = "Muško"
            });

            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Žensko",
                Text = "Žensko"
            });

            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem()
            {
                Value = x.GradId.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv
            }).ToList();

            return model;
        }
    }
}