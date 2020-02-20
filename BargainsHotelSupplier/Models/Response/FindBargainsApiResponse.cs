using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BargainHotelSupplier.Models.BargainSupplierModel.Response
{
    public  class FindBargainsApiResponse
    {
        public Hotel Hotel { get; set; }

        public List<Rate> Rates { get; set; }
    }

    public  class Hotel
    {
        public int PropertyId { get; set; }

        public string Name { get; set; }

        public long GeoId { get; set; }

        public int Rating { get; set; }
    }

    public  class Rate
    {
        public string RateType { get; set; }

        public string BoardType { get; set; }

        public decimal Value { get; set; }
    }


    public enum RateType { PerNight, Stay };

}
