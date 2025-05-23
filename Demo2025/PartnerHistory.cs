using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Demo2025
{
    public partial class PartnerHistory : Form
    {
        private int partnerId;
        public PartnerHistory(int partnerId)
        {
            InitializeComponent();
            this.partnerId = partnerId;
            LoadPartnerHistory();
        }
        private void LoadPartnerHistory()
        {
            string connectionString = "Server=DESKTOP-5QAJIJ1; Database =Partners; Trusted_Connection = True; TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"Select pr.Name AS [Продукция], pp.Quantity AS [Количество], pp.Date AS [Дата реализации] 
                                    FROM PartnerProducts pp JOIN Partners p ON pp.IdPartner = p.Id JOIN Products pr ON pp.Article = pr.Article
                                    WHERE p.Id = @partnerId;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable historyTable = new DataTable();
                        adapter.Fill(historyTable);
                        dataGridView1.DataSource = historyTable;
                    }

                }
                catch (Exception ex) {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void PartnerHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
