namespace eCinema.Model.Dtos;

public class SeatDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    
    public Guid? HallId { get; set; }

}