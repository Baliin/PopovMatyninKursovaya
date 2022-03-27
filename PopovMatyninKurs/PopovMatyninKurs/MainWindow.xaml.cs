﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PopovMatyninKurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Mem> memlist = new List<Mem>();
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
    }
}
