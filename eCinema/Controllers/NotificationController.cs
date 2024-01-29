using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class NotificationController : BaseCRUDController<NotificationDto, NotificationSearchObject, NotificationInsertRequest, NotificationUpdateRequest>
    {
        public NotificationController(INotificationService notificationService) 
            : base(notificationService)
        {
        }

    }
}
