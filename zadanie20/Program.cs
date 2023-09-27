using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = 3; 
        int[,] array = new int[n, n];

        Random rand = new Random();
        for (int i = 0; i < n * n; i++)
        {
            int x = rand.Next(1, n * n + 1); 
            if (!array.Cast<int>().Contains(x)) 
            {
                array[i / n, i % n] = x; 
            }
            else 
            {
                i--;
            }
        }

        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0}\t", array[i, j]);
            }
            Console.WriteLine();
        }

        
        int sum = n * (n * n + 1) / 2; 
        bool isMagicSquare = true;
        for (int i = 0; i < n && isMagicSquare; i++)
        {
            isMagicSquare &= array.Cast<int>().Skip(i * n).Take(n).Sum() == sum; 
            isMagicSquare &= array.Cast<int>().Where((x, j) => j % n == i).Sum() == sum; 
        }
        isMagicSquare &= array.Cast<int>().Where((x, i) => i % (n + 1) == 0).Sum() == sum; 
        isMagicSquare &= array.Cast<int>().Where((x, i) => (i + 1) % (n - 1) == 0 && i > 0 && i < n * n - 1).Sum() == sum; 

        if (isMagicSquare)
        {
            Console.WriteLine("Магический квадрат");
        }
        else
        {
            Console.WriteLine("Не магический квадрат");
        }

        {
            Console.WriteLine("Если хотите повторить ввод, нажмите 1, иначе любую другую цифру");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1) Main();
            return;
        }
        Console.ReadLine();

    }

}
