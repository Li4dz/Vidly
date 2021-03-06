﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
      
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var model = new MoviesViewModel
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View("Form",model);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MoviesViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("Form", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                var viewModel = new MoviesViewModel
                {
                    Movie = movie
                };
                return View(viewModel);
            }

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MoviesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesViewModel
                {
                    Movie = new Movie(),
                    Genres = _context.Genres.ToList()
                };

                return View("Form", viewModel);
            }

            if (model.Movie.Id == 0)
                _context.Movies.Add(model.Movie);
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == model.Movie.Id);
                movieInDb.Name = model.Movie.Name;
                movieInDb.ReleaseDate = model.Movie.ReleaseDate;
                movieInDb.DateAdded = model.Movie.DateAdded;
                movieInDb.GenreId = model.Movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}