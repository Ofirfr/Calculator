using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double total;
        String current;
        List<double> thelist = new List<double>();
        List<int> where = new List<int>();
        List<int> what = new List<int>();
        Boolean firstIsNeg = false;
        Boolean negUsed = false;
        public Form1()
        {
            InitializeComponent();
            button11.Text = "0";
            button1.Text = "1";
            button2.Text = "2";
            button3.Text = "3";
            button4.Text = "4";
            button5.Text = "5";
            button6.Text = "6";
            button7.Text = "7";
            button8.Text = "8";
            button9.Text = "9";
            button13.Text = "+";
            button14.Text = "-";
            button15.Text = "*";
            button16.Text = "/";
            label1.Text = "";
        }

        private void number_Click(object sender, EventArgs e)
        {
            if (thelist.Count == 0&&!firstIsNeg&&total==0)
            {
                label1.Text = "";

            }

            Button b = (Button)sender;
            String n = "";
            if (total == 0)
            {
                total = Convert.ToInt32(b.Text);
                label1.Text = label1.Text+b.Text;
                current = b.Text;
                total = 1;
            }
            else
            {
                
                n = label1.Text;
                n += b.Text;
                current = current+b.Text;
                label1.Text = n;
            }
        }

        private void PlusMinus(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                label1.Text += b.Text;
                if (b.Text == "-")
                {
                    negUsed = true;
                    if (thelist.Count == 0 && current == "")
                    {
                        firstIsNeg = true;
                        negUsed = false;
                        return;
                    }
                    total = -Convert.ToInt32(current);
                }
                else
                {
                    total = Convert.ToInt32(current);
                }
            }catch(Exception ex)
            {
                label1.Text = "Error!";
                return;
            }
            current = "";
           
            thelist.Add(total);
            total = 0;
        }


       

        private void KafulHelkey(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                label1.Text += b.Text;
                if (b.Text == "/")
                {
                    what.Add(1);
                }
                else
                {
                    what.Add(2);
                }
                total = Convert.ToInt32(current);
            }catch(Exception ex)
            {
                label1.Text = "Error!";
                return;
            }
            current = "";
            thelist.Add(total);
            total = 0;
            where.Add(thelist.Count);
        }
        public void equals_Click(object sender, EventArgs e)
        {
            try
            {
                total = Convert.ToInt32(current);
                if (firstIsNeg)
                {
                    double temp = thelist[0];
                    temp = temp - temp - temp;
                    thelist[0] = temp;

                }


                current = "";
                int counter = 0;
                thelist.Add(total);
                total = 0;
                for (int i = 0; i < where.Count; i++)
                {
                    if (i > 0)
                    {
                        if (where[i] - 1 > where[i - 1])
                        {
                            counter = 0;
                        }
                    }
                    if (what[i] == 1)
                    {
                        thelist[where[i] - counter - 1] = thelist[where[i - counter] - 1] / thelist[where[i]];
                        counter++;
                        thelist[where[i]] = 0;
                    }
                    else
                    {
                        thelist[where[i] - counter - 1] = thelist[where[i - counter] - 1] * thelist[where[i]];
                        counter++;
                        thelist[where[i]] = 0;
                    }
                }
                for (int i = 0; i < thelist.Count; i++)
                {
                    total += thelist[i];
                }
            }catch(Exception ex)
            {
                label1.Text = "Error!";
                return;
            }
            if (negUsed)
            {
                double temp = total;
                temp = temp - temp - temp;
                total = temp;
            }
            label1.Text = total.ToString();
            thelist.Clear();
            what.Clear();
            where.Clear();
            current = "";
            negUsed = false;
            firstIsNeg = false;
            total = 0;
        }

        private void clear(object sender, EventArgs e)
        {
            thelist.Clear();
            what.Clear();
            where.Clear();
            current = "";
            total = 0;
            label1.Text = "";
            firstIsNeg = false;
        }
    }

}
