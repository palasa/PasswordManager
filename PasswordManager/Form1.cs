using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            string nums = "0123456789";
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = lowers.ToUpper();
            string symbols = "!@#$%^&*";

            StringBuilder sb = new StringBuilder();
            sb.Append(lowers);
            if (this.checkBox3.Checked)
                sb.Append(uppers);
            if (this.checkBox1.Checked)
                sb.Append(nums);
            if (this.checkBox4.Checked)
                sb.Append(symbols);
            char[] original = sb.ToString().ToCharArray();

            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    var t = item as TextBox;
                    t.Enabled = true;
                    StringBuilder pwd = new StringBuilder();
                    for (int i = 0; i < this.numericUpDown1.Value; i++)
                    {
                        pwd.Append(original[r.Next(0, original.Length)]);
                    }
                    t.Text = pwd.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    var t = item as TextBox;
                    t.Enabled = false;
                    t.Click += delegate
                    {
                        t.SelectAll();
                        t.Copy();
                    };
                }
            }
        }


    }
}
