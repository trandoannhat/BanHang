using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Data.Entities
{
    public class SystemSetting
    {
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }

        public string SettingDescription { get; set; }
    }
}