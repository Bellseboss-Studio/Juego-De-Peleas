using System.Collections.Generic;
using NSubstitute;
using ServiceLocator;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ServiceLocator
{
    public class Character
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreateCharacterWhitStats_themCreateCharacterWhitThisStats()
        {
            //arrage
            StatsBase statsBase = new StatsBase(default,default);

            //act
            CharacterBase character = new CharacterTest(statsBase);

            //assert
            Assert.IsTrue(character.StatsBase.Compare(statsBase), $"The character's stats do not correspond to the past in the constructor");
        }
        
        [Test]
        public void CreateCharacterFromStringName_ThemCreateThereCharacter()
        {
            //arrange
            var subIFactoryStats = Substitute.For<IFactoryStats>();
            var stats = new StatsBase(200,"Cybor");
            subIFactoryStats.Create(Arg.Any<string>()).Returns(stats);

            ServiceLocatorImplement.Instancie.RegisterService(subIFactoryStats);
            //Act

            StatsBase statBase = ServiceLocatorImplement.Instancie.GetService<IFactoryStats>().Create("Cybor");

            CharacterBase character = new CharacterTest(statBase);

            //assert
            Assert.AreEqual("Cybor", character.StatsBase.Name, $"the name from character is not equals, verify all stats");
            Assert.AreEqual(200, character.StatsBase.Life, "the life from character is not equals, verify all stats");
        }
    }
}
