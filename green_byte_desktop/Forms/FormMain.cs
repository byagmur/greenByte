using greenByte.Controls;
using greenByte.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace greenByte.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.buttonDashboardPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonUserControlPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonDataControlPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonLightControlPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonMouistControlPage.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonTempControlPage.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonWaterControlPage.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonSeraYonetimPage.Click += new System.EventHandler(this.buttonClose_Click);


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearAndAddControl(Control control)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Padding = new Padding(5);
        }

        private void buttonPage_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                panelMain.Controls.Clear();
                switch (clickedButton.Name)
                {
                    case "buttonDashboardPage":
                        clearAndAddControl(new AdminDashboardPage());
                        break; 
                    case "buttonUserControlPage":
                        clearAndAddControl(new UsersControlPage());
                        break;
                    case "buttonSeraYonetimPage":
                        clearAndAddControl(new SeraYonetimPage());
                        break;
                    //case "buttonDataControlPage":
                    //    clearAndAddControl(new DataControlPage());
                    //    break;
                    //case "buttonLightControlPage":
                    //    clearAndAddControl(new LightControlPage());
                    //    break;
                    //case "buttonMouistControlPage":
                    //    clearAndAddControl(new MoistureControlPage());
                    //    break;
                    //case "buttonTempControlPage":
                    //    clearAndAddControl(new TemperatureControlPage());
                    //    break;
                    //case "buttonWaterControlPage":
                    //    clearAndAddControl(new WaterControlPage());
                    //    break;

                    default:
                        clearAndAddControl(new AdminDashboardPage());
                        break;
                }

                //MessageBox.Show($"TablePanel kontrol sayısı: {tablePanel1.Controls.Count}");

            }
        }
    }
}
