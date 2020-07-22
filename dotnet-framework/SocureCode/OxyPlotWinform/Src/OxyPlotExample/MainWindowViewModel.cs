/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotExampleBrowser
 *文件名:MainWindowViewModel
 *版本号:V1.0.0.0
 *唯一标识:660d40a8-dd00-4810-9f60-a0f250523723
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:58:45

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:58:45
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OxyPlotDemoLibs;
using OxyPlotExampleBrowser.Annotations;

namespace OxyPlotExampleBrowser
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private IEnumerable<ExampleInfo> examples;
        private ExampleInfo selectedExample;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            Examples = OxyPlotDemoLibs.Examples.GetList().OrderBy(e => e.Category);
            SelectedExample = Examples.FirstOrDefault(ei => ei.Title == Properties.Settings.Default.SelectedExample);
        }

        public IEnumerable<ExampleInfo> Examples
        {
            get { return examples; }
            set { examples = value;this.RaisePropertyChanged("Examples"); }
        }

        public ExampleInfo SelectedExample
        {
            get { return selectedExample; }
            set
            {
                selectedExample = value;
                RaisePropertyChanged("SelectedExample");
                Properties.Settings.Default.SelectedExample = value != null ? value.Title : null;
                Properties.Settings.Default.Save();
            }
        }

        protected void RaisePropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (null != null)
            {
                handler(this,new PropertyChangedEventArgs(property));
            }
        }
        
    }
}
