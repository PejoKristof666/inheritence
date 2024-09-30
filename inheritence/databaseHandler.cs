using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace inheritence
{
    public class databaseHandler
    {
        MySqlConnection connection;
        string tableName = "cars";
        public databaseHandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbName = "Trabant";

            string connectionString = $"user={username};password={password};server={host};database={dbName}";
            connection = new MySqlConnection(connectionString);
        }
        public void addOne(car oneCar)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} (`id`, `make`, `model`, `color`, `year`, `power`) VALUES ('{oneCar.id}','{oneCar.make}','{oneCar.model}','{oneCar.color}','{oneCar.year}','{oneCar.power}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Sikerült hozzáadni");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void readAll()
        {

            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string make = read.GetString(read.GetOrdinal("make"));
                    string model = read.GetString(read.GetOrdinal("model"));
                    string color = read.GetString(read.GetOrdinal("color"));
                    int year = read.GetInt32(read.GetOrdinal("year"));
                    int power = read.GetInt32(read.GetOrdinal("power"));
                    car oneCar = new car();
                    oneCar.id = id;
                    oneCar.make = make;
                    oneCar.model = model;
                    oneCar.color = color;
                    oneCar.year = year;
                    oneCar.power = power;
                    car.cars.Add(oneCar);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Siker");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void DeleteOne(car oneCar)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName} WHERE ID = {oneCar.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Bober kurwa");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
        }
    }
}
