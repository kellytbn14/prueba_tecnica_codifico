using SalesDatePrediction.Core.Exceptions;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetCustomerByIdUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> ExecuteAsync(int id)
        {
            var customer = await customerRepository.FindAsync(id).ConfigureAwait(false);
            if (customer is null)
            {
                throw new DataNotFoundException("Customer does not exist");
            }
            return customer;
        }
    }
}
