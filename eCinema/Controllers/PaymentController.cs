using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class PaymentController : BaseCRUDController<PaymentDto, BaseSearchObject, PaymentUpsertRequest, PaymentUpsertRequest>
    {
        public PaymentController(IPaymentService paymentService)
            : base(paymentService)
        {
        }
    }
}
