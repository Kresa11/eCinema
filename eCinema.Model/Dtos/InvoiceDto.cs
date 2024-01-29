namespace eCinema.Model.Dtos;

public class InvoiceDto
{
    public Guid Id { get; set; } 

    public DateTime? Created { get; set; }

    public decimal? Price { get; set; }

    public decimal? VAT { get; set; }

    public Guid ReservationId { get; set; }

    public ReservationDto? Reservation { get; set; }
}