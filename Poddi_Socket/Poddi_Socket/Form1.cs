using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Poddi_Socket
{
    public partial class Form1 : Form
    {
        SynchronousSocketListener server;
        Thread t1;
        public Form1()
        {
            InitializeComponent();
            server = new SynchronousSocketListener();
            t1 = new Thread(new ThreadStart(server.StartListening));
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            btn_Server.Enabled = false;
            t1.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s;
            if(!server.connessione())
            {
                richTextBox1.Text = "Aspettando connessione";
            }
            else
            {
                richTextBox1.Text = "Connesso";
            }
            s = server.dataRicevuti();
            if (s!="")
            {
                richTextBox2.Text = richTextBox2.Text + s;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
