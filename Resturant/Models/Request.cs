using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Remaining_Quantity { get; set; }
        public DateTime orderDate { get; set; }

        
        public List<MealType> MealTypes { get; set; }

        
        public List<AddtionalMeals> Other_meals { get; set; }

        [ForeignKey("Subscriber")]
        
        public int SubscriberId { get; set; }

        [JsonIgnore]
        public virtual Subscriber Subscriber { get; set; }
    }
}
