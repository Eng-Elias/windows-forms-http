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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            JsonElement res = await APIRequestModule.sendGetRequest("/authentication/hello/", true);

            JsonElement message;

            if (res.TryGetProperty("message", out message))
            {
                textBox1.Text = message.GetString();
            } else
            {
                textBox1.Text = "error";
            }
        }
    }
}
