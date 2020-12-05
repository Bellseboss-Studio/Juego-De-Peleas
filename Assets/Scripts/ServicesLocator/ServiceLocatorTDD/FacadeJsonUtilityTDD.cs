using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLocator;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FacadeJsonUtilityTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SearchJsonStrong_themObjectCastSuccess()
        {
            //arrange
            IFacadeJsonUtility jsonUtility = new FacadeJsonUtility();
            StatsBaseJson statBase = new StatsBaseJson();
            statBase.Name = "nombre";
            statBase.Life = 20;
            string jsonString = jsonUtility.ToJson(statBase);
            
            //Act
            StatsBase result = new StatsBase(jsonUtility.FromJson<StatsBaseJson>(jsonString));

            //assert
            Assert.AreEqual(statBase.Name, result.Name, "The conversion is not work");
            Assert.AreEqual(statBase.Life, result.Life, "The conversion is not work");
        }
        
    }
}
