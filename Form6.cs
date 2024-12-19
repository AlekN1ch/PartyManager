using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RandA
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (BudjNow > 0)
            {
                try
                {
                    
                    BudjNow = Process(BudjNow, int.Parse(textBox2.Text));
                    RenderLabels(BudjBegin.ToString(), BudjNow.ToString());
                    
                }
                catch { MessageBox.Show("Строка затрат имела неверный формат"); }
            }
            else  { MessageBox.Show("Средства закончились"); }
            
        }
        public int BudjBegin = 0;
        public int BudjNow = 0;
        public void RenderLabels(string budjB,string budjNow)
        { 
            label5.Text=budjB;
            label6.Text=budjNow;
        }
        public int Process(int budj,int razn)
        {
            int res = budj - razn;
            if (res < 0)
            {
                res = res + razn;
                MessageBox.Show("Средств недостаточно");
                return res;
            }
            else { listBox1.Items.Add(textBox1.Text + "-" + int.Parse(textBox2.Text).ToString());
                Form4.budjNow = BudjNow;
                return res; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            BudjBegin=Form4.budjNow;
            BudjNow = BudjBegin;
            RenderLabels(BudjBegin.ToString(), BudjNow.ToString());
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form4.budjNow= BudjNow;
        }
    }
}
