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
       public void GetAll_ClientsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Client.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Client()
      {
        //Arrange, Act
        Client firstClient = new Client("Barry");
        Client secondClient = new Client("Wendy");

        //Assert
        Assert.AreEqual(firstClient, secondClient);
      }

      [TestMethod]
      public void Save_SavesClientToDatabase_ClientList()
      {
        //Arrange
        Client testClient = new Client("Wendy");
        testClient.Save();

        //Act
        List<Client> result = Client.GetAll();
        List<Client> testList = new List<Client>{testClient};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }


     [TestMethod]
     public void Save_DatabaseAssignsIdToClient_Id()
     {
       //Arrange
       Client testClient = new Client("Barry");
       testClient.Save();

       //Act
       Client savedClient = Client.GetAll()[0];

       int result = savedClient.GetId();
       int testId = testClient.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Wendy");
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    public void Dispose()
    {
      Task.DeleteAll();
      Client.DeleteAll();
    }
  }
}
