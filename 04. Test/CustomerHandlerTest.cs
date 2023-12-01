using Fish.Application.Model;
using Fish.Application.Usecase;
using Fish.Data;
using Fish.Entity.SQL;
using Fish.Export.Controllers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerHandlerTest
{
    public class CustomerHandlerTest : BaseController
    {
        private readonly CancellationToken token;
        public DataContext context { get; }
        //public DataContext context { get; }

        public CustomerHandlerTest() {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer($@"server=localhost;database=Fish;user id=sa;password=P@ssw0rd;TrustServerCertificate=True;");
            context = new DataContext(optionsBuilder.Options);
        }

        [Fact]
        public async void FindCustomer()
        {
            FindCustomerRequest request = new FindCustomerRequest();
            FindCustomerHandler hander = new FindCustomerHandler( context );
            var data = hander.Handle(request, token);
            Assert.NotNull(data);
        }
        [Fact]
        public async void CreateCustomer()
        {
            CreateCustomerRequest request = new CreateCustomerRequest();
            request.customerName = "rosa black pink";
            request.customerCode = "C8";
            request.customerAddress = "Jalan Myongdong";
            CreateCustomerHandler hander = new CreateCustomerHandler(context);
            var data = hander.Handle(request, token);
            Assert.NotNull(data);
        }
        [Fact]
        public async void UpdateCustomer()
        {
            UpdateCustomerRequest request = new UpdateCustomerRequest();
            request.customerCode = "C9";
            request.customerId = 2008;
            request.customerName = "Jenie";
            request.customerAddress = "Jalan kedondong";
            UpdateCustomerHandler hander = new UpdateCustomerHandler(context);
            var data = hander.Handle(request, token);
            Assert.NotNull(data);
        }
    }
}