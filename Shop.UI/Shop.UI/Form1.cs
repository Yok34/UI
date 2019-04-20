using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GunShop;

namespace Shop.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var LoadPicture = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var lp = LoadPicture.ShowDialog(this);
            if (lp == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(LoadPicture.FileName);
            }

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            var ad = new AddGun(new Specifications { ProductionDate = DateTime.Now } );
            if (ad.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(ad.Specifications);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Specifications)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox1.SelectedItem is Specifications;
        }

        

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var item = (Specifications)listBox1.Items[index];
                var ad = new AddGun(item);
                if (ad.ShowDialog(this) == DialogResult.OK)
                {
                    listBox1.Items.Remove(item);
                    listBox1.Items.Insert(index, item);
                }
            }

        }
    }
}
