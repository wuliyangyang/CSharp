using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Messages;
using Renci.SshNet.Sftp;
using Renci.SshNet.Security.Cryptography;


namespace SSHTest
{
    public partial class Form1 : Form
    {
        SshClient client;
        public Form1()
        {
            InitializeComponent();
            InitSSH();
        }

        private void InitSSH()
        {
            string SSHHost = "172.15.0.36";        // SSH地址
            int SSHPort = 22;              // SSH端口
            string SSHUser = "soft";           // SSH用户名
            string SSHPassword = "123456";           // SSH密码

            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSHHost, SSHPort, SSHUser, SSHPassword);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);
            // SSH密码
            try
            {
                client = new SshClient(connectionInfo);
                client.Connect();

                var cmd = client.CreateCommand("ls -l");
                var res = cmd.Execute();
                Console.Write(res);
        

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}
