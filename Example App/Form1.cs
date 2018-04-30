using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
        }
    }
}
