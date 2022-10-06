using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poddi_SocketClient
{
    public partial class Form1 : Form
    {
        SynchronousSocketClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SynchronousSocketClient();
        }

        private void btn_Client_Click(object sender, EventArgs e)
        {
            btn_Client.Enabled = false;
            client.StartClient();
            btn_Client.Enabled = true;
        }
    }
}
