using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MyConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config c = new config();
            c.name = "cabinet medecin";
            c.version = "1.0 beta";
            c.cs = "sunKnoXif2COW2enG9zZV5UY+CGc2aUNGmLPnSb1zvA5cXF4zhSXGmZteNGz0wkPAzLNqIg1bJsY5ZooaCoL79d5kFE/1x3PzkBsAiePtzMgUH8oeQpsfw==";


            StreamWriter sw = new StreamWriter("config.cfg");
            sw.Write(Newtonsoft.Json.JsonConvert.SerializeObject(c));
            sw.Close();
        }
    }
}
