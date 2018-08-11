using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DialogLibrary;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;


namespace Wizard
{   
    public class Wizard : IWizard
    {
        private StartWindow _startWindow;

        // This method is called before opening any item that   
        // has the OpenInEditor attribute.  
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            
        }   

        public void ProjectFinishedGenerating(Project project)
        {
            
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.  
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {

            _startWindow = new StartWindow();
            if (_startWindow.ShowDialog() != true)
            {
                throw new WizardCancelledException();
            }

            // Add custom parameters.  
            replacementsDictionary.Add("$serialkey$",
                _startWindow.SerialKey ?? "ВАШ_СЕРИЙНЫЙ_КЛЮЧ");
            replacementsDictionary.Add("$includecodegenerator$", _startWindow.IncludeCodeGenerator.ToString().ToLower());
            replacementsDictionary.Add("$interfaceslibrarydllpath$", Path.Combine(_startWindow.ZennoPosterFolder, "ZennoLab.InterfacesLibrary.dll"));
            replacementsDictionary.Add("$commandcenterdllpath$", Path.Combine(_startWindow.ZennoPosterFolder, "ZennoLab.CommandCenter.dll"));
            replacementsDictionary.Add("$emulationllpath$", Path.Combine(_startWindow.ZennoPosterFolder, "ZennoLab.Emulation.dll"));
            replacementsDictionary.Add("$instanceport$", "50606");
            replacementsDictionary.Add("$coderunnerpath$", Path.Combine(_startWindow.ZennoPosterFolder, "ZennoLab.CodeRunner.exe").Replace(@"\", @"\\"));
            replacementsDictionary.Add("$zennocachepath$", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"ZennoLab\ZennoPoster\5").Replace(@"\", @"\\"));

            //var projectDllPath = replacementsDictionary["$destinationdirectory$"] + @"\bin\Debug\" +
            //                     replacementsDictionary["$projectname$"] + ".dll"; 
            var projectDllPath = Path.Combine(_startWindow.ZennoPosterFolder, @"ExternalAssemblies\" + replacementsDictionary["$projectname$"] + ".dll");
            replacementsDictionary.Add("$projectdllpath$", projectDllPath.Replace(@"\", @"\\"));
            replacementsDictionary.Add("$externalassembliespath$", Path.Combine(_startWindow.ZennoPosterFolder, "ExternalAssemblies"));

        }

        // This method is only called for item templates,  
        // not for project templates.  
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}

