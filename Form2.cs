using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace HyperlinkExtract
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories);

                listBox1.Items.AddRange(files
                    .Select(f => new ListItem
                    {
                        Display = Path.GetFileName(f),
                        Path = f
                    })
                    .ToArray());
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox1.IndexFromPoint(e.X, e.Y);

                if (index >= 0)
                {
                    listBox1.SelectedIndex = index;
                }
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListItem[] list = listBox1.Items.OfType<ListItem>().ToArray();

            listBox1.Items.Clear();

            if (textBox1.Text == string.Empty)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories);

                listBox1.Items.AddRange(files
                    .Select(f => new ListItem
                    {
                        Display = Path.GetFileName(f),
                        Path = f
                    })
                    .ToArray());
            }
            else
            {
                Regex regex = new Regex(textBox1.Text);

                foreach (ListItem item in list)
                {
                    if (regex.IsMatch(item.Display))
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }
    }
}
