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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        static string DB = "server=cronus.net.ua;database=maindb;Uid=xergofian;pwd=2112";
        public MySqlConnection conn_for_db = new MySqlConnection(DB);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioSelect.Checked) 
            {
                spell_for_mysql_search("Select * from GAME_TYPE;");
            }
            else if (radioInsert.Checked)
            {
                if (spell_for_check_is_not_null() && spell_for_check_id_is_element_int() && spell_for_check_id_is_element_presence())
                {
                    spell_for_mysql($"Insert into GAME_TYPE game_type_id, game_type_name, game_type_description VALUES ({game_type_id_textbox.Text}, {game_type_name_textbox.Text}, {game_type_description_textbox.Text})");       
                }
            }
            else if (radioUpdate.Checked)
            {
                if (spell_for_check_is_not_null() && spell_for_check_id_is_element_int()) 
                {
                    spell_for_mysql($"Update");
                }
            }
            else if (radioDelete.Checked)
            {

            }
        }
        private bool spell_for_check_is_not_null()
        {
            bool test = true;

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            if (radioSelect.Checked)
            {

                if (game_type_id_textbox.Text == "")
                {
                    errorProvider1.SetError(game_type_id_textbox, "game_type_id_textbox не может быть пустым полем");
                    test = false;
                }
            }
            else if (radioUpdate.Checked)
            {
                if (game_type_id_textbox.Text == "")
                {
                    errorProvider1.SetError(game_type_id_textbox, "game_type_id_textbox не может быть пустым полем");
                    test = false;
                }
                if (game_type_name_textbox.Text == "")
                {
                    errorProvider2.SetError(game_type_name_textbox, "game_type_name не может быть пустым полем");
                    test = false;
                }
                if (game_type_description_textbox.Text == "")
                {
                    errorProvider3.SetError(game_type_description_textbox, "game_type_description_textbox не может быть пустым полем");
                    test = false;
                }

            }
            return test;
        }//проверка не пустой ли Textbox
        private bool spell_for_check_id_is_element_presence()
        {
            if (game_type_id_textbox.Text == "")
                return true;


            bool test = true;
            this.conn_for_db.Open();
            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Convert.ToString("select game_type_id from GAME_TYPE;");
            cmd.ExecuteScalar();

            conn_for_db.Close();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            using (DataTableReader reader = dt.CreateDataReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (Convert.ToInt32(game_type_id_textbox.Text) == Convert.ToInt32(reader[i]))
                        {
                            test = false;
                        }
                    }
                }
            }
            if (!test)
            {
                errorProvider1.SetError(game_type_id_textbox, "нарушение Primary key, введи пожалуйста game_type_id_textbox, который ты не видешь в списке");
            }
            else
            {
                errorProvider1.Clear();
            }
            return test;
        }//провер+ка на наличие введеного ID в Texbox для ID
        private bool spell_for_check_id_is_element_int()
        {
            if (game_type_id_textbox.Text == "")
                return true;
            int check_something_in_game_type_id_textbox = 0;
            bool success = false;

            success = Int32.TryParse(game_type_id_textbox.Text, out check_something_in_game_type_id_textbox);
            if (!success)
            {
                errorProvider1.SetError(game_type_id_textbox, "game_type_id должно быть целым числом");
                success = false;
            }
            else
            {
                errorProvider1.Clear();
                success = true;
            }
            return success;
        }
        public void spell_for_mysql(string sql_request) // delete_update_insert 
        {

            conn_for_db.Open();

            MySqlCommand command = new MySqlCommand(sql_request, conn_for_db);
            int rows_num = command.ExecuteNonQuery();
            MessageBox.Show($"{rows_num} рядків було додано/змінено/видалено");

            conn_for_db.Close();
        }
        public void spell_for_mysql_search(object command)  // подключаешся к SQL и выполняешь действие которые тебе нужны (по сути переменная  СOMMAND , это код на SQL)
        {                                       // а суть метода в том чтобы закинуть заклинание SQL на Windows form 
            conn_for_db.Open();
            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Convert.ToString(command);
            cmd.ExecuteScalar();
            conn_for_db.Close();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //clear_fields();
        }
    }
}
