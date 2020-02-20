using CheapAwesomeDomain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesomeDomain.Models.Response
{
    public class HotelListResponse
    {
        public HotelInformationModel HotelInformation { get; set; } = new HotelInformationModel();
        /// <summary>
        /// Supplier type
        /// </summary>
        public string SupplierType { get; set; }

        /// <summary>
        /// Hotel Price information
        /// </summary>
        public List<HotelPriceModel> Price { get; set; } = new List<HotelPriceModel>();
    }

    public class HotelInformationModel
    {
        /// <summary>
        /// Hotel Property ID
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Name of hotel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Geo location Id
        /// </summary>
        public long GeoId { get; set; }

        /// <summary>
        /// Hotel Star Rating
        /// </summary>
        public int Rating { get; set; }
    }
    public class HotelPriceModel
    {
        /// <summary>
        /// Board Type
        /// </summary>
        public string BoardType { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Rate Type example per night /stay
        /// </summary>
        public string RateType { get; set; }
    }

    
}
