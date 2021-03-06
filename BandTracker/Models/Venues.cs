using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System;

namespace BandTracker.Models
{
    public class Venue
    {
      private string _name;
      private int _id;
      private int _venueId;

      public Venue(string name, int bandId, int id = 0)
      {
        _id = id;
        _name = name;
        _bandId = bandId;
      }
      public override bool Equals(System.Object otherVenue)
      {
          if (!(otherVenue is Venue))
          {
              return false;
          }
          else
          {
              Venue newVenue = (Venue) otherVenue;
              bool idEquality = this.GetId() == newVenue.GetId();
              bool nameEquality = (this.GetName() == newVenue..GetName());
              bool venueEquality = this.GetBandId() == newBand.GetVenueId();
              return (idEquality && nameEquality && venueEquality);
          }
      }
      public override int GetHashCode()
      {
          return this.GetId().GetHashCode();
      }
      public string GetName()
      {
          return _name;
      }
      public int GetId()
      {
          return _id;
      }
      public void Save()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO venues (name) VALUES (@name);";

          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@name";
          name.Value = this._name;
          cmd.Parameters.Add(name);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }

      }
      public static List<Venue> GetAll()
      {
          List<Venue> allVenues = new List<Venue> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM venues;";
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int id = rdr.GetInt32(0);
            string name = rdr.GetString(1);
            Venue newVenue = new Venue(name, id);
            allVenues.Add(newVenue);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allVenues;
      }
      public static Venue Find(int id)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM venues WHERE id = (@searchId);";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = id;
          cmd.Parameters.Add(searchId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int Id = 0;
          string Name = "";

          while(rdr.Read())
          {
            Id = rdr.GetInt32(0);
            Name = rdr.GetString(1);
          }
          Venue newVenue = new Venue(Name, Id);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return newVenue;
      }
      public static void DeleteAll()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM venue;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }
      public List<Band> GetBands()
      {
          List<Band> allVenueBands = new List<Band> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM venues WHERE venue_id = @venue_id;";

          MySqlParameter venueId = new MySqlParameter();
          venueId.ParameterName = "@venue_id";
          venueId.Value = this._id;
          cmd.Parameters.Add(venueId);


          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int venueId = rdr.GetInt32(0);
            string venueName = rdr.GetString(1);
            int venueBandId = rdr.GetInt32(2);
            Band newBand = new Band(venueName, venueBandId, venueId);
            allVenueBands.Add(newBand);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allVenueBands;
      }
      public void UpdateVenue(string newName)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE venues SET name = @newName WHERE id = @searchId;";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = _id;
          cmd.Parameters.Add(searchId);

          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@newName";
          name.Value = name;
          cmd.Parameters.Add(name);

          cmd.ExecuteNonQuery();
          _name = newName;

          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }
    }
}
