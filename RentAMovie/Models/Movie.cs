using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string  MovieName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
       
        //creating foreign key
        public Genre Genre { get; set; }


        public int GenreId { get; set; }
        public int Stock { get; set; }

       
    }
}