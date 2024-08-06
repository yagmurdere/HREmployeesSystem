using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace HREmployeesSystem
{
    public partial class icerik : Form
    {
        public icerik()
        {
            InitializeComponent();
        }
        void goster()
        {
            SqlConnection baglanti=new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\denemeVT.mdf;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter vericerik=new SqlDataAdapter("select * from icerik order by ad",baglanti);
            DataSet ds = new DataSet();
            vericerik.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void icerik_Load(object sender, EventArgs e)
        {
            goster();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        

        public string SeciliKayitNo;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SeciliKayit=dataGridView1.SelectedCells[0].RowIndex;
            SeciliKayitNo = dataGridView1.Rows[SeciliKayit].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[SeciliKayit].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[SeciliKayit].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[SeciliKayit].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[SeciliKayit].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[SeciliKayit].Cells[5].Value.ToString();

            SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\denemeVT.mdf;Integrated Security=True");
            baglanti.Open();

            SqlCommand komut=new SqlCommand("select * from icerik where ID=@kimlik",baglanti);
            komut.Parameters.AddWithValue("@kimlik", dataGridView1.Rows[SeciliKayit].Cells[0].Value);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                if (dr[6].ToString() == "")
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    byte[] imgData = (byte[])dataGridView1.Rows[SeciliKayit].Cells[6].Value;
                    MemoryStream ms =new MemoryStream(imgData);
                    pictureBox1.Image=Image.FromStream(ms);

                }
                komut.Dispose();
                baglanti.Close();
            }



        }
    }
}
