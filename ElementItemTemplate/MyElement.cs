﻿using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using ZennoFramework;
using ZennoFramework.Wrappers;

namespace $rootnamespace$
{
    public class $safeitemrootname$ : Element<$safeitemrootname$>
    {
        public $safeitemrootname$(BotContext context) : base(context)
        {
        }

        protected override Element OnFinding()
        {
            return Context.Instance.ActiveTab.FindElementByXpath("your xpath");
        }
    }
}
