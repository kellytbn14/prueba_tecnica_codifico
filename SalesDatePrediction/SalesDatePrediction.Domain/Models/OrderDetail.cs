namespace SalesDatePrediction.Domain.Models
{
    public class OrderDetail : ModelBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
