using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Globalization;

namespace ExecelApp
{
    public partial class Form1 : Form
    {
        string excelFilePath = "";
        public List<string> ColumnDB = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.InitialDirectory = @"";
            //openExcel.Filter = "Excel文件|*.xls|Excel文件|*.xlsx"; //这里是个问题需要处理           
            openExcel.Filter = "CSV文件 | *.csv|Excel文件|*.xlsx|Excel文件|*.xls";
            openExcel.Title = "打开Excel|CSV文件";
            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                excelFilePath = openExcel.FileName;
                textBox2.Text = excelFilePath;
                //获得文件的全路径           
            }
            else
            {
                MessageBox.Show("Excel 文件读取失败 ");
            }
        }
        public void getColumnDB(string ExcelName)
        {

            //创建 Excel对象

            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();

            //获取缺少的object类型值

            object missing = Missing.Value;

            //打开指定的Excel文件

            Workbook openwb = App.Workbooks.Open(ExcelName, missing, missing, missing, missing,

                missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

            //获取选选择的工作表

            //Worksheet ws = ((Worksheet)openwb.Worksheets["TestSingleResult_SFR300_2019-02"]);//方法一：指定工作表名称读取

            Worksheet ws = (Worksheet)openwb.Worksheets.get_Item(1);//方法二：通过工作表下标读取

            //获取工作表中的行数

            int rows = ws.UsedRange.Rows.Count;

            //获取工作表中的列数

            int columns = ws.UsedRange.Columns.Count;

            //Console.WriteLine("请输入你要获取哪列数据");

            int column = Convert.ToInt16(textBox1.Text);//Convert.ToInt16(Console.ReadLine());

            //提取对应行列的数据并将其存入数组中

            for (int i = 2; i < rows; i++)

            {

                string a = ((Range)ws.Cells[i, column]).Text.ToString();

                //Console.WriteLine("读取的数据:" + a);//测试是否获得数据

                ColumnDB.Add(a);

            }

            //遍历数组

            foreach (string db in ColumnDB)
            {

                Console.WriteLine("list data:" + db);//查看数组中的数据，测试是否存储成功

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            ColumnDB.RemoveAll(it => true);
            if (string.IsNullOrEmpty(excelFilePath) || excelFilePath=="")
            {
                MessageBox.Show("请选择execel文件");
                return;
            }
            getColumnDB(excelFilePath);
            List<DateTime> temp = new List<DateTime>();
            //foreach (string db in ColumnDB)
            //{
            //    string[] arr = db.Split(new char[1] { '_' });
            //    string str = arr[0] + " " + arr[1].Replace("-", ":");
            //    temp.Add(Convert.ToDateTime(str));
            //}
            //for (int i = 1; i < temp.Count; i++)
            //{
            //    string s = (temp[i] - temp[i - 1]).ToString();
            //    textBox3.AppendText(s+"\r\n");
            //}
        }

        private DateTime TimeTranf(string timeStr)
        {
            DateTime dt;
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss.ff";
            dt = Convert.ToDateTime(timeStr, dtFormat);
            return dt;
        }
    }
}
