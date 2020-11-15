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
        //====================================================================
        //Mysql_comand_Type_search = $"select game_type_id FROM GAME_TYPE WHERE game_type_name = '{comboBox1.Text}';";
        //
        //====================================================================
        
        //серверы для лаб (*_*)//
        //==============================================================================================================================================
        //static string DB = "host=62.149.24.91;Initial Catalog = maindb;User Id = dbadmin;Password=superadmin;CharSet=UTF8;Connect Timeout = 100";
        //"Server=localhost;Database=database;Uid=username;Pwd=password;"

        static string DB = "server=62.149.24.91;database=maindb;Uid=nopass;";

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
            cmd.CommandText = "Select game_type_name from GAME_TYPE";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow i in dt.Rows)
            {
                comboBox1.Items.Add(i["game_type_name"].ToString());
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

            clear_fields();
        }
        public void spell_for_mysql(string sql_request) // delete_update_insert 
        {

            conn_for_db.Open();

            MySqlCommand command = new MySqlCommand(sql_request, conn_for_db);
            command.ExecuteNonQuery();

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

            if (radioButton1.Checked)// Search 
            {
                if (checkBox1.Checked && (checkBox2.Checked == false))
                {
                    if (spell_for_check_id_is_element_int()) 
                    {
                        spell_for_mysql_search($"select  FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id where GAME.game_id = {Convert.ToInt32(game_IDTextBox.Text)}");
                    }
                    //пошук за ID работает
                }
                else if (checkBox1.Checked == false && checkBox2.Checked && comboBox1.Text != "")
                {
                    spell_for_mysql_search($"select game_id, game_name, game_description, game_type_name FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id where GAME_TYPE.game_type_name = '{comboBox1.Text}';");
                    //пошук за типом гри
                }
                else if (checkBox1.Checked && checkBox2.Checked && comboBox1.Text != "")
                {
                    spell_for_mysql_search($"select game_id, game_name, game_description, game_type_name FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id where GAME.game_id = {Convert.ToInt32(game_IDTextBox.Text)} AND GAME_TYPE.game_type_name = '{comboBox1.Text}';");
                    //пошук за ID та Типом 
                }
                else if (checkBox1.Checked == false && checkBox2.Checked == false) 
                {
                    spell_for_mysql_search($"SELECT game_id, game_name, game_description, game_type_id, game_type_name, game_type_description FROM GAME INNER JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id;");
                    //пошук без id без Type
                }
            }

            if (radioButton2.Checked) //Insert 
            {
                if (spell_for_CHECK_ID()) 
                {
                  spell_for_mysql_Insert(comboBox1.Text);
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
            if (radioButton4.Checked) //Delete
            {
                if (checkBox1.Checked && (!checkBox2.Checked))
                {
                    if (spell_for_CHECK_ID())
                    {
                        spell_for_mysql($"delete from GAME where game_id = {game_IDTextBox.Text};");
                        display_data();
                    }
                }
                else if (!checkBox1.Checked && checkBox2.Checked && comboBox1.Text != "")
                {
                    spell_for_mysql($"delete from GAME where game_type = {comboBox1.Text};");
                    display_data();
                }
                else if (checkBox1.Checked && checkBox2.Checked)
                {
                    if (spell_for_CHECK_ID())
                    {
                        spell_for_mysql($"delete from GAME where (game_id = {game_IDTextBox.Text}) AND (game_type = {comboBox1.Text});");
                        display_data();
                    }
                       
                }
            }
        }
        // как изменить тип таблицы  ==> ALTER TABLE tablename MODIFY columnname INTEGER;
        private void button2_Click(object sender, EventArgs e)
        {

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
        private void spell_for_mysql_Insert(string game_type_name)//insert_for_mysql
        {
            int check_game_type_id = 0;
            conn_for_db.Open();
            MySqlCommand cmd = conn_for_db.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Convert.ToString($"select game_type_id FROM GAME_TYPE WHERE (game_type_name = '{game_type_name}');");
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
                        check_game_type_id = Convert.ToInt32(reader[i]);
                    }
                }
            }
            spell_for_mysql($"Insert INTO GAME (game_id, game_name, game_description, game_type_ID) VALUES ({Convert.ToInt32(game_IDTextBox.Text)}, '{nameTextBox.Text}', '{descriptionTextBox.Text}', {check_game_type_id});");
        }
        //==============================================================================================
        //Отсеивание ошибок при вводе инфы в текстовые поля
        //==============================================================================================
        private bool spell_for_check_id_is_element_int()
        {
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
                if (checkBox1.Checked && !checkBox2.Checked) 
                {
                    if (game_IDTextBox.Text == "")
                    {
                        errorProvider1.SetError(game_IDTextBox, "game_id не может быть пустым полем");
                        test = false;
                    }
                    else
                    {
                        errorProvider1.Clear();
                        test = true;
                    }
                }
                else if (!checkBox1.Checked && checkBox2.Checked)
                {
                    if (comboBox1.Text == "")
                    {
                        errorProvider1.SetError(comboBox1, "game_type_name не может быть пустым полем");
                        test = false;
                    }
                    else
                    {
                        errorProvider1.Clear();
                        test = true;
                    }
                }
            }
            else if (radioButton2.Checked)
            { }
            else if (radioButton3.Checked)
            { }
            else if (radioButton4.Checked) 
            { }
            
            else 
            {
                

                if (nameTextBox.Text == "")
                {
                    errorProvider2.SetError(nameTextBox, "game_name не может быть пустым полем");
                    test = false;
                }
                else
                {
                    errorProvider2.Clear();
                    test = true;
                }

                if (descriptionTextBox.Text == "")
                {
                    errorProvider3.SetError(descriptionTextBox, "game_description не может быть пустым полем");
                    test = false;
                }
                else
                {
                    errorProvider3.Clear();
                    test = true;
                }

                if (comboBox1.Text == "")
                {
                    errorProvider1.SetError(comboBox1, "game_type_name не может быть пустым полем");
                    test = false;
                }
            }
            return test;
        }//проверка не пустой ли Textbox
        private bool spell_for_check_id_is_element_presence()
        {
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
        }//проверка на наличие введеного ID в Texbox для ID

        private bool spell_for_CHECK_ID() //дикий костыль с всеми проверками;
        {
            bool test = true;
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    if (spell_for_check_is_not_null()) 
                    {
                        if (spell_for_check_id_is_element_int())
                        {
                            spell_for_mysql_search($"select  FROM GAME LEFT JOIN GAME_TYPE ON GAME.game_type_ID = GAME_TYPE.game_type_id where GAME.game_id = {Convert.ToInt32(game_IDTextBox.Text)}");
                        }
                    }
                    
                    //пошук за ID работает
                }
            }
            else if (radioButton2.Checked)
            {

            }
            else if (radioButton3.Checked)
            {

            }
            else if (radioButton4.Checked) 
            {
            
            }
            if (spell_for_check_is_not_null())
            { 
                if (spell_for_check_id_is_element_int())
                {
                    if (spell_for_check_id_is_element_presence())
                    {
                        test = true;
                    }
                    else 
                    {
                        test = false;
                    }
                }
                else 
                {
                    test = false;
                }
            }
            else 
            {
                test = false;
            }
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
            clear_fields();
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
  