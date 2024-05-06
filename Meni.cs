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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SamostalniProjekat
{
    public partial class Meni : Form
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        int krediti = 0;
        public Meni(string a)
        {
            InitializeComponent();
            label3.Text = a;

            SqlConnection veza1 = Konekcija.Connect();
            string sqlQuery1 = "SELECT TOP 1 Krediti FROM ekipa join korisnik on ekipa.ID_korisnika = korisnik.ID where korisnik.Ime_Korisnika = @Email";
            SqlDataAdapter getkrediti = new SqlDataAdapter(sqlQuery1, veza1);
            getkrediti.SelectCommand.Parameters.AddWithValue("@Email", a);
            DataTable dt1 = new DataTable();
            getkrediti.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                krediti = Convert.ToInt32(dt1.Rows[0][0]);
                label5.Text = krediti.ToString();
            }


            SqlConnection veza = Konekcija.Connect();
            string sqlQuery = "SELECT Ime_Ekipe FROM ekipa join korisnik on ekipa.ID_korisnika = korisnik.ID where korisnik.Ime_Korisnika = @Email";
            SqlDataAdapter getid = new SqlDataAdapter(sqlQuery, veza);
            getid.SelectCommand.Parameters.AddWithValue("@Email", a);
            DataTable dt = new DataTable();
            getid.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                label11.Text = (dt.Rows[0]["Ime_Ekipe"]).ToString();
            }

        }

        private void Load_igraci()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT igraci.ID_igraca, igraci.Ime, igraci.Prezime, igraci.Pozicija, igraci.Cena, tim.Ime_tima FROM igraci JOIN tim ON igraci.ID_tima = tim.ID_tima WHERE igraci.Pozicija = 'G' ORDER BY igraci.Cena desc", veza);
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT igraci.ID_igraca, igraci.Ime, igraci.Prezime, igraci.Pozicija, igraci.Cena, tim.Ime_tima FROM igraci JOIN tim ON igraci.ID_tima = tim.ID_tima WHERE igraci.Pozicija = 'F' ORDER BY igraci.Cena desc", veza);
            SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT igraci.ID_igraca, igraci.Ime, igraci.Prezime, igraci.Pozicija, igraci.Cena, tim.Ime_tima FROM igraci JOIN tim ON igraci.ID_tima = tim.ID_tima WHERE igraci.Pozicija = 'C' ORDER BY igraci.Cena desc", veza);
            adapter1.Fill(dt1);
            adapter2.Fill(dt2);
            adapter3.Fill(dt3);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt1.Rows[i][1].ToString() + " " + dt1.Rows[i][2].ToString() + ", " + dt1.Rows[i][3].ToString() + ", " + dt1.Rows[i][4].ToString() + ", " + dt1.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt1.Rows[i][1].ToString() + " " + dt1.Rows[i][2].ToString() + ", " + dt1.Rows[i][3].ToString() + ", " + dt1.Rows[i][4].ToString() + ", " + dt1.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBox3.Items.Add(dt2.Rows[i][1].ToString() + " " + dt2.Rows[i][2].ToString() + ", " + dt2.Rows[i][3].ToString() + ", " + dt2.Rows[i][4].ToString() + ", " + dt2.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBox4.Items.Add(dt2.Rows[i][1].ToString() + " " + dt2.Rows[i][2].ToString() + ", " + dt2.Rows[i][3].ToString() + ", " + dt2.Rows[i][4].ToString() + ", " + dt2.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                comboBox5.Items.Add(dt3.Rows[i][1].ToString() + " " + dt3.Rows[i][2].ToString() + ", " + dt3.Rows[i][3].ToString() + ", " + dt3.Rows[i][4].ToString() + ", " + dt3.Rows[i][5].ToString());
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Meni_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = false;
            button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1111")
            {
                this.Hide();
                Admin admin = new Admin();
                admin.Show();
            }
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            Load_igraci();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = comboBox1.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti -= pom;
            if (krediti >= 0) { label5.Text = krediti.ToString(); comboBox1.Enabled = false; button9.Visible = true; }
            else { krediti += pom; comboBox1.Text = String.Empty; MessageBox.Show("Nemate dovoljno kredita", "ERROR"); }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = comboBox3.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti -= pom;
            if (krediti >= 0) { label5.Text = krediti.ToString(); comboBox3.Enabled = false; button11.Visible = true; }
            else { krediti += pom; comboBox3.Text = String.Empty; MessageBox.Show("Nemate dovoljno kredita", "ERROR"); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = comboBox4.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti -= pom;
            if (krediti >= 0) { label5.Text = krediti.ToString(); comboBox4.Enabled = false; button12.Visible = true; }
            else { krediti += pom; comboBox4.Text = String.Empty; MessageBox.Show("Nemate dovoljno kredita", "ERROR"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //id ekipe
            SqlConnection veza = Konekcija.Connect();
            string sqlQuery = "SELECT TOP 1 ID_ekipe FROM ekipa where Ime_ekipe = @Ime_Ekipe";
            SqlDataAdapter getidekipe = new SqlDataAdapter(sqlQuery, veza);
            getidekipe.SelectCommand.Parameters.AddWithValue("@Ime_Ekipe", label11.Text);
            DataTable dt = new DataTable();
            getidekipe.Fill(dt);
            int idekipe = Convert.ToInt32(dt.Rows[0][0]);

            //id igraca
            string[] delovicombobox1 = comboBox1.Text.Split(' ');
            string g1ime = delovicombobox1[0];
            string g1prezime = delovicombobox1[1].TrimEnd(',');
            string[] delovicombobox2 = comboBox2.Text.Split(' ');
            string g2ime = delovicombobox2[0];
            string g2prezime = delovicombobox2[1].TrimEnd(',');
            string[] delovicombobox3 = comboBox3.Text.Split(' ');
            string f1ime = delovicombobox3[0];
            string f1prezime = delovicombobox3[1].TrimEnd(',');
            string[] delovicombobox4 = comboBox4.Text.Split(' ');
            string f2ime = delovicombobox4[0];
            string f2prezime = delovicombobox4[1].TrimEnd(',');
            string[] delovicombobox5 = comboBox5.Text.Split(' ');
            string c1ime = delovicombobox5[0];
            string c1prezime = delovicombobox5[1].TrimEnd(',');

            string sqlQuery1 = "select top 1 ID_igraca from igraci where Ime = @Ime and Prezime = @Prezime";
            SqlDataAdapter getidg1 = new SqlDataAdapter(sqlQuery1, veza);
            getidg1.SelectCommand.Parameters.AddWithValue("@Ime", g1ime);
            getidg1.SelectCommand.Parameters.AddWithValue("@Prezime", g1prezime);
            DataTable dt1 = new DataTable();
            getidg1.Fill(dt1);
            int idg1 = Convert.ToInt32(dt1.Rows[0][0]);

            SqlDataAdapter getidg2 = new SqlDataAdapter(sqlQuery1, veza);
            getidg2.SelectCommand.Parameters.AddWithValue("@Ime", g2ime);
            getidg2.SelectCommand.Parameters.AddWithValue("@Prezime", g2prezime);
            getidg2.Fill(dt1);
            int idg2 = Convert.ToInt32(dt1.Rows[1][0]);

            SqlDataAdapter getidf1 = new SqlDataAdapter(sqlQuery1, veza);
            getidf1.SelectCommand.Parameters.AddWithValue("@Ime", f1ime);
            getidf1.SelectCommand.Parameters.AddWithValue("@Prezime", f1prezime);
            getidf1.Fill(dt1);
            int idf1 = Convert.ToInt32(dt1.Rows[2][0]);

            SqlDataAdapter getidf2 = new SqlDataAdapter(sqlQuery1, veza);
            getidf2.SelectCommand.Parameters.AddWithValue("@Ime", f2ime);
            getidf2.SelectCommand.Parameters.AddWithValue("@Prezime", f2prezime);
            getidf2.Fill(dt1);
            int idf2 = Convert.ToInt32(dt1.Rows[3][0]);

            SqlDataAdapter getidc1 = new SqlDataAdapter(sqlQuery1, veza);
            getidc1.SelectCommand.Parameters.AddWithValue("@Ime", c1ime);
            getidc1.SelectCommand.Parameters.AddWithValue("@Prezime", c1prezime);
            getidc1.Fill(dt1);
            int idc1 = Convert.ToInt32(dt1.Rows[4][0]);


            //sql
            StringBuilder obrisistaro = new StringBuilder("delete from ekipa_igraci where ID_ekipe = ");
            obrisistaro.Append(idekipe);

            StringBuilder ekipaUpdate = new StringBuilder("exec ekipa_update '");
            ekipaUpdate.Append(label11.Text + "', " + krediti + ", " + 0);

            StringBuilder sbEKIPA_IGRACI = new StringBuilder("insert into ekipa_igraci(ID_ekipe, ID_igraca) VALUES (");
            sbEKIPA_IGRACI.Append(idekipe + ", " + idg1 + "),(");
            sbEKIPA_IGRACI.Append(idekipe + ", " + idg2 + "),(");
            sbEKIPA_IGRACI.Append(idekipe + ", " + idf1 + "),(");
            sbEKIPA_IGRACI.Append(idekipe + ", " + idf2 + "),(");
            sbEKIPA_IGRACI.Append(idekipe + ", " + idc1 + ")");


            SqlCommand Komanda = new(sbEKIPA_IGRACI.ToString(), veza);
            SqlCommand Komanda1 = new(obrisistaro.ToString(), veza);
            SqlCommand Komanda2 = new(ekipaUpdate.ToString(), veza);
            try
            {
                veza.Open();
                Komanda1.ExecuteNonQuery();
                Komanda.ExecuteNonQuery();
                Komanda2.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show("Promene sacuvane.", "POTVRDA");
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = comboBox2.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti -= pom;
            if (krediti >= 0) { label5.Text = krediti.ToString(); comboBox2.Enabled = false; button10.Visible = true; }
            else { krediti += pom; comboBox2.Text = String.Empty; MessageBox.Show("Nemate dovoljno kredita", "ERROR"); }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inputString = comboBox5.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti -= pom;
            if (krediti >= 0) { label5.Text = krediti.ToString(); comboBox5.Enabled = false; button13.Visible = true; }
            else { krediti += pom; comboBox5.Text = String.Empty; MessageBox.Show("Nemate dovoljno kredita", "ERROR"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.Text = String.Empty;
            comboBox2.Text = String.Empty;
            comboBox3.Text = String.Empty;
            comboBox4.Text = String.Empty;
            comboBox5.Text = String.Empty;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            krediti = 60;
            label5.Text = krediti.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string inputString = comboBox1.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti += pom;
            label5.Text = krediti.ToString();
            comboBox1.Text = String.Empty;
            comboBox1.Enabled = true;
            button9.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string inputString = comboBox2.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti += pom;
            label5.Text = krediti.ToString();
            comboBox2.Text = String.Empty;
            comboBox2.Enabled = true;
            button10.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string inputString = comboBox3.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti += pom;
            label5.Text = krediti.ToString();
            comboBox3.Text = String.Empty;
            comboBox3.Enabled = true;
            button11.Visible = false;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string inputString = comboBox4.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti += pom;
            label5.Text = krediti.ToString();
            comboBox4.Text = String.Empty;
            comboBox4.Enabled = true;
            button12.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string inputString = comboBox5.Text;
            int countDigits = 0;
            string s = "";
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    countDigits++;
                    s += c;
                    if (countDigits >= 2)
                    {
                        break;
                    }
                }
            }
            int pom = Convert.ToInt32(s);
            krediti += pom;
            label5.Text = krediti.ToString();
            comboBox5.Text = String.Empty;
            comboBox5.Enabled = true;
            button13.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false;
            label14.Text = label3.Text;
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Email, Datum_registracije from korisnik WHERE Ime_Korisnika = @Ime", veza);
            adapter.SelectCommand.Parameters.AddWithValue("@Ime", label3.Text); DataTable dt = new DataTable(); adapter.Fill(dt); label16.Text = dt.Rows[0][0].ToString(); label18.Text = dt.Rows[0][1].ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.Orange)
            {
                textBox2.Visible = true; button14.BackColor = Color.Green; button14.ForeColor = Color.White;
            }
            else
            {
                if (textBox2.Text != "")
                {
                    SqlConnection veza = Konekcija.Connect();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Email from korisnik WHERE Ime_Korisnika = @Ime", veza);
                    adapter.SelectCommand.Parameters.AddWithValue("@Ime", label3.Text); DataTable dt = new DataTable(); adapter.Fill(dt); string email = dt.Rows[0][0].ToString();
                    StringBuilder korisnikUpdate = new StringBuilder("exec korisnik_update '");
                    korisnikUpdate.Append(textBox2.Text + "', '" + email + "'");
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
                    label3.Text = textBox2.Text; label14.Text = textBox2.Text;
                    textBox2.Clear(); button14.BackColor = Color.Orange; button14.ForeColor = Color.Black; textBox2.Visible = false;
                }
            }

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}