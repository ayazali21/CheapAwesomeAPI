using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CheapAwesome.Domain.Models.Request
{
    public class GetHotelRequest
    {
        [Required]
        public int destId { get; set; }
        [Required]
        public int noOfNights { get; set; }
    }
}
