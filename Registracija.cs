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

namespace SamostalniProjekat
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbRegistracija = new StringBuilder("INSERT INTO korisnik(Ime_Korisnika, Email, Lozinka, Datum_Registracije) VALUES ('");
            sbRegistracija.Append(textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + "GETDATE() )");
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new(sbRegistracija.ToString(), veza);
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
            ImeEkipe f1 = new ImeEkipe(textBox2.Text);
            f1.Show(); this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
