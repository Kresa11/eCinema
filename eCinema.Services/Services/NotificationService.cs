using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class NotificationService : BaseCRUDService<NotificationDto, Notification, NotificationSearchObject, NotificationInsertRequest, NotificationUpdateRequest>, INotificationService
    {
        public NotificationService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override IQueryable<Notification> AddFilter(IQueryable<Notification> query, NotificationSearchObject search)
        {
            var filteredQuery = query;
            if (!string.IsNullOrWhiteSpace(search.Title))
                filteredQuery = filteredQuery.Where(x => x.Title != null && x.Title.ToLower().Contains(search.Title.ToLower()));
            if (search.AuthorId != Guid.Empty)
            {
                filteredQuery = filteredQuery.Where(x => x.AuthorId == search.AuthorId);

            }
            if (!string.IsNullOrWhiteSpace(search.NotificationType) && search.NotificationType!="Svi")
                filteredQuery = filteredQuery.Where(x => x.NotificationType != null && x.NotificationType.ToLower().Contains(search.NotificationType.ToLower()));

            return filteredQuery;

        }
      
        public override void BeforeInsert(NotificationInsertRequest insert,Notification entity)
        {
            //entity.AuthorId = new Guid("089782f3-710f-4f40-84d1-0b99623e7985");
            entity.Date = DateTime.Now;
            if (insert.Picture == null)
                entity.Picture = Images.DefaultImage;
        }

        public override void BeforeUpdate(Notification entity)
        {
            entity.Date = DateTime.Now;
            if (entity.Picture == null)
                entity.Picture = Images.DefaultImage;
        }

        public override IQueryable<Notification> AddInclude(IQueryable<Notification> query, NotificationSearchObject search)
        {
            if (search?.IncludeUsers is true)
            {
                query = query.Include(x => x.Author);
            }

            return query;
        }
    }
}
