using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDefine
{
    public class Protocols
    {
        //Message type
        public const string REQ = "REQ";
        public const string RSP = "RSP";
    }

    public class MouduleType
    {
        public const string PLC = "PLC";

        public const string CCD = "CCD";
        public const string CCD1 = "CCD1";
        public const string CCD2 = "CCD2";

        public const string SCANNER = "SCANNER";
        public const string SCANNER1 = "SCANNER1";
        public const string SCANNER2 = "SCANNER2";
        public const string SCANNER3 = "SCANNER3";
    }

    
    public class ReceivedData
    {
        public string moduleType { get; set; }
        public string moduleId { get; set; }
        public string sender { get; set; }

        public string ip { set; get; }
        public int port { set; get; }

        public JsonData strData { get; set; }
        public PLCData plcData { get; set; }

        public string toString()
        {
            string res = string.Format("moduleType = {0}, moduleId = {1}, sender = {2}， ip = {3}, port = {4}, strData = {5}， BinaryData = {6}",
                moduleType ?? "", moduleId ?? "", sender ?? "", ip ?? "", port,
                strData == null ? "" : strData.ToString(),
                plcData == null ? "" : plcData.ToString());
            return res;
        }
    }

    public class JsonData
    {
        public string msgType { set; get; }
        public string msgName { set; get; }
        public string msgChannel { set; get; }
        public object msgParam { set; get; }
        public int msgResult { set; get; }
        public string errMsg { set; get; }

        public string toString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class PLCData
    {
        public int channelId { set; get; }//4 byte
        public int commandId { set; get; }//4 byte
        public int msgType { set; get; }//4 byte
        public float param1 { set; get; }//4 byte
        public float param2 { set; get; }//4 byte
        public float param3 { set; get; }//4 byte
        public float param4 { set; get; }//4 byte
        public float param5 { set; get; }//4 byte
        public long errorcode { set; get; }//8 byte
        public string strMessage { set; get; }// 32 byte


        public string toString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    

    public class CCDCommands
    {
        public const string Start = "start";
        public const string IsTest = "istest";
        public const string TestDone = "testdone";
        public const string Error = "error";
    }

    public class Scanner_state
    {
        public const string s1_dis = "scanner1 discannet!";
        public const string s2_dis = "scanner2 discannet!";
        public const string s3_dis = "scanner3 discannet!";
    }

    public class MsgType
    {
        public const int ACK = 1;
        public const int CMD = 0;
        public const string req = "REQ";
        public const string rsp = "RSP";
    }

    public class CommonCommands
    {
        public const string Register = "register";
        public const string Disconnected = "disconnected";

        public const int BinaryRegister = 1;
        public const int BinaryDisconnected = 2;
    }
    public class ReturnErrorCode
    {
        public const int OK = 0;
        public const int FAIL = 1;

    }
    //plc broadcast to scanner<----
    public class scannerParm
    {
        public const int loadscan = 1;
        public const int unloadscan = 2;
    }
    public class scannerR
    {
        public const int Req = 1;
        public const int Rsp = 2;
    }
    //---->
    public class LnTn
    {
        public const int L1S1 = 1;
        public const int L1S2 = 2;
        public const int L2S1 = 3;
        public const int L2S2 = 4;
    }
    public class RegisterParam
    {
        public string moduletype { set; get; }
        public string modulename { set; get; }
    }

    public class PLCCommands
    {
        public const int Register = 1;
        public const int Start = 2;
        public const int LoadDut = 3;
        public const int LoadScan = 4;
        public const int Dispatch = 5;
        public const int Merge = 6;
        public const int UnloadScan = 7;
        public const int Unload = 8;
        public const int Kickoff = 9;
        public const int GRR = 10;
        public const int Stop = 11;
        public const int Reset = 12;
        public const int Continue = 13;
        public const int Pause = 14;

        public const int Log = 20;


        public const int Error = 99;
        public const int Disconnect = 100;

        public const int loadscan_scan = 101;
        public const int isTest = 102;

        private static readonly Dictionary<int, string> _cmds = new Dictionary<int, string>()
        {
            {Register, "Register"},
            {Start, "Start"},
            {LoadDut,"LoadDut"},
            {LoadScan,"LoadScan"},
            {Dispatch,"Dispatch"},
            {Merge,"Merge"},
            {UnloadScan,"UnloadScan"},
            {GRR,"GRR"},
            {Stop, "Stop"},
            {Reset, "Reset"},
            {Continue, "Continue"},
            {Pause,"Pause"},
            {Error,"Error"},
            {Kickoff,"Kickoff"},
            {Unload,"Unload"},
            {Log,"Log"},
            {loadscan_scan,"loadscan_scan"},
            {isTest,"isTest"}
        };

        public static string getCommandName(int cmd)
        {
            if (_cmds.Keys.Contains(cmd))
            {
                return _cmds[cmd];
            }
            else
            {
                return "Unexpected Command";
            }
        }
    }

    public class CCDStrParam
    {
        public int testtype { set; get; }
    }

    public class IsTestParam
    {
        public string socketSN { set; get; }
        public string dutSN { set; get; }
        public int istest { set; get; }
    }

    public class TestResult
    {
        public string socketSN { set; get; }
        public string dutSN { set; get; }
        public List<TestValue> result { set; get; }
    }
    public class TestValue
    {
        public string key { set; get; }
        public string value { set; get; }
    }

    public class CCDID
    {
        public const string CCD1 = "L1S1";
        public const string CCD2 = "L1S2";
        public const string CCD3 = "L2S1";
        public const string CCD4 = "L2S2";
    }

    public class FrameworkUIEventAgrs : EventArgs
    {
        public WindowsType WindowType { get; set; }
        public int ItemType { get; set; }
        public object Data { get; set; }
    }

    public enum WindowsType
    {
        GenInfo = 1,
        //LoadGen,
        //LoadDetail,
        //UnloadGen,
        //UnloadDetail,
        //LogWindow,
        BinTable,
        //TMSimple,
        //TMUnit,
        //PlcConveyor,
        //LoadTray,
        //UnloadTray,
        //FailTray,

        //LoadGenLeftStacker,
        //LoadGenRightStacker,
        //LoadGenEmptyStacker,
        //UPH,

        //UnloadGenLeftStacker,
        //UnloadGenRightStacker,
        //UnloadGenEmptyStacker,
        //UnloadGenFailStacker,
        //SocketCount,
    }

    public enum UpdateBinCode
    {
        Read = 1000,
        Write,
        Clear,
    }

    #region // developing unusing demo //
    //public class TestDoneParam
    //{
    //    public string socketSN { set; get; }
    //    public string dutSN { set; get; }
    //    public string InnerLengthY { set; get; }
    //    public string InnerLengthX { set; get; }
    //    public string OverAllY { set; get; }
    //    public string OverAllX { set; get; }
    //    public string ADatumFlatneess { set; get; }
    //    public string LeftFangCenterToADatumZ { set; get; }
    //    public string RightFangToFrameEdgeX { set; get; }
    //    public string LeftFangToFrameEdgeX { set; get; }
    //    public string RightHookBase { set; get; }
    //    public string LeftHookBase { set; get; }
    //    public string CDatumToFangY { set; get; }
    //    public string CenterHookBase { set; get; }
    //    public string FlangeNutHoleCenterToTopY { set; get; }
    //    public string LeftWeldNutToSide { set; get; }
    //    public string TopWeldNutCenterToSideX { set; get; }
    //    public string FlangeNutHoleCenterToSideY { set; get; }
    //    public string TopWeldNutCenterToTopY { set; get; }
    //    public string LeftWeldNutToTopY { set; get; }
    //    public string RightWindowSnapToADatumZ { set; get; }
    //    public string MiddleWindowSnapToADatumZ { set; get; }
    //    public string LeftWindowSnapToADatumZ { set; get; }
    //    public string LeftWindowSnapToSideX { set; get; }
    //    public string CenterWindowSnapToSideX { set; get; }
    //    public string RightWindowSnapToSideX { set; get; }
    //    public string FramePlasticToMetalZ1 { set; get; }
    //    public string FramePlasticToMetalZ2 { set; get; }
    //    public string MiddleSnapWindowToTopY { set; get; }
    //    public string RightSnapWindowToTopY { set; get; }
    //    public string LeftSnapWindowToTopY { set; get; }
    //    public string TopWeldNutAndLeftWeldNutZ { set; get; }
    //    public string FlangNutOffsetZ { set; get; }

    //}

    //public class TestDoneParamD33
    //{
    //    public string socketSN { set; get; }
    //    public string dutSN { set; get; }
    //    public string InnerLengthY { set; get; }
    //    public string InnerLengthX { set; get; }
    //    public string OverAllY { set; get; }
    //    public string OverAllX { set; get; }
    //    public string ADatumFlatneess { set; get; }
    //    public string LeftFangCenterToADatumZ { set; get; }
    //    public string RightFangToFrameEdgeX { set; get; }
    //    public string LeftFangToFrameEdgeX { set; get; }
    //    public string RightHookBase { set; get; }
    //    public string LeftHookBase { set; get; }
    //    public string CDatumToFangY { set; get; }
    //    public string CenterHookBase { set; get; }
    //    public string FlangeNutHoleCenterToTopY { set; get; }
    //    public string LeftWeldNutToSide { set; get; }
    //    public string TopWeldNutCenterToSideX { set; get; }
    //    public string FlangeNutHoleCenterToSideY { set; get; }
    //    public string TopWeldNutCenterToTopY { set; get; }
    //    public string LeftWeldNutToTopY { set; get; }
    //    public string RightWindowSnapToADatumZ { set; get; }
    //    public string MiddleWindowSnapToADatumZ { set; get; }
    //    public string LeftWindowSnapToADatumZ { set; get; }
    //    public string LeftWindowSnapToSideX { set; get; }
    //    public string CenterWindowSnapToSideX { set; get; }
    //    public string RightWindowSnapToSideX { set; get; }
    //    public string FramePlasticToMetalZ1 { set; get; }
    //    public string FramePlasticToMetalZ2 { set; get; }
    //    public string MiddleSnapWindowToTopY { set; get; }
    //    public string RightSnapWindowToTopY { set; get; }
    //    public string LeftSnapWindowToTopY { set; get; }
    //    public string TopWeldNutAndLeftWeldNutZ { set; get; }
    //    public string FlangNutOffsetZ { set; get; }
    //}
    #endregion
}
