using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace DialogLibrary
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            SetStartFolder();
            DataContext = this;
            tbZennoPosterFolder.KeyUp += ValidateData;
        }

        private void SetStartFolder()
        {
            
            var startPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"ZennoLab\RU\ZennoPoster Pro");
            if (Directory.Exists(startPath))
            {
                var lastVersionPath = Directory.GetDirectories(startPath).OrderByDescending(p => p).First() + @"\Progs";
                if (File.Exists(Path.Combine(lastVersionPath, "ZennoPoster.exe")))
                {
                    ZennoPosterFolder = lastVersionPath;
                }
                else
                {
                    ZennoPosterFolder = startPath;
                }
            }

            ParseZennoPosterVersion();
        }

        public bool IncludeCodeGenerator
        {       
            get => (bool)GetValue(IncludeCodeGeneratorProperty);
            set => SetValue(IncludeCodeGeneratorProperty, value);
        }

        public static readonly DependencyProperty IncludeCodeGeneratorProperty =
            DependencyProperty.Register(nameof(IncludeCodeGenerator), typeof(bool), typeof(StartWindow), new PropertyMetadata(true));

        public string ZennoPosterFolder
        {
            get => (string)GetValue(ZennoPosterFolderProperty);
            set => SetValue(ZennoPosterFolderProperty, value);
        }

        public static readonly DependencyProperty ZennoPosterFolderProperty =
            DependencyProperty.Register(nameof(ZennoPosterFolder), typeof(string), typeof(StartWindow));

        
        public string SerialKey
        {
            get => (string)GetValue(SerialKeyProperty);
            set => SetValue(SerialKeyProperty, value);
        }

        public static readonly DependencyProperty SerialKeyProperty =
            DependencyProperty.Register(nameof(SerialKey), typeof(string), typeof(StartWindow));


        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = ZennoPosterFolder;
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    ZennoPosterFolder = dialog.SelectedPath;
                    ParseZennoPosterVersion();
                }
            }
        }

        private void ParseZennoPosterVersion()
        {
            string zennoPosterPath = Path.Combine(ZennoPosterFolder, "ZennoPoster.exe");
            if (File.Exists(zennoPosterPath))
            {
                var info = FileVersionInfo.GetVersionInfo(zennoPosterPath);
                tbCheckPathInfo.Foreground = new SolidColorBrush(Colors.MediumSeaGreen);
                tbCheckPathInfo.Text = "Версия ZennoPoster: " + info.FileVersion;
                CreateButton.IsEnabled = true;
            }
            else
            {
                tbCheckPathInfo.Foreground = new SolidColorBrush(Colors.DarkRed);
                tbCheckPathInfo.Text = "ZennoPoster.exe не найден";
                CreateButton.IsEnabled = false;
            }   
        }

        private void ValidateData(object sender = null, KeyEventArgs keyEventArgs = null)
        {
            ParseZennoPosterVersion();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }   

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
