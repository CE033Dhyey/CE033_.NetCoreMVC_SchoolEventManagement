
using SchoolEventMvc.Models.Domain;
using SchoolEventMvc.Models.Domain.DTO;
using SchoolEventMvc.Models.Domain.DTO.SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Models.DTO;

namespace SchoolEventMvc.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
    }
}
