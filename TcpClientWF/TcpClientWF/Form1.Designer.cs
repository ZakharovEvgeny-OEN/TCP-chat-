namespace TcpClientWF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_InChat = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_SendMess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Men = new System.Windows.Forms.CheckBox();
            this.checkBox_Fem = new System.Windows.Forms.CheckBox();
            this.checkBox_Child = new System.Windows.Forms.CheckBox();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_InChat
            // 
            this.button_InChat.Location = new System.Drawing.Point(489, 10);
            this.button_InChat.Name = "button_InChat";
            this.button_InChat.Size = new System.Drawing.Size(75, 23);
            this.button_InChat.TabIndex = 0;
            this.button_InChat.Text = "Войти в чат";
            this.button_InChat.UseVisualStyleBackColor = true;
            this.button_InChat.Click += new System.EventHandler(this.button_InChat_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(47, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(517, 238);
            this.listBox1.TabIndex = 1;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(47, 8);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя:";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(46, 393);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(427, 40);
            this.textBox_Message.TabIndex = 4;
            // 
            // button_SendMess
            // 
            this.button_SendMess.Location = new System.Drawing.Point(489, 391);
            this.button_SendMess.Name = "button_SendMess";
            this.button_SendMess.Size = new System.Drawing.Size(75, 23);
            this.button_SendMess.TabIndex = 5;
            this.button_SendMess.Text = "Отправить";
            this.button_SendMess.UseVisualStyleBackColor = true;
            this.button_SendMess.Click += new System.EventHandler(this.button_SendMess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "поле для ввода сообщений:";
            // 
            // checkBox_Men
            // 
            this.checkBox_Men.AutoSize = true;
            this.checkBox_Men.Location = new System.Drawing.Point(47, 283);
            this.checkBox_Men.Name = "checkBox_Men";
            this.checkBox_Men.Size = new System.Drawing.Size(91, 17);
            this.checkBox_Men.TabIndex = 7;
            this.checkBox_Men.Text = "Мужской чат";
            this.checkBox_Men.UseVisualStyleBackColor = true;
            this.checkBox_Men.CheckedChanged += new System.EventHandler(this.checkBox_Men_CheckedChanged);
            // 
            // checkBox_Fem
            // 
            this.checkBox_Fem.AutoSize = true;
            this.checkBox_Fem.Location = new System.Drawing.Point(47, 306);
            this.checkBox_Fem.Name = "checkBox_Fem";
            this.checkBox_Fem.Size = new System.Drawing.Size(92, 17);
            this.checkBox_Fem.TabIndex = 8;
            this.checkBox_Fem.Text = "Женский чат";
            this.checkBox_Fem.UseVisualStyleBackColor = true;
            this.checkBox_Fem.CheckedChanged += new System.EventHandler(this.checkBox_Fem_CheckedChanged);
            // 
            // checkBox_Child
            // 
            this.checkBox_Child.AutoSize = true;
            this.checkBox_Child.Location = new System.Drawing.Point(46, 329);
            this.checkBox_Child.Name = "checkBox_Child";
            this.checkBox_Child.Size = new System.Drawing.Size(89, 17);
            this.checkBox_Child.TabIndex = 9;
            this.checkBox_Child.Text = "Детский чат";
            this.checkBox_Child.UseVisualStyleBackColor = true;
            this.checkBox_Child.CheckedChanged += new System.EventHandler(this.checkBox_Child_CheckedChanged);
            // 
            // checkBox_All
            // 
            this.checkBox_All.AutoSize = true;
            this.checkBox_All.Location = new System.Drawing.Point(46, 352);
            this.checkBox_All.Name = "checkBox_All";
            this.checkBox_All.Size = new System.Drawing.Size(83, 17);
            this.checkBox_All.TabIndex = 10;
            this.checkBox_All.Text = "Общий  чат";
            this.checkBox_All.UseVisualStyleBackColor = true;
            this.checkBox_All.CheckedChanged += new System.EventHandler(this.checkBox_All_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 450);
            this.Controls.Add(this.checkBox_All);
            this.Controls.Add(this.checkBox_Child);
            this.Controls.Add(this.checkBox_Fem);
            this.Controls.Add(this.checkBox_Men);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_SendMess);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_InChat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_InChat;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_SendMess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_Men;
        private System.Windows.Forms.CheckBox checkBox_Fem;
        private System.Windows.Forms.CheckBox checkBox_Child;
        private System.Windows.Forms.CheckBox checkBox_All;
    }
}

