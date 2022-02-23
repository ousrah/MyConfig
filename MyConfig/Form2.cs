using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace MyConfig
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("config.cfg");
            string p = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(p);
            sr.Close();

            byte[] cs = Convert.FromBase64String(c.cs);
            string newCs = cryptage.DecryptSym(cs, cryptage.cle, cryptage.iv);

            SqlConnection cn = new SqlConnection(newCs);
            cn.Open();
            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            listBox1.DisplayMember = "nomouvr";
            listBox1.ValueMember = "numouvr";
            listBox1.DataSource = dt;
            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;

        }
    }
}
