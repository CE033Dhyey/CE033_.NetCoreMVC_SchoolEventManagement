using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using SchoolEventMvc.Models.Domain;
using SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Repositories.Abstract;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SchoolEventMvc.Repositories.Implementation
{

    public class EventService : IEventService
    {
        private readonly DatabaseContext ctx;
        private int genreId;

        public EventService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Event model)
        {
            try
            {

                ctx.Event.Add(model);
                ctx.SaveChanges();
                foreach (var item in model.Genres)
                {
                    var eventGenre = new EventGenre
                    {
                        EventId = model.Id,
                        GenreId = genreId
                    };
                    ctx.EventGenre.Add(eventGenre);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                var eventGenres = ctx.EventGenre.Where(a => a.EventId == data.Id);
                foreach (var eventGenree in eventGenres) 
                {
                    ctx.EventGenre.Remove(eventGenree);
                }
                ctx.Event.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Event GetById(int id)
        {
            return ctx.Event.Find(id);
        }

        public EventListVm List()
        {
            var list = ctx.Event.ToList();
            foreach (var eventt in list)
            {
                var genres = (from genre in ctx.Genre
                              join bg in ctx.EventGenre
                              on genre.Id equals bg.GenreId
                              where bg.EventId == eventt.Id
                              select genre.GenreName
                              ).ToList();
                var genreNames = string.Join(",", genres);
                eventt.GenreNames = genreNames;
            }
            var data = new EventListVm
            {
                EventList = list.AsQueryable()
            };
            return data;
        }

        public bool Update(Event model)
        {
         


            try
            {
                ctx.Event.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetGenreByEventId(int eventId)
        {
            var genreIds = ctx.EventGenre.Where(a => a.EventId == eventId).Select(a => a.GenreId).ToList();
            return genreIds;
        }


    }
}
