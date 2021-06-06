using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLaba10.Model;

namespace WpfLaba10.DataBase
{
    public class DB
    {
        /*
         public string conStr = ConfigurationManager.ConnectionStrings["MyConnetionString2"].ConnectionString;//"Data Source=db4free.net; User Id = xrabell; Password=XRabell13; charset=utf8";//"SERVER=10.35.250.195;DATABASE=sql11406498;USERID=root;PASSWORD=;"; // "Database=belbusdb; Data Source=db4free.net; User Id=xrabell; Password=XRabell13; charset=utf8";//"Database=sql11406498; Data Source=sql11.freesqldatabase.com; User Id=sql11406498; Password=Tg7M28zuml; charset=utf8"; // "Database=belbusdb; Data Source=db4free.net; User Id=xrabell; Password=XRabell13; charset=utf8";// "Database=sql11402426; Data Source=sql11.freesqldatabase.com; User Id=sql11402426; Password=625TQQ4mMS; charset=utf8";//utf8_unicode_ci
         public  bool status = false;
       
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnetionString2"].ConnectionString);

        public void Open()
        {

            if (conn.State != System.Data.ConnectionState.Open)
                try
                {
                    conn.Open();
                }
                catch(Exception a)
                {
                    MessageBox.Show(a.Message +"\n"+ a.StackTrace);
                }
            if (conn.State.ToString() == "Open")
            {
                status = true;

            }
            else
            {
                MessageBox.Show("Сервер не открыт");
            }

        }
        public void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                status = false;

            }
        }*/
      
           private SqlConnection cn_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnetionString2"].ConnectionString);
        public bool status = false;

        public SqlConnection GetDBConnection()
           {
               if (cn_connection.State != ConnectionState.Open)
               {
                       cn_connection.Open();
               }
               else MessageBox.Show("Server not open");



               return cn_connection;
           }

        public void Open()
        {

            if (cn_connection.State != System.Data.ConnectionState.Open)
                try
                {
                    cn_connection.Open();
                //    MessageBox.Show("OPEN");
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с сервером");
                }
            if (cn_connection.State.ToString() == "Open")
            {
                status = true;

            }
            else
            {
                MessageBox.Show("Сервер не открыт");
            }

        }
        public void Close()
        {
            if (cn_connection.State == System.Data.ConnectionState.Open)
            {
                cn_connection.Close();
                status = false;
              //  MessageBox.Show("CLOSE");
            }
        }

        public DataTable GetDataTable(string query)
           {
               SqlConnection cn_connection = GetDBConnection();

               DataTable table = new DataTable();
               SqlDataAdapter adapter = new SqlDataAdapter(query, cn_connection);
               adapter.Fill(table);

               return table;
           }

      

      public void ExecuteSQL(string query)
           {
               SqlConnection cn_connection = GetDBConnection();

               SqlCommand cmd_Command = new SqlCommand(query, cn_connection);
               cmd_Command.ExecuteNonQuery();
           }

           public void CloseDBConnection()
           {
               if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
           }


           public string GetProduser()
           {
            try
            {
                Open();
                string query = "select * from Produser";
                string red = "";
                SqlDataReader reader;
                SqlCommand cmd_Command = new SqlCommand(query, cn_connection);
                reader = cmd_Command.ExecuteReader();
                while (reader.Read())
                {
                    red += reader[0].ToString();
                }
                reader.Close();
                Close();
                return red;
            }
            catch (Exception a) { MessageBox.Show(a.Message +"\n"+ a.StackTrace); }
            return "";
           }

        public ObservableCollection<Produser> GetProdusers()
        {
            ObservableCollection<Produser> produsers = new ObservableCollection<Produser>();
           
                string sql1 = "SELECT * from Produser;";
                SqlCommand myCommand = new SqlCommand(sql1, cn_connection);
              

            Open();
            if (status)
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                //  MessageBox.Show(reader[2].ToString() + reader[3].ToString());
                produsers.Add(new Model.Produser(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                  reader[2].ToString()));

                }
               
                reader.Close();
                Close();
                return produsers;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Produser");

