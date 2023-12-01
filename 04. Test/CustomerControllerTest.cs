//using Fish.Application.Usecase;
//using Fish.Data;
//using Fish.Entity.SQL;
//using Fish.Export.Controllers;
//using Kendo.Mvc.UI;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
//using Moq;
//using System;
//using System.Threading;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace CustomerControllerTest
//{
//    public class CustomerControllerTest
//    {
//        private readonly Mock<IMediator> mediator;
//        [Fact]
//        public async void CreateCustomerValidateSuccess()
//        {
//            var mediator = new Mock<IMediator>();

//            UpdateCustomerCommand command = new UpdateCustomerCommand();
//            CreateCustomerHandler handler = new CreateCustomerHandler(mediator.Object);

//            //Act
//            Unit x = await handler.Handle(command, new System.Threading.CancellationToken());

//            //Assert
//            //Do the assertion

//            //something like:
//            mediator.Verify(x => x.Publish(It.IsAny<Customer>()));
//        }

//        [Fact]
//        public async void CreateCustomerValidateFail()
//        {
//            var _validator = new CreateCustomerValidation();
//            var request = new CreateCustomerRequest();

//            request.customerAddress = "Jalan beringin";
//            request.customerCode = "C1";
//            request.customerName = "Fifi";
//            var actual = await _validator.ValidateAsync(request);

//            Assert.Equal(actual.Errors.Count, 0);
//        }
//        [Fact]
//        public async void UpdateCustomerValidateSuccess()
//        {
//            var _validator = new UpdateCustomerValidation();
//            var request = new UpdateCustomerRequest();

//            request.customerAddress = "Jalan beringin";
//            request.customerCode = "C1";
//            request.customerId = 2022;
//            request.customerName = "Fifi";
//            var actual = await _validator.ValidateAsync(request);

//            Assert.Equal(actual.Errors.Count, 0);
//        }

//        [Fact]
//        public async void UpdateCustomerValidateFail()
//        {
//            var _validator = new UpdateCustomerValidation();
//            var request = new UpdateCustomerRequest();

//            request.customerAddress = "Jalan beringin";
//            request.customerCode = "";
//            request.customerId = 0;
//            request.customerName = "";
//            var actual = await _validator.ValidateAsync(request);

//            Assert.Equal(actual.Errors.Count, 0);
//        }
//        public async void DeleteCustomerValidateSuccess()
//        {
//            var _validator = new DeleteCustomerValidation();
//            var request = new DeleteCustomerRequest();

//            request.customerId = 2002;
//            var actual = await _validator.ValidateAsync(request);

//            Assert.Equal(actual.Errors.Count, 0);
//        }
//        public async void DeleteCustomerValidateFail()
//        {
//            var _validator = new DeleteCustomerValidation();
//            var request = new DeleteCustomerRequest();

//            request.customerId = null;
//            var actual = await _validator.ValidateAsync(request);

//            Assert.Equal(actual.Errors.Count, 0);
//        }
//    }
//}
