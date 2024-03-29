﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;
using WindowsInput;
using WindowsInput.Native;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;
using Excel = Microsoft.Office.Interop.Excel;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            CefSharp.Cef.Initialize(settings);
            InitializeComponent();
            string url = $"https://translate.yandex.com/?source_lang=en&target_lang=ru&text=";
            browser_window.Load(url);
            //ProcessStartInfo info = new ProcessStartInfo("C:\\Users\\Drogen\\OneDrive\\WpfApp2\\script.ahk");
            //info.UseShellExecute = true;
            //info.Verb = "runas";
            //Process.Start(info);
            //this.ShowInTaskbar=true;

        }

        public async void Favourite()
        {
            var items = await Clipboard.GetHistoryItemsAsync();
            int cnt = 0;

            foreach (var item in items.Items)
            {
                cnt++;
                string data = await item.Content.GetTextAsync();
                data = data.Replace(System.Environment.NewLine, " ");
                if(cnt == 1)
                    textbox_context_trs.Text = data;
                if (cnt == 2)
                {
                    textbox_context_src.Text = data;
                    break;
                }
     
            }

            ClearClipboard();
        }


        public async void test()
        {

            


        }

        public async void WordTranslate()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            textbox_word.Text = data;
            string url = $"https://translate.google.com/?hl=en&tab=TT&sl=en&tl=ru&text={data}&op=translate";
            browser_window.Load(url);
            ClearClipboard();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteToSpreadsheet();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ClearTextboxes();
        }

        public void WriteToSpreadsheet()
        {
            this.WindowState = (WindowState)FormWindowState.Minimized;
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open("C:\\Users\\Drogen\\OneDrive\\Book.xlsx", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Rows[1].Insert();
            xlWorkSheet.Cells[1, 1].Value = textbox_word.Text;
            xlWorkSheet.Cells[1, 2].Value = textbox_translation.Text;
            xlWorkSheet.Cells[1, 3].Value = textbox_context_src.Text;
            xlWorkSheet.Cells[1, 4].Value = textbox_context_trs.Text;
            excelWorkBook.Save();

            excelWorkBook.Close(true);
            excelApplication.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            ClearTextboxes();
            

        }

        public void ClearTextboxes()
        {
            textbox_word.Text = "";
            textbox_translation.Text = "";
            textbox_context_src.Text = "";
            textbox_context_trs.Text = "";
        }

        public void ClearClipboard()
        {
            Clipboard.ClearHistory();
            Clipboard.Clear();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName == "AutoHotkey")
                    process.Kill();
            }
        }

        public async void WordTextbox()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            textbox_word.Text = data;
            ClearClipboard();
        }
        
        public async void TranslationTextbox()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            textbox_translation.Text = data;
            ClearClipboard();
        }

        public async void SrcContextTextbox()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            textbox_context_src.Text = data;
            ClearClipboard();
        }

        public async void TrsContextTextbox()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            textbox_context_trs.Text = data;
            ClearClipboard();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                WordTranslate();
            }            
            if (e.Key == Key.F5)
            {
                Favourite();
            }
            if (e.Key == Key.F6)
            {
                WriteToSpreadsheet();
            }
            if (e.Key == Key.F7)
            {
                WholeSentenceTranslate();
            }
            if (e.Key == Key.F8)
            {
                WordTextbox();
            }
            if (e.Key == Key.F9)
            {
                TranslationTextbox();
            }
            if (e.Key == Key.F1)
            {
                SrcContextTextbox();
            }
            if (e.Key == Key.F2)
            {
                TrsContextTextbox();
            }
        }

        public async void WholeSentenceTranslate()
        {
            var item = Clipboard.GetContent();
            string data = await item.GetTextAsync();
            string url = $"https://translate.google.com/?hl=en&tab=TT&sl=en&tl=ru&text={data}&op=translate";
            browser_window.Load(url);
            ClearClipboard();
        }
    }


}
