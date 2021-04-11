using JamesBondGadgets.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JamesBondGadgets.Data
{
    internal class GadgetDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgetsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //Performs all operations on the database. 

        //Get all items in the database
        public List<GadgetModel> GetAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        //Create a new gadget object. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = sqlDataReader.GetInt32(0);
                        gadget.Name = sqlDataReader.GetString(1);
                        gadget.Description= sqlDataReader.GetString(2);
                        gadget.AppearsIn = sqlDataReader.GetString(3);
                        gadget.WithThisActor = sqlDataReader.GetString(4);

                        returnList.Add(gadget);

                    }
                }

            }
            return returnList;
        }

        

        //Get a single item in the database
        public GadgetModel GetGadget(int Id)
        {
            

            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE Id = @id";
                //associate @id with Id parameter

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                GadgetModel gadget = new GadgetModel();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        //Create a new gadget object. Add it to the list to return.
                        gadget.Id = sqlDataReader.GetInt32(0);
                        gadget.Name = sqlDataReader.GetString(1);
                        gadget.Description = sqlDataReader.GetString(2);
                        gadget.AppearsIn = sqlDataReader.GetString(3);
                        gadget.WithThisActor = sqlDataReader.GetString(4);
                    }
                }
                return gadget;
            }
            
        }

       



        //Create a single item in the database
        public int CreateOrUpdateGadget(GadgetModel gadgetModel)
        {
            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (gadgetModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor) ";
                }
                else
                {
                    //Update
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                }

                
                //Associate @id with Id parameter

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = gadgetModel.Id;
                sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100).Value = gadgetModel.Name;
                sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 100).Value = gadgetModel.Description;
                sqlCommand.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 100).Value = gadgetModel.AppearsIn;
                sqlCommand.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 100).Value = gadgetModel.WithThisActor;

                sqlConnection.Open();

                int newId = sqlCommand.ExecuteNonQuery();

                return newId;
            }

        }

        //Delete a single item from the database
        public int Delete(int id)
        {
            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.Gadgets WHERE Id = @Id";



                //Associate @id with Id parameter
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                
                sqlConnection.Open();

                int deletedId = sqlCommand.ExecuteNonQuery();

                return deletedId;
            }
        }


        //Update(Edit) a single item in the database



        //Search for name 
        public List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE NAME LIKE @searchForMe";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";


                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        //Create a new gadget object. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = sqlDataReader.GetInt32(0);
                        gadget.Name = sqlDataReader.GetString(1);
                        gadget.Description = sqlDataReader.GetString(2);
                        gadget.AppearsIn = sqlDataReader.GetString(3);
                        gadget.WithThisActor = sqlDataReader.GetString(4);

                        returnList.Add(gadget);

                    }
                }

            }
            return returnList;
        }


        //Search for description
        public List<GadgetModel> SearchForDescription(string searchPhraseDescription)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //Access the database
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE NAME LIKE @searchForMe";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhraseDescription + "%";


                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        //Create a new gadget object. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = sqlDataReader.GetInt32(0);
                        gadget.Name = sqlDataReader.GetString(1);
                        gadget.Description = sqlDataReader.GetString(2);
                        gadget.AppearsIn = sqlDataReader.GetString(3);
                        gadget.WithThisActor = sqlDataReader.GetString(4);

                        returnList.Add(gadget);

                    }
                }

            }
            return returnList;
        }
    }
}