using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Runtime.InteropServices;

namespace MMouseTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetPosBtn_Click(object sender, RoutedEventArgs e)
        {
            Get();
        }

        private void MoveClick_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int cw = int.Parse(computerW.Text);
                int ch = int.Parse(computerH.Text);
                int xx = 0;
                int yy = 0;

                if (leftCheck.IsChecked == true)
                {
                    xx = int.Parse(leftText.Text) + int.Parse(leftOffsetText.Text);
                }
                if (rightCheck.IsChecked == true)
                {
                    xx = int.Parse(rightText.Text) + int.Parse(rightOffsetText.Text);
                }
                if (topCheck.IsChecked == true)
                {
                    yy = int.Parse(topText.Text) + int.Parse(topOffsetText.Text);
                }
                if (bottomCheck.IsChecked == true)
                {
                    yy = int.Parse(bottomText.Text) + int.Parse(bottomOffsetText.Text);
                }

                int x = xx * 65536 / cw;
                int y = yy * 65536 / ch;

                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Get()
        {
            try
            {
                int leftOffset = int.Parse(leftOffsetText.Text);
                int rightOffset = int.Parse(rightOffsetText.Text);
                int topOffset = int.Parse(topOffsetText.Text);
                int bottomOffset = int.Parse(bottomOffsetText.Text);
                int cw = int.Parse(computerW.Text);
                int ch = int.Parse(computerH.Text);
                string winName = this.winNameBox.Text;

                if (string.IsNullOrEmpty(winName))
                {
                    return;
                }
                IntPtr hWnd = FindWindow(null, winName);
                Rect rect = new Rect();
                if (hWnd != IntPtr.Zero)
                {

                    SetForegroundWindow(hWnd);
                    GetWindowRect(hWnd, ref rect);

                    int xx = 0;
                    int yy = 0;

                    if (leftCheck.IsChecked == true)
                    {
                        xx = rect.Left / 2 + int.Parse(leftOffsetText.Text);
                    }
                    if (rightCheck.IsChecked == true)
                    {
                        xx = rect.Right / 2 + int.Parse(rightOffsetText.Text);
                    }
                    if (topCheck.IsChecked == true)
                    {
                        yy = rect.Top / 2 + int.Parse(topOffsetText.Text);
                    }
                    if (bottomCheck.IsChecked == true)
                    {
                        yy = rect.Bottom / 2 + int.Parse(bottomOffsetText.Text);
                    }
                    if (xx==0&&yy==00)
                    {
                        xx = rect.Left;
                        yy = rect.Top;
                        Console.WriteLine("offset is zero!!!");
                    }
                    int x = xx * 65536 / cw;
                    int y = yy * 65536 / ch;

                    //mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x, y, 0, 0);
                    //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);

                    topText.Text = (rect.Top/2).ToString();
                    bottomText.Text = (rect.Bottom/2).ToString();
                    leftText.Text = (rect.Left/2).ToString();
                    rightText.Text = (rect.Right/2).ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
