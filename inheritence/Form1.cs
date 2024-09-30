using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inheritence
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        public Form1()
        {

            InitializeComponent();
            db = new databaseHandler();
            db.readAll();
            car oneCar = new car();
            oneCar.color = "piros";
            oneCar.power = 500;
            oneCar.make = "VW";
            oneCar.model = "Bober";
            oneCar.year = 1973;
            db.addOne(oneCar);
        }
    }
}
