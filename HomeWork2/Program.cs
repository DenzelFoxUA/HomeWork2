using HomeWork2.Task1;

namespace HomeWork2
{
    internal class Program
    {
        public enum Menu
        { 
            Task1 = 1,
            Task2 = 2,
            Task3 = 3,
            Exit = 4
        
        }

        static void Main(string[] args)
        {
            int numberOfbuttons = 4;
            bool correct = false;
            int choise = 0;
            do
            {
                string input = string.Empty;
                Console.WriteLine("Choose task: [1] [2] [3] or [4] - exit");
                input = Console.ReadLine();
                correct = int.TryParse(input, out choise);

                if(!correct || choise > numberOfbuttons && choise <= 0)
                {
                    Console.WriteLine("Incorrect selection. Press enter");
                    Console.ReadLine();
                    correct = false;
                    Console.Clear();
                }

            }
            while (!correct);


            switch (choise)
            {
                case (int)Menu.Task1: Task1.Task1.Run(); break; 
                case (int)Menu.Task2: Task2.Task2.Run(); break; 
                case (int)Menu.Task3: Task3.Task3.Run(); break;
                case (int)Menu.Exit: break;
                default: break;
            
            }
        }
    }
}
