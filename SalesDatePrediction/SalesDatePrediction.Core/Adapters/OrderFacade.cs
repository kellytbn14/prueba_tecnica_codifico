using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Core.UseCases.Production;
using SalesDatePrediction.Core.UseCases.Sales;
using SalesDatePrediction.Core.Utils;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Adapters
{
    public class OrderFacade : IOrderFacade
    {
        private readonly GetCustomerOrdersUseCase getCustomerOrdersUseCase;
        private readonly GetCustomerByIdUseCase getCustomerByIdUseCase;
        private readonly GetEmployeeByIdUseCase getEmployeeByIdUseCase;
        private readonly GetShipperByIdUseCase getShipperByIdUseCase;
        private readonly GetProductByIdUseCase getProductByIdUseCase;
        private readonly CreateOrderUseCase createOrderUseCase;
        private readonly CreateOrderDetailUseCase createOrderDetailUseCase;
        private readonly GetCustomersWithOrdersUseCase customersWithOrdersUseCase;
        private readonly IMapper _mapper;

        public OrderFacade(GetCustomerOrdersUseCase getCustomerOrders, GetCustomerByIdUseCase getCustomerById,
            GetEmployeeByIdUseCase getEmployeeById, GetShipperByIdUseCase getShipperById,
            CreateOrderUseCase createOrderUseCase, GetProductByIdUseCase getProductByIdUseCase,
            CreateOrderDetailUseCase createOrderDetailUse, GetCustomersWithOrdersUseCase customersWithOrdersUseCase, IMapper mapper)
        {
            this.getCustomerOrdersUseCase = getCustomerOrders;
            this.getCustomerByIdUseCase = getCustomerById;
            this.getEmployeeByIdUseCase = getEmployeeById;
            this.getShipperByIdUseCase = getShipperById;
            this.createOrderUseCase = createOrderUseCase;
            this.getProductByIdUseCase = getProductByIdUseCase;
            this.createOrderDetailUseCase = createOrderDetailUse;
            this.customersWithOrdersUseCase = customersWithOrdersUseCase;
            _mapper = mapper;
        }

        public async Task<PageableList<CustomerOrderResponse>> GetOrdersByCustomerPaged(int CustomerId, int page, int size, string sort)
        {
            FieldValidator.ValidateRequiredFields(CustomerId);
            var customer = await getCustomerByIdUseCase.ExecuteAsync(CustomerId);

            PageableList<CustomerOrderResponse> customerOrdersResponse = getCustomerOrdersUseCase.ExecuteAsync(CustomerId, page, size, sort);
            return customerOrdersResponse;
        }

        public async Task<OrderDto> CreateOrderWithDetails(CreateOrderRequest request)
        {
            ValidateRequiredFields(request);
            var customer = await getCustomerByIdUseCase.ExecuteAsync(request.CustumerId);
            var employee = await getEmployeeByIdUseCase.ExecuteAsync(request.EmployeeId);
            var shipper = await getShipperByIdUseCase.ExecuteAsync(request.ShipperId);
            var product = await getProductByIdUseCase.ExecuteAsync(request.ProductId);

            var order = _mapper.Map<Order>(request);
            var orderSaved = await createOrderUseCase.ExecuteAsync(order);

            var orderDetail = new OrderDetail
            {
                OrderId = orderSaved.OrderId,
                ProductId = product.ProductId,
                UnitPrice = request.UnitPrice,
                Qty = request.Quantity,
                Discount = request.Discount
            };

            await createOrderDetailUseCase.ExecuteAsync(orderDetail);

            return _mapper.Map<OrderDto>(orderSaved);
        }

        private static void ValidateRequiredFields(CreateOrderRequest request)
        {
            FieldValidator.ValidateRequiredFields(request);
            FieldValidator.ValidateRequiredFields(request.CustumerId);
            FieldValidator.ValidateRequiredFields(request.EmployeeId);
            FieldValidator.ValidateRequiredFields(request.ShipperId);
            FieldValidator.ValidateRequiredFields(request.ProductId);
            FieldValidator.ValidateRequiredFields(request.ShipName);
            FieldValidator.ValidateRequiredFields(request.ShipAddress);
            FieldValidator.ValidateRequiredFields(request.ShipCity);
            FieldValidator.ValidateRequiredFields(request.ShipCountry);
            FieldValidator.ValidateRequiredFields(request.OrderDate);
            FieldValidator.ValidateRequiredFields(request.RequiredDate);
            FieldValidator.ValidateRequiredFields(request.ShippedDate);
            FieldValidator.ValidateRequiredFields(request.Freight);
            FieldValidator.ValidateRequiredFields(request.UnitPrice);
            FieldValidator.ValidateRequiredFields(request.Quantity);
            FieldValidator.ValidateRequiredFields(request.Discount);
        }
    }
}
