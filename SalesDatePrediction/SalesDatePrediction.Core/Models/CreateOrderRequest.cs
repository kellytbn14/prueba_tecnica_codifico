namespace SalesDatePrediction.Core.Models
{
    public class CreateOrderRequest
    {
        public int CustumerId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public int ProductId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
