using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1,30,ErrorMessage ="Number in stock must be between 1 and 30")]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}