
using SchoolEventMvc.Models.Domain;
using SchoolEventMvc.Models.Domain.DTO;
using SchoolEventMvc.Models.Domain.DTO.SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Models.DTO;

namespace SchoolEventMvc.Repositories.Abstract
{
    public interface IEventService
    {
        bool Add(Event model);
        bool Update(Event model);
        Event GetById(int id);
        bool Delete(int id);
        EventListVm List();
        
        List<int> GetGenreByEventId(int movieId);
    }
}
