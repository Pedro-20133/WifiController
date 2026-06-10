namespace WifiController
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            on = new Button();
            off = new Button();
            status = new Label();
            validar = new Button();
            tabControl1 = new TabControl();
            mainTab = new TabPage();
            configs = new TabPage();
            label3 = new Label();
            label2 = new Label();
            pswTxt = new TextBox();
            userTxt = new TextBox();
            hostTxt = new TextBox();
            label1 = new Label();
            reset = new Button();
            tabControl1.SuspendLayout();
            mainTab.SuspendLayout();
            configs.SuspendLayout();
            SuspendLayout();
            // 
            // on
            // 
            on.Enabled = false;
            on.Location = new Point(3, 91);
            on.Name = "on";
            on.Size = new Size(229, 36);
            on.TabIndex = 0;
            on.Text = "Ligar Wifi";
            on.UseVisualStyleBackColor = true;
            on.Click += on_Click;
            // 
            // off
            // 
            off.Enabled = false;
            off.Location = new Point(3, 133);
            off.Name = "off";
            off.Size = new Size(229, 36);
            off.TabIndex = 1;
            off.Text = "Desligar Wifi";
            off.UseVisualStyleBackColor = true;
            off.Click += off_Click;
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(3, 3);
            status.Name = "status";
            status.Size = new Size(51, 18);
            status.TabIndex = 2;
            status.Text = "Status:";
            // 
            // validar
            // 
            validar.Location = new Point(3, 24);
            validar.Name = "validar";
            validar.Size = new Size(229, 36);
            validar.TabIndex = 3;
            validar.Text = "Validar Conn";
            validar.UseVisualStyleBackColor = true;
            validar.Click += validar_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(mainTab);
            tabControl1.Controls.Add(configs);
            tabControl1.Location = new Point(-2, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(246, 214);
            tabControl1.TabIndex = 4;
            // 
            // mainTab
            // 
            mainTab.Controls.Add(status);
            mainTab.Controls.Add(validar);
            mainTab.Controls.Add(on);
            mainTab.Controls.Add(off);
            mainTab.Location = new Point(4, 27);
            mainTab.Name = "mainTab";
            mainTab.Padding = new Padding(3);
            mainTab.Size = new Size(238, 183);
            mainTab.TabIndex = 0;
            mainTab.Text = "Main Tab";
            mainTab.UseVisualStyleBackColor = true;
            // 
            // configs
            // 
            configs.Controls.Add(reset);
            configs.Controls.Add(label3);
            configs.Controls.Add(label2);
            configs.Controls.Add(pswTxt);
            configs.Controls.Add(userTxt);
            configs.Controls.Add(hostTxt);
            configs.Controls.Add(label1);
            configs.Location = new Point(4, 27);
            configs.Name = "configs";
            configs.Padding = new Padding(3);
            configs.Size = new Size(238, 183);
            configs.TabIndex = 1;
            configs.Text = "Configs";
            configs.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(31, 18);
            label3.TabIndex = 5;
            label3.Text = "Psw";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 51);
            label2.Name = "label2";
            label2.Size = new Size(37, 18);
            label2.TabIndex = 4;
            label2.Text = "User";
            // 
            // pswTxt
            // 
            pswTxt.Location = new Point(48, 79);
            pswTxt.Name = "pswTxt";
            pswTxt.Size = new Size(184, 25);
            pswTxt.TabIndex = 3;
            pswTxt.Text = "admin";
            // 
            // userTxt
            // 
            userTxt.Location = new Point(48, 48);
            userTxt.Name = "userTxt";
            userTxt.Size = new Size(184, 25);
            userTxt.TabIndex = 2;
            userTxt.Text = "admin";
            // 
            // hostTxt
            // 
            hostTxt.Location = new Point(48, 17);
            hostTxt.Name = "hostTxt";
            hostTxt.Size = new Size(184, 25);
            hostTxt.TabIndex = 1;
            hostTxt.Text = "192.162.1.1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 20);
            label1.Name = "label1";
            label1.Size = new Size(36, 18);
            label1.TabIndex = 0;
            label1.Text = "Host";
            // 
            // reset
            // 
            reset.Location = new Point(9, 139);
            reset.Name = "reset";
            reset.Size = new Size(226, 38);
            reset.TabIndex = 6;
            reset.Text = "Reset Configs";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 219);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Wifi Controller";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            mainTab.ResumeLayout(false);
            mainTab.PerformLayout();
            configs.ResumeLayout(false);
            configs.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button on;
        private Button off;
        private Label status;
        private Button validar;
        private TabControl tabControl1;
        private TabPage mainTab;
        private TabPage configs;
        private Label label1;
        private TextBox hostTxt;
        private Label label3;
        private Label label2;
        private TextBox pswTxt;
        private TextBox userTxt;
        private Button reset;
    }
}
