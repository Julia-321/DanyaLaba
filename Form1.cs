using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class GameType
        {
            public int id;
            public string name;
            public GameType(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public override string ToString()
            {
                return this.name;
            }
        }
        //====================================================================
        //Mysql_comand_Type_search = $"select game_type_id FROM GAME_TYPE WHERE game_type_name = '{comboBox1.Text}';";
        //
        //====================================================================
        
        //серверы для лаб (*_*)//
        //==============================================================================================================================================
        //static string DB = "host=62.149.24.91;Initial Catalog = maindb;User Id = dbadmin;Password=superadmin;CharSet=UTF8;Connect Timeout = 100";
        //"Server=localhost;Database=database;Uid=username;Pwd=password;"

        //static string DB = "server=62.149.24.91;database=maindb;Uid=nopass;";
        static string DB = "server=cronus.net.ua;database=maindb;Uid=xergofian;pwd=2112";

        //==============================================================================================================================================

        //==============================================================================================================================================
        public MySqlConnection conn_for_db = new MySqlConnection(DB);
        public Form1()
        {
            InitializeComponent();

        }
        public void clear_fields()//метод что чистит места для ввода 
        {
            game_IDTextBox.Text = "";
            nameTextBox.Text = "";
            descriptionTextBox.Text = "";
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = true;
            // type_IDTextBox.Text = "";
        }
        //static string login = "MANDRYKA\administartor";
        //static string ps = "P@ssw0rd1";
        public void display_comobox()
        {
            comboBox1.Items.Clear();
            conn_for_db.Open();
            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT game_type_id, game_type_name " +
                                "FROM GAME_TYPE";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow i in dt.Rows)
            {
                comboBox1.Items.Add(new GameType(Convert.ToInt32(i["game_type_id"]), i["game_type_name"].ToString()));
            }
            conn_for_db.Close();
        }
        public void display_data()// моментальное отображение даных таблици)
        {

            conn_for_db.Open();

            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select game_id, game_name,game_description, game_type_name FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id;";
            cmd.ExecuteScalar();
            DataTable dta = new DataTable();
            MySqlDataAdapter dataapdt = new MySqlDataAdapter(cmd);
            dataapdt.Fill(dta);
            dataGridView1.DataSource = dta;

            conn_for_db.Close();

            //clear_fields();
        }
        public void spell_for_mysql(string sql_request) // delete_update_insert 
        {

            conn_for_db.Open();

            MySqlCommand command = new MySqlCommand(sql_request, conn_for_db);
            int rows_num = command.ExecuteNonQuery();
            MessageBox.Show($"{rows_num} рядків було додано/змінено/видалено");

            conn_for_db.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'azart_companyDataSet.Game' table. You can move, or remove it, as needed.
            // this.gameTableAdapter.Fill(this.azart_companyDataSet.Game);
            display_data();
            display_comobox();
        }
        private void gameBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //  this.gameBindingSource.EndEdit();
            //  this.tableAdapterManager.UpdateAll(this.azart_companyDataSet);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            if (radioButton2.Checked) //Insert 
            {
                if (spell_for_check_all()) 
                {
                    spell_for_mysql($"INSERT INTO GAME (game_id, game_name, game_description, game_type_ID) " +
                            $"VALUES ({Convert.ToInt32(game_IDTextBox.Text)}, '{nameTextBox.Text}', '{descriptionTextBox.Text}', {((GameType)comboBox1.SelectedItem).id});");
                    clear_fields();
                }
            }

            if (radioButton4.Checked)// DELETE
            {
                if (spell_for_check_all())
                {

                    string cond1 = "true", cond2 = "true";
                    if (checkBox1.Checked)
                    {
                        cond1 = $"game_id = {game_IDTextBox.Text}";
                    }

                    if (checkBox2.Checked)
                    {
                        cond2 = $"GAME_TYPE.game_type_id = '{((GameType)comboBox1.SelectedItem).id}'";
                    }
                    string query = "delete" +
                                   " FROM GAME" +
                                   $" WHERE {cond1} AND {cond2};";
                    spell_for_mysql(query);
                    clear_fields();
                }
            }
            
            //if (radioButton1.Checked)// Search 
            {
                if (spell_for_check_all())
                {

                    string cond1 = "true", cond2 = "true";
                    if (checkBox1.Checked)
                    {
                        cond1 = $"game_id = {game_IDTextBox.Text}";
                    }

                    if (checkBox2.Checked)
                    {
                        cond2 = $"GAME_TYPE.game_type_id = '{((GameType)comboBox1.SelectedItem).id}'";
                    }
                    string query = "select game_id, game_name, game_description, game_type_name " +
                                    "FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id " +
                                    $"WHERE {cond1} AND {cond2};";
                    spell_for_mysql_search(query);
                }
            }
            /*
                        if (radioButton3.Checked) //Update            
                        {
                            if (checkBox1.Checked && (checkBox2.Checked == false))
                            {
                                spell_for_mysql($"update GAME set game_id = {game_IDTextBox.Text}, game_name = '{nameTextBox.Text}', game_description = '{descriptionTextBox.Text}', game_type = {type_IDTextBox.Text} where game_id = {game_IDTextBox.Text}");
                                display_data();
                            }
                            else if (checkBox1.Checked == false && checkBox2.Checked)
                            {
                                spell_for_mysql($"update GAME set game_id = {game_IDTextBox.Text}, game_name = '{nameTextBox.Text}', game_description = '{descriptionTextBox.Text}', game_type = {type_IDTextBox.Text} where game_type = {type_IDTextBox.Text}");
                                display_data();
                                //update GAME set game_id = {game_IDTextBox.Text}, game_name = '{nameTextBox.Text}', game_description = '{descriptionTextBox.Text}', game_type = {type_IDTextBox.Text} where game_type = {game_IDTextBox.Text}";
                            }
                            else if (checkBox1.Checked && checkBox2.Checked)
                            {
                                spell_for_mysql($"update GAME set game_id = {game_IDTextBox.Text}, game_name = '{nameTextBox.Text}', game_description = '{descriptionTextBox.Text}', game_type = {type_IDTextBox.Text}  where (( game_type = {type_IDTextBox.Text} ) AND (game_id = {game_IDTextBox.Text}))");
                                display_data();
                            }
                        }
                      */

        }
        // как изменить тип таблицы  ==> ALTER TABLE tablename MODIFY columnname INTEGER;
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //==============================================================================================
        //Отсеивание ошибок при вводе инфы в текстовые поля
        //==============================================================================================
        private bool spell_for_check_id_is_element_int()
        {
            if (game_IDTextBox.Text == "")
                return true;
            int check_something_in_game_IDTextBox = 0;
            bool success = false;

            success = Int32.TryParse(game_IDTextBox.Text, out check_something_in_game_IDTextBox);
            if (!success)
            {
                errorProvider1.SetError(game_IDTextBox, "game_id должно быть целым числом");
                success = false;
            }
            else
            {
                errorProvider1.Clear();
                success = true;
            }
            return success;
        }
        private bool spell_for_check_is_not_null()
        {
            bool test = true;
            if (radioButton1.Checked)//search
            { 
                errorProvider1.Clear();
                if (checkBox2.Checked && comboBox1.Text == "")
                {
                    errorProvider1.SetError(comboBox1, "game_type_name не может быть пустым полем");
                    test = false;
                }
                if (checkBox1.Checked && game_IDTextBox.Text == "")
                {
                    errorProvider1.SetError(game_IDTextBox, "game_id не может быть пустым полем");
                    test = false;
                }
                if (test)
                {
                    errorProvider1.Clear();
                }
            }
            else if (radioButton2.Checked)
            {
                if (true) { }
                    
            }
            else if (radioButton3.Checked)
            { }
            else if (radioButton4.Checked) 
            { }
            
           
            
            return test;
        }//проверка не пустой ли Textbox
        private bool spell_for_check_id_is_element_presence()
        {
            if (game_IDTextBox.Text == "")
                return true;


            bool test = true;
            conn_for_db.Open();
            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Convert.ToString("select game_id from GAME;");
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
                        if (Convert.ToInt32(game_IDTextBox.Text) == Convert.ToInt32(reader[i]))
                        {
                            test = false;
                        }
                    }
                }
            }
            if (!test)
            {
                errorProvider1.SetError(game_IDTextBox, "нарушение Primary key, введи пожалуйста game_id, который ты не видешь в списке");
            }
            else
            {
                errorProvider1.Clear();
            }
            return test;
        }//провер+ка на наличие введеного ID в Texbox для ID

        private bool spell_for_check_all() //дикий костыль с всеми проверками;
        {
            bool test = true;
            if (radioButton1.Checked)
            {
                test = spell_for_check_is_not_null() &&
                spell_for_check_id_is_element_int();
            }
            else if (radioButton2.Checked)
            {
                test = spell_for_check_is_not_null() &&
                spell_for_check_id_is_element_int() && spell_for_check_id_is_element_presence();
            }
            else if (radioButton4.Checked)
            {
                test = spell_for_check_is_not_null() &&
                spell_for_check_id_is_element_int();
            }
            //else if (radioButton3.Checked)
            //{

            //}
            //else if (radioButton4.Checked) 
            //{

            //}
            return test;



            
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
        private void test_button_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void game_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
  