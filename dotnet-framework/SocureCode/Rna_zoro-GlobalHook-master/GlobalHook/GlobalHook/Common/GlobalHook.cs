﻿//GlobalHook.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace GlobalHook
{
    /*
     * 
     * 捕获键盘鼠标所有事件
     * 模拟鼠标和模拟键盘操作
     * 
     * */
    /// <summary>  
    /// 鼠标和键盘钩子的抽象类
    /// </summary>  
    public abstract class GlobalHook
    {
        #region Windows API Code
        [StructLayout(LayoutKind.Sequential)]
        protected class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        //键盘结构
        [StructLayout(LayoutKind.Sequential)]
        protected class KeyboardHookStruct
        {
            public int vkCode;//定一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode;// 指定的硬件扫描码的关键
            public int flags;// 键标志
            public int time;// 指定的时间戳记的这个讯息
            public int dwExtraInfo;// 指定额外信息相关的信息
        }
        //使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        protected static extern int SetWindowsHookEx(
            int idHook,
             HookProc lpfn,
            IntPtr hMod,
             int dwThreadId);
        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(String modulename);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookExW(
                    int idHook,
                    HookProc lpfn,
                    IntPtr hmod,
                    uint dwThreadID);
        //调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        protected static extern int UnhookWindowsHookEx(int idHook);
        //使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        protected static extern int CallNextHookEx(
            int idHook,
            int nCode,
            int wParam,
            IntPtr lParam);
        [DllImport("user32")]
        protected static extern int ToAscii(
            int uVirtKey,
            int uScanCode,
            byte[] lpbKeyState,
            byte[] lpwTransKey,
            int fuState);
        [DllImport("user32")]
        protected static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern short GetKeyState(int vKey);
        protected delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        protected const int WH_MOUSE_LL = 14;
        protected const int WH_KEYBOARD_LL = 13;
        protected const int WH_MOUSE = 7;
        protected const int WH_KEYBOARD = 2;
        protected const int WM_MOUSEMOVE = 0x200;//鼠标移动 512（int）
        protected const int WM_LBUTTONDOWN = 0x201;//鼠标左键 513（int）
        protected const int WM_RBUTTONDOWN = 0x204;//鼠标右键 516（int）
        protected const int WM_MBUTTONDOWN = 0x207;//鼠标中健 519（int）
        protected const int WM_LBUTTONUP = 0x202;//左键弹起 514（int）
        protected const int WM_RBUTTONUP = 0x205;//右键弹起 517（int）
        protected const int WM_MBUTTONUP = 0x208;//中健弹起 520（int）
        protected const int WM_LBUTTONDBLCLK = 0x203;//双击左键 515（int）
        protected const int WM_RBUTTONDBLCLK = 0x206;//双击右键 518（int）
        protected const int WM_MBUTTONDBLCLK = 0x209;//双击中健 521（int）
        protected const int WM_MOUSEWHEEL = 0x020A;
        protected const int WM_KEYDOWN = 0x100;
        protected const int WM_KEYUP = 0x101;
        protected const int WM_SYSKEYDOWN = 0x104;
        protected const int WM_SYSKEYUP = 0x105;
        protected const byte VK_SHIFT = 0x10;
        protected const byte VK_CAPITAL = 0x14;
        protected const byte VK_NUMLOCK = 0x90;
        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        protected const byte VK_LCONTROL = 0xA2;
        protected const byte VK_RCONTROL = 0x3;
        protected const byte VK_LALT = 0xA4;
        protected const byte VK_RALT = 0xA5;
        protected const byte LLKHF_ALTDOWN = 0x20;
        #endregion
        #region Private Variables
        protected int _hookType;
        protected int _handleToHook;
        protected bool _isStarted;
        protected HookProc _hookCallback;
        #endregion
        #region Properties
        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
        }
        #endregion
        #region Constructor
        public GlobalHook()
        {
            //绑定ApplicationExit事件
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }
        #endregion
        #region Methods
        public void Start()
        {
            if (!_isStarted &&
                _hookType != 0)
            {
                //确保_hookCallback不是一个空的引用
                //如果是，GC会随机回收它，并且一个空的引用会爆出异常
                _hookCallback = new HookProc(HookCallbackProcedure);
                using (Process curPro = Process.GetCurrentProcess())
                {
                    using (ProcessModule curMod = curPro.MainModule)
                    {
                        _handleToHook = (int)SetWindowsHookExW(
                            _hookType,
                            _hookCallback,
                             GetModuleHandle(curMod.ModuleName),
                           0);
                        //关于SetWindowsHookEx (int idHook, HookProc lpfn, IntPtrhInstance, int threadId)函数将钩子加入到钩子链表中，说明一下四个参数：
                        //idHook 钩子类型，即确定钩子监听何种消息，上面的代码中设为2，即监听键盘消息并且是线程钩子，如果是全局钩子监听键盘消息应设为13，
                        //线程钩子监听鼠标消息设为7，全局钩子监听鼠标消息设为14。lpfn钩子子程的地址指针。如果dwThreadId参数为0 或是一个由别的进程创建的
                        //线程的标识，lpfn必须指向DLL中的钩子子程。 除此以外，lpfn可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子钩到任何
                        //消息后便调用这个函数。hInstance应用程序实例的句柄。标识包含lpfn所指的子程的DLL。如果threadId 标识当前进程创建的一个线程，而且子
                        //程代码位于当前进程，hInstance必须为NULL。可以很简单的设定其为本应用程序的实例句柄。threadId 与安装的钩子子程相关联的线程的标识符
                        //如果为0，钩子子程与所有的线程关联，即为全局钩子
                        //如果SetWindowsHookEx失败

                    }
                }
                // 钩成功
                if (_handleToHook != 0)
                {
                    _isStarted = true;
                }
            }
        }
        public void Stop()
        {
            if (_isStarted)
            {
                UnhookWindowsHookEx(_handleToHook);
                _isStarted = false;
            }
        }
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual int HookCallbackProcedure(int nCode, Int32 wParam, IntPtr lParam)
        {
            // This method must be overriden by each extending hook  
            return 0;
        }
        /// <summary>
        /// 程序退出方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (_isStarted)
            {
                Stop();
            }
        }
        #endregion
    }
    /// <summary>  
    /// 键盘钩子类
    /// </summary>  
    public class KeyboardHook : GlobalHook
    {
        #region Events
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event KeyPressEventHandler KeyPress;
        #endregion
        #region Constructor
        public KeyboardHook()
        {
            _hookType = WH_KEYBOARD_LL;
        }
        #endregion
        #region Methods
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            bool handled = false;
            if (nCode > -1 && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                KeyboardHookStruct keyboardHookStruct =
                    (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                // Is Control being held down?  
                bool control = ((GetKeyState(VK_LCONTROL) & 0x80) != 0) ||
                               ((GetKeyState(VK_RCONTROL) & 0x80) != 0);
                // Is Shift being held down?  
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                             ((GetKeyState(VK_RSHIFT) & 0x80) != 0);
                // Is Alt being held down?  
                bool alt = ((GetKeyState(VK_LALT) & 0x80) != 0) ||
                           ((GetKeyState(VK_RALT) & 0x80) != 0);
                // Is CapsLock on?  
                bool capslock = (GetKeyState(VK_CAPITAL) != 0);
                // Create event using keycode and control/shift/alt values found above  
                KeyEventArgs e = new KeyEventArgs(
                    (Keys)(
                        keyboardHookStruct.vkCode |
                        (control ? (int)Keys.Control : 0) |
                        (shift ? (int)Keys.Shift : 0) |
                        (alt ? (int)Keys.Alt : 0)
                        ));
                // Handle KeyDown and KeyUp events  
                switch (wParam)
                {
                    case WM_KEYDOWN:
                    case WM_SYSKEYDOWN:
                        if (KeyDown != null)
                        {
                            KeyDown(this, e);
                            handled = handled || e.Handled;
                        }
                        break;
                    case WM_KEYUP:
                    case WM_SYSKEYUP:
                        if (KeyUp != null)
                        {
                            KeyUp(this, e);
                            handled = handled || e.Handled;
                        }
                        break;
                }
                // Handle KeyPress event  
                if (wParam == WM_KEYDOWN &&
                   !handled &&
                   !e.SuppressKeyPress &&
                    KeyPress != null)
                {
                    byte[] keyState = new byte[256];
                    byte[] inBuffer = new byte[2];
                    GetKeyboardState(keyState);
                    if (ToAscii(keyboardHookStruct.vkCode,
                              keyboardHookStruct.scanCode,
                              keyState,
                              inBuffer,
                              keyboardHookStruct.flags) == 1)
                    {
                        char key = (char)inBuffer[0];
                        if ((capslock ^ shift) && Char.IsLetter(key))
                            key = Char.ToUpper(key);
                        KeyPressEventArgs e2 = new KeyPressEventArgs(key);
                        KeyPress(this, e2);
                        handled = handled || e.Handled;
                    }
                }
            }
            if (handled)
            {
                return 1;
            }
            else
            {
                return CallNextHookEx(_handleToHook, nCode, wParam, lParam);
            }
        }
        #endregion
    }
    /// <summary>  
    /// 鼠标钩子类
    /// </summary>  
    public class MouseHook : GlobalHook
    {
        #region MouseEventType Enum
        private enum MouseEventType
        {
            None,
            MouseDown,
            MouseUp,
            DoubleClick,
            MouseWheel,
            MouseMove
        }
        #endregion
        #region Events
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        public event MouseEventHandler MouseDown;
        /// <summary>
        /// 送开鼠标事件
        /// </summary>
        public event MouseEventHandler MouseUp;
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        public event MouseEventHandler MouseMove;
        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        public event MouseEventHandler MouseWheel;
        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        public event EventHandler DoubleClick;
        #endregion
        #region Constructor
        public MouseHook()
        {
            _hookType = WH_MOUSE_LL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode > -1 && (MouseDown != null || MouseUp != null || MouseMove != null))
            {
                MouseLLHookStruct mouseHookStruct =
                    (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));
                MouseButtons button = GetButton(wParam);
                MouseEventType eventType = GetEventType(wParam);
                MouseEventArgs e = new MouseEventArgs(
                    button,
                    (eventType == MouseEventType.DoubleClick ? 2 : 1),
                    mouseHookStruct.pt.x,
                    mouseHookStruct.pt.y,
                    (eventType == MouseEventType.MouseWheel ? (short)((mouseHookStruct.mouseData >> 16) & 0xffff) : 0));
                // Prevent multiple Right Click events (this probably happens for popup menus)  
                if (button == MouseButtons.Right && mouseHookStruct.flags != 0)
                {
                    eventType = MouseEventType.None;
                }
                switch (eventType)
                {
                    case MouseEventType.MouseDown:
                        if (MouseDown != null)
                        {
                            MouseDown(this, e);
                        }
                        break;
                    case MouseEventType.MouseUp:
                        if (Click != null)
                        {
                            Click(this, new EventArgs());
                        }
                        if (MouseUp != null)
                        {
                            MouseUp(this, e);
                        }
                        break;
                    case MouseEventType.DoubleClick:
                        if (DoubleClick != null)
                        {
                            DoubleClick(this, new EventArgs());
                        }
                        break;
                    case MouseEventType.MouseWheel:
                        if (MouseWheel != null)
                        {
                            MouseWheel(this, e);
                        }
                        break;
                    case MouseEventType.MouseMove:
                        if (MouseMove != null)
                        {
                            MouseMove(this, e);
                        }
                        break;
                    default:
                        break;
                }
            }
            return CallNextHookEx(_handleToHook, nCode, wParam, lParam);
        }
        private MouseButtons GetButton(Int32 wParam)
        {
            switch (wParam)
            {
                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                case WM_LBUTTONDBLCLK:
                    return MouseButtons.Left;
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                case WM_RBUTTONDBLCLK:
                    return MouseButtons.Right;
                case WM_MBUTTONDOWN:
                case WM_MBUTTONUP:
                case WM_MBUTTONDBLCLK:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;
            }
        }
        private MouseEventType GetEventType(Int32 wParam)
        {
            switch (wParam)
            {
                case WM_LBUTTONDOWN:
                case WM_RBUTTONDOWN:
                case WM_MBUTTONDOWN:
                    return MouseEventType.MouseDown;
                case WM_LBUTTONUP:
                case WM_RBUTTONUP:
                case WM_MBUTTONUP:
                    return MouseEventType.MouseUp;
                case WM_LBUTTONDBLCLK:
                case WM_RBUTTONDBLCLK:
                case WM_MBUTTONDBLCLK:
                    return MouseEventType.DoubleClick;
                case WM_MOUSEWHEEL:
                    return MouseEventType.MouseWheel;
                case WM_MOUSEMOVE:
                    return MouseEventType.MouseMove;
                default:
                    return MouseEventType.None;
            }
        }
        #endregion
    }
    /// <summary>  
    /// 模拟键盘事件类
    /// </summary>  
    public static class KeyboardSimulator
    {
        #region Standard Keyboard Shortcuts Enum
        /// <summary>  
        ///  标准的人体工程键盘快捷键 
        /// </summary>  
        public enum StandardShortcut
        {
            Copy,
            Cut,
            Paste,
            SelectAll,
            Save,
            Open,
            New,
            Close,
            Print
        }
        #endregion
        #region Windows API Code
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        [DllImport("user32.dll")]
        static extern void keybd_event(byte key, byte scan, int flags, int extraInfo);
        #endregion
        #region Methods
        public static void KeyDown(Keys key)
        {
            keybd_event(ParseKey(key), 0, 0, 0);
        }
        public static void KeyUp(Keys key)
        {
            keybd_event(ParseKey(key), 0, KEYEVENTF_KEYUP, 0);
        }
        public static void KeyPress(Keys key)
        {
            KeyDown(key);
            KeyUp(key);
        }
        public static void SimulateStandardShortcut(StandardShortcut shortcut)
        {
            switch (shortcut)
            {
                case StandardShortcut.Copy:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.C);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.Cut:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.X);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.Paste:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.V);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.SelectAll:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.A);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.Save:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.S);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.Open:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.O);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.New:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.N);
                    KeyUp(Keys.Control);
                    break;
                case StandardShortcut.Close:
                    KeyDown(Keys.Alt);
                    KeyPress(Keys.F4);
                    KeyUp(Keys.Alt);
                    break;
                case StandardShortcut.Print:
                    KeyDown(Keys.Control);
                    KeyPress(Keys.P);
                    KeyUp(Keys.Control);
                    break;
            }
        }
        static byte ParseKey(Keys key)
        {
            // Alt, Shift, and Control need to be changed for API function to work with them  
            switch (key)
            {
                case Keys.Alt:
                    return (byte)18;
                case Keys.Control:
                    return (byte)17;
                case Keys.Shift:
                    return (byte)16;
                default:
                    return (byte)key;
            }
        }
        #endregion
    }
    /// <summary>  
    /// 模拟鼠标事件类
    /// </summary>  
    public static class MouseSimulator
    {
        /// <summary>  
        /// And X, Y point on the screen  
        /// </summary>  
        public struct MousePoint
        {
            public MousePoint(Point p)
            {
                X = p.X;
                Y = p.Y;
            }
            public int X;
            public int Y;
            public static implicit operator Point(MousePoint p)
            {
                return new Point(p.X, p.Y);
            }
        }
        /// <summary>  
        /// Mouse buttons that can be pressed  
        /// </summary>  
        public enum MouseButton
        {
            Left = 0x2,
            Right = 0x8,
            Middle = 0x20
        }
        #region Windows API Code
        [DllImport("user32.dll")]
        static extern int ShowCursor(bool show);
        [DllImport("user32.dll")]
        static extern void mouse_event(int flags, int dX, int dY, int buttons, int extraInfo);
        const int MOUSEEVENTF_MOVE = 0x1;
        const int MOUSEEVENTF_LEFTDOWN = 0x2;
        const int MOUSEEVENTF_LEFTUP = 0x4;
        const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        const int MOUSEEVENTF_RIGHTUP = 0x10;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const int MOUSEEVENTF_MIDDLEUP = 0x40;
        const int MOUSEEVENTF_WHEEL = 0x800;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        #endregion
        #region Properties
        /// <summary>  
        /// Gets or sets a structure that represents both X and Y mouse coordinates  
        /// </summary>  
        public static MousePoint Position
        {
            get
            {
                return new MousePoint(Cursor.Position);
            }
            set
            {
                Cursor.Position = value;
            }
        }
        /// <summary>  
        /// Gets or sets only the mouse's x coordinate  
        /// </summary>  
        public static int X
        {
            get
            {
                return Cursor.Position.X;
            }
            set
            {
                Cursor.Position = new Point(value, Y);
            }
        }
        /// <summary>  
        /// Gets or sets only the mouse's y coordinate  
        /// </summary>  
        public static int Y
        {
            get
            {
                return Cursor.Position.Y;
            }
            set
            {
                Cursor.Position = new Point(X, value);
            }
        }
        #endregion
        #region Methods
        /// <summary>  
        /// Press a mouse button down  
        /// </summary>  
        /// <param name="button"></param>  
        public static void MouseDown(MouseButton button)
        {
            mouse_event(((int)button), 0, 0, 0, 0);
        }
        public static void MouseDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    MouseDown(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    MouseDown(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    MouseDown(MouseButton.Right);
                    break;
            }
        }
        /// <summary>  
        /// Let a mouse button up  
        /// </summary>  
        /// <param name="button"></param>  
        public static void MouseUp(MouseButton button)
        {
            mouse_event(((int)button) * 2, 0, 0, 0, 0);
        }
        public static void MouseUp(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    MouseUp(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    MouseUp(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    MouseUp(MouseButton.Right);
                    break;
            }
        }
        /// <summary>  
        /// Click a mouse button (down then up)  
        /// </summary>  
        /// <param name="button"></param>  
        public static void Click(MouseButton button)
        {
            MouseDown(button);
            MouseUp(button);
        }
        public static void Click(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    Click(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    Click(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    Click(MouseButton.Right);
                    break;
            }
        }
        /// <summary>  
        /// Double click a mouse button (down then up twice)  
        /// </summary>  
        /// <param name="button"></param>  
        public static void DoubleClick(MouseButton button)
        {
            Click(button);
            Click(button);
        }
        public static void DoubleClick(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    DoubleClick(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    DoubleClick(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    DoubleClick(MouseButton.Right);
                    break;
            }
        }
        /// <summary>  
        /// Show a hidden current on currently application  
        /// </summary>  
        public static void Show()
        {
            ShowCursor(true);
        }
        /// <summary>  
        /// Hide mouse cursor only on current application's forms  
        /// </summary>  
        public static void Hide()
        {
            ShowCursor(false);
        }
        #endregion
    }
}
