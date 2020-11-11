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
            public const int CountryNameMaxLength = 30;

            public const int CityNameMaxLength = 30;

            public const int StreetNameMaxLength = 40;

            public const int StreetNumberMaxLength = 5;

            public const int EntranceNumberMaxLength = 4;

            public const int BuildingMaxEntrances = 10;

            public const int BuildingMaxFloors = 30;

            public const int ApartmentNumberMaxLengh = 4;

            public const int ApartmentResidentsMaxNumber = 10;

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
            public const string Title = "Title must be between 5 and 60 characters.";

            public const string Content = "Content must be between 700 and 3500 characters.";

            public const string Author = "Author name must be between 2 and 40 characters.";

            public const string Name = "Name must be between 2 and 40 characters.";

            public const string Description = "Description must be between 50 and 700 characters.";

            public const string Address = "Address must be between 5 and 100 characters.";
        }
    }
}
