using Dapper;
using MySqlConnector;
 
 public static class Font
 {


 private static void ProgressBarPaint(int progress, int total, string _label)
        {
            //Draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            int oneChunk = 30 / total;

            //draw filled part
            int cursorPosition = 1;
            for (int i = 0; i <= oneChunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = cursorPosition++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = cursorPosition; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = cursorPosition++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 33;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" " + (progress*10) + "%" + " " + _label); //blanks at the end remove any excess
        }

     public static void ProgressBar(int _time_in_sec, string _label)
        {
            int time_in_milli_sec = _time_in_sec * 1000;
            int totalBlocks = 10;

            for (int currentBlock = 0; currentBlock <= totalBlocks; currentBlock++ )
            {
                Thread.Sleep(time_in_milli_sec/totalBlocks);
                ProgressBarPaint(currentBlock, totalBlocks, _label);
            }
            Console.Write("\n\n");
        }




 }