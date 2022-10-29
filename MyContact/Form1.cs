using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContact
{
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgContact.AutoGenerateColumns = false;
            dgContact.DataSource = repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmBox frm = new frmBox();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow != null)
            {
                string name = dgContact.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($"آیا از حذف {name} مطمئنید؟", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(id);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("انتخاب نکردید.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow != null)
            {
                int id = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
                frmBox frm = new frmBox();
                frm.id = id;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("انتخاب نکردید.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContact.DataSource = repository.Search(txtSearch.Text);
        }
    }
}
