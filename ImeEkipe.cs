using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SamostalniProjekat
{
    public partial class ImeEkipe : Form
    {
        public ImeEkipe(string a)
        {
            InitializeComponent();
            label2.Text = a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            SqlConnection veza = Konekcija.Connect();
            string sqlQuery = "SELECT ID FROM korisnik WHERE Email = @Email";
            SqlDataAdapter getid = new SqlDataAdapter(sqlQuery, veza);
            getid.SelectCommand.Parameters.AddWithValue("@Email", label2.Text);

            DataTable dt = new DataTable();
            getid.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0]["ID"]);
            }

            StringBuilder sbEkipa = new StringBuilder("INSERT INTO ekipa(Ime_ekipe, Krediti, Bodovi, ID_korisnika) VALUES ('");
            sbEkipa.Append(textBox1.Text + "', '" + 60 + "', '" + 0 + "', " + id + ")");
            SqlCommand Komanda = new(sbEkipa.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            Login f1 = new Login();
            f1.Show(); this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
