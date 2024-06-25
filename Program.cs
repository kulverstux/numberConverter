using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static bool IsItGoodHexNumber(string number)
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
        {


            return true;
        }
        else
        {
            Console.WriteLine("Wrong number entered.");
            return false;
        }
    }

    public static bool CheckFormat(string number, string format)
    {

        bool isItIntNumber = int.TryParse(number, out int intNumber);
        bool isItIntFormat = int.TryParse(format, out int intFormat);
        int numberLength = number.Length;

        for (int i = 0; i < numberLength; i++)
        {
            int liekana = intNumber % 10;
            if (liekana >= intFormat)
            {

                Console.WriteLine("Number you entered is in bad format");
                return false;
            }
            intNumber = intNumber / 10;

        }

        return true;
    }

    public static void ConvertDecimalToSelected(Dictionary<int, int> intDict, int ConvertToSystem)
    {
        int realLength = intDict.Count;
        int minusOneLength = realLength - 1;

        for (; minusOneLength >= 0;) //output
        {
            if (realLength % 4 == 0) Console.Write(" "); //dvejetainiu formatavimas
            var singleDictValue = intDict[minusOneLength];
            Console.Write(singleDictValue);
            minusOneLength--;
            realLength--;
        }

        Console.WriteLine();

    }

    public static void Converter(string number, string system)
    {

        bool intNumberBool = int.TryParse(number, out int intNumber);
        bool intSystemBool = int.TryParse(system, out int intNumberSystem);
        int leftOverNumber = 0;
        int i = 0;
      
        Dictionary<int, int> intDict = new Dictionary<int, int>();

        //Console.WriteLine("Please enter a number:");
        //enteredNumber = Console.ReadLine();
        //intNumber = int.Parse(enteredNumber); !!
        // checkNumber(enteredNumber);
        //bool isItInt = int.TryParse(enteredNumber, out intNumber);

        //if (custom)
        //{
        //    Console.WriteLine("Please enter a number system in number:");
        //    string numberSystem = Console.ReadLine();
        //    intNumberSystem = int.Parse(numberSystem);
        //}

        Console.WriteLine($"To witch format you want to convert your number? Your number is {intNumber} which is in {intNumberSystem} number system");
        var Conv = Console.ReadLine();
        int ConvertToSystem = int.Parse(Conv);

        while (intNumber >= leftOverNumber) //converts to decimal
        { 
                leftOverNumber = intNumber % intNumberSystem;
                intNumber = intNumber / intNumberSystem;

                intDict.Add(i, leftOverNumber);
                i++;
                if (intNumber != 0 && intNumber < leftOverNumber) intDict.Add(i, intNumber);
        }

        ConvertDecimalToSelected(intDict, ConvertToSystem);
           
        
            //int realLength = intDict.Count;
            //int minusOneLength = realLength - 1;

        //    for (; minusOneLength >= 0;) //output
        //    {
        //        if (realLength % 4 == 0) Console.Write(" "); //dvejetainiu formatavimas
        //        var singleDictValue = intDict[minusOneLength];
        //        Console.Write(singleDictValue);
        //        minusOneLength--;
        //        realLength--;
        //    }
        
        //Console.WriteLine();
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

            Console.WriteLine("Please enter number system you want:");
            Console.WriteLine("10. decimal(10)");
            Console.WriteLine("2. binary(2)");
            Console.WriteLine("8. octal(8)");
            Console.WriteLine("16. hexadecimal (16)");
            Console.WriteLine("0. custom");
            //  Console.WriteLine("6. binary to decimal");

            string selectedSystem = Console.ReadLine();

            Console.WriteLine($"Please enter your number in selected format '{selectedSystem}':");
            string givenNumber = Console.ReadLine();

            if (CheckFormat(givenNumber, selectedSystem) && selectedSystem != "16")
            {
                
                Converter(givenNumber, selectedSystem);

            }
            else if (selectedSystem == "16" && IsItGoodHexNumber(selectedSystem))
            {
                Console.WriteLine("sesioliktainis");

            }




            canProceed = true;



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
                        {
                            Console.WriteLine("Wrong entry. Please enter 'y' to continue or 'n' to end the program.");
                           // itsOn = false;
                            break;
                        }
                }
            }
        }

    }

}