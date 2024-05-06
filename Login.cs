using System.Data;
using System.Data.SqlClient;

namespace SamostalniProjekat
{
    public partial class Login : Form
    {
        DataTable dt;
        int broj = 0;
        public Login()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Ime_Korisnika, Lozinka FROM korisnik", veza);
            dt = new DataTable();
            adapter.Fill(dt);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registracija f1 = new Registracija();
            f1.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dt.Rows.Count;
            broj = 0;
            int x = 0;
            string ime = textBox1.Text;
            Meni f1 = new Meni(ime);
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Unesite ime ili lozinku", "greska"); }
            else
            {
                for (int i = 0; i < a; i++)
                {
                    if (dt.Rows[broj][0].ToString().Contains(textBox1.Text) && dt.Rows[broj][1].ToString().Contains(textBox2.Text)) { x = 1; break; }
                    broj++;
                }
                if (x == 1) { f1.Show(); this.Hide(); }
                else { MessageBox.Show("Pogresili ste ime ili lozinku", "greska"); }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
