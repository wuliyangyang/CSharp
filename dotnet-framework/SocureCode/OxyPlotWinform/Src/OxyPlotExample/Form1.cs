using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlotDemoLibs;

namespace OxyPlotExampleBrowser
{
    public partial class Form1 : Form
    {
        readonly  MainWindowViewModel vm = new MainWindowViewModel();
        public Form1()
        {
            InitializeComponent();

            InitTree();
        }

        private void InitTree()
        {
            TreeNode node = null;
            foreach (var ex in vm.Examples)
            {
                if (null == node || node.Text != ex.Category)
                {
                    node = new TreeNode(ex.Category);
                    treeView1.Nodes.Add(node);
                }
                var exNode = new TreeNode(ex.Title) {Tag = ex};
                node.Nodes.Add(exNode);
                if (ex == vm.SelectedExample)
                {
                    treeView1.SelectedNode = exNode;
                }
            }
            treeView1.AfterSelect+= TreeView1OnAfterSelect;
        }

        private void TreeView1OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            vm.SelectedExample = e.Node.Tag as ExampleInfo;
            InitPlot();
        }

        private void InitPlot()
        {
            plotView1.Model = vm.SelectedExample != null ? vm.SelectedExample.PlotModel : null;
            plotView1.Controller = vm.SelectedExample != null ? vm.SelectedExample.PlotController : null;
        }
    }
}
