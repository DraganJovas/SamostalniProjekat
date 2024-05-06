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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Korisnik", veza);
            DataTable dt = new DataTable(); adapter.Fill(dt); dataGridView1.DataSource = dt;
            panel1.Visible = false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from igraci", veza);
            DataTable dt = new DataTable(); adapter.Fill(dt); dataGridView1.DataSource = dt;
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from ekipa", veza);
            DataTable dt = new DataTable(); adapter.Fill(dt); dataGridView1.DataSource = dt;
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from tim", veza);
            DataTable dt = new DataTable(); adapter.Fill(dt); dataGridView1.DataSource = dt;
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;
            button9.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide(); f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Visible = true; label2.Text = "Tim"; textBox1.Visible = true;
                label3.Visible = true; label3.Text = "Ime"; textBox2.Visible = true;
                label4.Visible = true; label4.Text = "Prezime"; textBox3.Visible = true;
                label5.Visible = true; label5.Text = "Pozicija"; textBox4.Visible = true;
                label6.Visible = true; label6.Text = "Cena"; textBox5.Visible = true;
                button9.Visible = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label2.Visible = true; label2.Text = "Ime"; textBox1.Visible = true;
                label3.Visible = true; label3.Text = "Grad"; textBox2.Visible = true;
                label4.Visible = true; label4.Text = "Trener"; textBox3.Visible = true;
                label5.Visible = false; label5.Text = "Pozicija"; textBox4.Visible = false;
                label6.Visible = false; label6.Text = "Cena"; textBox5.Visible = false;
                button9.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder igracInsert = new StringBuilder("exec igrac_insert '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '");
                igracInsert.Append(textBox4.Text + "', " + Convert.ToInt32(textBox5.Text));
                SqlCommand cmd = new SqlCommand(igracInsert.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder timInsert = new StringBuilder("exec tim_insert '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "'");
                SqlCommand cmd = new SqlCommand(timInsert.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void textBox8_TextChanged(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                label8.Visible = true; label8.Text = "Ime"; textBox6.Visible = true;
                label9.Visible = true; label9.Text = "Email(fix)"; textBox7.Visible = true;
                label10.Visible = false; label10.Text = ""; textBox8.Visible = false;
                label11.Visible = false; label11.Text = ""; textBox9.Visible = false;
                button10.Visible = true;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                label8.Visible = true; label8.Text = "Ime(fix)"; textBox6.Visible = true;
                label9.Visible = true; label9.Text = "Prezime(fix)"; textBox7.Visible = true;
                label10.Visible = true; label10.Text = "Pozicija"; textBox8.Visible = true;
                label11.Visible = true; label11.Text = "Cena"; textBox9.Visible = true;
                button10.Visible = true;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                label8.Visible = true; label8.Text = "Ime(fix)"; textBox6.Visible = true;
                label9.Visible = true; label9.Text = "Grad"; textBox7.Visible = true;
                label10.Visible = true; label10.Text = "Trener"; textBox8.Visible = true;
                label11.Visible = false; label11.Text = ""; textBox9.Visible = false;
                button10.Visible = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder korisnikUpdate = new StringBuilder("exec korisnik_update '" + textBox6.Text + "', '" + textBox7.Text + "'");
                SqlCommand cmd = new SqlCommand(korisnikUpdate.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox6.Clear();
                textBox7.Clear();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder igracUpdate = new StringBuilder("exec igrac_update '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', " + Convert.ToInt32(textBox9.Text));
                SqlCommand cmd = new SqlCommand(igracUpdate.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder timUpdate = new StringBuilder("exec tim_update '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "'");
                SqlCommand cmd = new SqlCommand(timUpdate.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;
            textBox6.Visible = false; textBox7.Visible = false; textBox8.Visible = false; textBox9.Visible = false;
            label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false;
            button10.Visible = false;
            button9.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder korisnikDelete = new StringBuilder("exec korisnik_delete '" + textBox10.Text + "'");
                SqlCommand cmd = new SqlCommand(korisnikDelete.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox10.Clear();
            }
            if (comboBox3.SelectedIndex == 1)
            {
                SqlConnection veza = Konekcija.Connect();
                StringBuilder igracDelete = new StringBuilder("exec igrac_delete '" + textBox10.Text + "', '" + textBox11.Text + "'");
                SqlCommand cmd = new SqlCommand(igracDelete.ToString(), veza);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                textBox10.Clear();
                textBox11.Clear();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0) 
            {
                label12.Visible = true; label12.Text = "Email"; textBox10.Visible = true;
                label13.Visible = false; label13.Text = ""; textBox11.Visible = false;
                button11.Visible = true;
            }
            if (comboBox3.SelectedIndex == 1) 
            {
                label12.Visible = true; label12.Text = "Ime"; textBox10.Visible = true;
                label13.Visible = true; label13.Text = "Prezime"; textBox11.Visible = true;
                button11.Visible = true;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                label12.Visible = true; label12.Text = "Ime"; textBox10.Visible = true;
                label13.Visible = false; label13.Text = ""; textBox11.Visible = false;
                button11.Visible = true;
            }
        }
    }
}
