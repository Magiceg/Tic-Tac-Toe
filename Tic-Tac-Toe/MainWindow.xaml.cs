using System;
using System.CodeDom;
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
            /* this method is called here to make sure that all buttons 
             * were initialized correctly before the game
             */
            NewGame();
        }
        /* 
         * For more convenient further reference in the code 
         */
        private void NewGame()
        {
            InitializePlayingField();
        }

        #endregion
        #region Private members
        //taking the current player prosses
        private bool isPlayerTurn = true;
        private Button[,] arrayOfButtons; //Declaration of the buttons array
        private int moveCounter; // Counter for the number of moves
        #endregion

        private void InitializePlayingField()
        {            
            arrayOfButtons = new Button[3, 3]; //Initialize the buttons array with a 3x3 size

            //Assigning button names to a two-dimensional array
            arrayOfButtons[0, 0] = Button0_0;
            arrayOfButtons[0, 1] = Button0_1;
            arrayOfButtons[0, 2] = Button0_2;
            arrayOfButtons[1, 0] = Button1_0;
            arrayOfButtons[1, 1] = Button1_1;
            arrayOfButtons[1, 2] = Button1_2;
            arrayOfButtons[2, 0] = Button2_0;
            arrayOfButtons[2, 1] = Button2_1;
            arrayOfButtons[2, 2] = Button2_2;

            moveCounter = 0; //Initialize the move counter
            isPlayerTurn = true;
        }
                
        /* This method takes the button object as an argument
         * and is responsible for setting the button content
         * depending on the player's current move
         */ 
        private void ButtonContent(Button button)
        {
            bool currentPlayerTurn = isPlayerTurn;
            if (isPlayerTurn)
            {
                button.Content = "X";
                labelPlayerTurn.Content = "Player: O";
            }
            else
            {
                button.Content = "O";
                labelPlayerTurn.Content = "Player: X";
            }
            

            moveCounter++;  //Increment the move counter

            //check for winning condition
            if (CheckForWin())
            {
                GameOver();
                isPlayerTurn = currentPlayerTurn;
                labelPlayerTurn.Content = currentPlayerTurn ? "Player: X" : "Player: O";
                return;
            }
            //check for a tie
            else if (moveCounter == 9 && !CheckForWin())
            {
                GameTie();
                isPlayerTurn = currentPlayerTurn;
                labelPlayerTurn.Content = currentPlayerTurn ? "Player: X" : "Player: O";
                return;
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
                    DisableButtons();
                    return true;
                }
                    
            }
            //Check columns for win
            for(int column  = 0; column < 3; column++)
            {
                if (CheckLine(arrayOfButtons[0, column], arrayOfButtons[1, column], arrayOfButtons[2,column]))
                {
                    DisableButtons();
                    return true;
                }
                    
            }
            //Check diagonals for win
            if (CheckLine(arrayOfButtons[0,0], arrayOfButtons[1,1], arrayOfButtons[2,2]))
            {
                DisableButtons();
                return true;
            }
               
            //Antidiagonals
            if (CheckLine(arrayOfButtons[0,2], arrayOfButtons[1,1], arrayOfButtons[2,0]))
            {
                DisableButtons();
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
            string content1 = button1.Content?.ToString();
            string content2 = button2.Content?.ToString();
            string content3 = button3.Content?.ToString();
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


        private async void GameOver()
        {
            //wait one second before calling the method ShowEndScreen
            await Task.Delay(1000);
            //if 'isPlayerTurn' = true, winner is Player X, else Player O
            string result = isPlayerTurn ? "Winner: Player X" : "Winner: Player O";
            ShowEndScreen(result);
        }
        private async void GameTie()
        {
            await Task.Delay(1000);
            string result = "It's a tie";
            ShowEndScreen(result);
        }

        /* Displaying information about who won
         * or would have been a tie
         */
        private void ShowEndScreen(string result)
        {
            EndScreen.Visibility = Visibility.Visible;
            Result.Text = result;
        }
        
        /* After pressing the 'Play' button, it clear the field,
         * starts a new game and hides the end and start screen of the game
         */
        private void Restart_Button(object sender, RoutedEventArgs e)
        {
            NewGame();
            ClearPlayingField();
            EndScreen.Visibility = Visibility.Hidden;
        }

        /* Disables the buttons. In this case, it is used to disable
         * pressing the buttons after a winning combination
         */
        private void DisableButtons()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    arrayOfButtons[row, col].IsEnabled = false;
                }
            }
        }

        /* This method iterates over all elements of a two-dimensional array.
         * Sets the content of the button to null to clear  it from precious move.
         * After that, the value of all buttons is set to 'true' for the new game
         */
        private void ClearPlayingField()
        {
           for(int row  = 0; row < 3;  row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    arrayOfButtons[row, col].Content = null;
                    arrayOfButtons[row, col].IsEnabled = true;
                }
            }
            isPlayerTurn = true;
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
