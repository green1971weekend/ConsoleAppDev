using System;
using Xunit;
using ATM.BL;

namespace ATM_Tests2._0
{
    public class BankTest
    {
        Bank bank_instance = new Bank("BankInstance");
        Account acc = new Account("John", "Smith", 1234, 3000);
        #region OpenCloseTests

        [Fact]
        public void If_OpenAccountWentWell_ReturnTrue()
        {
            //Arrange
            bool isOkay = true;

            //Act
            try
            {
                bank_instance.OpenAccount(acc);
            }
            catch
            {
                isOkay = false;
            }

            //Assert
            Assert.True(isOkay);
        }

        [Fact]
        public void When_TryToClose_NoneExistingAccount_ReturnException()
        {
            // Arrange
            bool isException = false;
            int none_existing_id = 1234;

            //Act
            try
            {
                bank_instance.CloseAccount(none_existing_id);
            }
            catch
            {
                isException = true;
            }
            //Assert
            Assert.True(isException);
        }

        #endregion

        #region PutWithdrawTests
        [Fact]
        public void When_PutSomeMoneyToExistingAccount_IncreaseAccountCurrentSum()
        {
            //Arrange
            Account acc = new Account("John", "Smith", 1234, 3000);
            decimal expected = 4000;

            //Act
            acc.Put(1000);
            decimal actual = acc.CurrentSum;

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void When_WithdrawSomeMoneyFromExistingAccount_DecreaseAccountCurrentSum()
        {
            //Arrange
            Account acc = new Account("John", "Smith", 1234, 3000);
            decimal expected = 2000;

            //Act
            acc.Withdraw(1000);
            decimal actual = acc.CurrentSum;

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void When_WithdrawSomeMoney_MoreThanItActuallyIs_ReturnException()
        {
            //Arrange
            Account acc = new Account("John", "Smith", 1234, 3000);
            bool isException = false;

            //Act
            try
            {
                acc.Withdraw(5000);
            }
            catch
            {
                isException = true;
            }

            //Assert
            Assert.True(isException);
        }
        #endregion

        [Fact]
        public void When_PutSomeMoneyToExistingAccount_SumsAreEqual()
        {
            //Arrange
            decimal expected = 4000;
            Account acc = new Account("John", "Smith", 1234, 3000);
            bank_instance.OpenAccount(acc);

            //Act
            bank_instance.Put(1000, 1234); // Тест не проходиться из-за несуществующего аккаунта, почему аккаунта не существует?
            decimal actual = acc.CurrentSum;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
