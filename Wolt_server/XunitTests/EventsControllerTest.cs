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
        [Fact]
        public void GetOrders_ReturnsOk()
        {


            //Act
            var controller = new CustomerController();
            var result = controller.GetOrders();
            //Assert

            Assert.IsType<List<Customer>>(result);
        }

        [Fact]
        public void GetByID_ReturnsOk()
        {
            //Arrange
            var id = "1";

            //Act
            var controller = new OrdersController();
            var result = controller.GetByID(id);

            //Assert
            Assert.IsType<Orders>(result);
        }

        [Fact]
        public void GetByID_Returnsnull()
        {
            //Arrange
            var id = "2";

            //Act
            var controller = new OrdersController();
            var result = controller.GetByID(id);

            //Assert
            Assert.Null(result);
        }
    }
}
