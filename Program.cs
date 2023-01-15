namespace KrydsOgBolle
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamestate state = new Gamestate();
            
           TicTac game = new TicTac();
           while (true){
           game.TakeInput();

           }
            
        }
    }
    class TicTac
    {
        public TicTac(){_state = new Gamestate(); Turn = true;}

        public bool Turn { get; set;}

        public void TakeInput(){
            Console.WriteLine(View.DisplayState(_state.State));
            if(_state.checkWin()){
                Console.WriteLine($" the winner is {Turn}");
            }
            // if(_state.CheckDraw()){
            //     Console.WriteLine("Hello, World! its a draw!");
            // }
            Turn = !Turn;
            Console.WriteLine(View.inputMessage());
                int row;
                int column;
            try
            {
                while (!Int32.TryParse(Console.ReadLine(), out row))
            {
                Console.WriteLine("The value entered was not a number, try again.");
                Console.WriteLine("Input number: ");
            }

                while (!Int32.TryParse(Console.ReadLine(), out column))
            {
                Console.WriteLine("The value entered was not a number, try again.");
                Console.WriteLine("Input number: ");
            }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            _state.changegameState(row,column,Turn == true? 1:-1);



        }

        private Gamestate _state; 
    }
    class View 
    {
        public static string DisplayState(int [][] state){
            Console.Clear();
            string outputString = "";
            foreach(int [] column in state){
                outputString += "||";
                foreach ( int element in column){
                    if(element == 1){
                        outputString += "X";
                    }
                    else if(element == 0){
                        outputString += "*";
                    }
                    else outputString += "O";
                    

                }
                outputString += "||\n";
            }
            return(outputString);
        }
        public static string inputMessage(){
            return("input row then column to place X cannot place X where there already is a O press q to exit");
        }

    }


    class Gamestate
    {
        public Gamestate(){
            int [][] newState = new int[3][];
            newState[0] = new int[3]{0,0,0};
            newState[1] = new int[3]{0,0,0};
            newState[2] = new int[3]{0,0,0};
            _state = newState;
        }
        private int[][] _state;
        public int[][]State{get {return _state;}}

        public void changegameState(int row, int column, int type) => _state[row][column] = type;

        public bool checkWin(){
            int length = 3;
            int target = 9;
            
            //checks row win
            foreach( int [] row in _state){
                int value = row.Sum();
                if ( Math.Pow(value, 2) == target){
                    return true;
                }
            }
            //checks column win
            int column1 = 0;
            int column2 = 0;
            int column3 = 0;
            
            for (int i = 0; i < length; i++)
            {
                column1 += State[i][0];
                column2 += State[i][1];
                column3 += State[i][2];
            }

            // checks cross win
            int rightDiagonal = 0;
            int leftDiagonal = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if(i + j == 2){
                        rightDiagonal += State[i][j];
                    }
                    if(i == j){
                        leftDiagonal += State[i][j];
                    }
                }
            }
            if(Math.Pow(column1, 2) == target || Math.Pow(column2, 2) == target || Math.Pow(column1, 2) == target || Math.Pow(rightDiagonal, 2) == target || Math.Pow(column1, 2) == target){
                return true;
            }
            else return false;
        }
        public bool CheckDraw(){
            if(_state.Any(i=>i.Contains(0))){
                    return true;
                }
            else return false;
        }

    }
}