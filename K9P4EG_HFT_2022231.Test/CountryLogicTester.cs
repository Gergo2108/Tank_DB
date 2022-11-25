using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K9P4EG_HFT_2022231.Test
{
    class CountryLogicTester
    {

        [TestFixture]
        public class TankogicTester
        {
            CountryLogic CountryLogic;
            Mock<Repo<Country>> mock;
            Country FakeCountry;
            Tank tank1;
            Tank tank2;

            [SetUp]

            public void Init()
            {
                mock = new Mock<Repo<Country>>();
                FakeCountry = new Country();
                FakeCountry.Id = 1;
                FakeCountry.Name = "Hungary";
                
                tank1 = new Tank()
                {
                    Id = 1,
                    Model = "BTR",
                    GunSize = 65,
                    Weight = 8,
                    Country = FakeCountry
                };

                tank2 = new Tank()
                {
                    Id = 2,
                    Model = "BTR-2",
                    GunSize = 88,
                    Weight = 10,
                    Country = FakeCountry
                };

                var countries = new List<Country>
            {
                FakeCountry
            }.AsQueryable();

                mock.Setup(t => t.ReadAll())
                    .Returns(countries);
                CountryLogic = new CountryLogic(mock.Object);

            }
            [Test]
            public void StrongerCountryTester()
            {
                var c = CountryLogic.StrongerCountry();

                mock.Verify(mock => mock.ReadAll(), Times.Once);
                Assert.That(c.Name == "Hungary");
            }

            [Test]
            public void CountryCreateTester()
            {
                Country S = new Country()
                {
                    Name = "Spain",
                    Id = 2,

                };
                CountryLogic.Create(S);
                mock.Verify(mock => mock.Create(S), Times.Once);
               
            }
        }
        
    }
}
