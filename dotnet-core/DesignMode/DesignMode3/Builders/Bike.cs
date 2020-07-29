using DesignMode3.Builders.Interface;
using DesignMode3.Builders.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders
{
    public class Bike
    {
        /// <summary>
        /// 框架
        /// </summary>
        public IFrame Frame { get; set; }

        /// <summary>
        /// 座椅
        /// </summary>
        public ISeat Seat { get; set; }

        /// <summary>
        /// 轮胎
        /// </summary>
        public ITire Tire { get; set; }
    }
}
