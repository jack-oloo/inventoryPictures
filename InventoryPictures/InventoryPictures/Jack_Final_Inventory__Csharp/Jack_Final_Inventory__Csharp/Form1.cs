using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack_Final_Inventory__Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel.Enabled = true;
            // TODO: This line of code loads data into the 'computerInventoryDataSet.Computers' table. You can move, or remove it, as needed.
            this.computersTableAdapter.Fill(this.computerInventoryDataSet.Computers);
            computersBindingSource.DataSource = this.computerInventoryDataSet.Computers;




            var query = from o in this.computerInventoryDataSet.Computers
                        where o.Product_ID.Contains(cmbSearch.Text) || o.Name == cmbSearch.Text || o.Description == cmbSearch.Text || o.Price == cmbSearch.Text || o.Quantity.Contains(cmbSearch.Text)
                        select o;
            //computersBindingSource1.DataSource = query.ToList();
            cmbSearch.DataSource = query.ToList();
            cmbSearch.DisplayMember = "Name";
            cmbSearch.ValueMember = "Product_ID";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtProdID.Focus();
                this.computerInventoryDataSet.Computers.AddComputersRow(this.computerInventoryDataSet.Computers.NewComputersRow());
                computersBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                computersBindingSource.ResetBindings(false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtProdID.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            panel.Enabled = false;
            computersBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                computersBindingSource.EndEdit();
                computersTableAdapter.Update(this.computerInventoryDataSet.Computers);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                computersBindingSource.ResetBindings(false);
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            computersBindingSource.Position = cmbSearch.SelectedIndex;


            if (cmbSearch.SelectedIndex == 0)
            {
                pictureBox.Image = Properties.Resources.Flex5_14;
            }
            if (cmbSearch.SelectedIndex == 1)
            {
                pictureBox.Image = Properties.Resources.Lenovoideapad_320_156;
            }
            if (cmbSearch.SelectedIndex == 2)
            {
                pictureBox.Image = Properties.Resources.LenovoIdeaPad_173;
            }
            if (cmbSearch.SelectedIndex == 3)
            {
                pictureBox.Image = Properties.Resources.Yoga_920_14;
            }
            if (cmbSearch.SelectedIndex == 4)
            {
                pictureBox.Image = Properties.Resources.Miix320;
            }
            if (cmbSearch.SelectedIndex == 5)
            {
                pictureBox.Image = Properties.Resources.Flex5_14;
            }
            if (cmbSearch.SelectedIndex == 6)
            {
                pictureBox.Image = Properties.Resources.Lenovoideapad_320_156;
            }
            if (cmbSearch.SelectedIndex == 7)
            {
                pictureBox.Image = Properties.Resources.Yoga910_14;
            }
            if (cmbSearch.SelectedIndex == 8)
            {
                pictureBox.Image = Properties.Resources.Flex5_14;
            }
            if (cmbSearch.SelectedIndex == 9)
            {
                pictureBox.Image = Properties.Resources.lenovohero;
            }
        }
    }
    }


