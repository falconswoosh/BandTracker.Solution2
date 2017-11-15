using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BandTracker.Models;

namespace BandTracker.Tests
{
  [TestClass]
  public class BandsTests : IDisposable
  {
        public BandsTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

       [TestMethod]
       public void GetAll_BandsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Band.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Band()
      {
        //Arrange, Act
        Band firstBand = new Band("Barry");
        Band secondBand = new Band("Wendy");

        //Assert
        Assert.AreEqual(firstBand, secondBand);
      }

      [TestMethod]
      public void Save_SavesBandToDatabase_BandList()
      {
        //Arrange
        Band testBand = new Band("Wendy");
        testBand.Save();

        //Act
        List<Band> result = Band.GetAll();
        List<Band> testList = new List<Band>{testBand};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }


     [TestMethod]
     public void Save_DatabaseAssignsIdToBand_Id()
     {
       //Arrange
       Band testBand = new Band("Barry");
       testBand.Save();

       //Act
       Band savedBand = Band.GetAll()[0];

       int result = savedBand.GetId();
       int testId = testBand.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void Find_FindsBandInDatabase_Band()
    {
      //Arrange
      Band testBand = new Band("Wendy");
      testBand.Save();

      //Act
      Band foundBand = Band.Find(testBand.GetId());

      //Assert
      Assert.AreEqual(testBand, foundBand);
    }

    public void Dispose()
    {
      Task.DeleteAll();
      Band.DeleteAll();
    }
  }
}
