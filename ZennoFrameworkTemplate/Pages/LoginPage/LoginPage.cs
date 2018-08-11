using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoFramework;
using ZennoFramework.Wrappers;

namespace ZennoFrameworkTemplate.Pages.LoginPage
{
    public class LoginPage : ElementContainer<BotContext>
    {
        public LoginPage(BotContext context) : base(context)
        {
        }
    }
}
