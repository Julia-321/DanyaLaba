namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radioSelect = new System.Windows.Forms.RadioButton();
            this.radioInsert = new System.Windows.Forms.RadioButton();
            this.radioUpdate = new System.Windows.Forms.RadioButton();
            this.radioDelete = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.game_type_id_textbox = new System.Windows.Forms.TextBox();
            this.game_type_name_textbox = new System.Windows.Forms.TextBox();
            this.game_type_description_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // radioSelect
            // 
            this.radioSelect.AutoSize = true;
            this.radioSelect.Location = new System.Drawing.Point(19, 20);
            this.radioSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioSelect.Name = "radioSelect";
            this.radioSelect.Size = new System.Drawing.Size(83, 24);
            this.radioSelect.TabIndex = 0;
            this.radioSelect.TabStop = true;
            this.radioSelect.Text = "Пошук";
            this.radioSelect.UseVisualStyleBackColor = true;
            // 
            // radioInsert
            // 
            this.radioInsert.AutoSize = true;
            this.radioInsert.Location = new System.Drawing.Point(19, 58);
            this.radioInsert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioInsert.Name = "radioInsert";
            this.radioInsert.Size = new System.Drawing.Size(120, 24);
            this.radioInsert.TabIndex = 1;
            this.radioInsert.TabStop = true;
            this.radioInsert.Text = "Додавання";
            this.radioInsert.UseVisualStyleBackColor = true;
            // 
            // radioUpdate
            // 
            this.radioUpdate.AutoSize = true;
            this.radioUpdate.Location = new System.Drawing.Point(19, 94);
            this.radioUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioUpdate.Name = "radioUpdate";
            this.radioUpdate.Size = new System.Drawing.Size(132, 24);
            this.radioUpdate.TabIndex = 2;
            this.radioUpdate.TabStop = true;
            this.radioUpdate.Text = "Редагування";
            this.radioUpdate.UseVisualStyleBackColor = true;
            // 
            // radioDelete
            // 
            this.radioDelete.AutoSize = true;
            this.radioDelete.Location = new System.Drawing.Point(19, 131);
            this.radioDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioDelete.Name = "radioDelete";
            this.radioDelete.Size = new System.Drawing.Size(120, 24);
            this.radioDelete.TabIndex = 3;
            this.radioDelete.TabStop = true;
            this.radioDelete.Text = "Видалення";
            this.radioDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 320);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 188);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "game_type_id";
            // 
            // game_type_id_textbox
            // 
            this.game_type_id_textbox.Location = new System.Drawing.Point(29, 285);
            this.game_type_id_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.game_type_id_textbox.Name = "game_type_id_textbox";
            this.game_type_id_textbox.Size = new System.Drawing.Size(112, 26);
            this.game_type_id_textbox.TabIndex = 6;
            // 
            // game_type_name_textbox
            // 
            this.game_type_name_textbox.Location = new System.Drawing.Point(148, 285);
            this.game_type_name_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.game_type_name_textbox.Name = "game_type_name_textbox";
            this.game_type_name_textbox.Size = new System.Drawing.Size(206, 26);
            this.game_type_name_textbox.TabIndex = 7;
            // 
            // game_type_description_textbox
            // 
            this.game_type_description_textbox.Location = new System.Drawing.Point(360, 285);
            this.game_type_description_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.game_type_description_textbox.Name = "game_type_description_textbox";
            this.game_type_description_textbox.Size = new System.Drawing.Size(242, 26);
            this.game_type_description_textbox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "game_type_name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "game_type_description";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "ВИКОНАТИ ЗАПИТ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 228);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "GAME";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.game_type_description_textbox);
            this.Controls.Add(this.game_type_name_textbox);
            this.Controls.Add(this.game_type_id_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioDelete);
            this.Controls.Add(this.radioUpdate);
            this.Controls.Add(this.radioInsert);
            this.Controls.Add(this.radioSelect);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioSelect;
        private System.Windows.Forms.RadioButton radioInsert;
        private System.Windows.Forms.RadioButton radioUpdate;
        private System.Windows.Forms.RadioButton radioDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox game_type_id_textbox;
        private System.Windows.Forms.TextBox game_type_name_textbox;
        private System.Windows.Forms.TextBox game_type_description_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}