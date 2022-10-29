using System;
using System.Windows.Forms;

namespace MyContact
{
    public partial class frmBox : Form
    {
        IContactRepository repository;
        public frmBox()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void frmBox_Load(object sender, EventArgs e)
        {

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
                bool isSuccess = repository.Insert(name.Text, details.Text);

                if (isSuccess == true) {
                    MessageBox.Show("عملیات انجام شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات شکست خورد.","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
