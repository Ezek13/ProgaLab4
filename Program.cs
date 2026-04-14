using System;
using System.Collections.Generic;

namespace TransportSystem
{

    public class TransportTicket
    {
        private readonly string _code; 
        private string _name;
        private decimal _price;

        private static int _totalTicketsCount = 0;

        public TransportTicket(string code, string name, decimal price)
        {
            _code = code;
            _name = name;
            _price = price;
            _totalTicketsCount++;
        }

        public decimal Price => _price;
        public static int TotalTicketsCount => _totalTicketsCount;

        public virtual string GetInfo()
        {
            return $"Код: {_code} | Назва: {_name} | Ціна: {_price} грн";
        }

        public bool IsExpensive() => _price > 500;

        public override string ToString() => GetInfo();
    }

    public class SingleRide : TransportTicket
    {
        private string _transportType;

        public SingleRide(string code, string name, decimal price, string transportType) 
            : base(code, name, price)
        {
            _transportType = transportType;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Транспорт: {_transportType}";
        }
    }

    public class MonthlyPass : TransportTicket
    {
        private int _validDays;

        public MonthlyPass(string code, string name, decimal price, int validDays) 
            : base(code, name, price)
        {
            _validDays = validDays;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Термін дії: {_validDays} днів";
        }
    }


    public class TicketManager
    {
        private List<TransportTicket> _tickets = new List<TransportTicket>();

        public void AddTicket(TransportTicket ticket)
        {
            _tickets.Add(ticket);
            Console.WriteLine($"[Менеджер]: Додано квиток {ticket.GetType().Name}.");
        }

        public void PrintFullReport()
        {
            Console.WriteLine("\n--- ЗВІТ ПО КВИТКАХ ---");
            decimal totalSum = 0;
            int expensiveCount = 0;

            foreach (var ticket in _tickets)
            {
                Console.WriteLine(ticket.GetInfo());
                totalSum += ticket.Price;
                if (ticket.IsExpensive()) expensiveCount++;
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine($"Загальна сума: {totalSum} грн");
            Console.WriteLine($"Кількість дорогих (>500): {expensiveCount}");
            Console.WriteLine($"Всього створено в системі (static): {TransportTicket.TotalTicketsCount}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            TicketManager manager = new TicketManager();

            manager.AddTicket(new SingleRide("QR-01", "Метро-разовий", 15.00m, "Метро"));
            manager.AddTicket(new MonthlyPass("MP-30", "Місячний абонемент", 800.00m, 30));
            manager.AddTicket(new MonthlyPass("MP-15", "Півмісячний", 450.00m, 15));
            manager.AddTicket(new SingleRide("TR-05", "Квиток на трамвай", 12.00m, "Трамвай"));
            manager.PrintFullReport();
        }
    }
}