namespace SalesDatePrediction.Domain.Models
{
    public class Category : ModelBase
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
