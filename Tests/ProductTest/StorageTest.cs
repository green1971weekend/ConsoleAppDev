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
            int actual = phone.GetAmount();

            // Assert
            int expected = 0;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Phone_WhenSetZeroAmount_Return_ZeroAmount()
        {
            // Arrange
            int zero_amount = 0;
            Phone phone = new Phone("Company", "Model", zero_amount);

            // Act
            int actual = phone.GetAmount();

            // Assert
            int expected = 0;
            Assert.Equal(expected, actual);
        }
    }
    
}
