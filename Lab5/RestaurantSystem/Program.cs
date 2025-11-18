using System;
using System.Text;

namespace RestaurantSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant();

            restaurant.ShowMenu();

            Order order1 = restaurant.CreateOrder(5);

            var item1 = restaurant.FindMenuItem("Борщ");
            var item2 = restaurant.FindMenuItem("Стейк");
            var item3 = restaurant.FindMenuItem("Вино");

            if (item1 != null) order1.AddItem(item1);
            if (item2 != null) order1.AddItem(item2);

            if (item3 != null)
            {
                order1.AddItem(item3);
                order1.AddItem(item3);
            }

            order1.PrintOrderDetails();

            order1.RemoveItem("Вино");

            order1.ChangeStatus(OrderStatus.InProgress);

            order1.ChangeStatus(OrderStatus.Ready);

        
            Console.Write("Бажаєте розділити чек на компанію? (так/ні): ");
            string userInput = Console.ReadLine(); 

            if (userInput == "так" )
            {
                Console.Write("Введіть кількість гостей: ");
                string guestInput = Console.ReadLine();

               
                if (int.TryParse(guestInput, out int guests) && guests > 0)
                {
                    order1.SplitBill(guests);
                }
                else
                {
                    Console.WriteLine("Помилка: введено некоректну кількість гостей. Розділення скасовано.");
                }
            }
            else
            {
                Console.WriteLine("Ок, оплачуємо повну суму одним чеком.");
            }

            order1.ChangeStatus(OrderStatus.Paid);

            restaurant.ShowAllOrders();
        }
    }
}