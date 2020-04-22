using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projek
{
    public partial class Form1 : Form
    {
        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=rental;";
        private MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

        }

        private void ListMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            private void ListBuku_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBuku.SelectedItems.Count > 0)
                {
                    ListViewItem item = listBuku.SelectedItems[0];
                    text_id.Text = item.SubItems[0].Text;
                    text_judul.Text = item.SubItems[1].Text;
                    text_pengarang.Text = item.SubItems[2].Text;
                    text_jumlah.Text = item.SubItems[3].Text;
                }
                else
                {
                    text_id.Text = string.Empty;
                    text_judul.Text = string.Empty;
                    text_pengarang.Text = string.Empty;
                    text_jumlah.Text = string.Empty;

                }
            }
        }
    }
}
