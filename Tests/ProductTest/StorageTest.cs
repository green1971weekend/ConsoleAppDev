using System;
using Xunit;
using ShopProgram;
using ShopLibrary;

namespace Shop_Simulator_Test
{
    public class StorageTest
    {
        [Fact]
        public void Phone_WhenSetNegativeAmount_Return_ZeroAmount()
        {
            // Arrange
            int negative_amount = -1;
            Phone phone = new Phone("Company", "Model", negative_amount);

            // Act
            int actual_amount = phone.GetAmount();

            // Assert
            int expected_amount = 0;
            Assert.Equal(expected_amount, actual_amount);
        }


        [Fact]
        public void Phone_WhenSetZeroAmount_Return_ZeroAmount()
        {
            // Arrange
            int zero_amount = 0;
            Phone phone = new Phone("Company", "Model", zero_amount);

            // Act
            int actual_amount = phone.GetAmount();

            // Assert
            int expectedAmount = 0;
            Assert.Equal(expectedAmount, actual_amount);
        }
    }
    
}
