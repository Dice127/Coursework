using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Controllers;
using Models;
using Services.Abstract;

namespace CourseworkVar6
{
    class Menu : Getters
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            RealtyController realtyController = new RealtyController();
            ClientController clientController = new ClientController();
            OffersController offersController = new OffersController();
            SearchController searchController = new SearchController();

            while (true)
            {
                Console.Clear();
                Console.Write("Введіть сутність з якою бажаєте працювати або її номер:\n" +
                              "1. Клієнт\n" +
                              "2. Нерухомість\n" +
                              "3. Пропозицї клієнту\n" +
                              "4. Пошук за ключовим словом\n" +
                              "Щоб закрити програму введіть \"Вихід\": \n");

                string entity = Console.ReadLine();
                Console.Clear();

                if (entity == "1" || UppercaseFirstLetter(entity) == "Клієнт")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або обновити дані клієнта\n" +
                              "2. Видалити клієнта\n" +
                              "3. Переглянути дані клієнта\n" +
                              "4. Переглянути список всіх клієнтів\n" +
                              "5. Розширений пошук клієнта\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або обновити дані клієнта" || UppercaseFirstLetter(action) == "Додати" || UppercaseFirstLetter(action) == "Обновити")
                        {
                            Console.Clear();
                            clientController.AddOrUpdateClient(GetString("Ім'я: "), GetString("Прізвище: "), GetInt("Вік: ", 18, 115), GetIdentificationCode(), GetIBAN(),
                                                   GetEmail(), GetString("Місто росташування: ", true), GetRealtyType("Тип нерухмості(квартира або приватний будинок): "),
                                                   GetInt("Бажана кількість кімнат: ", 1, 10), GetDouble("Бажана площа(м^2): "), GetInt("Бюджет на нерухомість: ", 0));

                            Console.WriteLine("Дані клієнта успішно додано, щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Видалити клієнта" || UppercaseFirstLetter(action) == "Видалити")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікаційний код або номер банківського рахунку клієнта якого бажаєте видалити: ");
                            string idOrIBAN = Console.ReadLine();

                            if (clientController.DeleteClient(idOrIBAN))
                                Console.WriteLine("Дані клієнта успішно видалено, щоб продовжити натисніть \"Enter\"");
                            else
                                Console.WriteLine("Клієнт з такими даними не існує, щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані клієнта")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікаційний код або номер банківського рахунку клієнта інформацію про якого бажаєте отримати: ");
                            string idOrIBAN = Console.ReadLine();

                            Console.WriteLine("\n" + clientController.GetClientInfo(idOrIBAN));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх клієнтів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            Console.Write("Введіть назву сортування або його номер:\n" +
                              "1. Сортування по імені\n" +
                              "2. Сортування по прізвищу\n" +
                              "3. Сортування по початковій цифрі банківського рахунку\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                            string sort = Console.ReadLine();

                            if (sort == "1" || sort == "Сортування по імені")
                            {
                                Console.Clear();
                                Console.WriteLine("Список клієнтів відсортованих по імені: ");

                                List<ClientModel> clientModels = clientController.GetClientsListSortedByName();

                                if(clientModels.Count == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("База даних пуста");
                                    Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                                    Console.ReadLine();
                                    break;
                                }

                                foreach (var client in clientModels)
                                {
                                    Console.WriteLine(clientController.GetClientInfo(client.IdentificationCode));
                                    Console.Write("-------------------------\n\n");
                                }

                                Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (sort == "2" || sort == "Сортування по прізвищу")
                            {
                                Console.Clear();
                                Console.WriteLine("Список клієнтів відсортованих по прізвищу: ");

                                List<ClientModel> clientModels = clientController.GetClientsListSortedByLastName();

                                if (clientModels.Count == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("База даних пуста");
                                    Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                                    Console.ReadLine();
                                    break;
                                }

                                foreach (var client in clientModels)
                                {
                                    Console.WriteLine(clientController.GetClientInfo(client.IdentificationCode));
                                    Console.Write("-------------------------\n\n");
                                }

                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (sort == "3" || sort == "Сортування по початковій цифрі банківського рахунку")
                            {
                                Console.Clear();
                                Console.WriteLine("Список клієнтів відсортованих по початковій цифрі банківського рахунку: ");

                                List<ClientModel> clientModels = clientController.GetClientsListSortedByBankAccountNumber();

                                if (clientModels.Count == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("База даних пуста");
                                    Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                                    Console.ReadLine();
                                    break;
                                }

                                foreach (var client in clientModels)
                                {
                                    Console.WriteLine(clientController.GetClientInfo(client.IdentificationCode));
                                    Console.Write("-------------------------\n\n");
                                }

                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else if (action == "5" || UppercaseFirstLetter(action) == "Розширений пошук клієнта")
                        {
                            Console.Clear();
                            Console.WriteLine("Введіть потрібні параметри для пошуку клієнта: \n");
                            string findedClient = searchController.FindByClientParameters(GetString("Ім'я: ", false, false), GetString("Прізвище: ", false, false), GetInt("Вік: ", 18, 115, false), GetIdentificationCode(false), GetIBAN(false),
                                                   GetEmail(false), GetString("Бажане місто проживання: ", true, false), GetRealtyType("Тип нерухмості(квартира або приватний будинок): ", false),
                                                   GetInt("Бажана кількість кімнат: ", 1, 10, false), GetDouble("Бажана площа(м^2): ", double.MinValue, double.MaxValue, false), GetInt("Бюджет на нерухомість: ", 0, int.MaxValue, false));

                            if (findedClient == "")
                            {
                                Console.Clear();
                                Console.WriteLine("\nКлієнта за даними параметрми не знайдено.\n");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(findedClient);
                            }                           

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }

                        Console.Clear();
                    }
                }
                else if (entity == "2" || UppercaseFirstLetter(entity) == "Нерухомість")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або обновити дані нерухомості\n" +
                              "2. Видалити нерухомість\n" +
                              "3. Переглянути дані нерухомості\n" +
                              "4. Переглянути список всіх нерухомостей\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або обновити дані нерухомості" || UppercaseFirstLetter(action) == "Додати" || UppercaseFirstLetter(action) == "Обновити")
                        {
                            Console.Clear();
                            realtyController.AddOrUpdateRealty(GetInt("Номер нерухомості: ", 1000, 9999).ToString(), GetString("Місто розташування: "), GetRealtyType("Тип нерухмості(квартира або приватний будинок): "),
                                                               GetInt("Бажана кількість кімнат: ", 1, 10), GetDouble("Бажана площа(м^2): "), GetInt("Ціна: ", 0));

                            Console.WriteLine("Дані нерухомості успішно додано, щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Видалити нерухомість" || UppercaseFirstLetter(action) == "Видалити")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікатор нерухомості: ");
                            string realtyID = Console.ReadLine();

                            if (realtyController.DeleteRealty(realtyID))
                                Console.WriteLine("Дані нерухомості успішно видалено, щоб продовжити натисніть \"Enter\"");
                            else
                                Console.WriteLine("Нерухомість з такими даними не існує, щоб продовжити натисніть \"Enter\"");

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані нерухомості")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікатор нерухомості: ");
                            string realtyID = Console.ReadLine();

                            Console.WriteLine("\n" + realtyController.GetRealtyInfo(realtyID));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх клієнтів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            Console.Write("Введіть назву сортування або його номер:\n" +
                              "1. Сортування по типу нерухомості\n" +
                              "2. Сортування по вартості\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                            string sort = Console.ReadLine();

                            if (sort == "1" || sort == "Сортування по типу нерухомості")
                            {
                                Console.Clear();
                                Console.WriteLine("Список нерухомостей відсортованих по типу: ");
                                foreach (var realty in realtyController.GetRealtiesListSortedByType())
                                {
                                    Console.WriteLine(realtyController.GetRealtyInfo(realty.RealtyID));
                                    Console.Write("-------------------------\n\n");
                                }

                                Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (sort == "2" || sort == "Сортування по вартості")
                            {
                                Console.Clear();
                                Console.WriteLine("Список клієнтів відсортованих по вартості: ");
                                foreach (var realty in realtyController.GetRealtiesListSortedByPrice())
                                {
                                    Console.WriteLine(realtyController.GetRealtyInfo(realty.RealtyID));
                                    Console.Write("-------------------------\n\n");
                                }

                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                                Console.ReadLine();
                                Console.Clear();
                            }

                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "3" || UppercaseFirstLetter(entity) == "Пропозицї клієнту")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Обновити та отримати пропозиції клієнта\n" +
                              "2. Отримати пропозиції клієнта\n" +
                              "3. Визначити, чи бажаний об'єкт знаходиться у списку доступних об'єктів нерухомості\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Обновити та отримати пропозиції клієнта")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікаційний код або номер банківського рахунку клієнта пропозиції якого бажаєте отримати: \n");
                            string idOrIBAN = Console.ReadLine();

                            ClientModel client = clientController.GetClient(idOrIBAN);

                            if(client == null)
                            {
                                Console.WriteLine("Клієнт з такими даними не існує");
                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }

                            Console.Clear();
                            Console.WriteLine(offersController.UpdateAndGetOffersInfo(client));

                            while (true)
                            {
                                Console.Write("Бажаєте відхилити одну з пропозицій?(Так або Ні): ");

                                string confirm = Console.ReadLine();

                                if (UppercaseFirstLetter(confirm) == "Так" || UppercaseFirstLetter(confirm) == "Да")
                                {
                                    int id = GetInt("Введіть номер пропозиції: ");

                                    if (offersController.RejectOffer(client, id))
                                    {
                                        Console.WriteLine("Дані успішно видалені\n");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Пропозицію за таким номером не знайдено\n");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else if (UppercaseFirstLetter(confirm) == "Ні")
                                {
                                    break;
                                }
                                else if (UppercaseFirstLetter(action) == "Вихід")
                                {
                                    Environment.Exit(1);
                                }
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Отримати пропозиції клієнта" || UppercaseFirstLetter(action) == "Отримати пропозиції")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікаційний код або номер банківського рахунку клієнта пропозиції якого бажаєте отримати: \n");
                            string idOrIBAN = Console.ReadLine();

                            ClientModel client = clientController.GetClient(idOrIBAN);

                            if (client == null)
                            {
                                Console.WriteLine("Клієнт з такими даними не існує");
                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }

                            Console.Clear();
                            Console.WriteLine(offersController.GetOffersInfo(client));

                            while (true)
                            {
                                Console.Write("Бажаєте відхилити одну з пропозицій?(Так або Ні): ");
                                string confirm = Console.ReadLine();

                                if (UppercaseFirstLetter(confirm) == "Так" || UppercaseFirstLetter(confirm) == "Да")
                                {
                                    int id = GetInt("Введіть номер пропозиції: ");

                                    if (offersController.RejectOffer(client, id))
                                    {
                                        Console.WriteLine("Дані успішно видалені\n");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Пропозицію за таким номером не знайдено\n");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else if (UppercaseFirstLetter(confirm) == "Ні")
                                {
                                    break;
                                }
                                else if (UppercaseFirstLetter(action) == "Вихід")
                                {
                                    Environment.Exit(1);
                                }
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Визначити, чи бажаний об'єкт знаходиться у списку доступних об'єктів нерухомості")
                        {
                            Console.Clear();
                            Console.Write("Введіть ідентифікаційний код або номер банківського рахунку клієнта пропозиції якого бажаєте отримати: \n");
                            string idOrIBAN = Console.ReadLine();

                            ClientModel client = clientController.GetClient(idOrIBAN);

                            if (client == null)
                            {
                                Console.WriteLine("Клієнт з такими даними не існує");
                                Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }

                            Console.Clear();
                            if (offersController.CheckDesirableRealty(client))
                                Console.WriteLine("Бажаний об'єкт знаходиться у списку доступних об'єктів нерухомості\n");
                            else
                                Console.WriteLine("Бажаний об'єкт не знаходиться у списку доступних об'єктів нерухомості\n");

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "4" || UppercaseFirstLetter(entity) == "Пошук за ключовим словом")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Пошук в базі клієнтів\n" +
                              "2. Пошук в базі нерухомостей\n" +
                              "3. Пошук в базі клієнтів та нерухомостей\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Пошук в базі клієнтів")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: \n");
                            string key = Console.ReadLine();

                            if (searchController.FindClientByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchController.FindClientByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Пошук в базі нерухомостей")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: \n");
                            string key = Console.ReadLine();

                            if (searchController.FindRealtyByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchController.FindRealtyByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Визначити, чи бажаний об'єкт знаходиться у списку доступних об'єктів нерухомості")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: \n");
                            string key = Console.ReadLine();

                            if (searchController.FindAllByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchController.FindAllByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (UppercaseFirstLetter(entity) == "Вихід")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                }
            }            
        }
    }
}
