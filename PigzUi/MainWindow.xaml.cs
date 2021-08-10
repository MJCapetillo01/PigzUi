using PigzUi.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PigzUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> compressFileNames = new();

        public List<string> decompressFileNames = new ();

        public List<int> allStrengths = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

        public List<string> compressParameters = new ();

        public List<string> decompressParameters = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadFields();
            SetupStrength();
            CheckForPath();
        }

        private void ButtonCFiles_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Multiselect = true;

            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                foreach (var file in openFileDlg.FileNames)
                {
                    compressFileNames.Add(file);
                }
            }
            RefreshList(ListBoxC, compressFileNames);
        }
        private void ButtonCFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFileDlg = new FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                compressFileNames.Add(openFileDlg.SelectedPath);
            }
            RefreshList(ListBoxC, compressFileNames);
        }

        private void ButtonCClear_Click(object sender, RoutedEventArgs e)
        {
            CompressClear();
        }

        private void ButtonCRun_Click(object sender, RoutedEventArgs e)
        {
            RunCompressCMD();
        }

        private void RadioFast_Checked(object sender, RoutedEventArgs e)
        {
            ComboBoxStrength.SelectedIndex = 1;
            ComboBoxStrength.IsEnabled = false;
        }

        private void RadioBest_Checked(object sender, RoutedEventArgs e)
        {
            ComboBoxStrength.SelectedIndex = 9;
            ComboBoxStrength.IsEnabled = false;
        }

        private void RadioCustom_Checked(object sender, RoutedEventArgs e)
        {
            ComboBoxStrength.IsEnabled = true;
        }

        private void ListBoxC_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var deleteItem = ListBoxC.SelectedValue.ToString();
                compressFileNames.Remove(deleteItem);
                RefreshList(ListBoxC, compressFileNames);
            }
        }

        private void LoadFields()
        {
            if (!String.IsNullOrEmpty(Settings.Default["PigzPath"].ToString()))
            {
                Utility.PigzPath = Settings.Default["PigzPath"].ToString();
                TextBoxSCompress.Text = Utility.PigzPath;
            }

            if (!String.IsNullOrEmpty(Settings.Default["UnPigzPath"].ToString()))
            {
                Utility.UnPigzPath = Settings.Default["UnPigzPath"].ToString();
                TextBoxSDecompress.Text = Utility.UnPigzPath;
            }
        }

        private void SetupStrength()
        {
            ComboBoxStrength.ItemsSource = allStrengths;
            ComboBoxStrength.SelectedIndex = 1;
            RadioBest.IsChecked = true;
        }

        private void RefreshList(System.Windows.Controls.ListBox lb, List<string> source)
        {
            lb.ItemsSource = null;
            lb.ItemsSource = source;
        }

        private void RunCompressCMD()
        {
            String command = @"/C " +
                $"{Utility.PigzPath} " +
                $"-{ComboBoxStrength.SelectedValue}";

            foreach (var parem in compressParameters)
                command += $"{parem}";

            foreach (var fileName in compressFileNames)
                command += $" {fileName}";

            Process.Start("cmd.exe", $"{command}").WaitForExit();
            CompressClear();
        }

        private void CompressClear()
        {
            compressFileNames.Clear();
            RefreshList(ListBoxC, compressFileNames);
        }

        private void ButtonDFiles_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Multiselect = true;

            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                foreach (var file in openFileDlg.FileNames)
                {
                    decompressFileNames.Add(file);
                }
            }
            RefreshList(ListBoxD, decompressFileNames);
        }

        private void ButtonDClear_Click(object sender, RoutedEventArgs e)
        {
            DecompressClear();
        }

        private void ButtonDRun_Click(object sender, RoutedEventArgs e)
        {
            RunDecompressCMD();
            DecompressClear();
        }

        private void RunDecompressCMD()
        {
            String command = @"/C " +
              $"{Utility.UnPigzPath} ";

            foreach (var parem in decompressParameters)
                command += $"{parem}";

            foreach (var fileName in decompressFileNames)
                command += $" {fileName}";

            Process.Start("cmd.exe", $"{command}").WaitForExit();
        }

        private void DecompressClear()
        {
            decompressFileNames.Clear();
            RefreshList(ListBoxD, decompressFileNames);
        }

        private void ButtonSFindCompress_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                Utility.PigzPath = openFileDlg.FileName;
                TextBoxSCompress.Text = Utility.PigzPath;
                Settings.Default["PigzPath"] = Utility.PigzPath;
                Settings.Default.Save();
            }
        }

        private void ButtonSFindDecompress_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                Utility.UnPigzPath = openFileDlg.FileName;
                TextBoxSDecompress.Text = Utility.UnPigzPath;
                Settings.Default["UnPigzPath"] = Utility.UnPigzPath;
                Settings.Default.Save();
            }
        }

        private void CheckBoxCRecursive_Checked(object sender, RoutedEventArgs e)
        {
            compressParameters.Add(" -r");
        }

        private void CheckBoxCPreserve_Checked(object sender, RoutedEventArgs e)
        {
            compressParameters.Add(" -k");
        }

        private void CheckBoxCRecursive_Unchecked(object sender, RoutedEventArgs e)
        {
            compressParameters.Remove(" -r");
        }

        private void CheckBoxCPreserve_Unchecked(object sender, RoutedEventArgs e)
        {
            compressParameters.Remove(" -k");
        }

        private void CheckBoxDPreserve_Checked(object sender, RoutedEventArgs e)
        {
            decompressParameters.Add(" -k");
        }

        private void CheckBoxDPreserve_Unchecked(object sender, RoutedEventArgs e)
        {
            decompressParameters.Add(" -k");
        }

        private void ButtonDFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFolderDlg = new FolderBrowserDialog();
            var result = openFolderDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                decompressFileNames.Add(openFolderDlg.SelectedPath);
            }
            RefreshList(ListBoxD, decompressFileNames);
        }

        private void CheckBoxDRecursive_Checked(object sender, RoutedEventArgs e)
        {
            decompressParameters.Add(" -r");
        }

        private void CheckBoxDRecursive_Unchecked(object sender, RoutedEventArgs e)
        {
            decompressParameters.Add(" -r");
        }

        private void ListBoxD_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var deleteItem = ListBoxD.SelectedValue.ToString();
                decompressFileNames.Remove(deleteItem);
                RefreshList(ListBoxD, decompressFileNames);
            }
        }

        private void CheckForPath()
        {
            if (String.IsNullOrEmpty(Settings.Default["PigzPath"].ToString()) ||
                String.IsNullOrEmpty(Settings.Default["UnPigzPath"].ToString()))
            {
                System.Windows.MessageBox.Show("Please setup paths to Pigz/Unpigz executable!");
            }
        }
    }
}
