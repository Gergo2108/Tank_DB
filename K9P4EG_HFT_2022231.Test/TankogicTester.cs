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

    [TestFixture]
    public class TankogicTester
    {
        TankLogic TankLogic;
        Mock<Repo<Tank>> mock;
        Country FakeCountry;
        Tank tank1;
        Tank tank2;

        [SetUp]

        public void Init()
        {
            mock = new Mock<Repo<Tank>>();
            FakeCountry = new Country();
            FakeCountry.Id = 1;
            FakeCountry.Name = "Hungary";

            tank1 = new Tank()
            {
                Model = "BTR",
                GunSize = 65,
                Weight = 8,
                Country = FakeCountry
            };

            tank2 = new Tank()
            {
                Model = "BTR-2",
                GunSize = 88,
                Weight = 10,
                Country = FakeCountry
            };

            var tanks = new List<Tank>
            {
                tank1, tank2
            }.AsQueryable();

            mock.Setup(t => t.ReadAll())
                .Returns(tanks);
            TankLogic = new TankLogic(mock.Object);

        }

        [Test]

        public void GetTanksByGunRangeTester()
        {
            int min = 70;
            int max = 100;

            var tanks = TankLogic.GetTanksByGunRange(min, max);

            mock.Verify(mock => mock.ReadAll(), Times.Once);
            Assert.That(tanks, Has.Exactly(1).Items);
         
        }

        [Test]

        public void BigestGunTester()
        {
            var gun = TankLogic.BigestGun();
            mock.Verify(mock => mock.ReadAll(), Times.Once);
            Assert.That(gun.Equals(88));
        }

    }
}
