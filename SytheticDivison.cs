/**
 *  Author:      Nicholas Martin
 *  Date:        12/10/2019
 *  Description: Performs synthetic division on a user-input polynomial.    
 **/

using System.Collections.Generic;
using static System.Console;

namespace SyntheticDivision
{
    class Program
    {
        // Asks user to define function
        // Pre-condition: 0 < degrees < infinity
        // Post-condition: returns a string
        static string PromptFunction(int degrees, out List<double> listCoefficients)
        { 
            string function = "f(x) = ";    // Polynomial as a string
            listCoefficients = new List<double>();  // List of each coefficient in the polynomial
            for (int i = degrees; i >= 0; --i)
            {
                Clear();    // Clear console
                if (i == degrees)
                {
                    WriteLine($"{function}?x^{i}");
                    Write("Enter coefficient: ");
                    double coefficient = double.Parse(ReadLine());
                    function += $"{coefficient}x^{i}";
                    listCoefficients.Add(coefficient);
                }
                else if (i > 1)  // If degrees exists and not last
                {
                    WriteLine($"{function} + ?x^{i}");
                    Write("Enter coefficient: ");
                    double coefficient = double.Parse(ReadLine());
                    function += $" + {coefficient}x^{i}";
                    listCoefficients.Add(coefficient);
                }
                else if (i > 0)  // If degrees still exists
                {
                    WriteLine($"{function} + ?x");
                    Write("Enter coefficient: ");
                    double coefficient = double.Parse(ReadLine());
                    function += $" + {coefficient}x";
                    listCoefficients.Add(coefficient);
                }
                else
                {
                    WriteLine($"{function} + ?");
                    Write("Enter last number: ");
                    double coefficient = double.Parse(ReadLine());
                    function += $" + {coefficient}";
                    listCoefficients.Add(coefficient);
                }
            }
            Clear();
            WriteLine($"{function}");
            return function;
        }

        // Synthetic division calculator
        // Pre-condition: 0 < degrees < infinity
        // Post-condition: Calculates and displays results of synthetic divison
        static void SynDivRange(int degrees, List<double> listCoefficients)
        {
            Write("Min: ");
            int min = int.Parse(ReadLine());    // Minimum range
            Write("Max: ");
            int max = int.Parse(ReadLine());    // Maximum range
            int x;  // x Value is multiplier (columns)
            int xInts = 0;  // Number of x-Intercepts
            List<double> listXInts = new List<double>();    // List of x-Intercepts
            for (x = min; x <= max; ++x)
            {
                double y = 0;   // y Value is Synthetic division total
                int coefficientIndex = 0;   // Index foreach loop. Reset on new column
                foreach (double coefficient in listCoefficients)
                {
                    if (coefficientIndex == 0)
                        y = coefficient;
                    else
                        y = (x * y + coefficient);

                    ++coefficientIndex; // Iterate
                }
                if (y == 0)
                {
                    Write($"[{x}, {y}], ");
                    ++xInts;
                    listXInts.Add(x);
                }
                else
                    Write($"[{x}, {y}], ");
            }
            WriteLine($"\nX-Intercepts: {xInts}");
            Write("{");
            int listCounter = 0;
            foreach (double val in listXInts)
            {
                if (listCounter == listXInts.Count - 1)
                    Write($"{val}");
                else
                    Write($"{val}, ");
                ++listCounter;
            }
            Write("}\n");
            WriteLine("--DONE--");
        }

        // Main method
        // Pre-condition: None
        // Post-condition: Calls SynDivRange() and waits user input to exit
        static void Main(string[] args)
        {
            Write("Degrees: ");
            int degrees = int.Parse(ReadLine());
            string function = PromptFunction(degrees, out List<double>listCoefficients);
            SynDivRange(degrees, listCoefficients);
            ReadKey();
        }
    }
}
