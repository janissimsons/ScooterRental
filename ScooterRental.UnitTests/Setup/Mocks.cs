﻿using CompanyRental.UnitTests.Builders;
using Moq;
using rentEventRental.UnitTests.Builders;
using ScooterRental.Core.Entities;
using ScooterRental.Core.Interfaces.Services;
using ScooterRental.Core.Validators;
using ScooterRental.UnitTests.Builders;
using System.Collections.Generic;

namespace ScooterRental.UnitTests.Setup
{
    /// <summary>
    /// Holds re-usable mock objects for setting up unit tests.
    /// </summary>
    public class Mocks
    {
        public Company Company { get; }
        public IList<Scooter> Scooters { get; }
        public IList<RentEvent> RentEvents { get; }
        public string ExistingScooterId { get; }
        public Mock<GetScooterByIdValidator> GetScooterByIdValidator { get; internal set; }
        public Mock<ICompanyRepository> CompanyRepository { get; internal set; }

        public Mocks()
        {
            Company = CompanyBuilder.Default().Build();

            Scooters = new List<Scooter>()
            {
                ScooterBuilder.Default(Company).Build(),
                ScooterBuilder.Default(Company).Build(),
                ScooterBuilder.Default(Company).Build(),
                ScooterBuilder.Default(Company).Build(),
                ScooterBuilder.Default(Company).Build(),
            };

            RentEvents = new List<RentEvent>()
            {
                RentEventBuilder.Default(Company).Build(),
                RentEventBuilder.Default(Company).Build(),
                RentEventBuilder.Default(Company).Build()
            };

            Company.RentEvents = RentEvents;
            Company.Scooters = Scooters;

            ExistingScooterId = Scooters[0].Id;

            GetScooterByIdValidator = new Mock<GetScooterByIdValidator>();

            CompanyRepository = new Mock<ICompanyRepository>();
            CompanyRepository.Setup(x => x.GetScooters(Company.Id)).Returns(Scooters);
            CompanyRepository.Setup(x => x.GetScooterById(Company.Id, ExistingScooterId)).Returns(Scooters[0]);
        }
    }
}
