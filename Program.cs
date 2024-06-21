namespace skaiciai
{

    internal class Program
    {

        public static bool IsItGoodForEach(string number)
        {
            if (number == null || number == "")
            {
                Console.WriteLine("Please enter some symbols.");
                Console.WriteLine("hexadecimal based numbers consists of digits from 0 to 9 and/or letters from A-F (A, B, C, D, E, F), case insensitive");
                return false;
            }
            Console.WriteLine();
            Console.WriteLine();
            string allCaps = number.ToUpper();
            bool correctFormat = true ; 

            foreach (var character in allCaps)
            {
                switch (character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                    
                     correctFormat = true;
                        break;   

                    default:
                        correctFormat = false;
                        break;
                        
                }
                if (!correctFormat) 
                {
                    Console.WriteLine($"Wrong symbol in your number: {character}");
                    Console.WriteLine("hexadecimal based numbers consists of digits from 0 to 9 and/or letters from A-F (A, B, C, D, E, F), case insensitive");
                    
                    return false;
                }

            }
            return true;

        }

        public static bool IsItGood(string number)
        {
            if (number == null || number == "")
            {
                Console.WriteLine("Please enter some symbols.");
                Console.WriteLine("hexadecimal based numbers consists of digits from 0 to 9 and/or letters from A-F (A, B, C, D, E, F), case insensitive");
                return false;
            }

            string allCaps = number.ToUpper();
            int stringLength = number.Length - 1;
            bool correctFormat = true;

            for (int i = 0; i <= stringLength; i++)
            {
                switch (allCaps[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':

                        correctFormat = true;
                        break;

                    default:

                        correctFormat = false;
                        break;

                }
                if (!correctFormat)
                 {
                    Console.WriteLine($"Wrong symbol in your number: {number[i]}");
                    Console.WriteLine("hexadecimal based numbers consists of digits from 0 to 9 and/or letters from A-F (A, B, C, D, E, F), case insensitive");

                    return false;
                 }

                

            }
            return true;


        }
        public static bool IsItGoodDoWhile(string number)
        {
            if (number == null || number == "") return false;

            string allCaps = number.ToUpper();
            int stringLength = number.Length - 1;
            bool correctFormat = true;

            do
            {
                Console.WriteLine(allCaps[stringLength]);
                switch (allCaps[stringLength])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':

                        correctFormat = true;
                        break;

                    default:

                        correctFormat = false;
                        break;

                }
                if (!correctFormat)
                {
                    return false;
                }



                stringLength--;
            }
            while (stringLength >= 0);
            
            return true;


        }
        
        public static int Suma(int a, int b)
        {
            int suma = a + b;
            return suma;
        }

        public static bool CheckInput(string inp)
        {
            var input = inp;
            //if (input == "2" ^ input == "8" ^ input == "16" ^ input == "10" ^ input == "0")
            //{
            //    return true;

            //}
            //else return false;

            if (Enum.TryParse(input, out NumberFormatEnum value))     //tikrina, ar skaicius ir iraso i value
            {
                return Enum.IsDefined(typeof(NumberFormatEnum), value); //tikrina, ar irasyta value reiksme yra enum sarase
            }

            return false;
        }
        static void Main(string[] args)
        {

            var goodOne = "abcd";



            //Console.WriteLine("Pasirinkite is saraso formata:");

            //Console.WriteLine(NumberFormatEnum.Desimtainis);
            //Console.WriteLine("10 - desimtainis");
            //Console.WriteLine("2 - dvejetainis");
            //Console.WriteLine("8 - astuntainis");
            //Console.WriteLine("16 - sesioliktainis");
            //Console.WriteLine("0 - kitas");
            //var inputNumberFormatSelection = Console.ReadLine();


            //Console.WriteLine("Iveskite 16:");
            //Console.ReadLine
            //while (true)
            //{
            //    goodOne = Console.ReadLine();

            //    // Console.WriteLine(IsItGoodForEach(goodOne));
            //     Console.WriteLine(IsItGood(goodOne));

            //}
            Console.WriteLine((char)54);
            //if (CheckInput(inputNumberFormatSelection))
            //{
            //    Console.Write("Veikia");
            //}
            //else Console.WriteLine("Klaida, blogas pasirinkimas ivestas");
        }
    }
}
