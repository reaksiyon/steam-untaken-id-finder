using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace steamdigitfinder
{
    public partial class Form1 : Form
    {
        int sayac = 1000;
        
        string gelenbilgiler = "";
        public Form1()
        {
            
            InitializeComponent();
            comboBox1.Text = "4digit";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            initSayac();
            search();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            gelenbilgiler = "";
            sayac++;
            search();
        }

        public void initSayac()
        {
            if(comboBox1.Text == "4digit")
            {
                sayac = 1000;
            }else
            {
                sayac = 10000;
            }


        }
        public void search()
        {
            
            while (gelenbilgiler != "Steam Community :: Error")
            {
                try { 
                string hedef = "https://steamcommunity.com/id/" + sayac;
                WebRequest istek = HttpWebRequest.Create(hedef);
                WebResponse yanıt;
                yanıt = istek.GetResponse();
                StreamReader bilgiler = new StreamReader(yanıt.GetResponseStream());
                string gelen = bilgiler.ReadToEnd();
                int baslangic = gelen.IndexOf("<title>") + 7;
                int bitis = gelen.Substring(baslangic).IndexOf("</title>");
                gelenbilgiler = gelen.Substring(baslangic, bitis);
                label1.Text = ("SEARCHING:" + sayac);
                sayac++;
                System.Threading.Thread.Sleep(1);
                }
                catch(Exception Ex)
                {


                }
            }

            label1.Text = ("FOUND!:" + (sayac-1));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
