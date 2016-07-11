using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    class Program
    {
        static int getOrderNumber()
        {
            Console.WriteLine("Enter order number");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int getUserTask()
        {
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. Show total order cost");
            Console.WriteLine("3. Stop it");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int getPrice()
        {
            Console.WriteLine("Enter orderItem cost");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int getTotalOrderPrice(List<OrderItem> orderItems)
        {
            int totalPrice = 0;

            orderItems.ForEach(delegate (OrderItem item)
            {
                totalPrice += Decimal.ToInt32(item.UnitPrice);
            });
            return totalPrice;
        }

        static void addNewOrderItem(Model1 context, int _orderId)
        {
            int price = getPrice();
            context.OrderItem.Add(new OrderItem() { OrderId = _orderId, UnitPrice = price, IsDeleted = false });
            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                var carts = context.Cart.ToList();

                while (true)
                {
                    int orderNum = getOrderNumber();
                    switch (getUserTask())
                    {
                        case 1:
                            {
                                addNewOrderItem(context, carts[0].Order.ToList()[orderNum - 1].Id);
                                break;
                            }
                        case 2:
                            {
                                int orderPrice = getTotalOrderPrice(carts[0].Order.ToList()[orderNum - 1].OrderItem.ToList());
                                Console.WriteLine("Total order cost: {0}", orderPrice);
                                break;
                            }
                        case 3:
                            {
                                return;
                            }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
