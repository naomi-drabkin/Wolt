using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt_server;
using Wolt_server.Controllers;

namespace XunitTests
{
    public class EventsControllerTest
    {

        private readonly CustomerController _contextCustomer;
        private readonly OrdersController _contextOrder;

        public EventsControllerTest()
        {
            FakeContext f = new FakeContext();
            _contextCustomer = new CustomerController(f);
            _contextOrder = new OrdersController(f);
        }

        [Fact]
        public void GetOrders_ReturnsOk()
        {


            //Act
            var result = _contextCustomer.GetOrders();
            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetByID_ReturnsOk()
        {
            //Arrange
            var id = "2";

            //Act
            var result = _contextOrder.GetByID(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetByID_Returnsnull()
        {
            //Arrange
            var id = "1";

            //Act
            var result = _contextOrder.GetByID(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
