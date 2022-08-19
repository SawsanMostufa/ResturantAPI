using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Resturant.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        
        public string PhoneNumber { get; set; }
       
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfMail { get; set; }
        public int RemainingQuantity { get; set; }
        
        [JsonIgnore]
        public virtual List<Request> Requests { get; set; }
    }
}
