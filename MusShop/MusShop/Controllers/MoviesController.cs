using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult Movies()
        {
            //var movie = _context.Movies.Include(c => c.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Movies");
            }

            return View("ReadOnlyMovies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.GenreId = movie.GenreId;
                movieDb.NumberInStock = movie.NumberInStock;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Movies","Movies");
        }
        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Alexander Tseluyko"},
                new Customer {Name = "Alex TSL"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        ////movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}
    }
}