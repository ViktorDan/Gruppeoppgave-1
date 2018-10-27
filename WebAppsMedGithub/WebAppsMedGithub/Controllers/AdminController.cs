﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace WebAppsMedGithub.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Admin()
        {
            if (SjekkLogin())
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminKunder()
        {
            if (SjekkLogin())
            {
                var adminDb = new AdminBLL();
                List<dbKunder> kunder = adminDb.HentAlleKunder();
                return View(kunder);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminFilm()
        {
            if (SjekkLogin())
            {
                var adminDb = new AdminBLL();
                List<Filmer> filmer = adminDb.HentAlleFilmer();
                return View(filmer);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminBestilling()
        {
            if (SjekkLogin())
            {
                var adminDb = new AdminBLL();
                List<Bestillinger> bestillinger = adminDb.HentAlleBestillinger();
                return View(bestillinger);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public void EndreKunde(int id, String bn, String fn, String en, String ad, int post, int tlf)
        {
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreKunde(id, bn, fn, en, ad, post, tlf);
        }
        public void SlettKunde(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        public void EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris)
        {
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreFilm(id, tittel, aar, sjan, len, stor, pris);
        }
        public void SlettFilm(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettFilm(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        public void SlettBestilling(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettBestilling(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        // Ender Session.
        public ActionResult LoggUt()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public bool SjekkLogin()
        {
            if (Session["AdminLoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["AdminLoggetInn"];
                if (loggetInn)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}