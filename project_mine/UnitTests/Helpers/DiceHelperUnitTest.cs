﻿using System;
using System.Collections.Generic;
using System.Text;
using Mine.Models;
using Mine.Helpers;
using NUnit.Framework;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class DiceHelperUnitTest
    {
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert 
            Assert.AreEqual(0, result);
        }

        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert 
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }
    }
}
