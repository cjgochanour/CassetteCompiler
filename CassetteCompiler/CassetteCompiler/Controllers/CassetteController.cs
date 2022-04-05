using Microsoft.AspNetCore.Http;
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
        private readonly IGenreRepository _genreRepo;
        public CassetteController(ICassetteRepository cassetteRepository, IGenreRepository genreRepository)
        {
            _cassetteRepo = cassetteRepository;
            _genreRepo = genreRepository;
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
            Cassette cassette = _cassetteRepo.GetById(id);
            return View(cassette);
        }

        // GET: CassetteController/Create
        public ActionResult Create()
        {
            CassetteFormViewModel cfvm = new CassetteFormViewModel();
            cfvm.Genres = _genreRepo.GetAll();
            cfvm.GenreIds = new List<int>();
            return View(cfvm);
        }

        // POST: CassetteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CassetteFormViewModel cfvm)
        {
            try
            {
                cfvm.Cassette.UserId = GetCurrentUserId();
                _cassetteRepo.AddCassette(cfvm.Cassette);
                foreach(int id in cfvm.GenreIds)
                {
                    _genreRepo.AddCassetteGenre(cfvm.Cassette.Id, id);
                }
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
            Cassette cassette = _cassetteRepo.GetById(id);
            return View(cassette);
        }

        // POST: CassetteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cassette cassette)
        {
            try
            {
                _cassetteRepo.DeleteCassette(cassette.Id);
                return RedirectToAction("Index");
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
