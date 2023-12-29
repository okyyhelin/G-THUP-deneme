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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ebubekirhoca
{
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=.;Database=OGRDENEME;Trusted_Connection=True;Encrypt=False;");

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into T_Ogrenci (adi,soyadi) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);

            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("Kayıt başarılı");
                Getir();
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update ogrenci set Adi='" + textBox1.Text + "', Soyadi='" + textBox2.Text + "' where OgrID=" + textBox3.Text + "", baglanti);

            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("güncelleme başarılı");
            }

            baglanti.Close();
        }

        private void SİLME_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from T_Ogrenci where OgrID=" + textBox3.Text + "", baglanti);
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("Silme başarılı");
            }

            baglanti.Close();
        }

        public void Getir()
            {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_Ogrenci", baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("Tamam");
            int sirano = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[sirano].Cells["Adi"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sirano].Cells["Soyadi"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sirano].Cells["OgrID"].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.label1.Text = textBox3.Text;

            frm.ShowDialog();

                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
