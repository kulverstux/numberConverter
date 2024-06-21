using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
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
    public static bool checkNumber(string nr)
    {
        string givenString = nr;
        bool isItInt = int.TryParse(givenString, out int intNumber);
        if (isItInt)
            return true;

        else
        {
            Console.WriteLine("Wrong number entered.");
            return false;
        }
    }
    public static void Converter(int system, bool custom)
    {
        bool isItcustom = custom;
        int intNumber = 0;
        int leftOverNumber = 0;
        int i = 0;
        int intNumberSystem = system;
        string enteredNumber = "";
        Dictionary<int, int> intDict = new Dictionary<int, int>();

        Console.WriteLine("Please enter a number:");
        enteredNumber = Console.ReadLine();
        //intNumber = int.Parse(enteredNumber);
        checkNumber(enteredNumber);
        bool isItInt = int.TryParse(enteredNumber, out intNumber);

        if (custom)
        {
            Console.WriteLine("Please enter a number system in number:");
            string numberSystem = Console.ReadLine();
            intNumberSystem = int.Parse(numberSystem);
        }

        if (isItInt)
        {
            while (intNumber >= leftOverNumber)
            {
                leftOverNumber = intNumber % intNumberSystem;
                intNumber = intNumber / intNumberSystem;

                intDict.Add(i, leftOverNumber);
                i++;
                if (intNumber != 0 && intNumber < leftOverNumber) intDict.Add(i, intNumber);
            }


            int realLength = intDict.Count;
            int minusOneLength = realLength - 1;


            for (; minusOneLength >= 0;)
            {
                if (intNumberSystem == 2 && realLength % 4 == 0) Console.Write(" "); //dvejetainiu formatavimas
                var singleDictValue = intDict[minusOneLength];
                Console.Write(singleDictValue);
                minusOneLength--;
                realLength--;
            }
        }
        Console.WriteLine();
    }
    public static void BinaryToDecimal()
    {

        double newSingleN = 0;
        int index = 0;
        double daugyba = 0;
        int digit = 0;
        string enteredNumber = "";
        int strLength = 0;

        Console.WriteLine("Please enter a binary number:");
        enteredNumber = Console.ReadLine();
        strLength = enteredNumber.Length;
        strLength--;

        while (strLength >= 0)
        {
            daugyba = Math.Pow(2, strLength);
            digit = (int)char.GetNumericValue(enteredNumber[index]);
            newSingleN = newSingleN + digit * daugyba;
            index++;
            strLength--;
        }

        Console.WriteLine("Decimal value:  " + newSingleN);

    }

    public static void Main()
    {

        bool itsOn = true;
        bool canProceed = true;
        string doWeContinue = "";

        while (itsOn)
        {

            Console.WriteLine("Please choose to what you want to convert to:");
            Console.WriteLine("1. to decimal(10)");
            Console.WriteLine("2. to binary(2)");
            Console.WriteLine("3. to octal(8)");
            Console.WriteLine("4. to hexadecimal (16)");
            Console.WriteLine("5. to custom");
            Console.WriteLine("6. binary to decimal");

            string menuChoice = Console.ReadLine();


            switch (menuChoice)
            {
                case "1":
                    Converter(10, false);
                    break;
                case "2":
                    Converter(2, false);
                    break;
                case "3":
                    Converter(8, false);
                    break;
                case "4":
                    
                    Converter(16, false);
                    break;
                case "5":
                    Converter(0, true);
                    break;
                case "6":
                    BinaryToDecimal();
                    break;
                default:
                    Console.WriteLine("Wrong menu item selected.");
                    canProceed = false;
                    break;


            }

            // 




            //-----------		
            if (canProceed)
            {
                Console.WriteLine("Do you want to continue? y/n");
                doWeContinue = Console.ReadLine();
                switch (doWeContinue)
                {
                    case "y":
                        break;
                    case "n":
                        itsOn = false;
                        Console.WriteLine("The End");
                        break;
                    default:
                        Console.WriteLine("Wrong entry. Please enter 'y' to continue or 'n' to end the program.");
                        break;
                }
            }
        }

    }

}
