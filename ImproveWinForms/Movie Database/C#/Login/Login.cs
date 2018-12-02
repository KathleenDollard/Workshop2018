using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        private const int NormalUserIndex = 0;
        private const int AdminUserIndex = 1;
        public Login() => InitializeComponent();

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userType = "";
            // TODO: What should we do if combo box is some other value
            if (comboBox1.SelectedIndex == NormalUserIndex
                || comboBox1.SelectedIndex == AdminUserIndex)
            {
                userType = comboBox1.SelectedItem.ToString();
            }
            bool success = DataAccess.Login(userType, textBox1.Text, textBox2.Text);
            if (success)
            {
                if (userType.Equals("admin"))
                {
                    new Form2().Show();
                }
                else if (userType.Equals("normal"))
                {
                    new Form3().Show();
                }
            }
            else
            {
                MessageBox.Show("UnSuccessful");
            }
            Hide();
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Hide();
        }
    }
}
