﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkLicenseUsageTests.cs" company="WildGums">
//   Copyright (c) 2008 - 2014 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LicenseManager.Tests.Client.Models
{
    using System;
    using Catel;
    using NUnit.Framework;

    public class NetworkLicenseUsageTests
    {
        [TestFixture]
        public class TheParsing
        {
            [Test]
            public void TestParsing()
            {
                var dateTime = DateTime.Now;

                var usage = new NetworkLicenseUsage("computerId", "ip", "userName", "licenseSignature", dateTime);

                Assert.AreEqual("computerId", usage.ComputerId);
                Assert.AreEqual("ip", usage.Ip);
                Assert.AreEqual("licenseSignature", usage.LicenseSignature);
                Assert.AreEqual("userName", usage.UserName);
                //Assert.IsTrue(ObjectHelper.AreEqual(dateTime, usage.StartDateTime));

                var networkString = usage.ToNetworkMessage();
                var usage2 = NetworkLicenseUsage.Parse(networkString);

                Assert.AreEqual(usage.ComputerId, usage2.ComputerId);
                Assert.AreEqual(usage.Ip, usage2.Ip);
                Assert.AreEqual(usage.LicenseSignature, usage2.LicenseSignature);
                Assert.AreEqual(usage.UserName, usage2.UserName);
                //Assert.IsTrue(ObjectHelper.AreEqual(usage.StartDateTime, usage2.StartDateTime));
            }
        }
    }
}
