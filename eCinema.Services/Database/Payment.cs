namespace eCinema.Services.Database;

public class Payment
{
    public Guid Id { get; set; }

    public string StripePaymentId { get; set; }

    public DateTime? Created { get; set; }

    public decimal? Amount { get; set; }
        
    public Guid ReservationId { get; set; }

    public Reservation? Reservation { get; set; }
}