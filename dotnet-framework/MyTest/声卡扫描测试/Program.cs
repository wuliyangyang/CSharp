using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace 声卡扫描测试
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(midiOutGetNumDevs());
            Console.WriteLine(waveOutGetNumDevs());
            Play("1.wav");


            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_SoundDevice");//声明一个用于检索设备管理信息的对象 
            foreach (ManagementObject VoiceDeviceObject in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象 
            {
                Console.WriteLine(VoiceDeviceObject["ProductName"].ToString());//显示声音设备的名称 
            }

            List<Task> tList = new List<Task>();
            Task task  =   Task.Run(delegate
            {
                StartRecordSound();
                Thread.Sleep(5000);
                StopRecordSound();
                Play("test.wav");
            });

            tList.Add(task);

            Task.WaitAll(tList.ToArray());
            Console.WriteLine("WaitAll Finish");
            Console.ReadKey();
        }


        [DllImport("winmm.dll", SetLastError = true)]
        static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        [DllImport("winmm.dll", SetLastError = true)]
        static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        private static extern long sndPlaySound(string lpszSoundName, long uFlags);

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]

        public static extern int mciSendString(
            string lpstrCommand,
            string lpstrReturnString,
            int uReturnLength,
            int hwndCallback
    );

        [Flags]
        public enum SoundFlags
        {
            /// <summary>play synchronously (default)</summary>
            SND_SYNC = 0x0000,
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>silence (!default) if sound not found</summary>
            SND_NODEFAULT = 0x0002,
            /// <summary>pszSound points to a memory file</summary>
            SND_MEMORY = 0x0004,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>don’t stop any currently playing sound</summary>
            SND_NOSTOP = 0x0010,
            /// <summary>Stop Playing Wave</summary>
            SND_PURGE = 0x40,
            /// <summary>don’t wait if the driver is busy</summary>
            SND_NOWAIT = 0x00002000,
            /// <summary>name is a registry alias</summary>
            SND_ALIAS = 0x00010000,
            /// <summary>alias is a predefined id</summary>
            SND_ALIAS_ID = 0x00110000,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000,
            /// <summary>name is resource name or atom</summary>
            SND_RESOURCE = 0x00040004
        }

        public static void Play(string strFileName)
        {
            PlaySound(strFileName, UIntPtr.Zero,
               (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC | SoundFlags.SND_NOSTOP));
        }
        public static void mciPlay(string strFileName)
        {
            string playCommand = "open " + strFileName + " type WAVEAudio alias MyWav";
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }
        public static void sndPlay(string strFileName)
        {
            sndPlaySound(strFileName, (long)SoundFlags.SND_SYNC);
        }

        public static void StartRecordSound()
        {

            mciSendString("set wave bitpersample 8", "", 0, 0);

            mciSendString("set wave samplespersec 20000", "", 0, 0);
            mciSendString("set wave channels 1", "", 0, 0);
            mciSendString("set wave format tag pcm", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);

            mciSendString("record movie", "", 0, 0);
        }

        public static void StopRecordSound()
        {
            mciSendString("stop movie", "", 0, 0);
            mciSendString("save movie test.wav", "", 0, 0);
            mciSendString("close movie", "", 0, 0);
        }

        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        public static extern int waveOutGetNumDevs();
        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        public static extern int midiOutGetNumDevs();


    }
}
