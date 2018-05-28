using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleHomeConsole
{
    public class SettingEntity : TableEntity
    {
        public SettingEntity(string kindName, string itemName)
        {
            this.PartitionKey = kindName;
            this.RowKey = itemName;
        }

        public SettingEntity() { }

        /// <summary>
        /// 設定値
        /// </summary>
        public string Value { get; set; }
    }
}