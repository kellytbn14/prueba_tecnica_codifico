namespace SalesDatePrediction.Domain.Models
{
    public class Shipper : ModelBase
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
