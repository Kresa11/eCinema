using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Model.Dtos
{
    public class HallDto
    {
        public Guid Id { get; set; }
        
        public string? Name { get; set; }
        
        public ICollection<SeatDto>? Seat { get; set; }

    }
}
