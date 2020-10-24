﻿using Moq;
using ScooterRental.Core.Interfaces.Services;
using ScooterRental.Core.Interfaces.Usecases;
using ScooterRental.Core.Services;
using ScooterRental.Core.Usecases.StartRent;
using ScooterRental.UnitTests.Builders;
using ScooterRental.UnitTests.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScooterRental.UnitTests.Services
{
    public class RentalCompanyTests : TestBase
    {
        public RentalCompanyTests(Context context) : base(context)
        {
        }

        [Fact]
        public void StartRent_DelegatesToRentHandler()
        {
            string id = GetRandom.UniqueId();

            var handler = new Mock<IStartRentHandler>();
            handler.Setup(x=>x.Handle(id)).Verifiable();
            
            IRentalCompany company = new RentalCompany(handler.Object);
            
            company.StartRent(id);
            handler.Verify();
        }

    }
}
