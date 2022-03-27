using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace PopovMatyninKurs
{
    /// <summary>
    /// Логика взаимодействия для AddMem.xaml
    /// </summary>
    public partial class AddMem : Window
    {
        //MainWindow main;
        private string name, kate, way;
        public AddMem()
        {
            InitializeComponent();
        }

        private void WayButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog way = new OpenFileDialog();
            way.ShowDialog();
            WayText.Text = way.FileName;
        }

        private void AddButt_Click(object sender, RoutedEventArgs e)
        {
            name = NameText.Text;
            kate = KateText.Text;
            way = WayText.Text;
            //main.Addmemin(name, kate, way);
            NameText.Text = "";
            KateText.Text = "";
            WayText.Text = "";
            Hide();
        }

        public string GetName()
        {
            return name;    
        }
        public string GetKate()
        {
            return kate;
        }
        public string GetWay()
        {
            return way;
        }
    }
}
