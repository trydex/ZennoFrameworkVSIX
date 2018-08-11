using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using ZennoFramework;
using ZennoFramework.Logging.Abstractions;
using ZennoFramework.Logging.Zenno;
using ZennoLab.InterfacesLibrary.ProjectModel;
using Instance = ZennoLab.CommandCenter.Instance;
using LogLevel = ZennoFramework.Logging.LogLevel;

namespace $rootnamespace$
{
    public class $safeitemrootname$ : BotContext
    {
        public $safeitemrootname$(Instance instance, IZennoPosterProjectModel project) : base(instance, project)
        {
        }

        protected override void Configure(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddZenno(Project, LogLevel.Trace);
        }
    }
}
