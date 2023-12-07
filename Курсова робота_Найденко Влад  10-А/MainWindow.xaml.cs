using System;
using System.Windows;


namespace Курсова_робота_Найденко_Влад__10_А
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Project prog = new Project();
            prog.Show();
            Close();
        }
            
    }
}
