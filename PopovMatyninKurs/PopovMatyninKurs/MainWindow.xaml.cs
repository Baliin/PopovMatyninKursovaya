using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace PopovMatyninKurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Mem> memlist = new List<Mem>();
        AddMem addMem = new AddMem();
        int count = 0;
        bool u = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            addMem.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            memlist.Add(new Mem(addMem.GetName(), addMem.GetKate(), addMem.GetWay()));
            ListM.Items.Add(memlist[count].GetName());
            for (int i = 0; i < KateComb.Items.Count; i++)
            {
                if (KateComb.Items[i].ToString() == memlist[count].GetKate())
                {
                    u = true;
                }
            }
            if (u == false)
            {
                KateComb.Items.Add(memlist[count].GetKate());
            }
            count++;
            u = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ListM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListM.SelectedIndex != -1)
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                for (int i = 0; i < memlist.Count; i++)
                {
                    if (memlist[i].GetName() == ListM.SelectedItem.ToString())
                    {
                        src.UriSource = new Uri(memlist[i].GetWay());
                        break;
                    }
                }
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                IMG.Source = src;
            }
        }

        private void DelBut_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < memlist.Count; i++)
            {
                if (memlist[i].GetName() == ListM.SelectedItem.ToString())
                {
                    ListM.Items.RemoveAt(i);
                    memlist.RemoveAt(i);
                    count--;
                    ListM.SelectedIndex = -1;
                    IMG.Source = null;
                    break;
                    //////////bag with combobox
                }
            }
        }

        private void KateComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListM.Items.Clear();
            IMG.Source = null;
            for (int i = 0; i < memlist.Count; i++)
            {
                if (memlist[i].GetKate() == KateComb.SelectedItem.ToString())
                {
                    ListM.Items.Add(memlist[i].GetName());
                    ListM.SelectedIndex = -1;
                }
            }
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("data.json", string.Empty);
            for (int i = 0; i < memlist.Count; i++)
            {
                File.AppendAllText("data.json", JsonConvert.SerializeObject(memlist[i]));
            }
        }

        private void LoadBut_Click(object sender, RoutedEventArgs e)
        {
            ListM.SelectedIndex = -1;
            ListM.Items.Clear();
            KateComb.Items.Clear();
            count = 0;
            IMG.Source = null;
            List<string> povt = new List<string>();
            JsonTextReader read = new JsonTextReader(new StreamReader("data.json"));
            read.SupportMultipleContent = true;
            while (true)
            {
                if (!read.Read())
                {
                    break;
                }
                JsonSerializer serializer = new JsonSerializer();
                Mem mem = serializer.Deserialize<Mem>(read);
                memlist.Add(mem);
                count++;
                ListM.Items.Add(mem.GetName());
            }
            for (int i = 0; i < memlist.Count; i++)
            {
                bool uwu = false;
                    for (int j = 0; j < povt.Count; j++)
                    {
                        if (povt[j] == memlist[i].GetKate())
                        {
                            uwu = true;
                            break;
                        }
                    }
                    if (uwu == false)
                    {
                        KateComb.Items.Add(memlist[i].GetKate());
                        povt.Add(memlist[i].GetKate());
                    }
            }
        }
    }
}
