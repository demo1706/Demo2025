using Microsoft.Data.SqlClient;

namespace Demo2025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPartners();
        }
        private void LoadPartners()
        {
            string connection = "Server=DESKTOP-5QAJIJ1; Database =Partners; Trusted_Connection = True; TrustServerCertificate=true;";
            using (SqlConnection connect = new SqlConnection(connection))
            {
                try
                {
                    connect.Open();
                    string query = @"SELECT p.Id, t.Name as Тип, p.Name AS Партнер, p.Director, p.Phone, p.Rating,
                                SUM(pp.Quantity * prod.MinPrice) AS TotalSales
                                 From Partners p JOIN PartnerType t ON p.IdType = t.Id
                                LEFT JOIN PartnerProducts pp ON p.Id = pp.IdPartner
                                LEFT JOIN Products prod ON pp.Article = prod.Article
                                GROUP BY p.Id, t.Name, p.Name, p.Director, p.Phone, p.Rating";
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal totalSales = reader.IsDBNull(reader.GetOrdinal("TotalSales")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalSales"));
                                decimal discount = CalculateDiscount(totalSales);
                                int partnerId = reader.GetInt32(reader.GetOrdinal("Id"));

                                Panel card = new Panel
                                {
                                    Size = new Size(250, 110),
                                    Margin = new Padding(10),
                                    BackColor = Color.White,
                                };
                                card.Click += (sender, e) => EditPartner(partnerId);
                                card.Controls.Add(new Label { Text = $"{reader["Тип"]} | {reader["Партнер"]}", AutoSize = true, Location = new Point(0, 10) });
                                card.Controls.Add(new Label { Text = $"{reader["Director"]}", AutoSize = true, Location = new Point(0, 40) });
                                card.Controls.Add(new Label { Text = $"+7 {reader["Phone"]}", AutoSize = true, Location = new Point(0, 60) });
                                card.Controls.Add(new Label { Text = $"Рейтинг: {reader["Rating"]}", AutoSize = true, Location = new Point(0, 80) });
                                card.Controls.Add(new Label { Text = $"{discount}%", AutoSize = true, Location = new Point(200, 10) });

                                ContextMenuStrip contextMenu = new ContextMenuStrip();
                                contextMenu.Items.Add("Посмотреть историю", null, (s, e) =>
                                {
                                    PartnerHistory history = new PartnerHistory(partnerId);
                                    history.ShowDialog();
                                });
                                card.ContextMenuStrip = contextMenu;
                                flowLayoutPanel1.Controls.Add(card);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private decimal CalculateDiscount(decimal totalSales)
        {
            if (totalSales < 10000) return 0;
            else if (totalSales < 50000) return 5;
            else if (totalSales < 300000) return 10;
            else return 15;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#67BA80");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPartner partner = new FormPartner();
            if (partner.ShowDialog() == DialogResult.OK)
                LoadPartners();
        }
        private void EditPartner(int partnerId)
        {
            FormPartner partner = new FormPartner(partnerId);
            if (partner.ShowDialog() == DialogResult.OK)
                LoadPartners();
        }
    }
}
