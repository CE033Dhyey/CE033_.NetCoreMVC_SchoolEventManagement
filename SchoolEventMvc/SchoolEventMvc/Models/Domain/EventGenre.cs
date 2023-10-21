using System.ComponentModel.DataAnnotations;

namespace SchoolEventMvc.Models.Domain
{
    public class EventGenre
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int GenreId { get; set; }

    }
}