                Close();
                return null;
            }
        }


        public List<Produser> GetProdusersList()
        {
            List<Produser> produsers = new List<Produser>();

            string sql1 = "SELECT * from Produser;";
            SqlCommand myCommand = new SqlCommand(sql1, cn_connection);


            Open();
            if (status)
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    //  MessageBox.Show(reader[2].ToString() + reader[3].ToString());
                    produsers.Add(new Model.Produser(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                      reader[2].ToString()));

                }

                reader.Close();
                Close();
                return produsers;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Produser");

                Close();
                return null;
            }
        }


        public ObservableCollection<Produser> GetProdusers(int pageNumberProd, int pageSize)
        {
            ObservableCollection<Produser> produsers = new ObservableCollection<Produser>();

            string sql1 = "SELECT * FROM Produser ORDER BY ID_produser OFFSET ((" + pageNumberProd + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
            SqlCommand myCommand = new SqlCommand(sql1, cn_connection);


            Open();
            if (status)
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    //  MessageBox.Show(reader[2].ToString() + reader[3].ToString());
                    produsers.Add(new Model.Produser(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                      reader[2].ToString()));

                }

                reader.Close();
                Close();
                return produsers;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Produser");

                Close();
                return null;
            }
        }





        public void CreateAirplane(int id_prod, string type, string model, int count_seats, byte[] pictureByteArray)
        {

            Open();
            if (status)
            {
                // название процедуры
                string sqlExpression = "insert_Airplanes";
                SqlCommand command = new SqlCommand(sqlExpression, cn_connection);
                    // указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@ID_produser", id_prod);
                command.Parameters.AddWithValue("@_Type", type);
                command.Parameters.AddWithValue("@Model", model);
                command.Parameters.AddWithValue("@Count_seats", count_seats);
                command.Parameters.AddWithValue("@Photo", pictureByteArray);

                    // если нам не надо возвращать id
                    var result = command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Не удалось выполнить вставку");
                Close();
            }
        }

        public void CreateProduser(string Name, string Land)
        {

            Open();
            if (status)
            {
                // название процедуры
                string sqlExpression = "insert_Produsers";
                SqlCommand command = new SqlCommand(sqlExpression, cn_connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Named", Name);
                command.Parameters.AddWithValue("@Land", Land);
             
                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Не удалось выполнить вставку");
                Close();
            }
        }
        public void DeleteProduser(int id_prod)
        {

            Open();

            SqlTransaction transaction = cn_connection.BeginTransaction();

            SqlCommand command = cn_connection.CreateCommand();

            command.Transaction = transaction;

            try
            {

                command.CommandText = "DELETE FROM Airplane WHERE ID_produser='" + id_prod + "';";
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM Produser WHERE ID_produser='" + id_prod + "';";

                command.ExecuteNonQuery();
                // подтверждаем транзакцию
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Ошибка удаления данных");
                MessageBox.Show("Ошибка  \n " + ex.Message);
                Close();
            }

            Close();
        }

        public void DeleteAirplane(int id_air)
        {

            Open();
            SqlCommand command = cn_connection.CreateCommand();

            try
            {
                // MessageBox.Show(id_air.ToString());
                command.CommandText = "DELETE FROM Airplane WHERE ID_airplane='" + id_air + "';";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления данных");
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }


        public void UpdateProdusers(List<Produser> produsers)
        {
            Open();
            foreach (var prod in produsers)
            {
                string sql1 = "UPDATE Produser SET Named ='" + prod.Named+ "', Land='"+prod.Land+"' WHERE ID_produser='" + prod.ID_produser + "';";
                try
                {
                    SqlCommand myCommand = new SqlCommand(sql1, cn_connection);
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка  \n " + ex.Message);
                }
            }
            Close();
        }

        public void UpdateAirplane(int ID_produser, string Type, string Model, int Count_seats, byte[] Array, int ID_airplane)
        {

            Open();
            if (status)
            {
                // название процедуры
                string sqlExpression = "update_Airplanes";
                SqlCommand command = new SqlCommand(sqlExpression, cn_connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_produser", ID_produser);
                command.Parameters.AddWithValue("@Type", Type);
                command.Parameters.AddWithValue("@Model", Model);
                command.Parameters.AddWithValue("@Count_seats", Count_seats);
                command.Parameters.AddWithValue("@Array", Array);
                command.Parameters.AddWithValue("@ID_airplane", ID_airplane);

                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Не удалось выполнить вставку");
                Close();
            }
        }


        public void UpdateAirplane(int ID_produser, string Type, string Model, int Count_seats, int ID_airplane)
        {

            Open();
            if (status)
            {
                // название процедуры
                string sqlExpression = "update_AirplanesNoCHangePicture";
                SqlCommand command = new SqlCommand(sqlExpression, cn_connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_produser", ID_produser);
                command.Parameters.AddWithValue("@Type", Type);
                command.Parameters.AddWithValue("@Model", Model);
                command.Parameters.AddWithValue("@Count_seats", Count_seats);
                command.Parameters.AddWithValue("@ID_airplane", ID_airplane);

                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Не удалось выполнить вставку");
                Close();
            }
        }


             public bool DataBaseIdNull()
            {
            Open();
            string sql = "if db_id('AirplaneDataBase') is null select 1 else select 0";
            bool b = false;
            SqlCommand command = new SqlCommand(sql,cn_connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                b = Convert.ToBoolean(reader[0]);
            }
            // если нам не надо возвращать id
            reader.Close();
            Close();
            return b;
             }
                /*  string sql1 = "UPDATE Airplane SET ID_produser ='" + ID_produser+ "', _Type='" + Type + "', Model='"+Model+"', "+
                  "Count_seats='"+Count_seats+"', Photo="+Array+" WHERE ID_airplane='" + ID_airplane + "';";
                  try
                  {
                      SqlCommand myCommand = new SqlCommand(sql1, cn_connection);
                      myCommand.ExecuteNonQuery();

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("Ошибка  \n " + ex.Message);
                  }*/


        /*  public ObservableCollection<Airplane> GetAirplanes()
          {
              ObservableCollection<Airplane> produsers = new ObservableCollection<Airplane>();

              string sql1 = "SELECT * from Airplane;";
              SqlCommand myCommand = new SqlCommand(sql1, cn_connection);
              SqlDataReader reader;

              Open();
              if (status)
              {
                  reader = myCommand.ExecuteReader();

                  while (reader.Read())
                  {
                      //  MessageBox.Show(reader[2].ToString() + reader[3].ToString());
                      produsers.Add(new Airplane(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                        reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToDateTime(reader[5])),(Picture)reader[6]);
                  }

                  reader.Close();
                  Close();
                  return produsers;
              }
              else
              {
                  MessageBox.Show("Не удалось получить таблицу Produser");
                  Close();
                  return null;
              }

          }*/

        public List<Airplane> GetAirplanes()
        {
            List<Airplane> adverts = new List<Airplane>();
            try
            {
                Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"Select * From Airplane";


                SqlDataReader info = command.ExecuteReader();
                object image = null;

                while (info.Read())
                {
                    image = info["Photo"];
                    adverts.Add(
                        new Airplane(
                             Convert.ToInt32(info[0]),
                             Convert.ToInt32(info[1]),
                             Convert.ToString(info[2]),
                             Convert.ToString(info[3]),
                             Convert.ToInt32(info[4]),
                             new Picture() { PictureByteArray = (byte[])image }
                        )
                    );;
                }
                
                Parallel.ForEach(adverts, el => {
                    el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
                    el.ImageSource.Freeze();
                });
                info.Close();
                Close();
                return adverts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message +"\n"+e.StackTrace);
                return adverts;
            }
        }


        public ObservableCollection<Airplane> GetAirplanes(int pageNumberAirp, int pageSize)
        {
            ObservableCollection<Airplane> adverts = new ObservableCollection<Airplane>();
            try
            {
                Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = "SELECT * FROM Airplane ORDER BY ID_airplane OFFSET ((" + pageNumberAirp + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";


                SqlDataReader info = command.ExecuteReader();
                object image = null;

                while (info.Read())
                {
                    image = info["Photo"];
                    adverts.Add(
                        new Airplane(
                             Convert.ToInt32(info[0]),
                             Convert.ToInt32(info[1]),
                             Convert.ToString(info[2]),
                             Convert.ToString(info[3]),
                             Convert.ToInt32(info[4]),
                             new Picture() { PictureByteArray = (byte[])image }
                        )
                    ); ;
                }

                Parallel.ForEach(adverts, el => {
                    el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
                    el.ImageSource.Freeze();
                });
                info.Close();
                Close();
                return adverts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
                return adverts;
            }
        }

        /*
         * 
        public static void CreateAdvert(string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {

            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"INSERT INTO Advert ([Advert_FullName], [Advert_ShortName], [Advert_AnimalAge], [Advert_AnimalWeight], [Advert_KindOfAnimal], [Advert_Description], [Advert_Image], [Advert_CreationDate]) 
                                        VALUES (@Advert_FullName,@Advert_ShortName,@Advert_AnimalAge, @Advert_AnimalWeight, @Advert_KindOfAnimal, @Advert_Description, @Advert_Image, GETDATE())";

                command.Parameters.Add("@Advert_FullName", SqlDbType.VarChar, 40);
                command.Parameters.Add("@Advert_ShortName", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_AnimalAge", SqlDbType.Int);
                command.Parameters.Add("@Advert_AnimalWeight", SqlDbType.Float);
                command.Parameters.Add("@Advert_KindOfAnimal", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_Description", SqlDbType.VarChar, 2000);
                command.Parameters.Add("@Advert_Image", SqlDbType.VarBinary);

                command.Parameters["@Advert_FullName"].Value = fullName;
                command.Parameters["@Advert_ShortName"].Value = shortName;
                command.Parameters["@Advert_AnimalAge"].Value = animalAge;
                command.Parameters["@Advert_AnimalWeight"].Value = animalWeight;
                command.Parameters["@Advert_KindOfAnimal"].Value = kindOfAnimal;
                command.Parameters["@Advert_Description"].Value = description;
                command.Parameters["@Advert_Image"].Value = pictureByteArray;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void EditAdvert(int id, string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {
            cn_connection = GetDBConnection();
            SqlTransaction sqlTransaction = null;
            try
            {
                SqlCommand command = new SqlCommand();
                sqlTransaction = cn_connection.BeginTransaction();
                command.Connection = cn_connection;
                command.Transaction = sqlTransaction;
                command.CommandText = @"UPDATE Advert SET Advert_FullName = @Advert_FullName, Advert_ShortName = @Advert_ShortName, 
                                        Advert_AnimalAge = @Advert_AnimalAge, Advert_AnimalWeight = @Advert_AnimalWeight, Advert_KindOfAnimal = @Advert_KindOfAnimal, 
                                        Advert_Description = @Advert_Description, Advert_Image = @Advert_Image WHERE Advert_ID = @Advert_ID";

                command.Parameters.Add("@Advert_ID", SqlDbType.Int);
                command.Parameters.Add("@Advert_FullName", SqlDbType.VarChar, 40);
                command.Parameters.Add("@Advert_ShortName", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_AnimalAge", SqlDbType.Int);
                command.Parameters.Add("@Advert_AnimalWeight", SqlDbType.Float);
                command.Parameters.Add("@Advert_KindOfAnimal", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_Description", SqlDbType.VarChar, 2000);
                command.Parameters.Add("@Advert_Image", SqlDbType.VarBinary);

                command.Parameters["@Advert_ID"].Value = id;
                command.Parameters["@Advert_FullName"].Value = fullName;
                command.Parameters["@Advert_ShortName"].Value = shortName;
                command.Parameters["@Advert_AnimalAge"].Value = animalAge;
                command.Parameters["@Advert_AnimalWeight"].Value = animalWeight;
                command.Parameters["@Advert_KindOfAnimal"].Value = kindOfAnimal;
                command.Parameters["@Advert_Description"].Value = description;
                command.Parameters["@Advert_Image"].Value = pictureByteArray;

                command.ExecuteNonQuery();
                if (shortName.Length < 5)
                {
                    MessageBox.Show("ShortName должно быть >=5 символам! Сработала транзакция");
                    sqlTransaction.Rollback();
                }
                else sqlTransaction.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    sqlTransaction.Rollback();
                    MessageBox.Show(e.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public static void DeleteAdvert(int id)
        {
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"DELETE Advert WHERE Advert_ID = @Advert_ID";
                command.Parameters.Add("@Advert_ID", SqlDbType.Int);
                command.Parameters["@Advert_ID"].Value = id;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static List<Advert> GetAdverts()
        {
            List<Advert> adverts = new List<Advert>();
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"Select Advert_ID, Advert_FullName, Advert_ShortName, Advert_AnimalAge, Advert_AnimalWeight, Advert_KindOfAnimal, Advert_Description, Advert_Image, Advert_Creator, Advert_CreationDate From Advert";


                SqlDataReader info = command.ExecuteReader();
                object advertCreator = null, id = null, fullName = null, shortName = null, animalAge = null, animalWeight = null, kindOfAnimal = null, description = null, image = null, creationDate = null;

                while (info.Read())
                {
                    id = info["Advert_ID"];
                    fullName = info["Advert_FullName"];
                    shortName = info["Advert_ShortName"];
                    animalAge = info["Advert_AnimalAge"];
                    animalWeight = info["Advert_AnimalWeight"];
                    kindOfAnimal = info["Advert_KindOfAnimal"];
                    image = info["Advert_Image"];
                    description = info["Advert_Description"];
                    advertCreator = info["Advert_Creator"];
                    creationDate = info["Advert_CreationDate"];
                    adverts.Add(
                        new Advert()
                        {
                            ID = Convert.ToInt32(id),
                            FullName = Convert.ToString(fullName),
                            ShortName = Convert.ToString(shortName),
                            AnimalAge = Convert.ToInt32(animalAge),
                            AnimalWeight = Convert.ToDecimal(animalWeight),
                            KindOfAnimal = Convert.ToString(kindOfAnimal),
                            Image = new Picture() { PictureByteArray = (byte[])image },
                            Description = Convert.ToString(description),
                            AdvertCreator = Convert.ToString(advertCreator),
                            CreationDate = Convert.ToString(creationDate)
                        }
                    );
                }
                Parallel.ForEach(adverts, el => {
                    el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
                    el.ImageSource.Freeze();
                });
                return adverts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return adverts;
            }
        }*/

    }
}
