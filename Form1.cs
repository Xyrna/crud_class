using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            DataView dv = DAL.SelectUser();
            dataGridView1.DataSource = dv;
        }

        private void select_Click(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            
            string name = textBoxName.Text;
            if (name == "")
            {
                MessageBox.Show("Please fill the name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = DAL.CreateUser(name);
            if(!result)
            {
                MessageBox.Show("Error while creating the user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillDataGridView();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text;
            string name = textBoxName.Text;
            if (id == "" || name == "")
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = DAL.UpdateUser(id, name);
            if (!result)
            {
                MessageBox.Show("Error while updating the user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillDataGridView();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text;
            if (id == "")
            {
                MessageBox.Show("Please fill the id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool result = DAL.DeleteUser(id);
            if (!result)
            {
                MessageBox.Show("Error while deleting the user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillDataGridView();
        }
    }
}
