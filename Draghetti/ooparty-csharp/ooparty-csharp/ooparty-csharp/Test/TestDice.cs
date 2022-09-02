using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooparty_csharp.Game.Dice;
using ooparty_csharp.Game.Player;
using ooparty_csharp.Game.Powerup;

namespace ooparty_csharp.Test
{
    /// <summary>
    /// Test class for Dice Model.
    /// </summary>
    [TestFixture]
    public class TestPowerups
    {
        private Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Player", "color");
        }

        [Test]
        public void TestDoubleDice()
        {
            IPowerup p = new DoubleDicePowerup();
            p.UsePowerup(player);
            Assert.AreEqual(2, player.DicesToRoll);
        }

        [Test]
        public void TestGun()
        {
            IPowerup p = new GunPowerup();
            p.UsePowerup(player);
            Assert.AreEqual(50, player.LifePoints);
        }

        [Test]
        public void TestMedikit()
        {
            IPowerup p = new DoubleDicePowerup();
            player.LoseLifePoints(80);
            p.UsePowerup(player);
            Assert.AreEqual(100, player.LifePoints);
        }

        [Test]
        public void TestMagnet()
        {
            IPowerup p = new DoubleDicePowerup();
            player.EarnCoins(30);
            p.UsePowerup(player);
            Assert.AreEqual(10, player.Coins);
        }

        static void Main()
        {

        }
    }
}
