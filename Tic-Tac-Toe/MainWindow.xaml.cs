using System;
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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion
        

        private bool isPlayerXTurn = true;
        private void ButtonContent(Button button)
        {
            if (isPlayerXTurn)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "O";
            }
            isPlayerXTurn = !isPlayerXTurn;
        }

        private void Button0_0_Click(object sender, RoutedEventArgs e)
        {
           Button button = (Button)sender;
           ButtonContent(button);
           button.IsEnabled = false;
        }
        private void Button1_0_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }
        private void Button2_0_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }

        private void Button0_1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }
        private void Button1_1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }
        private void Button2_1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }

        private void Button0_2_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }
        private void Button1_2_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }
        private void Button2_2_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ButtonContent(button);
            button.IsEnabled = false;
        }


        private void GameUniGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Restart_Button(object sender, RoutedEventArgs e)
        {
            
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
