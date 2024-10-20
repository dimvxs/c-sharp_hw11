using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Console;

namespace hw
{
    public class Game
    {
       static int rows = 3;
       static int cols = 3;
        string[,] array = new string[rows, cols];
        int moves = 9;


       public Game(){
    for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        array[i, j] = "[] ";
    }
}


        }


        public void Print(){
    for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                  
                    if (array[i, j] == "x ")
                    {
                        ForegroundColor = ConsoleColor.Red; 
                    }
                    else if (array[i, j] == "o ")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }

                    Write(array[i, j] + " ");
                }
                ResetColor();
                WriteLine();
            }
}

        




public void CheckWinner(){
  for (int i = 0; i < rows; i++)
            {
                if (array[i, 0] == "x " && array[i, 1] == "x " && array[i, 2] == "x ")
                {
                    WriteLine("ты победил по горизонтали!\n");
                    return;
                }
                if (array[i, 0] == "o " && array[i, 1] == "o " && array[i, 2] == "o ")
                {
                    WriteLine("компьютер победил по горизонтали!\n");
                    return;
                }
            }

            // Проверка вертикальных
            for (int i = 0; i < cols; i++)
            {
                if (array[0, i] == "x " && array[1, i] == "x " && array[2, i] == "x ")
                {
                    WriteLine("ты победил по вертикали!\n");
                    return;
                }
                if (array[0, i] == "o " && array[1, i] == "o " && array[2, i] == "o ")
                {
                    WriteLine("компьютер победил по вертикали!\n");
                    return;
                }
            }

            // Проверка диагоналей
            if (array[0, 0] == "x " && array[1, 1] == "x " && array[2, 2] == "x ")
            {
                WriteLine("ты победил по диагонали!\n");
            }
            else if (array[0, 0] == "o " && array[1, 1] == "o " && array[2, 2] == "o ")
            {
                WriteLine("компьютер победил по диагонали!\n");
            }
            else if (array[0, 2] == "x " && array[1, 1] == "x " && array[2, 0] == "x ")
            {
                WriteLine("ты победил по диагонали!\n");
            }
            else if (array[0, 2] == "o " && array[1, 1] == "o " && array[2, 0] == "o ")
            {
                WriteLine("компьютер победил по диагонали!\n");
            }
            else if (moves == 0)
            {
                WriteLine("ничья!\n");
            }
}




        public void UserComp(){
            Write("\n");
            Print();
            do{
            WriteLine("введите ряд: ");
            string r = ReadLine();
            int row = int.Parse(r);

            WriteLine("введите столбец: ");
            string c = ReadLine();
            int col = int.Parse(c);

if(array[row, col] == "[] "){
array[row, col] = "x ";
moves--;
}
 else
                {
                    Write("эта ячейка уже занята! попробуй снова");
                    continue; 
                }

Random random = new Random();

int compCol;
int compRow;

 do{
                    compRow = random.Next(0, rows);
                    compCol = random.Next(0, cols);
                } while (array[compRow, compCol] != "[] ");
     array[compCol, compRow] = "o ";


Clear();
Print();
CheckWinner();
            } while(moves > 0);
        
      


        }


        public void UserUser(){
            Write("\n");
            Print();

            WriteLine("введите имя первого пользователя: ");
            string name1 = ReadLine();

            WriteLine("введите имя второго пользователя: ");
            string name2 = ReadLine();

            string currentPlayer = name1;
            string currentSymbol = "x "; 


            do{
            WriteLine("${currentPlayer}, введите ряд: ");
            string r = ReadLine();
            int row = int.Parse(r);

            WriteLine("${currentPlayer}, введите столбец: ");
            string c = ReadLine();
            int col = int.Parse(c);

if(array[row, col] == "[] "){
array[row, col] = currentSymbol;
moves--;
            Clear();
            Print();
            CheckWinner();
            
            if(currentPlayer == name1){
                currentPlayer = name2;
                currentSymbol = "o ";
            }

}
 else
                {
                    Write("эта ячейка уже занята! попробуй снова");
                    continue; 
                }





Clear();
Print();
CheckWinner();
            } while(moves > 0);
             WriteLine("игра окончена!");
        
        }

        
    }
}