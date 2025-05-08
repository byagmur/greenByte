using System.Drawing;
using System.Windows.Forms;

namespace greenByte.Pages
{
    partial class SeraYonetimPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panel1;
        private Label labelBaslik;
        private DataGridView dataGridViewSeralar;
        private Panel panelButonlar;
        private Button btnEkle;
        private Button btnDuzenle;
        private Button btnSil;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewSeralar = new System.Windows.Forms.DataGridView();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.panelButonlar = new System.Windows.Forms.Panel();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeralar)).BeginInit();
            this.panelButonlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewSeralar);
            this.panel1.Controls.Add(this.labelBaslik);
            this.panel1.Controls.Add(this.panelButonlar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(998, 616);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewSeralar
            // 
            this.dataGridViewSeralar.AllowUserToAddRows = false;
            this.dataGridViewSeralar.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSeralar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeralar.Location = new System.Drawing.Point(15, 55);
            this.dataGridViewSeralar.MultiSelect = false;
            this.dataGridViewSeralar.Name = "dataGridViewSeralar";
            this.dataGridViewSeralar.ReadOnly = true;
            this.dataGridViewSeralar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeralar.Size = new System.Drawing.Size(968, 496);
            this.dataGridViewSeralar.TabIndex = 4;
            // 
            // labelBaslik
            // 
            this.labelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelBaslik.Location = new System.Drawing.Point(15, 15);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(968, 40);
            this.labelBaslik.TabIndex = 3;
            this.labelBaslik.Text = "Sera Yönetimi";
            // 
            // panelButonlar
            // 
            this.panelButonlar.Controls.Add(this.btnEkle);
            this.panelButonlar.Controls.Add(this.btnDuzenle);
            this.panelButonlar.Controls.Add(this.btnSil);
            this.panelButonlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButonlar.Location = new System.Drawing.Point(15, 551);
            this.panelButonlar.Name = "panelButonlar";
            this.panelButonlar.Size = new System.Drawing.Size(968, 50);
            this.panelButonlar.TabIndex = 5;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEkle.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(11, 10);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 30);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDuzenle.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnDuzenle.Location = new System.Drawing.Point(116, 10);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(100, 30);
            this.btnDuzenle.TabIndex = 1;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Brown;
            this.btnSil.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(221, 10);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 30);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            // 
            // SeraYonetimPage
            // 
            this.Controls.Add(this.panel1);
            this.Name = "SeraYonetimPage";
            this.Size = new System.Drawing.Size(998, 616);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeralar)).EndInit();
            this.panelButonlar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}