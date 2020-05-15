using BankApp.Controllers;
using BankApp.Data;
using BankApp.Models;
using BankApp.Services;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Tests.Customer
{
    [TestFixture]
    class CustomerControllerTests
    {
        private CustomerController sut;
        private Mock<ICustomerService> service;

        [OneTimeSetUp]
        public void Initialize()
        {
            service = new Mock<ICustomerService>();
            sut = new CustomerController(service.Object);
        }

        [Test]
        public void ViewCustomer_should_return_correct_view()
        {
            var result = sut.ViewCustomer(1) as ViewResult;
            Assert.IsNull(result.ViewName);
        }

        [Test]
        public void ViewCustomer_should_use_correct_viewmodel()
        {
            var viewModel = new CustomerAccountInformationViewModel
            {
                Birthday = "1988-09-08",
                City = "Stockholm",
                CountryCode = "SE",
                CustomerId = 1,
                Givenname = "David",
                Gender = "male",
                Emailaddress = "david.n.stahl@gmail.com",
                Country = "Sweden",
                Streetaddress = "Oxens gata 246",
                NationalId = "19880908-0032",
                Telephonenumber = "0733940951",
                Surname = "Ståhl",
                Telephonecountrycode = "46",
                Zipcode = "13663"
            };

            service.Setup(c => c.GetCustomerInformation(1)).Returns(viewModel);
            var result = sut.ViewCustomer(1) as ViewResult;
            Assert.IsInstanceOf(typeof(CustomerAccountInformationViewModel),result.Model);
        }
        [Test]
        public void ViewModel_should_fill_a_of_customer_in_viewmodel()
        {
            var viewModel = new CustomerAccountInformationViewModel
            {
                Birthday = "1988-09-08",
                City = "Stockholm",
                CountryCode = "SE",
                CustomerId = 1,
                Givenname = "David",
                Gender = "male",
                Emailaddress = "david.n.stahl@gmail.com",
                Country = "Sweden",
                Streetaddress = "Oxens gata 246",
                NationalId = "19880908-0032",
                Telephonenumber = "0733940951",
                Surname = "Ståhl",
                Telephonecountrycode = "46",
                Zipcode = "13663"
            };

            service.Setup(c => c.GetCustomerInformation(1)).Returns(viewModel);

            var result = sut.ViewCustomer(1) as ViewResult;
            var model = result.Model as CustomerAccountInformationViewModel;
            Assert.IsTrue(model.CustomerId == 1);
        }
    }
}
