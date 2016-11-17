using Garage2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class ApplicationController : Controller
    {
        private GarageRepository _garage = new GarageRepository();

        public ApplicationController()
        {
            var selectedGarage = MainRepository.selectedGarage;
            if  (selectedGarage != null)
            {
                ViewBag.selectedGarage = selectedGarage.Name;
            } else
            {
                ViewBag.selectedGarage = "Inget valt garage";
            }
            ViewBag.GarageCount = _garage.GetAllGarages().Count();
            ViewBag.Garages = _garage.GetAllGarages();
        }

    }
}