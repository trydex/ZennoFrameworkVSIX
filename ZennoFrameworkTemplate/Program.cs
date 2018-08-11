using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Resources;
using System.ComponentModel;
using System.Collections.Generic;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoLab.InterfacesLibrary.ProjectModel.Enums;
using ZennoLab.Emulation;

namespace $safeprojectname$
{
    /// <summary>
    /// Класс для запуска выполнения скрипта
    /// </summary>
    public class Program : IZennoCustomCode, IZennoCustomEndCode
    {
        /// <summary>
        /// GoodEnd
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        public void GoodEnd(Instance instance, IZennoPosterProjectModel project)
        {
            //TODO: insert your code of GoodEnd here
        }

        /// <summary>
        /// BadEnd
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        public void BadEnd(Instance instance, IZennoPosterProjectModel project)
        {
            //TODO: insert your code of BadEnd here
        }

        /// <summary>
        /// Метод для запуска выполнения скрипта
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        /// <returns>Код выполнения скрипта</returns>
        public int ExecuteCode(Instance instance, IZennoPosterProjectModel project)
        {
            int executionResult = 0;

            return executionResult;
        }
    }
}