using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models
{
    public class AddtionalMeals
    {
        public int Id { get; set; }
        public string MealName { get; set; }

        [ForeignKey("Request")]

        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
