namespace greenByte.Forms
{
    partial class FormMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonSeraYonetimPage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonWaterControlPage = new System.Windows.Forms.Button();
            this.buttonMouistControlPage = new System.Windows.Forms.Button();
            this.buttonLightControlPage = new System.Windows.Forms.Button();
            this.buttonTempControlPage = new System.Windows.Forms.Button();
            this.buttonDataControlPage = new System.Windows.Forms.Button();
            this.buttonUserControlPage = new System.Windows.Forms.Button();
            this.buttonDashboardPage = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(1225, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "GreenByte Sera Kontrol Paneli";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelMenu.Controls.Add(this.buttonSeraYonetimPage);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.buttonWaterControlPage);
            this.panelMenu.Controls.Add(this.buttonMouistControlPage);
            this.panelMenu.Controls.Add(this.buttonLightControlPage);
            this.panelMenu.Controls.Add(this.buttonTempControlPage);
            this.panelMenu.Controls.Add(this.buttonDataControlPage);
            this.panelMenu.Controls.Add(this.buttonUserControlPage);
            this.panelMenu.Controls.Add(this.buttonDashboardPage);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 43);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(213, 640);
            this.panelMenu.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 586);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 54);
            this.panel2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "admin";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(213, 43);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(4);
            this.panelMain.Size = new System.Drawing.Size(1012, 640);
            this.panelMain.TabIndex = 2;
            // 
            // buttonSeraYonetimPage
            // 
            this.buttonSeraYonetimPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonSeraYonetimPage.FlatAppearance.BorderSize = 0;
            this.buttonSeraYonetimPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeraYonetimPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSeraYonetimPage.ForeColor = System.Drawing.Color.White;
            this.buttonSeraYonetimPage.Image = global::greenByte.Properties.Resources.game_icons__greenhouse;
            this.buttonSeraYonetimPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeraYonetimPage.Location = new System.Drawing.Point(12, 316);
            this.buttonSeraYonetimPage.Name = "buttonSeraYonetimPage";
            this.buttonSeraYonetimPage.Size = new System.Drawing.Size(141, 34);
            this.buttonSeraYonetimPage.TabIndex = 9;
            this.buttonSeraYonetimPage.Text = "Sera Yönetimi";
            this.buttonSeraYonetimPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSeraYonetimPage.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::greenByte.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonWaterControlPage
            // 
            this.buttonWaterControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonWaterControlPage.FlatAppearance.BorderSize = 0;
            this.buttonWaterControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWaterControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonWaterControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonWaterControlPage.Image = global::greenByte.Properties.Resources.bi__moisture;
            this.buttonWaterControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWaterControlPage.Location = new System.Drawing.Point(9, 274);
            this.buttonWaterControlPage.Name = "buttonWaterControlPage";
            this.buttonWaterControlPage.Size = new System.Drawing.Size(173, 34);
            this.buttonWaterControlPage.TabIndex = 7;
            this.buttonWaterControlPage.Text = "Su Deposu Kontrol";
            this.buttonWaterControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonWaterControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonMouistControlPage
            // 
            this.buttonMouistControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonMouistControlPage.FlatAppearance.BorderSize = 0;
            this.buttonMouistControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMouistControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMouistControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonMouistControlPage.Image = global::greenByte.Properties.Resources.carbon__soil_moisture_field;
            this.buttonMouistControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMouistControlPage.Location = new System.Drawing.Point(12, 233);
            this.buttonMouistControlPage.Name = "buttonMouistControlPage";
            this.buttonMouistControlPage.Size = new System.Drawing.Size(132, 33);
            this.buttonMouistControlPage.TabIndex = 6;
            this.buttonMouistControlPage.Text = "Nem Kontrol";
            this.buttonMouistControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMouistControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonLightControlPage
            // 
            this.buttonLightControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonLightControlPage.FlatAppearance.BorderSize = 0;
            this.buttonLightControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLightControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonLightControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonLightControlPage.Image = global::greenByte.Properties.Resources.mingcute__light_fill;
            this.buttonLightControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLightControlPage.Location = new System.Drawing.Point(14, 193);
            this.buttonLightControlPage.Name = "buttonLightControlPage";
            this.buttonLightControlPage.Size = new System.Drawing.Size(119, 34);
            this.buttonLightControlPage.TabIndex = 5;
            this.buttonLightControlPage.Text = "Işık Kontrol";
            this.buttonLightControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLightControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonTempControlPage
            // 
            this.buttonTempControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonTempControlPage.FlatAppearance.BorderSize = 0;
            this.buttonTempControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTempControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTempControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonTempControlPage.Image = global::greenByte.Properties.Resources.fluent__temperature_icon;
            this.buttonTempControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTempControlPage.Location = new System.Drawing.Point(12, 151);
            this.buttonTempControlPage.Name = "buttonTempControlPage";
            this.buttonTempControlPage.Size = new System.Drawing.Size(141, 36);
            this.buttonTempControlPage.TabIndex = 4;
            this.buttonTempControlPage.Text = "Sıcaklık Kontrol";
            this.buttonTempControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTempControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonDataControlPage
            // 
            this.buttonDataControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonDataControlPage.FlatAppearance.BorderSize = 0;
            this.buttonDataControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDataControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonDataControlPage.Image = global::greenByte.Properties.Resources.data_manager_icon;
            this.buttonDataControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDataControlPage.Location = new System.Drawing.Point(12, 108);
            this.buttonDataControlPage.Name = "buttonDataControlPage";
            this.buttonDataControlPage.Size = new System.Drawing.Size(134, 37);
            this.buttonDataControlPage.TabIndex = 3;
            this.buttonDataControlPage.Text = "Veri Kontrolü";
            this.buttonDataControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDataControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonUserControlPage
            // 
            this.buttonUserControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonUserControlPage.FlatAppearance.BorderSize = 0;
            this.buttonUserControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonUserControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonUserControlPage.Image = global::greenByte.Properties.Resources.mynaui__users_group_solid;
            this.buttonUserControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUserControlPage.Location = new System.Drawing.Point(12, 66);
            this.buttonUserControlPage.Name = "buttonUserControlPage";
            this.buttonUserControlPage.Size = new System.Drawing.Size(159, 36);
            this.buttonUserControlPage.TabIndex = 2;
            this.buttonUserControlPage.Text = "Kullanıcı  Yönetimi";
            this.buttonUserControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUserControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonDashboardPage
            // 
            this.buttonDashboardPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashboardPage.FlatAppearance.BorderSize = 0;
            this.buttonDashboardPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboardPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDashboardPage.ForeColor = System.Drawing.Color.White;
            this.buttonDashboardPage.Image = global::greenByte.Properties.Resources.dashboard_icon1;
            this.buttonDashboardPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboardPage.Location = new System.Drawing.Point(12, 25);
            this.buttonDashboardPage.Name = "buttonDashboardPage";
            this.buttonDashboardPage.Size = new System.Drawing.Size(121, 35);
            this.buttonDashboardPage.TabIndex = 1;
            this.buttonDashboardPage.Text = " Dashboard";
            this.buttonDashboardPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDashboardPage.UseVisualStyleBackColor = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = global::greenByte.Properties.Resources._24px_close_icon;
            this.buttonClose.Location = new System.Drawing.Point(1186, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.buttonClose.Size = new System.Drawing.Size(35, 43);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 683);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonDashboardPage;
        private System.Windows.Forms.Button buttonUserControlPage;
        private System.Windows.Forms.Button buttonDataControlPage;
        private System.Windows.Forms.Button buttonTempControlPage;
        private System.Windows.Forms.Button buttonLightControlPage;
        private System.Windows.Forms.Button buttonMouistControlPage;
        private System.Windows.Forms.Button buttonWaterControlPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonSeraYonetimPage;
    }
}