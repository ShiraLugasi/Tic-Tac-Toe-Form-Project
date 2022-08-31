using System;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToeProject
{
    public partial class TicTacToe : Form
    {
        bool turn = true; // true= x turn, false= y turn
        int turn_count = 0;
        

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Shira&Dennis&May", "tic tac toe about");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            b.BackColor = Color.LightPink;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            //COMPUTER MOVE
            turn = !turn;
            turn_count++;

            checkfowinner();
        }
        private void checkfowinner()

        {
            bool there_is_a_winner = false;
            //ROW
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&& (!A2.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text)&& (!B2.Enabled))
                there_is_a_winner = true;
            else  if ((C1.Text == C2.Text) && (C2.Text == C3.Text)&& (!C2.Enabled))
                there_is_a_winner = true;
            //COLUM
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!B2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!B3.Enabled))
                there_is_a_winner = true;
            //DIAGONAL
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled))
                there_is_a_winner = true;




            if (there_is_a_winner)
            {
                disableButtons();
               String winner ="";
                if (turn)
                {
                    winner = "O";
                    O_Win_Count.Text = (Int32.Parse(O_Win_Count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    X_Win_Count.Text = (Int32.Parse(X_Win_Count.Text) + 1).ToString();
                }


                MessageBox.Show(winner + "wins! " , "the winner is: ");

                freshgame();

                
            }
            else
            {
                if(turn_count == 9)
                {
                    Draw_Count.Text = (Int32.Parse(Draw_Count.Text) + 1).ToString();
                    MessageBox.Show("Draw" ,"Bummer!");// בומר זה הכותרת של תיבת ההודעה ותיקו זה תוכן
                    freshgame();
                }
            }

        }
        private void disableButtons()

        {
            try// בגלל שיש אובייקטים שהם לא כפתורים צריך להוסיף קאסט
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

           // בגלל שיש אובייקטים שהם לא כפתורים צריך להוסיף קאסט
            
                foreach (Control c in Controls)
                    {
                try

                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";

                }
                catch { }
                }
            freshgame();
          
       
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            }
        }
        private void freshgame()
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    //b.Enabled = true;
                    //b.BackColor = Color.White;
                }
            }//end try
            catch { }
            A1.Enabled = true; A1.Text = ""; A1.BackColor = Color.White;
            A2.Enabled = true; A2.Text = ""; A2.BackColor = Color.White;
            A3.Enabled = true; A3.Text = ""; A3.BackColor = Color.White;
            B1.Enabled = true; B1.Text = ""; B1.BackColor = Color.White;
            B2.Enabled = true; B2.Text = ""; B2.BackColor = Color.White;
            B3.Enabled = true; B3.Text = ""; B3.BackColor = Color.White;
            C1.Enabled = true; C1.Text = ""; C1.BackColor = Color.White;
            C2.Enabled = true; C2.Text = ""; C2.BackColor = Color.White;
            C3.Enabled = true; C3.Text = ""; C3.BackColor = Color.White;
        }
    }
    

}
