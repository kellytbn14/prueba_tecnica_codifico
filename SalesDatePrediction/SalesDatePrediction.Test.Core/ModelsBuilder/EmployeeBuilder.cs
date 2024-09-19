using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Test.Core.ModelsBuilder
{
    public class EmployeeBuilder
    {
        private int _employeeId;
        private string _lastName;
        private string _firstName;
        private string _title;
        private string _titleOfCourtesy;
        private DateTime _birthdate;
        private DateTime _hiredate;
        private string _address;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;
        private string _phone;
        private int? _mgrId;

        public EmployeeBuilder SetEmployeeId(int employeeId)
        {
            _employeeId = employeeId;
            return this;
        }

        public EmployeeBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public EmployeeBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public EmployeeBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public EmployeeBuilder SetTitleOfCourtesy(string titleOfCourtesy)
        {
            _titleOfCourtesy = titleOfCourtesy;
            return this;
        }

        public EmployeeBuilder SetBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
            return this;
        }

        public EmployeeBuilder SetHiredate(DateTime hiredate)
        {
            _hiredate = hiredate;
            return this;
        }

        public EmployeeBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public EmployeeBuilder SetCity(string city)
        {
            _city = city;
            return this;
        }

        public EmployeeBuilder SetRegion(string? region)
        {
            _region = region;
            return this;
        }

        public EmployeeBuilder SetPostalCode(string? postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        public EmployeeBuilder SetCountry(string country)
        {
            _country = country;
            return this;
        }

        public EmployeeBuilder SetPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        public EmployeeBuilder SetMgrId(int? mgrId)
        {
            _mgrId = mgrId;
            return this;
        }

        public Employee Build()
        {
            return new Employee
            {
                EmployeeId = _employeeId,
                LastName = _lastName,
                FirstName = _firstName,
                Title = _title,
                TitleOfCourtesy = _titleOfCourtesy,
                Birthdate = _birthdate,
                Hiredate = _hiredate,
                Address = _address,
                City = _city,
                Region = _region,
                PostalCode = _postalCode,
                Country = _country,
                Phone = _phone,
                MGrid = _mgrId
            };
        }

        public Employee BuildDefault()
        {
            return new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                Title = "Software Engineer",
                TitleOfCourtesy = "Mr.",
                Birthdate = new DateTime(1990, 1, 1),
                Hiredate = new DateTime(2020, 1, 1),
                Address = "123 Default St",
                City = "Default City",
                Region = "Default Region",
                PostalCode = "12345",
                Country = "Default Country",
                Phone = "123-456-7890",
                MGrid = 2
            };
        }

        public List<Employee> BuildDefaultList()
        {
            var defaultEmployee = BuildDefault();
            return new List<Employee> { defaultEmployee };
        }
    }
}
