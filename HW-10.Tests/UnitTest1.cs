using System;
using HW_10.Shared.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MortgageProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMortgageConstructor()
        {
            MortgageViewModel testMortgage = new MortgageViewModel(100000, 1000, 4, 30);
            Assert.AreEqual(99000, testMortgage.MortgageAmount);
            Assert.AreEqual(99000, testMortgage.TotalPrincipal);
        }

        [TestMethod]
        public void TestMonthlyPaymentCalculation()
        {
            MortgageViewModel testMortgage = new MortgageViewModel(100000, 0, 4, 30);
            Assert.AreEqual(477, Math.Round(testMortgage.MonthlyPayment, 0));
        }

        [TestMethod]
        public void TestGraphInformation()
        {
            MortgageViewModel testMortgage = new MortgageViewModel(100000, 0, 4, 30);
            Assert.AreEqual(171871, Math.Round(testMortgage.TotalInterest + testMortgage.TotalPrincipal, 0));
        }

        [TestMethod]
        public void TestRightPercentage()
        {
            MortgageViewModel testMortgage = new MortgageViewModel(100000, 0, 4, 30);
            Assert.AreEqual(.42, Math.Round(testMortgage.TotalInterest / (testMortgage.TotalInterest + testMortgage.TotalPrincipal), 2));
        }

        [TestMethod]
        public void TestErrorCondition()
        {
            var vm = new MortgageViewModel();
            vm.PurchasePrice = -10000;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], "Purchase Price must be a postiive value");
        }
    }
}
