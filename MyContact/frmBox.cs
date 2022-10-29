using System;
using System.Windows.Forms;
using System.Data;

namespace MyContact
{
    public partial class frmBox : Form
    {
        IContactRepository repository;
        public int id = 00;
        public frmBox()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void frmBox_Load(object sender, EventArgs e)
        {
            if (id == 00)
            {
                this.Text = "افزودن";
            }
            else
            {
                this.Text = "ویرایش";
                DataTable dt = repository.SelectRow(id);
                name.Text = dt.Rows[0][1].ToString();
                details.Text = dt.Rows[0][2].ToString();
            }
        }

        bool ValidateInputs()
        {
            bool isValid = true;

            if (name.Text == "" && details.Text == "")
            {
                isValid = false;
                MessageBox.Show("لطفا مشخصات را تکمیل نمایید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess;

                if (id == 00)
                {
                    isSuccess = repository.Insert(name.Text, details.Text);
                }
                else
                {
                    isSuccess = repository.Update(id,name.Text, details.Text);
                }

                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات انجام شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات شکست خورد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
