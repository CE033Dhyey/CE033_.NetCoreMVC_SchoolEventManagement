using SchoolEventMvc.Models.Domain;

namespace SchoolEventMvc.Models.DTO
{
    public class EventListVm
    {
        public IQueryable<Event> EventList { get; set; }
    }
}
