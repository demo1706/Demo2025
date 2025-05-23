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
    public partial class FormPartner : Form
    {
        private int? partnerId;
        public FormPartner(int? partnerId = null)
        {
            InitializeComponent();
            LoadPartnerTypes();
            this.partnerId = partnerId;
            if (partnerId != null)
            {
                label1.Text = "Редактирование информации";
                button1.Text = "Редактировать";
                LoadPartnerData(partnerId.Value);
            }
        }
        private void LoadPartnerData(int Id)
        {
            string connectionString = "Server=DESKTOP-5QAJIJ1; Database =Partners; Trusted_Connection = True; TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT Name, IdType, Rating, Address, Director, Phone, Email FROM Partners WHERE Id = @Id;";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["Name"].ToString();
                                comboBox1.SelectedItem = comboBox1.Items.Cast<dynamic>().FirstOrDefault(x => x.Id.ToString() == reader["IdType"].ToString());
                                textBox2.Text = reader["Rating"].ToString();
                                textBox3.Text = reader["Address"].ToString();
                                textBox4.Text = reader["Director"].ToString();
                                textBox5.Text = reader["Email"].ToString();
                                string phone = reader["Phone"].ToString().Replace(" ", "");
                                if (phone.Length == 10)
                                {
                                    string formattedPhone = $"+7 {phone.Substring(0, 3)} {phone.Substring(3, 3)} {phone.Substring(6, 2)} {phone.Substring(8, 2)}";
                                    maskedTextBox1.Text = formattedPhone;
                                }
                                else
                                {
                                    maskedTextBox1.Text = "";
                                    MessageBox.Show($"Номер телефона имеет неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
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
        private void LoadPartnerTypes()
        {
            string connectionString = "Server=DESKTOP-5QAJIJ1; Database =Partners; Trusted_Connection = True; TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "Select Id, Name FROM PartnerType;";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var partnerType = new
                                {
                                    Id = reader["Id"],
                                    Name = reader["Name"],
                                };
                                comboBox1.Items.Add(partnerType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();
                string connectionString = "Server=DESKTOP-5QAJIJ1; Database =Partners; Trusted_Connection = True; TrustServerCertificate=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query;
                    SqlCommand command;
                    if (partnerId.HasValue)//если редактируем партнера
                    {
                        query = @"UPDATE Partners SET Name = @Name, IdType = @IdType, Rating = @Rating, Address = @Address, Director = @Director,
                                Phone = @Phone, Email = @Email WHERE Id = @Id;";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id", partnerId.Value);
                    }
                    else //если добавляем партнера
                    {
                        int newId;
                        using (SqlCommand maxIdCommand = new SqlCommand("Select ISNULL(MAX(Id), 0) + 1 From Partners;", connection))
                        {
                            newId = (int)maxIdCommand.ExecuteScalar();
                        }
                        query = @"INSERT INTO Partners (Id,Name, IdType, Rating, Address, Director, Phone, Email)
                            VALUES(@Id, @Name, @IdType, @Rating, @Address, @Director, @Phone, @Email);";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id", newId);

                    }
                    command.Parameters.AddWithValue("@Name", textBox1.Text);
                    command.Parameters.AddWithValue("@IdType", ((dynamic)comboBox1.SelectedItem).Id);
                    command.Parameters.AddWithValue("@Rating", int.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@Address", textBox3.Text);
                    command.Parameters.AddWithValue("@Director", textBox4.Text);

                    string phone = maskedTextBox1.Text.Replace("+7 ", "").Replace(" ", "");
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", textBox5.Text);
                    command.ExecuteNonQuery();

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Рейтинг должен быть целым неотрицательным числом", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                comboBox1.SelectedItem == null ||
                !int.TryParse(textBox2.Text, out int rating) ||
                rating < 0 ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                throw new Exception("Пожалуйста, заполните все поля корректно");
            }
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#67BA80");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
