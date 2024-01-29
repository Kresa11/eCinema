namespace eCinema.Model.Dtos;

public class PaymentDto
{
    public string StripePaymentId { get; set; }

    public DateTime? Created { get; set; }

    public decimal? Amount { get; set; }
        
    public Guid ReservationId { get; set; }
}