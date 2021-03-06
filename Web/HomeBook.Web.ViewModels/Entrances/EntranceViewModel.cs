﻿namespace HomeBook.Web.ViewModels.Entrances
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class EntranceViewModel : IMapFrom<Entrance>
    {
        public int Id { get; set; }

        public string EntranceAddressSign { get; set; }

        public int ApartmentsCount { get; set; }
    }
}
