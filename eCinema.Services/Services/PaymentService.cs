using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class PaymentService : BaseCRUDService<PaymentDto, Payment, BaseSearchObject, PaymentUpsertRequest, PaymentUpsertRequest>,
        IPaymentService
    {
        private IReservationService _reservationService;
        public PaymentService(CinemaContext cinemaContext, IMapper mapper, IReservationService reservationService) : base(cinemaContext, mapper)
        {
            _reservationService = reservationService;
        }
        
         public override async Task<PaymentDto> Insert(PaymentUpsertRequest insert)
         {
             var reservation = await _reservationService.Insert(insert.Reservation);

             var payment = new Payment
             {
                 ReservationId = reservation.Id,
                 Amount = insert.Amount,
                 Created = DateTime.Now,
                 StripePaymentId = insert.StripePaymentId
             };

             await _cinemaContext.AddAsync(payment);
             await _cinemaContext.SaveChangesAsync();
             
             return _mapper.Map<PaymentDto>(payment);

         }

        public override IQueryable<Payment> AddInclude(IQueryable<Payment> query, BaseSearchObject search = null)
        {
            query = query.Include(x => x.Reservation);
            return query;
        }
        
        
    }
}
