using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GenVersion
{
    public partial class Form1 : Form
    {
        public static String conexionsqllast = "server=148.223.153.37,5314; database=InfEq;User ID=eordazs;Password=Corpame*2013; integrated security = false ; MultipleActiveResultSets=True";

        public Form1()
        {
            InitializeComponent();
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GetName getname = new GetName();
            getname.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServMail servmail = new ServMail();
            servmail.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InfEq infeq = new InfEq();
            infeq.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Asignar asignar = new Asignar();
            asignar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ASiTTi asitti = new ASiTTi();
            asitti.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DesquemarSiTTi desquemarsitti = new DesquemarSiTTi();
            desquemarsitti.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Resguardos resguardos = new Resguardos();
            resguardos.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VerEconomico vereconomico = new VerEconomico();
            vereconomico.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Compras compras = new Compras();
            compras.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Impresoras impresoras = new Impresoras();
            impresoras.ShowDialog();
        }
    }
}
