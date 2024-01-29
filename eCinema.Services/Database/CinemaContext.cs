using System.Drawing;
using eCinema.Services.Helpers;
using eCinema.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Database
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SeatxrefReservation> SeatReservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(
            //        "Data Source=localhost;Initial Catalog=eCinema;Trusted_Connection=true;MultipleActiveResultSets=true;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var saltAdmin = UserService.GenerateSalt();
            var saltUser = UserService.GenerateSalt();

            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            var listHallId = new List<Guid>();
            for (int i = 0; i < 5; i++)
            {
                listHallId.Add(Guid.NewGuid());
            }

            var listPriceId = new List<Guid>();
            for (int i = 0; i < 5; i++)
            {
                listPriceId.Add(Guid.NewGuid());
            }

            modelBuilder.Entity<Hall>().HasData(
                new Hall { Id = listHallId[0], Name = "Hall 1" },
                new Hall { Id = listHallId[1], Name = "Hall 2" },
                new Hall { Id = listHallId[2], Name = "Hall 3" },
                new Hall { Id = listHallId[3], Name = "Hall 4" },
                new Hall { Id = listHallId[4], Name = "Hall 5" }
            );

            modelBuilder.Entity<Price>().HasData(
                new Price { Id = listPriceId[0], Name = "Dnevna projekcija", Value = 6, IsActive = true },
                new Price { Id = listPriceId[1], Name = "Vecernja projekcija", Value = 7, IsActive = true },
                new Price { Id = listPriceId[2], Name = "Vikend projekcija", Value = 8, IsActive = true }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Name = "Admin" },
                new Role { Id = userRoleId, Name = "User" }
            );

            var adminId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId, FirstName = "Admin", LastName = "Admin", Email = "admin@gmail.com",
                    Username = "admin", LozinkaSalt = saltAdmin, LozinkaHash = UserService.GenerateHash(saltAdmin, "admin"),
                    RoleId = adminRoleId,
                    IsActive = true,
                    PhoneNumber = "061 111 111"
                },
                new User
                {
                    Id = userId, FirstName = "User", LastName = "User", Email = "user@gmail.com",
                    Username = "user", LozinkaSalt = saltUser, LozinkaHash = UserService.GenerateHash(saltUser, "user"),
                    RoleId = userRoleId,
                    IsActive = true,
                    PhoneNumber = "060 222 2222"
                }
            );

            var listMovieId = new List<Guid>();
            for (int i = 0; i < 10; i++)
            {
                listMovieId.Add(Guid.NewGuid());
            }

            var movie1 = new Movie
            {
                Id = listMovieId[0],
                Name = "SHAZAM! BIJES BOGOVA",
                Description =
                    "Svi imamo superjunake u sebi, potrebno je samo malo magije. U slučaju 14-godišnjeg dječaka Billyja Batsona potrebno je samo reći SHAZAM!" +
                    "Henry Gayden je i ovog puta napisao scenarij pun akcije i smijeha." +
                    "Superheroj Shazam je cinični tinejdžer koji se trudi pronaći svoje mjesto u svijetu i ne zna ništa o takvim junacima, a kamoli kako biti jedan. U njegovom" +
                    "se životu sve vrti oko magične riječi koja ga transformira u njegov odrasli alter ego superheroja, Shazama.",
                Duration = 130,
                ReleaseYear = 2022,
                Country = "SAD",
                Actors = "Zachary Levi, Helen Mirren, Lucy Liu",
                Director = "David F. Sandberg ",
                Picture = Images.ImageList[0],
                Genres = "akcija, avantura",
                IsActive = true,
            };
            var movie2 = new Movie
            {
                Id = listMovieId[1],
                Name = "JOHN WICK 4",
                Description =
                    "U četvrtom nastavku velikog akcijskog spektakla John Wick se suočava sa dosad najsmrtonosnijim protivnicima." +
                    "John Wick (Keanu Reeves) otkriva put do pobjede nad Visokim stolom. Ali prije nego što uspije zaslužiti slobodu, Wick se mora suočiti s novim neprijateljem i moćnim savezima diljem svijeta, te silama koje stare prijatelje pretvaraju u neprijatelje." +
                    "Radnja novog filma odvija se diljem svijeta i donosi precizno-koreografiranu akciju posebne vrste. U potrazi za najmoćnijim igračima kriminalnog podzemnog svijeta, film vodi gledatelje u New York, Pariz, Osaku i Berlin.",
                Duration = 169,
                ReleaseYear = 2023,
                Country = "SAD",
                Actors = "Keanu Reeves, Donnie Yen, Bill Skarsgard, Laurence Fishburne",
                Director = "Chad Stahelski",
                Picture = Images.ImageList[1],
                Genres = "akcija",
                IsActive = true,
            };
            var movie3 = new Movie
            {
                Id = listMovieId[2],
                Name = "METALLICA: 72 SEASONS – GLOBAL PREMIERE",
                Description =
                    "Budite prvi koji će čuti novi album benda, 72 Seasons, dan prije njegovog objavljivanja, na velikom platnu sa zapanjujućim surround zvukom u ovom specijalnom događaju ekskluzivno u kinima na samo jednu noć." +
                    "72 Seasons je dugoočekivani 12. studijski album Metallice, kojem prethodi prvi singl „Lux Aterna“— pozdravljen po njegovom izdanju 28. novembra 2022., kao „gromovit, vratoloman“ (Billboard), „emocionalno pogađajući“ (Rolling Stone) i „ vatren“ (USA Today)..",
                Duration = 120,
                ReleaseYear = 2023,
                Country = "SAD",
                Actors = "Metallica",
                Director = "Tim Saccenti ",
                Picture = Images.ImageList[2],
                Genres = "koncertni film",
                IsActive = true,
            };
            var movie4 = new Movie
            {
                Id = listMovieId[3],
                Name = "CREED III",
                Description =
                    "Nakon uspjeha u svijetu boksa, Adonis Creed napreduje i u karijeri i u porodičnom životu. Kada se nakon odslužene zatvorske kazne pojavi njegov prijatelj iz djetinjstva, i nekadašnje boksačko čudo, Damian (Jonathan Majors) će zaželjeti priliku u ringu. Sučeljavanje bivših prijatelja više je od obične tučnjave. Kako bi poravnao račune, Adonis mora staviti svoju budućnost na kocku kako bi se borio protiv Damiana - borca koji nema što izgubiti.",
                Duration = 116,
                ReleaseYear = 2023,
                Country = "SAD",
                Actors = "Michael B. Jordan, Jonathan Majors, Tessa Thompson",
                Director = "Michael B. Jordan",
                Picture = Images.ImageList[3],
                Genres = "sportska drama",
                IsActive = true,
            };

            var movie5 = new Movie
            {
                Id = listMovieId[4],
                Name = "UZIMAM, MOŽDA",
                Description =
                    "Multigeneracijska romantična komedija predvođena Richardom Gereom, oskarovkama Diane Keaton i Susan Sarandon te Williamom H. Macyjem." +
                    "Michelle i Allen su u svojoj vezi došli do točke kada trebaju poduzeti slijedeći korak prema braku. Misleći da je dobra ideja pozvati roditelje da se konačno upoznaju, priprema se večera i igre počinju.",
                Duration = 95,
                ReleaseYear = 2023,
                Country = "SAD",
                Actors = "Emma Roberts, Luke Bracey, Richard Gere, Diane Keaton, William H. Macy, Susan Sarandon",
                Director = "Michael Jacobs ",
                Picture = Images.ImageList[4],
                Genres = "romantična komedija",
                IsActive = true,
            };

            var movie6 = new Movie
            {
                Id = listMovieId[5],
                Name = "DUHOVI OTOKA",
                Description =
                    "Crna komedija scenarista i redatelja filma „Tri plakata izvan grada” u kojoj su zvijezde Colin Farrell i Brendan Gleeson, nasmijat će vas, ali i rastužiti do suza." +
                    "Smješten na udaljenom otoku u blizini zapadne obale Irske, film prati dugogodišnje prijatelje Pádraica (Colin Farrell) i Colma (Brendan Gleeson), koji se nađu u slijepoj ulici kada Colm neočekivano prekine njihovo prijateljstvo.",
                Duration = 114,
                ReleaseYear = 2023,
                Country = "Velika Britanija, Irska ",
                Actors = "Colin Farrell, Brendan Gleeson, Kerry Condon, Barry Keoghan",
                Director = "Martin McDonagh ",
                Picture = Images.ImageList[5],
                Genres = "komedija, drama",
                IsActive = true,
            };

            var movie7 = new Movie
            {
                Id = listMovieId[6],
                Name = "TOP GUN: MAVERICK",
                Description = " Nakon više od 30 godina služenja u mornarici, kao jedan od najboljih pilota, Pete “Maverick” Mitchell (Tom Cruise) je tamo gdje i treba da bude. Ne preza da probije barijere kao hrabar test pilot i izbjegava da prihvati unapređenje koje bi ga zauvijek spustilo na zemlju. Kada je počeo da podučava vod mladih pilota koji su na obuci za specijalne misije, kakve ni jedan živi pilot nikada još nije vidio, Maverick sreće poručnika Bradleya Bradshawa čiji je nadimak “Rooster”, sina Maverickovog pokojnog prijatelja i oficira za presretanje radara, poručnika Nicka Bradshawa, zvanog “Gus”.",
                Duration = 131,
                ReleaseYear = 2022,
                Country = "SAD",
                Actors = "Tom Cruise, Miles Teller, Jennifer Connelly, Jon Hamm, Glen Powell",
                Director = "Joseph Kosinski ",
                Picture = Images.ImageList[6],
                Genres = "akcija, avantura",
                IsActive = true,
            };

            var movie8 = new Movie
            {
                Id = listMovieId[7],
                Name = "BLACK PANTHER: WAKANDA ZAUVIJEK",
                Description = "Pripremite se za povratak u Wakandu! Nastavak filma Black Panther iz 2018. godine koji je oduševio kritičare i publiku diljem svijeta. Uz to, film je osvojio i tri Oscara, za najbolju originalnu glazbu, najbolji dizajn kostima i najbolju scenografiju." +
                             "Wakanda se mora zaštititi od svjetskih sila koje interveniraju nakon smrti kralja T’Challe. Dok Wakanđani nastoje prihvatiti gubitak voljenog vođe, heroji se moraju udružiti te uz pomoć Nakiae i Everetta Rossa iskovati novi plan za kraljevstvo Wakande.",
                Duration = 161,
                ReleaseYear = 2022,
                Country = "SAD",
                Actors = "Martin Freeman, Letitia Wright, Angela Bassett, Lupita Nyong’o, Danai Gurira",
                Director = "Ryan Coogler",
                Picture = Images.ImageList[7],
                Genres = "akcija, avantura",
                IsActive = true,
            };
            var movie9 = new Movie
            {
                Id = listMovieId[8],
                Name = "FABELMANOVI",
                Description = "Višestruko nagrađivani Steven Spielberg, jedan od najznačajnijih reditelja u povijesti kinematografije, nakon ekranizacija svih mogućih priča, od fantastičnih avantura do ozbiljnih ratnih filmova, napokon je snimio film o sebi." +
                             "U novoj uzbudljivoj filmskoj priči Spielberg donosi intimni pogled u svoje djetinjstvo u polu-autobiografskom filmu koji prati osjetljive godine mladića koji će otkriti potresnu porodičnu tajnu što će ga potaknuti da uroni u svijet filmova koji će mu pomoći da spozna istinu o sebi i drugima.",
                Duration = 151,
                ReleaseYear = 2022,
                Country = "SAD",
                Actors = "Michelle Williams, Gabriel LaBelle, Paul Dano",
                Director = "Steven Spielberg",
                Picture = Images.ImageList[8],
                Genres = "drama",
                IsActive = true,
            };
            var movie10 = new Movie
            {
                Id = listMovieId[9],
                Name = "KIT",
                Description = "Priča govori o povučenom učitelju engleskog, ozbiljno pretilom, koji se bori sa zdravstvenim problemima te se pokušava ponovno povezati sa svojom otuđenom sedamnaestogodišnjom kćeri. Nju i njezinu majku ostavio je prije mnogo godina, zbog veze s muškarcem." +
                             "Na ovogodišnjem Venecijanskom filmskom festivalu film je dobio sve pohvale, kako kritike, tako i publike koja ga je nagradila višeminutnim ovacijama..",
                Duration = 117,
                ReleaseYear = 2022,
                Country = "SAD",
                Actors = "Brendan Fraser, Sadie Sink, Hong Chau",
                Director = "Darren Aronofsky",
                Picture = Images.ImageList[9],
                Genres = "drama",
                IsActive = true,
            };

            modelBuilder.Entity<Movie>().HasData(
                movie1,
                movie2,
                movie3,
                movie4,
                movie5,
                movie6,
                movie7,
                movie8,
                movie9,
                movie10
            );
            var listProjectionId = new List<Guid>();
            for (int i = 0; i < 25; i++)
            {
                listProjectionId.Add(Guid.NewGuid());
            }

            List<Seat> LoadSeatInHall(Guid hallId)
            {
                var listSeatsId = new List<Guid>();
                var seatList = new List<Seat>();
                string name = "";
                for (int i = 0; i < 20; i++)
                {
                    switch (i)
                    {
                        case <= 5: name = "A" + i;
                            break;
                        case <= 10: name = "B" + (i - 5);
                            break;
                        case <= 15: name = "C" + (i - 10);
                            break;
                        case <= 20: name = "D" + (i - 15);
                            break;
                    }

                    listSeatsId.Add(Guid.NewGuid());
                    seatList.Add(new Seat
                    {
                        Id = listSeatsId[i],
                        Name = name,
                        HallId = hallId
                    });
                }

                return seatList;
            }

            var loadAllList = LoadSeatInHall(listHallId[0]);
            loadAllList.AddRange(LoadSeatInHall(listHallId[1]));
            loadAllList.AddRange(LoadSeatInHall(listHallId[2]));
            loadAllList.AddRange(LoadSeatInHall(listHallId[3]));
            loadAllList.AddRange(LoadSeatInHall(listHallId[4]));

            modelBuilder.Entity<Seat>().HasData(loadAllList);

            var listProjection = new List<Projection>() {

                new Projection
                {
                    Id = listProjectionId[0],
                    StartTime = DateTime.Now.AddDays(7),
                    EndTime = DateTime.Now.AddDays(7).AddHours(2),
                    HallId = listHallId[0],
                    MovieId = listMovieId[0],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[1],
                    StartTime = DateTime.Now.AddHours(2),
                    EndTime = DateTime.Now.AddHours(4),
                    HallId = listHallId[0],
                    MovieId = listMovieId[0],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
            new Projection
                {
                    Id = listProjectionId[2],
                    StartTime = DateTime.Now.AddHours(4),
                    EndTime = DateTime.Now.AddHours(6),
                    HallId = listHallId[0],
                    MovieId = listMovieId[0],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[3],
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddDays(1).AddHours(2),
                    HallId = listHallId[1],
                    MovieId = listMovieId[1],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[4],
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddHours(26),
                    HallId = listHallId[1],
                    MovieId = listMovieId[9],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[5],
                    StartTime = DateTime.Now.AddDays(2).AddHours(3),
                    EndTime = DateTime.Now.AddDays(2).AddHours(5),
                    HallId = listHallId[1],
                    MovieId = listMovieId[1],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[6],
                    StartTime = DateTime.Now.AddDays(6),
                    EndTime = DateTime.Now.AddDays(6).AddHours(2),
                    HallId = listHallId[2],
                    MovieId = listMovieId[2],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[7],
                    StartTime = DateTime.Now.AddDays(2).AddHours(3),
                    EndTime = DateTime.Now.AddDays(2).AddHours(5),
                    HallId = listHallId[2],
                    MovieId = listMovieId[2],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[8],
                    StartTime = DateTime.Now.AddDays(3),
                    EndTime = DateTime.Now.AddDays(3).AddHours(2),
                    HallId = listHallId[3],
                    MovieId = listMovieId[3],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[9],
                    StartTime = DateTime.Now.AddDays(3).AddHours(3),
                    EndTime = DateTime.Now.AddDays(3).AddHours(5),
                    HallId = listHallId[3],
                    MovieId = listMovieId[3],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[10],
                    StartTime = DateTime.Now.AddDays(4).AddHours(3),
                    EndTime = DateTime.Now.AddDays(4).AddHours(5),
                    HallId = listHallId[4],
                    MovieId = listMovieId[3],
                    PriceId = listPriceId[2],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[11],
                    StartTime = DateTime.Now.AddDays(4),
                    EndTime = DateTime.Now.AddDays(4).AddHours(2),
                    HallId = listHallId[4],
                    MovieId = listMovieId[3],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[12],
                    StartTime = DateTime.Now.AddDays(4).AddHours(13),
                    EndTime = DateTime.Now.AddDays(4).AddHours(15),
                    HallId = listHallId[4],
                    MovieId = listMovieId[4],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[13],
                    StartTime = DateTime.Now.AddDays(5).AddHours(10),
                    EndTime = DateTime.Now.AddDays(5).AddHours(12),
                    HallId = listHallId[4],
                    MovieId = listMovieId[4],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[14],
                    StartTime = DateTime.Now.AddDays(5).AddHours(3),
                    EndTime = DateTime.Now.AddDays(5).AddHours(5),
                    HallId = listHallId[4],
                    MovieId = listMovieId[4],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[15],
                    StartTime = DateTime.Now.AddDays(9).AddHours(10),
                    EndTime = DateTime.Now.AddDays(9).AddHours(12),
                    HallId = listHallId[3],
                    MovieId = listMovieId[5],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[16],
                    StartTime = DateTime.Now.AddDays(5).AddHours(3),
                    EndTime = DateTime.Now.AddDays(5).AddHours(5),
                    HallId = listHallId[3],
                    MovieId = listMovieId[5],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[17],
                    StartTime = DateTime.Now.AddDays(9).AddHours(10),
                    EndTime = DateTime.Now.AddDays(9).AddHours(12),
                    HallId = listHallId[2],
                    MovieId = listMovieId[6],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[18],
                    StartTime = DateTime.Now.AddDays(8).AddHours(3),
                    EndTime = DateTime.Now.AddDays(8).AddHours(5),
                    HallId = listHallId[2],
                    MovieId = listMovieId[6],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[19],
                    StartTime = DateTime.Now.AddDays(6).AddHours(10),
                    EndTime = DateTime.Now.AddDays(6).AddHours(12),
                    HallId = listHallId[1],
                    MovieId = listMovieId[7],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[20],
                    StartTime = DateTime.Now.AddDays(8).AddHours(3),
                    EndTime = DateTime.Now.AddDays(8).AddHours(5),
                    HallId = listHallId[0],
                    MovieId = listMovieId[8],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[21],
                    StartTime = DateTime.Now.AddDays(6).AddHours(10),
                    EndTime = DateTime.Now.AddDays(6).AddHours(12),
                    HallId = listHallId[0],
                    MovieId = listMovieId[8],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                 new Projection
                {
                    Id = listProjectionId[22],
                    StartTime = DateTime.Now.AddDays(7).AddHours(10),
                    EndTime = DateTime.Now.AddDays(7).AddHours(12),
                    HallId = listHallId[0],
                    MovieId = listMovieId[8],
                    PriceId = listPriceId[0],
                    StateMachine = "Active",
                    IsActive = true,
                },
                new Projection
                {
                    Id = listProjectionId[23],
                    StartTime = DateTime.Now.AddDays(2).AddHours(3),
                    EndTime = DateTime.Now.AddDays(2).AddHours(5),
                    HallId = listHallId[1],
                    MovieId = listMovieId[7],
                    PriceId = listPriceId[1],
                    StateMachine = "Active",
                    IsActive = true,
                }}; 

            modelBuilder.Entity<Projection>().HasData(listProjection);


         var listNotificationId = new List<Guid>();
         for (int i = 0; i < 3; i++)
         {
             listNotificationId.Add(Guid.NewGuid());
         }

         modelBuilder.Entity<Notification>().HasData(
             new Notification
             {
                 Id = listNotificationId[0],
                 Title = "Neradni dan povodom Dana nezavisnosti BiH.",
                 Description = "Sretan Dana nezavisnosti BiH. ",
                 Date = new DateTime(2023, 2, 28),
                 AuthorId = adminId,
                 NotificationType = "Neradni dan",
                 Picture = Images.NotificationImageList[0],
                 IsActive = true
             },
             new Notification
             {
                 Id = listNotificationId[1],
                 Title = "Neradni dan povodom Praznika Rada.",
                 Description = "Sretan 1. maj praznik rada. ",
                 Date = new DateTime(2023, 4, 30),
                 AuthorId = adminId,
                 NotificationType = "Neradni dan",
                 Picture = Images.NotificationImageList[1],
                 IsActive = true
             },
             new Notification
             {
                 Id = listNotificationId[2],
                 Title = "Novi film u ponudi.",
                 Description = "Novi film stiže u eCinema kina. ",
                 Date = DateTime.Now,
                 AuthorId = adminId,
                 NotificationType = "Ponuda",
                 Picture = Images.ImageList[2],
                 IsActive = true
             }
         );
         
         var listReservationId = new List<Guid>();
            var listReservation = new List<Reservation>();
            var listSeatReservation = new List<SeatxrefReservation>();
            var listPayment= new List<Payment>();
            var listSeatReservationId = new List<Guid>();
            var listPaymentId = new List<Guid>();
            
            Guid registeredUserId = Guid.Empty; 
            
            for (int i = 0; i < 23; i++)
            {
                listReservationId.Add(Guid.NewGuid());
                //listPaymentId.Add(Guid.NewGuid());
                registeredUserId = i % 2 == 0 ? userId : adminId;
                listReservation.Add(new Reservation
                {
                    Id = listReservationId[i],
                    UserId = registeredUserId,
                    ProjectionId = listProjectionId[i],
                    IsActive = true,
                    DateTime = listProjection[i].StartTime.Value.AddHours(-i-1),
                });
            }
            
            for (int i = 0; i < 40; i++)
            {
                listSeatReservationId.Add(Guid.NewGuid());
                listSeatReservation.Add(new SeatxrefReservation
                {
                    Id = listSeatReservationId[i],
                    SeatId = loadAllList[i].Id ,
                    ReservationId = i <23 ? listReservationId[i] : listReservationId[i-23],
                    IsTaken = true
                });
            }
            
            for (int i = 0; i < 23; i++)
            {
                //listReservationId.Add(Guid.NewGuid());
                listPaymentId.Add(Guid.NewGuid());
                registeredUserId = i % 2 == 0 ? userId : adminId;
                listPayment.Add(new Payment
                {
                    Id = listPaymentId[i],
                    StripePaymentId = "stripe payment id",
                    Created = listReservation[i].DateTime,
                    Amount = i % 2 == 0 ? 24 : 18,
                    ReservationId = listReservationId[i],
                });
            }
            
            modelBuilder.Entity<Reservation>().HasData(listReservation);
            modelBuilder.Entity<SeatxrefReservation>().HasData(listSeatReservation);
            modelBuilder.Entity<Payment>().HasData(listPayment);
            
            
        }
    }
}
