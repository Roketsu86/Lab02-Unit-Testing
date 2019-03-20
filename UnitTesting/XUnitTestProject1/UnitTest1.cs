using System;
using Xunit;
using UnitTesting;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2000, 100, "1900")]
        [InlineData(100, 7, "93")]
        [InlineData(100.52, 13.73, "86.79")]
        [InlineData(732.85, 350.26, "382.59")]
        public void CanWithdrawMoney(decimal balance, decimal withdrawal, string expectedNewBalance)
        {
            // Act
            string newBalance = Program.withdrawMoney(balance, withdrawal);

            // Asert
            Assert.Equal(expectedNewBalance, newBalance);
        }

        [Theory]
        [InlineData(50, 100, "Cannot withdraw.  Your balance cannot be negative.")]
        [InlineData(0, 5, "Cannot withdraw.  Your balance cannot be negative.")]
        [InlineData(6530, 96735.15, "Cannot withdraw.  Your balance cannot be negative.")]
        public void CannotWithdrawIfYouWouldGoNegative(decimal balance, decimal withdrawal, string expectedException)
        {
            // Act
            string exception = Program.withdrawMoney(balance, withdrawal);

            // Asert
            Assert.Equal(expectedException, exception);
        }

        [Theory]
        [InlineData(500, -9451213875.23, "Cannot withdraw a negative amount.")]
        [InlineData(500, -1, "Cannot withdraw a negative amount.")]
        [InlineData(500, -100, "Cannot withdraw a negative amount.")]
        public void CannotWithdrawNegativeAmount(decimal balance, decimal withdrawal, string expectedException)
        {
            // Act
            string exception = Program.withdrawMoney(balance, withdrawal);

            // Asert
            Assert.Equal(expectedException, exception);
        }
    }
}
