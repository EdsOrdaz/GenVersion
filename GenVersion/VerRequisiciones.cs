using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVersion
{
    public partial class VerRequisiciones : Form
    {
        public VerRequisiciones()
        {
            InitializeComponent();
        }

        private void VerRequisiciones_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsqllast))
                {
                    conexion2.Open();
                    String sql2 = "SELECT valor as version,(SELECT valor FROM Configuracion WHERE nombre='VerRequisiciones_hash') as hash FROM Configuracion WHERE nombre='VerRequisiciones_Version'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        label4.Text = nwReader2["version"].ToString();
                        textBox1.Text = nwReader2["version"].ToString();
                        textBox2.Text = nwReader2["hash"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer version anterior.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No debe haber campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsqllast))
                {
                    conexion2.Open();
                    String sql2 = " UPDATE [Configuracion] SET [valor]='" + textBox1.Text + "' WHERE nombre='VerRequisiciones_Version'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();

                    String sql2_1 = " UPDATE [Configuracion] SET [valor]='" + textBox2.Text + "' WHERE nombre='VerRequisiciones_hash'";
                    SqlCommand comm2_1 = new SqlCommand(sql2_1, conexion2);
                    SqlDataReader nwReader2_1 = comm2_1.ExecuteReader();
                    MessageBox.Show("Version actualizada.\nPrograma: VerRequisiciones\n", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la versión\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string source = textBox1.Text;
            MD5 md5Hash = MD5.Create();
            string hash = Form1.GetMd5Hash(md5Hash, source);
            textBox2.Text = hash;
        }
    }
}
