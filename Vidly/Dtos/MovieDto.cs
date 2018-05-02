using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }
    }
}