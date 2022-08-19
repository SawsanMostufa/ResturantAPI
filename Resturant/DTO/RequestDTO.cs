using Resturant.Models;
using System;
using System.Collections.Generic;

namespace Resturant.DTO
{
    public class RequestDTO
    {


        public int Quantity { get; set; }
        public int Remaining_Quantity { get; set; }
        public DateTime orderDate { get; set; }

        public List<MealType> MealTypes { get; set; }


        public List<AddtionalMeals> Other_meals { get; set; }


        public int SubscriberId { get; set; }

    }
}
