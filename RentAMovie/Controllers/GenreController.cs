using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.Controllers
{
    public class GenreController : Controller
    {


        private ApplicationDbContext dbContext = null;

        public GenreController()
        {
            dbContext = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Genre
        public ActionResult Index()
        {
            //   var customer = GetCustomer();
            //  return View(customer);
            var Genres = GetGenres().ToList();
            return View(Genres);

        }

        public ActionResult Details(int id)

        {
            var genre = GetGenres().SingleOrDefault(c => c.Id == id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        public List<Genre> GetGenres()
        {
        List<Genre> genres = new List<Genre>
        {
            new Genre{Id=1,Name="Thriller"},
            new Genre{Id=1,Name="horror"},

        };
            return genres;
      

        }
       
    }
}