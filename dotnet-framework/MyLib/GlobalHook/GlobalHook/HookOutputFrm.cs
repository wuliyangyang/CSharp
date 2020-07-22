﻿//HookOutputFrm.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using GlobalHook.Properties; 

namespace GlobalHook
{
    public partial class HookOutputFrm : Form
    {
        public delegate void SaveMessageEventHandler();//工具栏保存委托
        public static event SaveMessageEventHandler SaveAll;
        public static event SaveMessageEventHandler SaveKey;
        public static event SaveMessageEventHandler SaveMouse;

        public delegate void SetHideFrmEventHandler(bool yesdata);//设置项：任务栏隐藏委托
        public static event SetHideFrmEventHandler SetHideFrm;

        public delegate void SetShowFrmEventHandler(bool nodata);//设置项：任务栏显示委托
        public static event SetShowFrmEventHandler SetShowFrm;

        //public delegate void SetKeyEventHandler(string keydata);//设置快捷键委托
        //public static event SetKeyEventHandler SetKey;

        //自动保存委托
        public delegate void SetAutoSaveEventHandler(string path, string interval, bool keySelect, bool mouseSelect, string filename);
        public static event SetAutoSaveEventHandler SetAutoSave;

        //关闭自动保存委托
        public delegate void SetManualSaveEventHandler();
        public static event SetManualSaveEventHandler SetManualSave;

        public HookOutputFrm()
        {
            InitializeComponent();
            SaveAll += new SaveMessageEventHandler(HookOutputFrm_SaveAll);
            SaveKey += new SaveMessageEventHandler(HookOutputFrm_SaveKey);
            SaveMouse += new SaveMessageEventHandler(HookOutputFrm_SaveMouse);
            SetHideFrm += new SetHideFrmEventHandler(HookOutputFrm_SetHideFrm);
            SetShowFrm += new SetShowFrmEventHandler(HookOutputFrm_SetShowFrm);
            //SetKey += new SetKeyEventHandler(HookOutputFrm_SetKey);
            SetAutoSave += new SetAutoSaveEventHandler(HookOutputFrm_SetAutoSave);
            SetManualSave+=new SetManualSaveEventHandler(HookOutputFrm_SetManualSave);
        }

        KeyboardHook k_hook;//键盘监测
        MouseHook m_hook;//鼠标监测
        HelpProvider HP;//帮助文档
        private void HookOutputFrm_Load(object sender, EventArgs e)
        {
            k_hook = new KeyboardHook();
            m_hook = new MouseHook();
            k_hook.KeyDown += new KeyEventHandler(k_hook_KeyDown);//全局按键事件
            k_hook.Start();//安装键盘钩子           
            m_hook.MouseDown += new MouseEventHandler(m_hook_MouseDown);//全局点击事件
            m_hook.MouseMove += new MouseEventHandler(m_hook_MouseMove);//鼠标移动事件
            m_hook.Start();
            //状态栏显示
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += (ss, ee) => { toolStripStatusLabel2.Text = "系统时间：" + DateTime.Now.ToString(); };
            timer1.Start();
            //帮助文档实例
            HP = new HelpProvider();
            string Source = "Help.txt";
            HP.HelpNamespace = Source;
            HP.SetShowHelp(this, true);
            //是否自动保存
            if (Settings.Default.radAutoSaveState && !(Settings.Default.radManualSaveState))
            {
                DoSetAutoSave(Settings.Default.tbSavePathState, Settings.Default.tbTimeState, Settings.Default.chkKeyState, Settings.Default.chkMouseState, Settings.Default.tbName);
            }
            else
            {
                DoSetManualSave();
            }
            //保存后是否清除输出
            if(Settings.Default.radYesState&&!(Settings.Default.radNoState))
            {
                DoSetShowFrm(Settings.Default.radYesState);
            }
            else
                DoSetHideFrm(Settings.Default.radNoState);
            //是否隐藏运行
            if (Settings.Default.chkHideRun)
            {
                this.Hide();
                notifyIcon1.Visible = false;
            }
            else
            {
                this.Show();
                notifyIcon1.Visible = true;
            }
        }
        #region 工具栏事件
        //禁止监测键盘
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Text.Equals("禁止监测键盘"))
            {
                k_hook.Stop();//执行Stop方法终止键盘钩子
                toolStripButton1.Text = "开始键盘监测";
                toolStripButton1.Image = imageList1.Images[0];
            }
            else
            {
                k_hook.Start();
                toolStripButton1.Text = "禁止监测键盘";
                toolStripButton1.Image = imageList1.Images[1];
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripButton2.Text.Equals("禁止监测鼠标"))
            {
                m_hook.Stop();
                toolStripButton2.Text = "开始鼠标监测";
                toolStripButton2.Image = imageList1.Images[2];
            }
            else
            {
                m_hook.Start();
                toolStripButton2.Text = "禁止监测鼠标";
                toolStripButton2.Image = imageList1.Images[3];
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定清除当前输出面板吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ProcessFrm pFrm = new ProcessFrm();
            //pFrm.ShowDialog(this);//显示进程
            pFrm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveFrm saveFrm = new SaveFrm();
            saveFrm.ShowDialog(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            SetFrm setFrm = new SetFrm();
            setFrm.hookFrm = this;
            setFrm.ShowDialog(this);//设置窗口
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FilterFrm frm = new FilterFrm();
            frm.ShowDialog(this);
        }
        #endregion

        #region 通知栏事件
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
            this.ShowInTaskbar = true;
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Dispose();
            this.Close();
        }

