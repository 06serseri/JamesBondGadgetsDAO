using JamesBondGadgets.Data;
using JamesBondGadgets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamesBondGadgets.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();

            GadgetDAO gadgetDAO = new GadgetDAO();

            gadgets = gadgetDAO.GetAll();



            return View("Index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.GetGadget(id);


            return View("Details", gadget);
        }

        //Create new gadget in the database
        public ActionResult Create()
        {
            return View("GadgetForm");
        }

        public ActionResult Edit(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.GetGadget(id);
            return View("GadgetForm", gadget);
        }

        public ActionResult Delete(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Delete(id);

            List<GadgetModel> gadgets = gadgetDAO.GetAll();

            return View("Index", gadgets);
        }

        public ActionResult ProcessCreate (GadgetModel gadgetModel)
        {
            //Save to the database
            GadgetDAO gadgetDAO = new GadgetDAO();

            gadgetDAO.CreateOrUpdateGadget(gadgetModel);

            return View("Details", gadgetModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }


        public ActionResult SearchForName(string searchPhrase)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            List<GadgetModel> searchResults = gadgetDAO.SearchForName(searchPhrase);

            return View("Index", searchResults);
        }

        public ActionResult SearchForDescription(string searchPhraseDescription)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            List<GadgetModel> searchResults = gadgetDAO.SearchForDescription(searchPhraseDescription);

            return View("Index", searchResults);
        }

    }
}