using Garage2.Data;
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
        private OwnerRepository _owner = new OwnerRepository();

        public ApplicationController()
        {
            var selectedGarage = MainRepository.selectedGarage;
            var selectedOwner  = MainRepository.selectedOwner;

            if  (selectedGarage != null)
            {
                ViewBag.selectedGarage = selectedGarage.Name;
            } else
            {
                ViewBag.selectedGarage = "Inget valt garage";
            }

            if  (selectedOwner != null)
            {
                ViewBag.selectedOwner = selectedOwner.FullName;
            } else
            {
                ViewBag.selectedOwner = "Inget valt garage";
            }

            //ViewBag.GarageCount = _garage.GetAllGarages().Count();
            ViewBag.Garages = _garage.GetAllGarages();
            ViewBag.Owners = _owner.GetAllOwners();
        }

    }
}