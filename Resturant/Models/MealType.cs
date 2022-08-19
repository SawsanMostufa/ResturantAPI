using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models
{
    public class MealType
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
