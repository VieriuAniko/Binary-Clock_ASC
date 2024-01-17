namespace Binary_Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j, hour, minute, second;

            int[,] matrice = new int[4, 6];

            string[,] binaryClock = new string[4, 6];

            Console.Write("Ora --> ");
            hour = int.Parse(Console.ReadLine());

            Console.Write("Minute --> ");
            minute = int.Parse(Console.ReadLine());

            Console.Write("Secunde --> ");
            second = int.Parse(Console.ReadLine());

            if ((hour < 0 || hour > 23) || (minute < 0 || minute > 59) || (second < 0 || second > 59))
            {
                Console.WriteLine("Invalid.");
                return;
            }

            ConvertHourToBinary(hour, matrice);
            ConvertMinuteToBinary(minute, matrice);
            ConvertSecondToBinary(second, matrice);

            Console.WriteLine("Matricea in binar este: ");
            AfisareMatriceBinara(matrice);

            BinaryClock(matrice, binaryClock);

            Console.WriteLine();

            Console.WriteLine($"Reprezentarea orei {hour}:{minute}:{second} in ceas binar este: ");
            AfisareBinaryClock(binaryClock);
            Console.WriteLine("-----------");
            Console.WriteLine("H H M M S S");
        }

        private static void AfisareBinaryClock(string[,] binaryClock)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j < 6; j++)
                    Console.Write(binaryClock[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static void BinaryClock(int[,] matrice, string[,] binaryClock)
        {
            int i, j;

            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == 2) || (i == 0 && j == 4) || (i == 1 && j == 0))
                        binaryClock[i, j] = " ";
                    else
                    {
                        if (matrice[i, j] == 0)
                            binaryClock[i, j] = "O";
                        else
                            binaryClock[i, j] = "*";
                    }
                }
            }
        }

        private static void AfisareMatriceBinara(int[,] matrice)
        {
            int i, j;

            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j < 6; j++)
                    Console.Write(matrice[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static void ConvertSecondToBinary(int second, int[,] matrice)
        {
            int firstDigit, lastDigit, i, j;

            if (second < 10)
                firstDigit = 0; //prima cifra - second
            else
                firstDigit = second / 10; //ultima cifra - second
            lastDigit = second % 10;

            string binary; //cifra second in binar

            for (j = 4; j < 6; j++)
            {
                if (j == 4)
                    binary = Convert.ToString(firstDigit, 2);
                else
                    binary = Convert.ToString(lastDigit, 2);
                binary = binary.PadLeft(4, '0'); //binar in 4 biti

                for (i = 3; i >= 0; i--)
                    matrice[i, j] = int.Parse(binary[i].ToString());
            }
        }

        private static void ConvertMinuteToBinary(int minute, int[,] matrice)
        {
            int firstDigit, lastDigit, i, j;

            if (minute < 10)
                firstDigit = 0; //prima cifra - minute
            else
                firstDigit = minute / 10; //ultima cifra - minute
            lastDigit = minute % 10;

            string binary; //cifra minute in binar

            for (j = 2; j < 4; j++)
            {
                if (j == 2)
                    binary = Convert.ToString(firstDigit, 2);
                else
                    binary = Convert.ToString(lastDigit, 2);
                binary = binary.PadLeft(4, '0'); //binar in 4 biti

                for (i = 3; i >= 0; i--)
                    matrice[i, j] = int.Parse(binary[i].ToString());
            }
        }

        private static void ConvertHourToBinary(int hour, int[,] matrice)
        {
            int firstDigit, lastDigit, i, j/*, nr*/;

            if (hour < 10)
                firstDigit = 0; //prima cifra - hour
            else
                firstDigit = hour / 10; //ultima cifra - hour
            lastDigit = hour % 10;

            string binary; //cifra hour in binar

            for (j = 0; j < 2; j++)
            {
                if (j == 0)
                    binary = Convert.ToString(firstDigit, 2);
                else
                    binary = Convert.ToString(lastDigit, 2);
                binary = binary.PadLeft(4, '0'); //binar in 4 biti

                for (i = 3; i >= 0; i--)
                    matrice[i, j] = int.Parse(binary[i].ToString());
            }
        }
    }
}
