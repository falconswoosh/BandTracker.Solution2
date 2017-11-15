using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using HairSalon;
using System;

namespace BandTracker.Models
{
  public class Band
  {
    private int _id;
    private string _name;
    private int _venueId;

    public Band(int id = 0, string name, int venueId)
    {
      _id = id;
      _name = name;
      _venueId = venueId;
    }

    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = this.GetId() == newBand.GetId();
        bool nameEquality = (this.GetName() == newBand.GetName());
        bool venueEquality = this.GetBandId() == newBand.GetVenueId();
        return (idEquality && nameEquality && venueEquality);
      }
    }
    public override int GetHashCode()
    {
         return this.GetName().GetHashCode();
    }

    public string GetName()
    {
        return _name;
    }
    public int GetId()
    {
        return _id;
    }
    public int GetVenueId()
    {
        return _venueId;
    }
    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO bands (name, venue_id) VALUES (@name, @venue_id);";

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = _name;
        cmd.Parameters.Add(name);

        MySqlParameter venueId = new MySqlParameter();
        venueId.ParameterName = "@venue_id";
        venueId.Value = this._venueId;
        cmd.Parameters.Add(venueId);


        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public static Band Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM bands WHERE id = (@searchId);";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int bandId = 0;
        string bandName = "";
        int bandVenueId = 0;

        while(rdr.Read())
        {
          bandId = rdr.GetInt32(0);
          bandName = rdr.GetString(1);
          bandVenueId = rdr.GetInt32(2);
        }
        Band newBand = new Band(bandName, bandVenueId, bandId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newBand;
    }
    public static List<Band> GetAll()
    {
        List<Band> allBands = new List<Band> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM bands;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int bandId = rdr.GetInt32(0);
          string bandName = rdr.GetString(1);
          int bandVenueId = rdr.GetInt32(2);
          Band newBand = new Band(bandName, bandVenueId, bandId);
          allBands.Add(newBand);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allBands;
    }
    public static void DeleteBand(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM bands WHERE id = @searchId";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM bands;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public void UpdateBand(string newName)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE bands SET name = @newName WHERE id = @searchId;";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@newName";
        name.Value = newName;
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
