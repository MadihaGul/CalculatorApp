using System;

namespace CalculatorApp
{
    class Program
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
                    int op = Convert.ToInt32(op1);
                    if (op != 0)
                    {
                        var tuple1 = GetValuesFromUser(op); // Bug: Should be called after switch as it runs on any op value except 0 before default in switch executes(Fixed in GetValuesFromUser method using op but control goes to the function unnessarily)
                        switch (op)
                        {
                            case 1: Addition(tuple1.Item1, tuple1.Item2); break;
                            case 2: Subtraction(tuple1.Item1, tuple1.Item2); break;
                            case 3: Multiplication(tuple1.Item1, tuple1.Item2); break;
                            case 4: Division(tuple1.Item1, tuple1.Item2); break;
                            case 5: Modulo(tuple1.Item1, tuple1.Item2); break;
                            case 6: Power(tuple1.Item1, tuple1.Item2); break;
                            case 7: Square(tuple1.Item1); break;
                            case 8: SquareRoot(tuple1.Item1); break;
                            case 9: UnitByNum(tuple1.Item1); break;
                            case 10: NumFact(tuple1.Item1); break;
                            case 11: NumLog(tuple1.Item1); break;
                            case 12: NumLn(tuple1.Item1); break;
                            

                            default: Console.WriteLine("\tChoose valid operation or 0 to exit"); break;

                        }
                    }
                    else
                    {
                        exitApp = true;
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


        static Tuple<double, double> GetValuesFromUser(int op)
        {
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
            if (op >= 1 && op <= 6)
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
            return new Tuple<double, double>(value1, value2);
        }
        static void UnitByNum(double value1)
        {
            Console.WriteLine("\n Ans= " +(1/value1));
        }
        static void NumFact(double value1)
        {
            if (value1 >= 0)
            {
                Checkint(Convert.ToString(value1));
                double ans = 1;
                for (int i = Convert.ToInt32(value1); i >= 1; i--)
                { ans = ans * i; }
                Console.WriteLine("\n Ans= " + ans);
            }
            else
            {
                Console.Write("\n Invalid Input! ");
            }
        }
        static void NumLog(double value1)
        {
            Console.WriteLine("\n Ans= " + Math.Log10(value1));
        }
        static void NumLn(double value1)
        {
            Console.WriteLine("\n Ans= " + Math.Log(value1));
        }
        static void Square(double value1)
        {             
            Console.WriteLine("\n Ans= " + Math.Pow(value1, 2));

        }
        static void SquareRoot(double value1)
        {
            
            Console.WriteLine("\n Ans= " + Math.Sqrt(value1));
        }
        static void Power(double value1, double value2)
        {
            Console.WriteLine("\n Ans= " + Math.Pow(value1, value2));

        }

        static void Modulo(double value1, double value2)
        {
             Console.WriteLine("\n Ans= " + (value1% value2));

        }

        static void Division(double value1, double value2)
        {
            if (value2 == 0)
            { Console.WriteLine("\n Invalid operation. Cannot divide a number by 0 "); }
            else
            {
                double Ans = value1 / value2;
                Console.WriteLine("\n Ans= " + Ans);
            }

        }
        static void Multiplication(double value1, double value2)
        {
            double Ans = value1 * value2;
            Console.WriteLine("\n Ans= " + Ans);

        }


        static void Subtraction(double value1, double value2)
        {
            double Ans = value1 - value2;
            Console.WriteLine("\n Ans= " + Ans);

        }
        static void Addition(double value1, double value2)
        {
            double Ans = value1 + value2;
            Console.WriteLine("\n Ans= " + Ans);

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
