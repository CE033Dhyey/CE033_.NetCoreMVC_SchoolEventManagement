using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SchoolEventMvc.Models.Domain
{
    public class Event
    {

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? EventDate { get; set; }

        public string? EventImage { get; set; }  // stores movie image name with extension (eg, image0001.jpg)
        [Required]
        public string? Organizer { get; set; }
        [Required]
        public string? Coordinator { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        


        public List<int>? Genres { get; set; }
        public IEnumerable<SelectListItem> GenreList;
        [NotMapped]

     

        public string? GenreNames { get; set; }

        [NotMapped]
        public MultiSelectList? MultiGenreList { get; set; }

    }
}
