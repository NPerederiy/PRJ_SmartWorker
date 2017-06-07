using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SmartWorker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*---search-menu---*/
            Search_menu.Location = new Point(-120, 0);
            Search_menu_comboBox_OfferType.SelectedIndex = 0;
            Search_menu_comboBox_PropType.SelectedIndex = 0;
            Search_menu_comboBox_Distinct.SelectedIndex = 0;
            /*-----------------*/
        }

        private int x = 0;
        private int y = 0;

        private void Menu_button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        bool IsSubmenuOpened = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Ви впевнені, що хочете вийти з програми?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void ShowHideSubmenu()
        {
            if (!IsSubmenuOpened)
            {
                while (Search_menu.Location.X < 60)
                {
                    Search_menu.Location = new Point(Search_menu.Location.X + 10, Search_menu.Location.Y);
                   // Thread.Sleep(1);
                    this.Refresh();
                }
                IsSubmenuOpened = !IsSubmenuOpened;
            }
            else
            {
                HideSubmenu();
            }
        }

        private void HideSubmenu()
        {
            if (IsSubmenuOpened)
            {
                while (Search_menu.Location.X > -2 * 60)
                {
                    Search_menu.Location = new Point(Search_menu.Location.X - 10, Search_menu.Location.Y);
                    // Thread.Sleep(1);
                    this.Refresh();
                }
                IsSubmenuOpened = !IsSubmenuOpened;
            }
        }

        private void Menu_button_Property_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Submenu_button_PropertyList_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Menu_button_Contacts_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Submenu_button_Contacts_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Menu_button_Chat_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Submenu_button_Chat_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Menu_button_Help_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Submenu_button_Help_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void Submenu_button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'propertyDBDataSet.Property' table. You can move, or remove it, as needed.
            this.propertyTableAdapter.Fill(this.propertyDBDataSet.Property);

        }

        private void selectAllToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.propertyTableAdapter.SelectAll(this.propertyDBDataSet.Property);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            Search_menu.Visible = true;
        }

        private void Menu_button_Search_Click(object sender, EventArgs e)
        {
            ShowHideSubmenu();
        }

        private void bindingNavigator1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void bindingNavigator1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void Search_menu_button_CleanAll_Click(object sender, EventArgs e)
        {
            Search_menu_PropID.Clear();
            Search_menu_comboBox_OfferType.SelectedIndex = 0;
            Search_menu_comboBox_PropType.SelectedIndex = 0;
            Search_menu_comboBox_Distinct.SelectedIndex = 0;
            Search_menu_Address.Clear();
            Search_menu_PriceFrom.Clear();
            Search_menu_PriceTo.Clear();
        }

        private void propertyDataGridView_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }
    }
}
