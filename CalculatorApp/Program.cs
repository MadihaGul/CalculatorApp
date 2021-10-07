using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class Program
    {

        static void Main(string[] args)
        {

            bool exitApp = false;
            while (!exitApp)  // Control Application Exit
            {

                Menu();      // Show menu (Visa meny)
                bool intchk = false;
                while (!intchk)  // Loop until user enters integer
                {
                    Console.Write("\n  Enter operation number? ");
                    string op = Console.ReadLine();
                    intchk = Checkint(op); // Check if user entered integer
                    if (intchk)
                    {
                        try
                        {
                            PerformUserchoice(op); // Execute the function selected by user

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                        }
                        if ((op != "10") && (exitApp != true)) { Console.WriteLine("\t\t------------------------\n"); } // Indicate end of executed function 
                    }


                }

                // Wait for the user to respond before closing
                if (!exitApp)
                {
                    Console.Write("Press any key: ");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.WriteLine("\n"); // Friendly linespacing.

                // Calls the function user chose to run
                void PerformUserchoice(string op1)
                {
                    List<double> nValues = new List<double>();
                    int op = Convert.ToInt32(op1);
                    
                        var tuple1 = GetValuesFromUser(op, out nValues ); 
                        switch (op)
                        {
                            case 0:     
                                exitApp = true; break;
                            case 1: 
                                if (nValues.Count >= 1) { double ans = Addition(nValues.ToArray()); DisplayAns(ans); } 
                                else { double ans = Addition(tuple1.Item1, tuple1.Item2); DisplayAns(ans); } break;
                            case 2: 
                                if (nValues.Count >= 1) { double ans = Subtraction(nValues.ToArray()); DisplayAns(ans); }
                                else { double ans = Subtraction(tuple1.Item1, tuple1.Item2); DisplayAns(ans); } break;
                            case 3:    
                                { double ans = Multiplication(tuple1.Item1, tuple1.Item2); DisplayAns(ans); } break;
                            case 4:
                                { bool invalid= Division(tuple1.Item1, tuple1.Item2, out double ans); 
                                if(!invalid) DisplayAns(ans); } break;
                            case 5: 
                                { double ans = Modulo(tuple1.Item1, tuple1.Item2); DisplayAns(ans); } break; 
                            case 6: 
                                { double ans = Power(tuple1.Item1, tuple1.Item2); DisplayAns(ans); } break;
                            case 7: 
                                { double ans = Square(tuple1.Item1); DisplayAns(ans); } break;
                            case 8: 
                                { double ans = SquareRoot(tuple1.Item1); DisplayAns(ans); } break;
                            case 9:
                                { double ans = UnitByNum(tuple1.Item1); DisplayAns(ans); } break;
                            case 10:
                                { double ans = NumFact(tuple1.Item1); if(ans!=0) DisplayAns(ans); } break;
                            case 11: 
                                { double ans = NumLog(tuple1.Item1); DisplayAns(ans); } break;
                            case 12:
                                { double ans = NumLn(tuple1.Item1); DisplayAns(ans); } break;                            

                            default: Console.WriteLine("\tChoose valid operation or 0 to exit"); break;
                        }
                  
                }
            }

            return;
        }

        // Display menu of functions
        static void Menu()
        {
            // Display title as LexiconApp in C#.
            Console.WriteLine("Calculator\r");
            Console.WriteLine("----------\n");

            // Ask the user to choose an operator.
            Console.WriteLine("\tChoose mathematical operations:");
            Console.WriteLine("\t========================================================================================");
            Console.WriteLine("\t1-\t+\t\t\t|\t7-\tx²\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t2-\t-\t\t\t|\t8-\t²√x\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t3-\t*\t\t\t|\t9-\t1/x\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t4-\t÷\t\t\t|\t10-\tn!\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t5-\tmod\t\t\t|\t11-\tlog\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t6-\tx^y\t\t\t|\t12-\tln\n\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\n\t0-\tExit");//\t\t\t\t|\t17 - Rensa konsolen");
            Console.WriteLine("\t=========================================================================================");

        }


        static Tuple<double, double> GetValuesFromUser(int op, out List<double> nValues )
        {
            List<double> listValues = new List<double>();
            double value1 = 0;
            double value2 = 0;
            if (op >= 7 && op <= 12)
            {
                bool doublechk = false;
                
                while (!doublechk)
                {
                    Console.Write("\n Enter number: ");
                    string num1 = Console.ReadLine();
                    doublechk = Checkdouble(num1);
                    if (doublechk) { value1 = Convert.ToDouble(num1); }
                }
              
            }
            if (op >= 3 && op <= 6)
            {
                bool doublechk = false;              
                
                while (!doublechk)
                {
                    Console.Write("\n Enter first number: ");

                    string num1 = Console.ReadLine();
                    doublechk = Checkdouble(num1);
                    if (doublechk) { value1 = Convert.ToDouble(num1); }
                }
                doublechk = false;
                while (!doublechk)
                {
                    Console.Write("\n Enter second number: ");

                    string num2 = Console.ReadLine();
                    doublechk = Checkdouble(num2);
                    if (doublechk) { value2 = Convert.ToDouble(num2); }
                }                
            }
            if (op >= 1 && op <= 2)
            {
                string chSum = string.Empty;
                bool intCheck = false;
                while (!intCheck)
                {
                    Console.Write("\n Enter 1 for sum of two numbers or 2 for sum of multiple values: ");
                    chSum = Console.ReadLine();
                    intCheck = Checkint(chSum);
                    if (intCheck)
                    { if (!(Convert.ToInt32(chSum) >= 1 && Convert.ToInt32(chSum) <= 2) ){ Console.Write("\n Invalid"); intCheck = false; } }
                }
                if (Convert.ToInt32(chSum) == 1)
                {
                    bool doublechk = false;

                    while (!doublechk)
                    {
                        Console.Write("\n Enter first number: ");

                        string num1 = Console.ReadLine();
                        doublechk = Checkdouble(num1);
                        if (doublechk) { value1 = Convert.ToDouble(num1); }
                    }
                    doublechk = false;
                    while (!doublechk)
                    {
                        Console.Write("\n Enter second number: ");

                        string num2 = Console.ReadLine();
                        doublechk = Checkdouble(num2);
                        if (doublechk) { value2 = Convert.ToDouble(num2); }
                    }
                }
                else
                {
                    bool doublechk = false;
                    string num=string.Empty;
                    do
                    {
                        while (!doublechk)
                        {
                            Console.Write("\n Give a value and press \'Enter\' to give more values (Press \'x\' to stop giving values): ");
                            num = Console.ReadLine();
                            if (num == "x" || num == "X") { break; }
                            else
                            {
                                doublechk = Checkdouble(num);
                                if (doublechk) { listValues.Add(Convert.ToDouble(num)); }
                            }
                        }
                        doublechk = false;


                    } while (!(num == "x" || num == "X"));

                }
            }

            nValues = listValues;
            return new Tuple<double, double>(value1, value2);
        }
        public static double UnitByNum(double value1)
        {
           return 1/value1;
        }
        public static double NumFact(double value1)
        {
            double ans = 0;
            if (value1 >= 0)
            {
                ans = 1;
                for (double i = value1; i>0 ; i --)
                { ans *= i; }
                // Bug for values like 2.2, 5.5 but works for whole numbers
            }
            else
            {
                Console.Write("\n Invalid Input! ");
            }
            return ans;
        }
        public static double NumLog(double value1)
        {
          return Math.Log10(value1);
        }
        public static double NumLn(double value1)
        {
            return Math.Log(value1);
        }
        public static double Square(double value1)
        {             
            return Math.Pow(value1, 2);

        }
        public static double SquareRoot(double value1)
        {
           return Math.Sqrt(value1);
        }
        public static double Power(double value1, double value2)
        {
           return Math.Pow(value1, value2);

        }

        public static double Modulo(double value1, double value2)
        {
            return value1% value2;

        }

        public static bool Division(double value1, double value2, out double ans)
        {
            ans = 0;
            bool invalid = false;
            if (value2 == 0)
            {
                Console.WriteLine("\n Invalid operation. Cannot divide a number by 0 ");
                invalid = true;
            }
            else { ans = value1 / value2; }
            return invalid;
        }
        public static double Multiplication(double value1, double value2)
        {
            return value1 * value2;         

        }


        public static double Subtraction(double value1, double value2)
        {
            return value1 - value2;
        }

        public static double Subtraction(double[] values)
        {
            double ans = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                ans -= values[i];
            }

            return ans;

        }
        public static double Addition(double[] values)
        {
            double ans =0;
            for (int i = 0; i < values.Length; i++)
                ans = ans + values[i];

            return ans;
        }
        static void DisplayAns( double ans) { Console.WriteLine("\n Ans= " + ans); }
        

        public static double Addition(double value1, double value2)
        {
            return value1 + value2;
        }
        // Check if user entered double
        static bool Checkdouble(string val1)
        {

            if (double.TryParse(val1, out double Dbval))
            {
                return true;
            }
            else
            {
                Console.Write(" Invalid. Enter numerical value ");
                return false;
            }

        }
        // Check if user entered integer
        static bool Checkint(string val1)
        {
            if (int.TryParse(val1, out int intval))
            {
                return true;
            }
            else
            {
                Console.WriteLine(" Invalid!");
                return false;
            }

        }

        static string ChkUserinput(string Userinput)
        {
            while (Userinput == "")
            {
                Console.WriteLine("\n Invalid! Try again.");
                Userinput = Console.ReadLine();
            }
            return Userinput;
        }

    }
}
