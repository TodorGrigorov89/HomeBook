namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class ApartmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Apartments.Any())
            {
                return;
            }

            var apartments = new Apartment[]
                {
                    new Apartment
                    {
                        ApartmentNumber = "33",
                        Floor = 1,
                        NumberOfResidents = 1,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "34",
                        Floor = 1,
                        NumberOfResidents = 2,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "35",
                        Floor = 1,
                        NumberOfResidents = 6,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "36",
                        Floor = 1,
                        NumberOfResidents = 3,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "37",
                        Floor = 2,
                        NumberOfResidents = 2,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "38",
                        Floor = 2,
                        NumberOfResidents = 1,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "39",
                        Floor = 2,
                        NumberOfResidents = 1,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "40",
                        Floor = 2,
                        NumberOfResidents = 2,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "41",
                        Floor = 3,
                        NumberOfResidents = 2,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "42",
                        Floor = 3,
                        NumberOfResidents = 2,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "43",
                        Floor = 3,
                        NumberOfResidents = 1,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "44",
                        Floor = 3,
                        NumberOfResidents = 3,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "45",
                        Floor = 4,
                        NumberOfResidents = 3,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "46",
                        Floor = 4,
                        NumberOfResidents = 1,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "47",
                        Floor = 4,
                        NumberOfResidents = 2,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "48",
                        Floor = 4,
                        NumberOfResidents = 1,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "49",
                        Floor = 5,
                        NumberOfResidents = 3,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "50",
                        Floor = 5,
                        NumberOfResidents = 1,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "51",
                        Floor = 5,
                        NumberOfResidents = 2,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "52",
                        Floor = 5,
                        NumberOfResidents = 1,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "53",
                        Floor = 6,
                        NumberOfResidents = 2,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "54",
                        Floor = 6,
                        NumberOfResidents = 1,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "55",
                        Floor = 6,
                        NumberOfResidents = 2,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "56",
                        Floor = 6,
                        NumberOfResidents = 2,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "57",
                        Floor = 7,
                        NumberOfResidents = 1,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "58",
                        Floor = 7,
                        NumberOfResidents = 2,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "59",
                        Floor = 7,
                        NumberOfResidents = 3,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "60",
                        Floor = 7,
                        NumberOfResidents = 1,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "61",
                        Floor = 8,
                        NumberOfResidents = 2,
                        Area = 68.80,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "62",
                        Floor = 8,
                        NumberOfResidents = 2,
                        Area = 40.25,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "63",
                        Floor = 8,
                        NumberOfResidents = 1,
                        Area = 59.45,
                        EntranceId = 1,
                    },
                    new Apartment
                    {
                        ApartmentNumber = "64",
                        Floor = 8,
                        NumberOfResidents = 2,
                        Area = 85.80,
                        EntranceId = 1,
                    },
                };

            foreach (var apartment in apartments)
            {
                await dbContext.AddAsync(apartment);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
