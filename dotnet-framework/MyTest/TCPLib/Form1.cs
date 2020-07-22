using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPLib
{
    public partial class Form1 : Form
    {
        private string _server_id;
        private int _port;

        private TCPServerManager serverManager;
        public Form1()
        {
            InitializeComponent();

        }
        private void InitServer()
        {
            _server_id = "127.0.0.1";
            _port = 6000;
            serverManager = new TCPServerManager(_server_id);
            serverManager.Start(_port);

        }
    }
}
