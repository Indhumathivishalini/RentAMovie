using RentAMovie.Models;
using RentAMovie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public MovieController()
        {
            dbContext = new ApplicationDbContext();

        }
        // GET: Movie
        public ActionResult Index()
        {
            var movie = GetMovies();
            return View(movie);
        }
        public ActionResult Detail(int id)

        {
            var mov = GetMovies().SingleOrDefault(m => m.MovieId == id);
            if (mov == null)
            {
                return HttpNotFound();
            }
            return View(mov);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MovieGenreViewModel viewModel = new MovieGenreViewModel();
            Movie movie = new Movie();
            var genres = dbContext.Genres.ToList();
            viewModel.Movie = movie;
            viewModel.Genres = genres;
            return View(viewModel);
        
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { MovieId =1, MovieName="Game of Thrones",AddedDate=Convert.ToDateTime("01-03-2019"),ReleaseDate=Convert.ToDateTime("13-03-2019")},
                new Movie { MovieId = 2, MovieName = "Hanna" ,AddedDate=Convert.ToDateTime("03-04-2018"),ReleaseDate=Convert.ToDateTime("23-04-2018")},
                new Movie { MovieId = 3, MovieName = "How to train your Dragon",AddedDate=Convert.ToDateTime("05-02-2017"),ReleaseDate=Convert.ToDateTime("15-02-2017") },
            };
            return movies;
        }
        
    }
}