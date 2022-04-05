﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CassetteCompiler.Repositories;
using CassetteCompiler.Models;
using CassetteCompiler.Models.ViewModels;
using System.Security.Claims;

namespace CassetteCompiler.Controllers
{
    public class CassetteController : Controller
    {
        private readonly ICassetteRepository _cassetteRepo;
        public CassetteController(ICassetteRepository cassetteRepository)
        {
            _cassetteRepo = cassetteRepository;
        }
        // GET: CassetteController
        public ActionResult Index()
        {
            int currentUserId = GetCurrentUserId();
            List<Cassette> cassettes = _cassetteRepo.GetByUserId(currentUserId);
            return View(cassettes);
        }

        // GET: CassetteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CassetteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CassetteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CassetteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CassetteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CassetteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CassetteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}