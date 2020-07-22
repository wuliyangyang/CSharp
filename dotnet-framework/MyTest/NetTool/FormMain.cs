using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NetTool.UserControls;
using CommonLibs;
using LogTool;
using log4net;

namespace NetTool
{
    public partial class FormMain : Form
    {
      
        private List<IPanelUser> panelList = new List<IPanelUser>();
        private List<TreeNode> nodesList = new List<TreeNode>();
        private List<TabPage> pagesList = new List<TabPage>();
        public FormMain()
        {
            InitializeComponent();
            this.Size = new Size(2100, 1200);
        }

        #region Remake tabControl Label
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)    //当前Tab页的样式
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.Blue, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshFore = Brushes.BlueViolet;
            }
            else    //其余Tab页的样式
            {
                fntTab = e.Font;
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshFore = new SolidBrush(Color.Black);

            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 12, e.Bounds.Top);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 4, e.Bounds.Top + 4);
            e.DrawFocusRectangle();

        }
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 12, r.Top, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    //bool isok = MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (true)
                    {
                        this.tabControl1.TabPages[i].Parent = null;
                       break;
                    }
                }
            }
        }
        #endregion

        private void CreatPanel(string CurrentNodeName, string parentNodeName, SocketType type,Model model)
        {
            switch (model)
            {
                case Model.Tcp:
                    AddPanel(CurrentNodeName, parentNodeName, type);
                    break;
                case Model.Serial:
                    AddPanel(CurrentNodeName, parentNodeName, type);
                    break;
                case Model.NMQ:
                    break;
                default:
                    break;
            }
            
        }
        private void AddPanel(string CurrentNodeName, string parentNodeName, SocketType type)
        {
            IPanelUser panel=null;
            switch (type)
            {
                case SocketType.TcpServer:
                    panel = new TcpPanel(type);
                    break;
                case SocketType.TcpClient:
                    panel = new TcpPanel(type);
                    break;
                case SocketType.SerialPort:
                    panel = new SerialPanel();
                    break;
                case SocketType.Rep:
                    break;
                case SocketType.Req:
                    break;
                case SocketType.Pub:
                    break;
                case SocketType.Sub:
                    break;
                default:
                    break;
            }
            panel.Evt_ActionStart += Panel_Evt_ActionStart;

            TabPage page = new TabPage();
            page.Text = CurrentNodeName;
            page.Controls.Add((UserControl)panel);
            this.tabControl1.TabPages.Add(page);

            TreeNode tn = new TreeNode();
            tn.Text = CurrentNodeName;
            treeView1.Nodes[parentNodeName].Nodes[CurrentNodeName].Nodes.Add(tn);

            this.nodesList.Add(tn);
            this.pagesList.Add(page);
            this.panelList.Add(panel);
        }
        /*
        private void AddTcpPanel(string CurrentNodeName, string parentNodeName, SocketType type)
        {
            TcpPanel panel = new TcpPanel(type);
            panel.Evt_ActionStart += Panel_Evt_ActionStart;

            TabPage page = new TabPage();
            page.Text = CurrentNodeName;
            page.Controls.Add(panel);
            this.tabControl1.TabPages.Add(page);

            TreeNode tn = new TreeNode();
            tn.Text = CurrentNodeName;
            treeView1.Nodes[parentNodeName].Nodes[CurrentNodeName].Nodes.Add(tn);

            this.nodesList.Add(tn);
            this.pagesList.Add(page);
            this.panelList.Add(panel);
        }
        private void AddSerialPortPanel(string CurrentNodeName, string parentNodeName, SocketType type)
        {
            SerialPanel panel = new SerialPanel();
            panel.Evt_ActionStart += Panel_Evt_ActionStart;
            TabPage page = new TabPage();
            page.Text = CurrentNodeName;
            page.Controls.Add(panel);
            this.tabControl1.TabPages.Add(page);

            TreeNode tn = new TreeNode();
            tn.Text = CurrentNodeName;
            treeView1.Nodes[parentNodeName].Nodes[CurrentNodeName].Nodes.Add(tn);

            this.nodesList.Add(tn);
            this.pagesList.Add(page);
            this.panelList.Add(panel);
        }
        */
        private void Panel_Evt_ActionStart(object sender)
        {
            IPanelUser panel = sender as IPanelUser;
            switch (panel.Model)
            {
                case Model.Tcp:
                    UpdateTcpNodeText(sender);
                    break;
                case Model.Serial:
                    UpdateSerialNodeText(sender);
                    break;
                case Model.NMQ:
                    break;
                default:
                    break;
            }
        }

        private void UpdateTcpNodeText(object sender)
        {
            TcpPanel panel = sender as TcpPanel;
            int index = panelList.IndexOf(panel);
            nodesList[index].Text = nodesList[index].Parent.Text + ":" + panel.IP + ":" + panel.Port;
        }
        private void UpdateSerialNodeText(object sender)
        {
            SerialPanel panel = sender as SerialPanel;
            int index = panelList.IndexOf(panel);
            nodesList[index].Text = nodesList[index].Parent.Text + ":" + panel.PortName;
        }
        private void RemoveNode(int i)
        {
            string firstNodeName = nodesList[i].Parent.Parent.Name;
            string secondNoneName = nodesList[i].Parent.Name;
            treeView1.Nodes[firstNodeName].Nodes[secondNoneName].Nodes.Remove(nodesList[i]);

            panelList[i].MDispose();
            this.tabControl1.TabPages.RemoveAt(i);
            nodesList.RemoveAt(i);
            pagesList.RemoveAt(i);
            panelList.RemoveAt(i);
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0 || e.Node.Level == 1) return;
            TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
            int index = nodesList.IndexOf(tn);
            TabPage page = pagesList[index];
            if (page.Parent==null)
            {
                this.tabControl1.Controls.Add(page);
            }
            this.tabControl1.SelectedTab = page;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                {
                    contextMenuStrip1.Items[i].Enabled = false; 
                }
            }
            if (e.Node.Level==1)
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = false;
            }
            if (e.Node.Level == 2)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = true;
            }
            TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
            if (tn!=null)
            {
                treeView1.SelectedNode = tn;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string currentNodeName = this.treeView1.SelectedNode.Name;
            string parentNodeName = this.treeView1.SelectedNode.Parent.Name;
            switch (currentNodeName)
            {
                case "TcpClient":
                    CreatPanel(currentNodeName, parentNodeName, SocketType.TcpClient,Model.Tcp);
                    break;
                case "TcpServer":
                    CreatPanel(currentNodeName, parentNodeName, SocketType.TcpServer,Model.Tcp);
                    break;
                case "SerialPort":
                    CreatPanel(currentNodeName, parentNodeName, SocketType.SerialPort,Model.Serial);
                    break;
                case "PubSocket":
                    break;
                case "SubSocket":
                    break;
                case "ReqSocket":
                    break;
                case "RepSocket":
                    break;
                default:
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNode(nodesList.IndexOf(this.treeView1.SelectedNode));
        }
    }
}
