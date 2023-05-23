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
using System.Xml.Linq;

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
        private Button[,] arrayOfButtons; //Declaration of the buttons array
        #endregion

        public void InitializePlayingField()
        {
            //Initialize the buttons array with a 3x3 size
            arrayOfButtons = new Button[3, 3];
            //assigning button names to a two-dimensional array
            arrayOfButtons[0, 0] = Button0_0;
            arrayOfButtons[0, 1] = Button0_1;
            arrayOfButtons[0, 2] = Button0_2;
            arrayOfButtons[1, 0] = Button1_0;
            arrayOfButtons[1, 1] = Button1_1;
            arrayOfButtons[1, 2] = Button1_2;
            arrayOfButtons[2, 0] = Button2_0;
            arrayOfButtons[2, 1] = Button2_1;
            arrayOfButtons[2, 2] = Button2_2;

        }
                
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
            InitializePlayingField();
            //check for winning condition
            if (CheckForWin())
            {
                GameOver();
            }
            //the isPlayerTurn value is inverted to pass the move to the next player
            isPlayerTurn = !isPlayerTurn;
        }

        /* The CheckForWin method iterates over the rows, columns,
         * and diagonals of the game board, using the CheckLine method
         * to check if a winning line is formed by the buttons' content
         */
        private bool CheckForWin()
        {
            //Check rows for win
            for(int row = 0; row < 3; row++)
            {
                if (CheckLine(arrayOfButtons[row,0], arrayOfButtons[row,1], arrayOfButtons[row,2]))
                {
                    return true;
                }
                    
            }
            //Check columns for win
            for(int column  = 0; column < 3; column++)
            {
                if (CheckLine(arrayOfButtons[0, column], arrayOfButtons[1, column], arrayOfButtons[2,column]))
                {
                    return true;
                }
                    
            }
            //Check diagonals for win
            if (CheckLine(arrayOfButtons[0,0], arrayOfButtons[1,1], arrayOfButtons[2,2]))
            {
                return true;
            }
               
            //Antidiagonals
            if (CheckLine(arrayOfButtons[0,2], arrayOfButtons[1,1], arrayOfButtons[2,0]))
            {
                return true;
            }
                

            return false;
        }

        /* This method accepts three Button type objects as arguments
         * and check whether they form a line the same content(X or O) 
         */
        private bool CheckLine(Button button1, Button button2, Button button3)
        {
            //to compare the contents of buttons as strings 
            string content1 = button1.Content as string;
            string content2 = button2.Content as string;
            string content3 = button3.Content as string;
            /* What is it for
             * Checking for null and empty string.
             * If this is done ot will mean that the three buttons form
             * a line with the same content
             */
            if(!string.IsNullOrEmpty(content1) && content1 == content2 && content2 == content3)
                    return true;

            return false;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //converting the sender object type to the Button type and assigning it to the button variable
           Button button = (Button)sender;
           ButtonContent(button);
           //disables the button  and makes it unavailable for further interaction
           button.IsEnabled = false;
        }

        private void GameOver()
        {
            MessageBox.Show("Game over");
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
