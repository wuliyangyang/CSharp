using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProcessTest
{
    public partial class Form1 : Form
    {
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int WM_SYSCOMMAND2 = 0x0112;
        public const int SC_MAXIMIZE2 = 0xF030;
        private const int BM_CLICK = 0xF5;

        private static int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        private static int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        private static int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        private static int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        private static int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        private static int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        private static int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        private static int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标


        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public Form1()
        {
            InitializeComponent();
            MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("------------------------");
            int xx = Cursor.Position.X;
            int yy = Cursor.Position.Y;
            Console.WriteLine("before click  Cursor {0} {1}", xx, yy);
            Task.Run(() =>
            {
                Go();
            });
        }
        private void Go()
        {
            IntPtr hWnd = FindWindow(null, "网易云音乐");
            Rect rect = new Rect();
            if (hWnd != IntPtr.Zero)
            {

                SetForegroundWindow(hWnd);
                //ShowWindow(hWnd, 1);
                GetWindowRect(hWnd, ref rect);

                Console.WriteLine("left:" + rect.Left);
                Console.WriteLine("bottom:" + rect.Bottom);
                int x = rect.Left + 160;
                int y = rect.Bottom - 45;

                Console.WriteLine("x:{0},y{1}", x, y);
                int xx =x * 65536 / 1280;
                int yy = y * 65536 / 800;

                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, xx, yy, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, xx, yy, 0, 0);

                Console.WriteLine("after click");
                int xxx = Cursor.Position.X;
                int yyy = Cursor.Position.Y;
                Console.WriteLine("Cursor {0} {1}", xxx, yyy);

            }

        }


        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
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

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
    public class Procession
    {
        public int Id;
        public string ProcessName;
        public string MainWindowTitle;
    }
}
