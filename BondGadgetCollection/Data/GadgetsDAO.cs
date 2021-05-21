using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BondGadgetCollection.Data
{
    internal class GadgetsDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgets;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // performs all operations on the database.  get all,create, delete,get one, search
        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. add it to the list to return
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                        returnList.Add(gadget);
                    }
                    
                }
            }
            return returnList;
        }

        public GadgetModel FetchOne(int Id)
        {
            
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                GadgetModel gadget = new GadgetModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. add it to the list to return
                        
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                    }

                }
                return gadget;
            }
        }

        internal List<GadgetModel> SearchFor(string searchPhrase,string searchParam)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = $"SELECT * FROM dbo.Gadgets WHERE {searchParam} LIKE @searchPhrase";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchPhrase", System.Data.SqlDbType.NVarChar).Value = "%" +searchPhrase+"%";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. add it to the list to return
                        GadgetModel gadget = new GadgetModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            AppearsIn = reader.GetString(3),
                            WithThisActor = reader.GetString(4)
                        };
                        returnList.Add(gadget);
                    }

                }
            }
            return returnList;
        }

        //create new
        public int CreaeteOrUpdate(GadgetModel gadgetModel)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery;
                if (gadgetModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets values (@Name,@Description,@AppearsIn,@WithThisActor)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                }
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.NVarChar).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.NVarChar).Value = gadgetModel.WithThisActor;
                connection.Open();
                int newId = command.ExecuteNonQuery();

                return newId;
            }
        }

        // detele one
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.Gadgets WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }
        //update one


        //search for name

        //search for descriprion

    }
}