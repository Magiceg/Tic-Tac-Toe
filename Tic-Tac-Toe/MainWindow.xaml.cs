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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion
        #region Private members
        // contains the current result of the cell of the field
        private CellType[] currentResult;
        //taking the current player prosses
        private bool isPlayerTurn = true;
        private bool gameEnd;
        #endregion


        /* This method takes the button object as an argument
         * and is responsible for setting the button content
         * depending on the player's current move
         */ 
        private void ButtonContent(Button button)
        {
            if (isPlayerTurn)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "O";
            }
            //the isPlayerTurn value is inverted to pass the move to the next player
            isPlayerTurn = !isPlayerTurn;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //converting the sender object type to the Button type and assigning it to the button variable
           Button button = (Button)sender;
           ButtonContent(button);
           //disables the button  and makes it unavailable for further interaction
           button.IsEnabled = false;
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
