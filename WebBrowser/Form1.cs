using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        //funkcja do nawigowania stron
        private void NavigateToPage()
        {
            toolStripStatusLabel1.Text = "Nawiązanie połączenia";//wyświetlenie na pasku stanu połączenia
            webBrowser1.Navigate(textBox1.Text);
        }

        //funkcja do zamknięcia programu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WebBrowser made by Michał Gołdyn");
        }
        //Przycisk "Przejdź"
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
        //Zaakceptowanie strony enterem
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }
        //wyświetlenie na pasku stanu połączenia
        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            toolStripStatusLabel1.Text = "Połączenie zakończone";
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }



        private void powróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void odświeżToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            toolStripStatusLabel1.Text = "Odświeżanie";
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
            toolStripStatusLabel1.Text = "Stop";
        }

        private void stronaStartowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            
            toolStripStatusLabel1.Text = "Strona główna";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress < e.MaximumProgress)
            {
                toolStripStatusLabel1.Text = "Ładowanie strony";
            }
            else
            {
                toolStripStatusLabel1.Text = "Połączenie zakończone";
            }
        }
        //wyświetlenie w textboxie strony załadowanej 
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }
    }
}