        private void 进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4_Click(sender, e);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton5_Click(sender, e);
        }
        #endregion

        #region 其他事件

        StreamWriter sw;//实例化流
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount <= 0)
            {
                return;
            }
            if (MouseSelect && !KeySelect)
            {
                if (!File.Exists(strPath + "\\" + Name + ".txt"))
                {//没有则创建
                    FileStream fs = File.Create(strPath + "\\" + Name + ".txt");
                    fs.Close();
                    fs.Dispose();
                }
                try
                {
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        //追加保存和覆盖保存
                        sw = File.AppendText(strPath + "\\" + Name + ".txt");
                    }
                    else
                        sw = new StreamWriter(strPath + "\\" + Name + ".txt", false);

                    StringBuilder sb = new StringBuilder();
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        string temp = string.Empty;
                        if (dr.Cells["deviceName"].Value.ToString() == "鼠标")
                        {
                            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                            {
                                if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                                {
                                    continue;
                                }
                                temp += dr.Cells[i].Value + ";";
                            }
                            sb.AppendLine(temp);
                        }
                    }
                    sw.WriteLine(sb.ToString());
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        dataGridView1.Rows.Clear();//清理输出窗口
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }

            else if (KeySelect && !MouseSelect)
            {
                if (!File.Exists(strPath + "\\" + Name + ".txt"))
                {
                    FileStream fs = File.Create(strPath + "\\" + Name + ".txt");
                    fs.Close();
                    fs.Dispose();
                }
                try
                {
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        sw = File.AppendText(strPath + "\\" + Name + ".txt");
                    }
                    else
                        sw = new StreamWriter(strPath + "\\" + Name + ".txt", false);
                    StringBuilder sb = new StringBuilder();
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        string temp = string.Empty;
                        if (dr.Cells["deviceName"].Value.ToString() == "键盘")
                        {
                            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                            {
                                if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                                {
                                    continue;
                                }
                                temp += dr.Cells[i].Value + ";";
                            }
                            sb.AppendLine(temp);
                        }
                    }
                    sw.WriteLine(sb.ToString());
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                if (!File.Exists(strPath + "\\" + Name + ".txt"))
                {
                    FileStream fs = File.Create(strPath + "\\" + Name + ".txt");
                    fs.Close();
                    fs.Dispose();
                }
                try
                {
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        sw = File.AppendText(strPath + "\\" + Name + ".txt");
                    }
                    else
                        sw = new StreamWriter(strPath + "\\" + Name + ".txt", false);
                    StringBuilder sb = new StringBuilder();
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        string temp = string.Empty;
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                            {
                                continue;
                            }
                            temp += dr.Cells[i].Value + ";";
                        }
                        sb.AppendLine(temp);
                    }
                    sw.WriteLine(sb.ToString());
                    if (Settings.Default.radYesState && !Settings.Default.radNoState)
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private void HookOutputFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseFrm closeFrm = new CloseFrm(); ;
            // 取消关闭窗体
            e.Cancel = true; 
            // 将窗体变为最小化
            if (Settings.Default.chkSave)
            {

                closeFrm.ShowDialog();
            }
            if (closeFrm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            if (Settings.Default.rbMin && !Settings.Default.rbMax)
            {
                this.ShowInTaskbar = false; //不显示在系统任务栏
                notifyIcon1.Visible = true; //托盘图标可见
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            if (!Settings.Default.rbMin && Settings.Default.rbMax)
            {
                notifyIcon1.Visible = false;
                this.Dispose();
                this.Close();
            }
        }
        #endregion

        protected override void WndProc(ref   Message m)
        {
            if (m.Msg == 0xa3)
            {
                return;
            }
            base.WndProc(ref   m);
        }

        //执行事件
        public static void DoSaveAllMessage() { if (SaveAll != null)SaveAll(); }
        public static void DoSaveKeyMessage(){ if(SaveKey!=null)SaveKey(); }
        public static void DoSaveMouseMessage(){ if(SaveMouse!=null)SaveMouse(); }
        public void DoSetHideFrm(bool yesdata) { if(SetHideFrm!=null)SetHideFrm(yesdata); }
        public void DoSetShowFrm(bool nodata) { if(SetShowFrm!=null)SetShowFrm(nodata); }
        //public void DoSetKey(string keydata) { SetKey(keydata); }
        public void DoSetAutoSave(string path, string interval, bool keySelect, bool mouseSelect, string filename) 
        { 
            if(SetAutoSave!=null)
            SetAutoSave(path, interval, keySelect, mouseSelect, filename); 
        }
        public void DoSetManualSave() { if(SetManualSave!=null) SetManualSave(); }

        #region 自定义方法
        /// <summary>
        /// 保存全部输出信息
        /// </summary>
        public void HookOutputFrm_SaveAll()
        {
            if (SaveAll == null) { return; }
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str;
                //string lst = listBox1.Items.Count;
                str = saveFileDialog1.FileName;
                myStream = new StreamWriter(saveFileDialog1.FileName);
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string temp = string.Empty;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                        {
                            continue;
                        }
                        temp += dr.Cells[i].Value + ";";
                    }
                    sb.AppendLine(temp);
                }
                myStream.WriteLine(sb.ToString());
                myStream.Flush();
                myStream.Close();
            }
        }
        /// <summary>
        /// 保存键盘输出信息
        /// </summary>
        void HookOutputFrm_SaveKey()
        {
            if (SaveKey == null) { return; }
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str;
                str = saveFileDialog1.FileName;
                myStream = new StreamWriter(saveFileDialog1.FileName);
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string temp = string.Empty;
                    if (dr.Cells["deviceName"].Value.ToString() == "键盘")
                    {
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                            {
                                continue;
                            }
                            temp += dr.Cells[i].Value + ";";
                        }
                        sb.AppendLine(temp);
                    }
                }
                myStream.WriteLine(sb.ToString());
                myStream.Flush();
                myStream.Close();
            }
        }
        /// <summary>
        /// 保存鼠标输出信息
        /// </summary>
        void HookOutputFrm_SaveMouse()
        {
            if (SaveMouse == null) { return; }
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str;
                str = saveFileDialog1.FileName;
                myStream = new StreamWriter(saveFileDialog1.FileName);
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string temp = string.Empty;
                    if (dr.Cells["deviceName"].Value.ToString() == "鼠标")
                    {
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (dr.Cells[i].ValueType == typeof(System.Drawing.Image))
                            {
                                continue;
                            }
                            temp += dr.Cells[i].Value + ";";
                        }
                        sb.AppendLine(temp);
                    }
                }
                myStream.WriteLine(sb.ToString());
                myStream.Flush();
                myStream.Close();
            }
        }

        public bool yesdata;
        public void HookOutputFrm_SetHideFrm(bool yesdata)
        {
            this.yesdata = yesdata;
        }
        public bool nodata;
        public void HookOutputFrm_SetShowFrm(bool nodata)
        {
            this.nodata = nodata;
        }

        public string strPath;//路径参数
        public bool KeySelect;//键盘选项
        public bool MouseSelect;//鼠标选项
        public string FileName;//文件名
        public void HookOutputFrm_SetAutoSave(string path, string interval, bool keySelect, bool mouseSelect,string filename)
        {            
            timer2.Interval = Convert.ToInt32(interval);
            strPath = path;
            KeySelect = keySelect;
            MouseSelect = mouseSelect;
            timer2.Start();//开始自动保存
            this.Name = filename;
        }
        public void HookOutputFrm_SetManualSave()
        {
            timer2.Stop();
        }

        void m_hook_MouseDown(object sender, MouseEventArgs e)
        {
            string info = string.Empty;
            string tit = string.Empty;
            Icon ico = null;

            #region 获取活动窗口进程信息
            //try
            //{
            //    IntPtr hWnd = GetForegroundWindow();    //获取活动窗口句柄
            //    int calcID = 0;    //进程ID
            //    int calcTD = 0;    //线程ID
            //    calcTD = GetWindowThreadProcessId(hWnd, out calcID);
            //    Process myProcess = Process.GetProcessById(calcID);

            //    info = "进程名：" + myProcess.ProcessName + " " + "进程ID：" + calcID + " " + "程序路径：" + myProcess.MainModule.FileName;
            //}
            //catch (Exception ex)
            //{
            //    info = ex.Message;
            //}
            //listBox1.Items.Add(info);
            #endregion

            try
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                Point p = new Point(x, y);
                IntPtr formHandle = WindowFromPoint(p);//得到窗口句柄 
                StringBuilder title = new StringBuilder(256);
                GetWindowText(formHandle, title, title.Capacity);//得到窗口的标题 
                StringBuilder className = new StringBuilder(256);
                GetClassName(formHandle, className, className.Capacity);//得到窗口的句柄
                //获取路径
                int pId = 0;
                IntPtr pHandle = IntPtr.Zero;
                GetWindowThreadProcessId(formHandle, out pId);
                pHandle = OpenProcess(PROCESS_ALL_ACCESS, 0, pId);
                StringBuilder sb = new StringBuilder(MAX_PATH);
                //GetModuleFileName(pHandle, sb, sb.Capacity);
                GetModuleFileNameEx(pHandle, IntPtr.Zero, sb, MAX_PATH);
                CloseHandle(pHandle);
                //获取图标
                IntPtr[] largeIcons, smallIcons;
                int IconCount = ExtractIconEx(sb.ToString(), -1, null, null, 0);
                largeIcons = new IntPtr[IconCount];
                smallIcons = new IntPtr[IconCount];
                ExtractIconEx(sb.ToString(), 0, largeIcons, smallIcons, IconCount);
                IntPtr icon = new IntPtr(0);
                try
                {
                    icon = largeIcons[0];
                    ico = Icon.FromHandle(icon);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
                tit = title.ToString();
                info = sb.ToString();
            }
            catch (Exception ex)
            {
                tit = ex.Message;
                info = ex.Message;
            }
            //listBox1.Items.Add("鼠标;" + e.Button + ";" + e.X + ";" + e.Y + ";" + tit + ";" + info + ";" + DateTime.Now.ToString());
            //this.listBox1.TopIndex = this.listBox1.Items.Count - 1;
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells["keyboard"].Value = global::GlobalHook.Properties.Resources.mousec;
            dataGridView1.Rows[index].Cells["deviceName"].Value = "鼠标";
            dataGridView1.Rows[index].Cells["KeyDate"].Value = e.Button;
            dataGridView1.Rows[index].Cells["LocationX"].Value = e.X;
            dataGridView1.Rows[index].Cells["LocationY"].Value = e.Y;
            dataGridView1.Rows[index].Cells["Title"].Value = tit;
            dataGridView1.Rows[index].Cells["ClassName"].Value = info;
            dataGridView1.Rows[index].Cells["Date"].Value = DateTime.Now.ToString();
            dataGridView1.Rows[index].Cells["ProgramIcon"].Value = ico;
            dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
        }

        void m_hook_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "鼠标位置：" + e.Location.ToString();
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point p = new Point(x, y);
            IntPtr formHandle = WindowFromPoint(p);//得到窗口句柄 
            StringBuilder title = new StringBuilder(256);
            GetWindowText(formHandle, title, title.Capacity);//得到窗口的标题 
            StringBuilder className = new StringBuilder(256);
            GetClassName(formHandle, className, className.Capacity);//得到窗口的句柄 
            toolStripStatusLabel3.Text = "当前窗口：" + title.ToString();
            toolStripStatusLabel4.Text = "窗口ID：" + formHandle.ToString();
            toolStripStatusLabel5.Text = "窗口所属：" + className.ToString();
        }

        void k_hook_KeyDown(object sender, KeyEventArgs e)
        {
            //判断按下的键（Alt + A）
            //if (e.KeyValue == (int)Keys.A && (int)Control.ModifierKeys == (int)Keys.Alt)
            if (e.KeyData.ToString() == Settings.Default.lblKeyState)
            {
                //System.Windows.Forms.MessageBox.Show("按下了指定快捷键组合");
                if (this.Visible == true)
                {
                    this.Hide();
                    if (Settings.Default.chkHide == true)
                    {
                        notifyIcon1.Visible = false;
                        this.ShowInTaskbar = false;
                    }
                    else
                    {
                        notifyIcon1.Visible = true;
                        this.ShowInTaskbar = true;
                    }
                }
                else
                {
                    this.ShowInTaskbar = true;
                    notifyIcon1.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.Show();
                }
            }

            string info = string.Empty;
            string tit = string.Empty;
            Icon ico = null;
            try
            {
                IntPtr formHandle = GetForegroundWindow();
                StringBuilder title = new StringBuilder(256);
                GetWindowText(formHandle, title, title.Capacity);//得到窗口的标题 
                StringBuilder className = new StringBuilder(256);
                GetClassName(formHandle, className, className.Capacity);//得到窗口的句柄
                //获取路径
                int pId = 0;
                IntPtr pHandle = IntPtr.Zero;
                GetWindowThreadProcessId(formHandle, out pId);
                pHandle = OpenProcess(PROCESS_ALL_ACCESS, 0, pId);
                StringBuilder sb = new StringBuilder(MAX_PATH);
                //GetModuleFileName(pHandle, sb, sb.Capacity);
                GetModuleFileNameEx(pHandle, IntPtr.Zero, sb, MAX_PATH);
                CloseHandle(pHandle);
                //获取图标
                IntPtr[] largeIcons, smallIcons;
                int IconCount = ExtractIconEx(sb.ToString(), -1, null, null, 0);
                largeIcons = new IntPtr[IconCount];
                smallIcons = new IntPtr[IconCount];
                ExtractIconEx(sb.ToString(), 0, largeIcons, smallIcons, IconCount);
                IntPtr icon = new IntPtr(0);
                try
                {
                    icon = largeIcons[0];
                    ico = Icon.FromHandle(icon);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
                tit = title.ToString();
                info = sb.ToString();
            }
            catch (Exception ex)
            {
                tit = ex.Message;
                info = ex.Message;
            }
            //listBox1.Items.Add("键盘;" + e.KeyData + ";" + "" + ";" + "" + ";" + tit + ";" + info + ";" + DateTime.Now.ToString());
            //this.listBox1.TopIndex = this.listBox1.Items.Count - 1;
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells["keyboard"].Value = global::GlobalHook.Properties.Resources.keyboardc;
            dataGridView1.Rows[index].Cells["deviceName"].Value = "键盘";
            dataGridView1.Rows[index].Cells["KeyDate"].Value = e.KeyData;
            dataGridView1.Rows[index].Cells["LocationX"].Value = "";
            dataGridView1.Rows[index].Cells["LocationY"].Value = "";
            dataGridView1.Rows[index].Cells["Title"].Value = tit;
            dataGridView1.Rows[index].Cells["ClassName"].Value = info;
            dataGridView1.Rows[index].Cells["Date"].Value = DateTime.Now.ToString();
            dataGridView1.Rows[index].Cells["ProgramIcon"].Value = ico;
            dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
        }
        #endregion

        #region 调用
        //获取活动窗口句柄
        [DllImport("User32.DLL")]
        static extern IntPtr GetForegroundWindow();

        //获取窗口标题
        [DllImport("user32", SetLastError = true)] 
        public static extern int GetWindowText( 
        IntPtr hWnd,//窗口句柄 
        StringBuilder lpString,//标题 
        int nMaxCount //最大值 
        );

        //根据句柄获取ID
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);//获取线程id

        //获取类的名字 
        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd,//句柄 
            StringBuilder lpString, //类名 
            int nMaxCount //最大值 
            );

        //根据坐标获取窗口句柄 
        [DllImport("user32")]
        private static extern IntPtr WindowFromPoint(
        Point Point  //坐标 
        );
        private const int MAX_PATH = 260;
        public const int PROCESS_ALL_ACCESS = 0x000F0000 | 0x00100000 | 0xFFF;

        [DllImport("Kernel32.dll")]
        public extern static IntPtr OpenProcess(int fdwAccess, int fInherit, int IDProcess);
        [DllImport("shell32.dll")]
        public extern static bool TerminateProcess(IntPtr hProcess, int uExitCode);

        [DllImport("shell32.dll", EntryPoint = "GetModuleFileName")]
        private static extern uint GetModuleFileName(IntPtr hModule, [Out] StringBuilder lpszFileName, int nSize);

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] int nSize);
        [DllImport("Kernel32.dll")]
        public extern static bool CloseHandle(IntPtr hObject);
        #endregion
    }
}

