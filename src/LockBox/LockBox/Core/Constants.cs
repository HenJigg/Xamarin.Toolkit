using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toolkit.Core
{
    public class Constants
    {
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "Toolkit.db");
            }
        }

        public static async void DataBaseInitAsync(ToolkitContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.ToolkitMasters.Any())
                {
                    await context.ToolkitMasters.AddRangeAsync(new ToolkitMaster[] {
                 new ToolkitMaster() { GroupIcon = "\xe605", GroupName = "钱包", GroupDesc = "存储与钱相关的账号密码..." },
                 new ToolkitMaster() { GroupIcon = "\xe720", GroupName = "游戏", GroupDesc = "存储游戏相关的账号密码..." },
                 new ToolkitMaster() { GroupIcon = "\xe61c", GroupName = "社区", GroupDesc = "存储社区相关的账号密码,例如:Github、Gitee..." },
                 new ToolkitMaster() { GroupIcon = "\xe601", GroupName = "论坛", GroupDesc = "存储论坛相关的账号密码,例如:博客园等..." },
                 new ToolkitMaster() { GroupIcon = "\xe6cb", GroupName = "企业", GroupDesc = "存储公司相关的账号密码..." },
                 new ToolkitMaster() { GroupIcon = "\xe6cb", GroupName = "其它", GroupDesc = "存储其它的账号密码..." },
                });
                    await context.SaveChangesAsync();
                }
            }
            catch
            {

            }
        }
    }
}
