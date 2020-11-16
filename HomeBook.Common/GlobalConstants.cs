namespace HomeBook.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "HomeBook";

        public const string AdministratorRoleName = "Administrator";

        public const string CloudName = "HomeBook";

        public static class AccountsSeeding
        {
            public const string Password = "123456";

            public const string AdminEmail = "admin@homebook.com";

            public const string UserEmail = "user@homebook.com";
        }

        public static class DataValidations
        {
            public const int CountryNameMinLength = 4;

            public const int CountryNameMaxLength = 40;

            public const int CityNameMinLength = 3;

            public const int CityNameMaxLength = 40;

            public const int StreetNameMinLength = 3;

            public const int StreetNameMaxLength = 50;

            public const int StreetNumberMinLength = 1;

            public const int StreetNumberMaxLength = 5;

            public const int EntranceNumberMaxLength = 4;

            public const int BuildingFullAddressMinLength = 1;

            public const int BuildingFullAddressMaxLength = 40;

            public const int BuildingMinEntrances = 1;

            public const int BuildingMaxEntrances = 20;

            public const int BuildingMinFloors = 1;

            public const int BuildingMaxFloors = 30;

            public const int EntranceAddressMinLength = 1;

            public const int EntranceAddressMaxLength = 4;

            public const int ApartmentMinNumber = 10;

            public const int ApartmentMaxNumber = 600;

            public const int ApartmentNumberMinLength = 1;

            public const int ApartmentNumberMaxLengh = 4;

            public const int ApartmentResidentsMinNumber = 0;

            public const int ApartmentResidentsMaxNumber = 10;

            public const int ApartmentFloorMinNumber = 1;

            public const int ApartmentFloorMaxNumber = 30;

            public const double ApartmentMinArea = 30.0D;

            public const double ApartmentMaxArea = 600.0D;

            public const int DescriptionMinLength = 10;

            public const int DescriptionMaxLength = 6000;

            // public const int TitleMaxLength = 60;
            //
            // public const int TitleMinLength = 5;
            //
            // public const int ContentMaxLength = 3000;
            //
            // public const int ContentMinLength = 700;
            //
            // public const int NameMinLength = 2;
            //
            // public const int DescriptionMaxLength = 800;
            //
            // public const int DescriptionMinLength = 50;
            //
            // public const int AddressMaxLength = 100;
            //
            // public const int AddressMinLength = 5;
        }

        public static class ErrorMessages
        {
            public const string CountryNameLength = "Country name must be between 4 and 40 characters.";

            public const string CountryNameAlreadyExists = "{0} already exists.";

            public const string CityNameLength = "City name must be between 3 and 40 characters.";

            public const string CityNameAlreadyExists = "{0} already exists.";

            public const string StreetNameLength = "Street name must be between 3 and 50 characters.";

            public const string StreetNameAlreadyExists = "{0} already exists.";

            public const string BuildingFullAddressLength = "Building full address must be between 1 and 40 characters.";

            public const string BuildingFullAddressAlreadyExists = "{0} already exists.";

            public const string EntranceAddressSignLength = "Entrance address sign must be between 1 and 4 characters.";

            public const string EntranceAddressSignExists = "{0} already exists.";

            public const string ApartmentNumberLength = "Apartment number must be between 1 and 4 characters.";

            public const string ApartmentNumberExists = "{0} already exists.";

            public const string UserNotFound = "User with id {0} is not found.";

            public const string ApartmentNotFound = "Apartment with id {0} is not found.";

            public const string UserApartmentExists = "Connection between user with id {0} and apartment with id {1} already exists.";

            public const string PaymentExists = "Payment with id {0} already exists.";

            public const string DescriptionLength = "Description length must be between 10 and 6000 characters.";

            public const string DocumentNotFound = "Dcoument with id {0} is not found.";

            public const string UserDocumentExists = "Connection between user with id {0} and document with id {1} already exists.";

            // public const string Title = "Title must be between 5 and 60 characters.";
            //
            // public const string Content = "Content must be between 700 and 3500 characters.";
            //
            // public const string Author = "Author name must be between 2 and 40 characters.";
            //
            // public const string Name = "Name must be between 2 and 40 characters.";
            //
            // public const string Description = "Description must be between 50 and 700 characters.";
            //
            // public const string Address = "Address must be between 5 and 100 characters.";
        }
    }
}
