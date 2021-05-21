using BondGadgetCollection.Data;
using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BondGadgetCollection.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            //List<GadgetModel> gadgets = new List<GadgetModel>
            //{
            //    new GadgetModel(0, "Gun", "A secret gun", "Moonraker", "Actor name"),
            //    new GadgetModel(0, "Knife", "A secret knife", "Moonraker", "Actor name"),
            //    new GadgetModel(0, "Rope", "A secret rope", "Moonraker", "Actor name"),
            //    new GadgetModel(0, "Car", "A secret car", "Moonraker", "Actor name")
            //};
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            List<GadgetModel> gadgets = gadgetsDAO.FetchAll();
            return View(gadgets);
        }
        public ActionResult Details(int Id)
        {
            GadgetsDAO allGadgets = new GadgetsDAO();
            GadgetModel gadget = allGadgets.FetchOne(Id);
            return View(gadget);
        }
       
        public ActionResult Create()
        {
            return View("GadgetForm",new GadgetModel());
        }

        public ActionResult Delete(int id)
        {
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            gadgetsDAO.Delete(id);
            return View("Index",gadgetsDAO.FetchAll());
        }
        public ActionResult Edit(int id)
        {
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            GadgetModel gadget = gadgetsDAO.FetchOne(id);
            return View("GadgetForm",gadget);
        }
        [HttpPost]
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            //save to the db
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            gadgetsDAO.CreaeteOrUpdate(gadgetModel);
            return View("Details", gadgetModel);
        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForName(string searchPhrase)
        {
            //get list of serach results from the database
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            List<GadgetModel> searchResults = gadgetsDAO.SearchFor(searchPhrase,"Name");

            return View("Index", searchResults);
        }
        public ActionResult SearchForDescription(string searchPhrase)
        {
            //get list of serach results from the database
            GadgetsDAO gadgetsDAO = new GadgetsDAO();
            List<GadgetModel> searchResults = gadgetsDAO.SearchFor(searchPhrase, "Description");

            return View("Index", searchResults);
        }
    }
}