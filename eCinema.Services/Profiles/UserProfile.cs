using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Services.Database;

namespace eCinema.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Notification, NotificationInsertRequest>().ReverseMap();
            CreateMap<Notification, NotificationUpdateRequest>().ReverseMap();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieUpsertRequest>().ReverseMap();

            CreateMap<Projection, ProjectionDto>().ReverseMap();
            CreateMap<Projection, ProjectionUpsertRequest>().ReverseMap();
            CreateMap<ProjectionDto, ProjectionUpsertRequest>().ReverseMap();

            CreateMap<Price, PriceDto>().ReverseMap();
            CreateMap<Price, PriceUpsertRequest>().ReverseMap();
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserInsertRequest>().ReverseMap();
            CreateMap<User, UserUpdateRequest>().ReverseMap();
            CreateMap<User, UserAdminUpdateRequest>().ReverseMap();
            
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<Hall, HallDto>().ReverseMap();
            
            CreateMap<Seat, SeatDto>().ReverseMap();
            
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            
            CreateMap<SeatxrefReservation, SeatxrefReservationDto>().ReverseMap();
            
            CreateMap<PaymentDto, Payment>().ReverseMap();

        }
    }
}
