using System;
using System.Collections.Generic;
using System.Linq;

public class Contact
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class Program
{
    static List<Contact> phoneBook = new List<Contact>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Найти контакт");
            Console.WriteLine("3. Редактировать контакт");
            Console.WriteLine("4. Удалить контакт");
            Console.WriteLine("5. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    SearchContacts();
                    break;
                case "3":
                    EditContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }

    static void AddContact()
    {
        Contact newContact = new Contact();
        Console.WriteLine("Введите имя:");
        newContact.FirstName = Console.ReadLine();
        Console.WriteLine("Введите фамилию:");
        newContact.LastName = Console.ReadLine();
        Console.WriteLine("Введите номер телефона:");
        newContact.PhoneNumber = Console.ReadLine();
        Console.WriteLine("Введите адрес электронной почты:");
        newContact.Email = Console.ReadLine();

        newContact.ID = phoneBook.Count + 1;
        phoneBook.Add(newContact);

        Console.WriteLine("Контакт успешно добавлен!");
    }

    static void SearchContacts()
    {
        Console.WriteLine("Введите ключевое слово для поиска:");
        string keyword = Console.ReadLine().ToLower();

        var results = phoneBook
            .Where(contact =>
                contact.FirstName.ToLower().Contains(keyword) ||
                contact.LastName.ToLower().Contains(keyword) ||
                contact.PhoneNumber.Contains(keyword) ||
                contact.Email.ToLower().Contains(keyword))
            .ToList();

        if (results.Count > 0)
        {
            Console.WriteLine("Результаты поиска:");
            foreach (var contact in results)
            {
                Console.WriteLine($"ID: {contact.ID}, Имя: {contact.FirstName}, Фамилия: {contact.LastName}, Номер телефона: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        else
        {
            Console.WriteLine("Контакты не найдены.");
        }
    }

    static void EditContact()
    {
        Console.WriteLine("Введите ID контакта, который вы хотите отредактировать:");
        if (int.TryParse(Console.ReadLine(), out int contactID))
        {
            Contact contactToEdit = phoneBook.FirstOrDefault(contact => contact.ID == contactID);

            if (contactToEdit != null)
            {
                Console.WriteLine("Выберите, какой атрибут вы хотите отредактировать (имя, фамилия, номер телефона, или адрес электронной почты):");
                string attributeToEdit = Console.ReadLine();

                switch (attributeToEdit.ToLower())
                {
                    case "имя":
                        Console.WriteLine("Введите новое имя:");
                        contactToEdit.FirstName = Console.ReadLine();
                        break;
                    case "фамилия":
                        Console.WriteLine("Введите новую фамилию:");
                        contactToEdit.LastName = Console.ReadLine();
                        break;
                    case "номер телефона":
                        Console.WriteLine("Введите новый номер телефона:");
                        contactToEdit.PhoneNumber = Console.ReadLine();
                        break;
                    case "адрес электронной почты":
                        Console.WriteLine("Введите новый адрес электронной почты:");
                        contactToEdit.Email = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор атрибута.");
                        break;
                }

                Console.WriteLine("Контакт успешно отредактирован!");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID контакта.");
        }
    }

    static void DeleteContact()
    {
        Console.WriteLine("Введите ID контакта, который вы хотите удалить:");
        if (int.TryParse(Console.ReadLine(), out int contactID))
        {
            Contact contactToDelete = phoneBook.FirstOrDefault(contact => contact.ID == contactID);

            if (contactToDelete != null)
            {
                phoneBook.Remove(contactToDelete);
                Console.WriteLine("Контакт успешно удален!");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID контакта.");
        }
    }
}
