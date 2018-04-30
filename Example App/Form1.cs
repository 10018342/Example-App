using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_App
{
    public partial class Form1 : Form
    {
        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orderline;Integrated Security=True;";
        SqlConnection con = new SqlConnection(ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInitialise_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("CREATE TABLE Customer(CustomerID INT PRIMARY KEY,Name VARCHAR(40),Address VARCHAR(255)); ", con);

            SqlCommand cmd2 = new SqlCommand("CREATE TABLE Product(ProductID INT PRIMARY KEY,Price INT,Description VARCHAR(255));", con);

            SqlCommand cmd3 = new SqlCommand("CREATE TABLE Orders(OrderID INT PRIMARY KEY,CustomerID INT,OrderDate DATE,FOREIGN KEY(CustomerID) " +
                "REFERENCES Customer(CustomerID));", con);

            SqlCommand cmd4 = new SqlCommand("CREATE TABLE OrderLine(ProductID INT,OrderID INT,Quantity INT,PRIMARY KEY(ProductID,OrderID)," +
                "FOREIGN KEY(ProductID) REFERENCES Product(ProductID),FOREIGN KEY(OrderID) REFERENCES Orders(OrderID));", con);

            using (con)
            {
                con.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
            }
            MessageBox.Show("Tables Created");
        }
    }
}
