using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYYServerOpenSorcePlugin
{
    public sealed class Config : IConfig
    {
        [Description("是否开启插件")]
        public bool IsEnabled { get; set; } = true;
        [Description("是否开启扫地插件")]
        public bool Enable_cleaneraddon { get; set; } = true;
        [Description("是否开启Debug")]
        public bool Debug { get; set; } = true;
    }
}
