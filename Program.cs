using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text;
public class Program
{
    public static bool IsItGoodHexNumber(string number) //checks if entered hex number is in good format
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
                Console.WriteLine("Hexadecimal based numbers consists of digits from 0 to 9 and/or letters from A-F (A, B, C, D, E, F), case insensitive");

                return false;
            }
        }
        return true;
    }

    public static Dictionary <int, long> CheckFormat(string number, string format) //checks if entered number is in good format (excluding hexadecimal)
    {

        int intFormat = int.Parse(format); //converts format to int, format is already checked
        var numbers = number.Split(' ');
        
        bool isItGood = true;
        
        Dictionary<int, long> givenNumberToDict = new Dictionary<int, long>();      
        int dictKey = 0;
        int howManyValuesNumberHave = numbers.Length;
       
        foreach (var n in numbers) 
        {
            if (long.TryParse(n, out long num))
            { 
                int numberLength = n.Length;
                long numberToCheck = num;
                for (int i = 0; i < numberLength; i++)
                {
                    if (howManyValuesNumberHave == 1)
                    {
                        long leftover = numberToCheck % 10;
                        if (leftover >= intFormat)
                        {

                            isItGood = false;
                            break;
                        }
                        numberToCheck = numberToCheck / 10;
                    }
                    else if (num >= intFormat)
                        {
    
                            isItGood = false;
                            break;
                        }
  
                }
                if (isItGood)
                {
                    givenNumberToDict.Add(dictKey, num);
                    dictKey++;
                }
                else 
                {
                    Console.WriteLine($"Number you entered is in bad format. Digits/numbers cannot be higher than your selected -{intFormat}- format.");
                    givenNumberToDict.Clear();
                    break;
                }
            }
            else 
            {
                Console.WriteLine("Please use digits only seperated by space.");
                givenNumberToDict.Clear();
                break;
            }

        }

        return givenNumberToDict;

    }

    public static double ConvertToDecimal(int intNumber, int intNumberSystem, Dictionary<int, long> transferedDict) //converts given number to decimal for an easier conversion to provided base later on
    {
        long leftOverNumber = 0;
        double convertedToDecimal = 0;
        int power = 0;
        int index = 0;
        int countHowManyValuesDictHave = transferedDict.Count;

        //if (transferedDict.Count != 0)            //checks if dictionary has any values. Only hexadecimal have values, others are empty
        //{
        //    int strLength = transferedDict.Count - 1;
        //    while (strLength >= 0)                //converts hexadecimal to decimal
        //    {
        //        int intValue = transferedDict[index];
        //        convertedToDecimal = convertedToDecimal + intValue * Math.Pow(16, strLength);
        //        strLength--;
        //        index++;
        //    }
        //}
        if (countHowManyValuesDictHave == 1)
        {
            long newNumber = transferedDict[0];
            while (newNumber > 0)
            {
                leftOverNumber = newNumber % 10;
                newNumber = newNumber / 10;
                convertedToDecimal = convertedToDecimal + leftOverNumber * Math.Pow(intNumberSystem, power);
                power++;
            }
        }
    
        else
        {
            countHowManyValuesDictHave--;
            while (countHowManyValuesDictHave >= 0)
            {
                convertedToDecimal = convertedToDecimal + transferedDict[index] * Math.Pow(intNumberSystem, countHowManyValuesDictHave);
                countHowManyValuesDictHave--;
                index++;
            }
        }
        Console.WriteLine($"converted to deci: {convertedToDecimal}");
        return convertedToDecimal;    
    }

    public static void ConvertBackToHex(int element, Dictionary<int, long> ddd)    //takes each value from converted value to hex and replaces letters with numbers
    {

        switch (ddd[element])
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                {
                    Console.Write(ddd[element]);
                    break;
                }
            case 10:
                {
                    Console.Write('A');
                    break;
                }
            case 11:
                {
                    Console.Write('B');
                    break;
                }
            case 12:
                {
                    Console.Write('C');
                    break;
                }
            case 13:
                {
                    Console.Write('D');
                    break;
                }
            case 14:
                {
                    Console.Write('E');
                    break;
                }
            case 15:
                {
                    Console.Write('F');
                    break;
                }

            default:
                Console.WriteLine("something is wrong with output reading");
                break;

        }

    }

    public static void PrintFinalOutput(string originalNumber, int originalBase, Dictionary<int, long> intDict, int ConvertToSystem) //prints final result
    {
        int realLength = intDict.Count;

        int minusOneLength = realLength - 1;
        Console.WriteLine($"Number entered: {originalNumber}, base: {originalBase}");
        Console.Write($"Your number converted to {ConvertToSystem} system: ");
        for (; minusOneLength >= 0;) //output
        {
            var singleDictValue = intDict[minusOneLength];
            if (ConvertToSystem >= 10 && ConvertToSystem != 16)                                                     //conversion for other than hexadecimal
            {
                Console.Write($"{singleDictValue} ");
            }
            else if (ConvertToSystem == 16)                                 //for converting to hexadecimal
            {
                ConvertBackToHex(minusOneLength, intDict);
            }

            else
            {
                if (realLength % 4 == 0) Console.Write(" ");
                Console.Write($"{singleDictValue}");
            }

            minusOneLength--;
            realLength--;
        }

        Console.WriteLine();

    }

    public static void Converter(string number, string system, Dictionary<int, long> d) //method controlling whole converting thing
    {

        int.TryParse(number, out int intNumber);
        int.TryParse(system, out int intNumberSystem);
        double leftOverNumber = 0;
        double convertedToDecimal = 0;
        int i = 0;

        Dictionary<int, long> intDict = new Dictionary<int, long>();


        convertedToDecimal = ConvertToDecimal(intNumber, intNumberSystem, d);    //converts given number to decimal for an easier later on conversion

        Console.WriteLine("To witch format you want to convert your number?");
        Console.WriteLine($"Your number is {number}, number system: {intNumberSystem}");
       
        var conv = Console.ReadLine();

        if (int.TryParse(conv, out int systemToConvertTo))
        {
            while (convertedToDecimal >= leftOverNumber)                //converts number to chosen system
            {
                leftOverNumber = convertedToDecimal % systemToConvertTo;
                convertedToDecimal = convertedToDecimal / systemToConvertTo;
                intDict.Add(i, (long)leftOverNumber);
                i++;
            }
            intDict.Add(i, (long)convertedToDecimal);
            PrintFinalOutput(number, intNumberSystem, intDict, systemToConvertTo);
        }
        else 
        {
            Console.WriteLine($"{conv} is not a correct system to convert to. Please write a number.");
        }
    }

    public static bool CheckNumberSystemInput(string selectedSystem, out string numberFormatManuallyEntered) //checks if correct system was chosen
    {

            numberFormatManuallyEntered = "";
            if (int.TryParse(selectedSystem, out int systemCheck))
            {
                if (systemCheck == 10 ^ systemCheck == 2 ^ systemCheck == 8 ^ systemCheck == 16)
                {

                    return true;

                }
                else if (systemCheck == 0)

                {
                    Console.WriteLine("Please enter a number system of your choice from 17 to 99: ");
                    string? entered = Console.ReadLine();
                    if (int.TryParse(entered, out int isItGood) && isItGood >= 17 && isItGood <= 99)
                    {
                        numberFormatManuallyEntered = entered;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Selected system {entered} doesn't meet requirements. Systems you can choose are any from 17 to 99.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Selected system {selectedSystem} doesn't meet requirements. Systems you can choose are any from 17 to 99, 2, 8, 10 or 16. ");
                    return false;
                }
            }
            Console.WriteLine($"Selected system {selectedSystem} doesn't meet requirements. Your entered symbol does not meet criteria ");
        return false;
    }

    public static Dictionary<int, long> ConvertHexToDecimalNumber(string givenString) //converts given Hex numbers and letters to each of their decimal value and sends to ConvertToDecimal for an actual conversion
    {
        string allCaps = givenString.ToUpper();

        int strLength = givenString.Length - 1;
        int convertedNumberToDecimal = 0;

        Dictionary<int, long> hexToDecDict = new Dictionary<int, long>();

        for (int i = 0; i <= strLength; i++)
        {
            switch (allCaps[i])
            {
                case '0':
                    {
                        convertedNumberToDecimal = 0;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '1':
                    {
                        convertedNumberToDecimal = 1;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '2':
                    {
                        convertedNumberToDecimal = 2;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '3':
                    {
                        convertedNumberToDecimal = 3;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '4':
                    {
                        convertedNumberToDecimal = 4;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '5':
                    {
                        convertedNumberToDecimal = 5;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '6':
                    {
                        convertedNumberToDecimal = 6;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '7':
                    {
                        convertedNumberToDecimal = 7;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '8':
                    {
                        convertedNumberToDecimal = 8;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case '9':
                    {

                        convertedNumberToDecimal = 9;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'A':
                    {
                        convertedNumberToDecimal = 10;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'B':
                    {
                        convertedNumberToDecimal = 11;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'C':
                    {
                        convertedNumberToDecimal = 12;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'D':
                    {
                        convertedNumberToDecimal = 13;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'E':
                    {
                        convertedNumberToDecimal = 14;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }
                case 'F':
                    {
                        convertedNumberToDecimal = 15;
                        hexToDecDict.Add(i, convertedNumberToDecimal);
                        break;
                    }

                default:

                    Console.WriteLine("Something went wrong trying to convert Hex letters to numbers");
                    break;

            }
        }
        return hexToDecDict;

    }

    //-----------------------------//
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
            Console.WriteLine("0. custom from 17-99");

            string ?selectedSystem = Console.ReadLine();

            if (CheckNumberSystemInput(selectedSystem, out string numberFormatManuallyEntered))
            {
                if (numberFormatManuallyEntered != "") selectedSystem = numberFormatManuallyEntered; //if format was chosen as custom, returns manually entered format

                Console.WriteLine($"Please enter your number in selected format '{selectedSystem}':");
                string ?givenNumber = Console.ReadLine();


                if (selectedSystem != "16" && CheckFormat(givenNumber, selectedSystem).Count != 0)
                {

                    Dictionary<int, long> DictionaryWithSeperatedNumbersEntered = CheckFormat(givenNumber, selectedSystem);
                    Converter(givenNumber, selectedSystem, DictionaryWithSeperatedNumbersEntered);

                }
                else if (selectedSystem == "16" && IsItGoodHexNumber(givenNumber))
                {

                    Converter(givenNumber, selectedSystem, ConvertHexToDecimalNumber(givenNumber));

                }
            }

            canProceed = true;



            //-----------        
            if (canProceed)
            {
                
                do
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Do you want to continue? y/n");
                    doWeContinue = Console.ReadLine();
                    switch (doWeContinue)
                    {
                        case "y":
                            
                            itsOn = true;
                            break;
                        case "n":
                            itsOn = false;
                            Console.WriteLine("The End");
                            break;
                        default:
                            {
                                Console.WriteLine("Wrong entry. Please enter 'y' to continue or 'n' to end the program.");
                                canProceed = false;
                                itsOn = false;
                                break;
                            }
                    }
                } 
                while (!canProceed);
            }
        }

    }

}


