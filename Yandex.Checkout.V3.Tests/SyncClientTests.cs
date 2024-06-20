﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Yandex.Checkout.V3.Tests
{
    [TestClass]
    public class SyncClientTests
    {
        // ReSharper disable StringLiteralTypo
        private readonly Client _clientInvalidPasswordFormat = 
            new("fake shop id", "fake key");
        private readonly Client _clientInvalidLoginFormat = 
            new("fake shop id", "test_As0OONRn1SsvFr0IVlxULxst5DBIoWi_tyVaezSRTEI");
        private readonly Client _clientIncorrectLoginOrPassword = 
            new("501156", "test_As0OONRn1SsvFr0IVlxULxst5DBIoWi_tyVaezSRAAA");
        // ReSharper restore StringLiteralTypo

        private readonly NewPayment _newPayment = new()
        {
            Amount = new Amount { Value = 10, Currency = "RUB" },
            Confirmation = new Confirmation { Type = ConfirmationType.Redirect }
        };

        [TestMethod]
        public void UnauthorizedInvalidPasswordFormatThrowsException()
        {
            object Action() => _clientInvalidPasswordFormat.CreatePayment(_newPayment);
            var ex = Assert.ThrowsException<YandexCheckoutException>(Action);
            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
            Assert.AreEqual("Incorrect password format in the Authorization header. Use Secret key issued in Merchant Profile as the password", ex.Error.Description);
        }

        [TestMethod]
        public void UnauthorizedInvalidKeyFormatThrowsException()
        {
            object Action() => _clientInvalidLoginFormat.CreatePayment(_newPayment);
            var ex = Assert.ThrowsException<YandexCheckoutException>(Action);
            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
            Assert.AreEqual("Login has illegal format", ex.Error.Description);
        }

        [TestMethod]
        public void UnauthorizedIncorrectLoginOrPasswordThrowsException()
        {
            object Action() => _clientIncorrectLoginOrPassword.CreatePayment(_newPayment);
            var ex = Assert.ThrowsException<YandexCheckoutException>(Action);
            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
            Assert.AreEqual("Error in shopId or secret key. Check their validity. You can reissue the key in the Merchant Profile", ex.Message);
        }
    }
}
