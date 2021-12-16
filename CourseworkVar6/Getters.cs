using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseworkVar6
{
    public class Getters
    {
        public static string UppercaseFirstLetter(string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }

            return value;
        }

        public static string GetString(string massage, bool whitespace = false, bool required = true)
        {
            string value;
            string pattern;

            if (whitespace == true)
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ ]";
            }
            else
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ]";
            }

            do
            {
                Console.Write(massage);
                value = Console.ReadLine();

                if (!required && value == "")
                {
                    return "";
                }

            } while (Regex.IsMatch(value, pattern) || value == "");

            return UppercaseFirstLetter(value);
        }

        public static string GetRealtyType(string massage, bool required = true)
        {
            string value;
            string pattern;

            pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ ]";

            do
            {
                Console.Write(massage);
                value = Console.ReadLine();

                if (!required && value == "")
                {
                    return "";
                }
            } while ((Regex.IsMatch(value, pattern) || (UppercaseFirstLetter(value) != "Квартира" && UppercaseFirstLetter(value) != "Приватний будинок")) || value == "");
            
            return UppercaseFirstLetter(value);
        }

        public static string GetIdentificationCode(bool required = true)
        {
            string IdentificationCode;

            do
            {
                Console.Write("Ідентифікаційний код: ");
                IdentificationCode = Console.ReadLine();

                if (!required && IdentificationCode == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(IdentificationCode, @"(?:^|\s)(?!0+)([0-9]{10})(?:$|\s|\.|\,)"));

            return IdentificationCode;
        }

        public static int GetInt(string message, int from = int.MinValue, int to = int.MaxValue, bool required = true)
        {
            string res;
            bool test = true;

            do
            {
                Console.Write(message);
                res = Console.ReadLine();

                if (!required && res == "")
                {
                    return 0;
                }

                if (Regex.IsMatch(res, @"[^0-9]") || res == "")
                {
                    continue;
                }
                else if (int.Parse(res) > to || int.Parse(res) < from)
                {
                    continue;
                }
                else
                {
                    test = false;
                }

            } while (test);

            return int.Parse(res);
        }

        public static string GetEmail(bool required = true)
        {
            string Email;

            do
            {
                Console.Write("Email: ");

                Email = Console.ReadLine();

                if (!required && Email == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));

            return Email;
        }

        public static string GetIBAN(bool required = true)
        {
            string IBAN;

            do
            {
                Console.Write("Банківський рахунок: ");

                IBAN = Console.ReadLine();

                if (!required && IBAN == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(IBAN, @"^UA([0-9a-zA-Z]\s?){27}$"));

            return IBAN;
        }

        public static double GetDouble(string message, double from = double.MinValue, double to = double.MaxValue, bool required = true)
        {
            Console.Write(message);
            string value = Console.ReadLine().Replace('.', ',');

            if (!required && value == "")
            {
                return 0;
            }

            double res;
            bool test = double.TryParse(value, out res);

            while (!test)
            {
                Console.Write(message);
                value = Console.ReadLine().Replace('.', ',');
                test = double.TryParse(value, out res);
            }

            return res;
        }
    }
}
