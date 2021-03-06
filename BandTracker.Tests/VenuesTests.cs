using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BandTracker.Models;

namespace BandTracker.Tests
{
  [TestClass]
  public class VenueTests : IDisposable
  {
        public VenueTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
        }

       [TestMethod]
       public void GetAll_VenuesEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Venue.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Venue()
      {
        //Arrange, Act
        Venue firstVenue = new Venue("Barry");
        Venue secondVenue = new Venue("Wendy");

        //Assert
        Assert.AreEqual(firstVenue, secondVenue);
      }

      [TestMethod]
      public void Save_SavesVenueToDatabase_VenueList()
      {
        //Arrange
        Venue testVenue = new Venue("Wendy");
        testVenue.Save();

        //Act
        List<Venue> result = Venue.GetAll();
        List<Venue> testList = new List<Venue>{testVenue};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }


     [TestMethod]
     public void Save_DatabaseAssignsIdToVenue_Id()
     {
       //Arrange
       Venue testVenue = new Venue("Barry");
       testVenue.Save();

       //Act
       Venue savedVenue = Venue.GetAll()[0];

       int result = savedVenue.GetId();
       int testId = testVenue.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void Find_FindsVenueInDatabase_Venue()
    {
      //Arrange
      Venue testVenue = new Venue("Wendy");
      testVenue.Save();

      //Act
      Venue foundVenue = Venue.Find(testVenue.GetId());

      //Assert
      Assert.AreEqual(testVenue, foundVenue);
    }

    public void Dispose()
    {
      Task.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
