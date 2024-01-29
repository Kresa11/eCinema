namespace eCinema.Model.Requests;

public class PaymentUpsertRequest
{
    public string StripePaymentId { get; set; }
    
    public decimal? Amount { get; set; }
    
    public ReservationUpsertRequest? Reservation { get; set; }
}