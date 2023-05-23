using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            loginButton.BackColor = SystemColors.Highlight;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            loginButton.BackColor = SystemColors.HotTrack;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            Console.WriteLine(username);
            Console.WriteLine(password);

            try
            {
                JsonElement res = await APIRequestModule.sendPostRequest("/authentication/login/", new { username = username, password = password });

                JsonElement token;

                /*Console.WriteLine(res.TryGetProperty("token", out token));
                Console.WriteLine(token.GetString());*/
                if (res.TryGetProperty("token", out token))
                {
                    /*Console.WriteLine(res.GetProperty("token"));*/
                    /*Console.WriteLine(token.GetString());*/
                    APIRequestModule.setAuthToken(token.GetString());
                    /*Console.WriteLine(APIRequestModule.getAuthToken());*/
                    this.Hide();
                    new HomePage().Show();
                }
                else
                {
                    messageLabel.Text = "Authentication failed, try again.";
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
