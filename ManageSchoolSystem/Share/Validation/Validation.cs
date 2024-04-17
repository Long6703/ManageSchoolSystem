using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Share.Validation
{
    public class Validation
    {
        public static int checkInputChoice(int max, int min)
        {
            while (true)
            {
                try
                {
                    int re = int.Parse(Console.ReadLine());
                    if (max < re || min > re)
                    {
                        throw new Exception();
                    }
                    return re;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }

        public static int checkInputInt()
        {
            while (true)
            {
                try
                {
                    int re = int.Parse(Console.ReadLine());
                    if (re <= 0)
                    {
                        throw new FormatException();
                    }
                    return re;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }

        public static double checkInputDouble()
        {
            while (true)
            {
                try
                {
                    double re = double.Parse(Console.ReadLine());
                    if (re <= 0)
                    {
                        throw new FormatException();
                    }
                    return re;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }

        public static string checkInputString()
        {
            while (true)
            {
                try
                {
                    string re = Console.ReadLine();
                    if (re == "")
                    {
                        throw new FormatException();
                    }
                    return re;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }

        public static bool checkInputYN()
        {
            Console.WriteLine("Do you want to continue (Y/N) : ");
            while (true)
            {
                String re = checkInputString();
                if (re.Equals("y"))
                {
                    return false;
                }
                if (re.Equals("n"))
                {
                    return true;
                }
                Console.WriteLine("Please input must be y or n");
                Console.WriteLine("Enter again : ");
            }
        }

        public static string checkValidEmailInput()
        {
            while (true)
            {
                try
                {
                    string email = Console.ReadLine();
                    string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
                    if (Regex.IsMatch(email, emailPattern))
                    {
                        throw new FormatException();
                    }
                    return email;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }

        public static string IsValidPhoneNumberInput()
        {
            while (true)
            {
                try
                {
                    string phone = Console.ReadLine();
                    string phonePattern = @"^\d{3}-\d{3}-\d{4}$";
                    if (Regex.IsMatch(phone, phonePattern))
                    {
                        throw new FormatException();
                    }
                    return phone;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Enter again : ");
                }
            }
        }
    }
}
