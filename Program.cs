using System;
using System.Collections.Generic;

namespace ClothingApp
{
    public class Odyah
    {
        public string Model { get; set; }
        public string Size { get; set; }

        public Odyah(string model, string size)
        {
            Model = model;
            Size = size;
        }

        public virtual void Odiahatys()
        {
            Console.WriteLine($"[Метод Одяг]: Ви одягаєте базовий елемент гардеробу.");
        }

        public override bool Equals(object obj)
        {
            if (obj is Odyah other)
                return Model == other.Model && Size == other.Size;
            return false;
        }

        public override int GetHashCode() => (Model, Size).GetHashCode();

        public override string ToString() => $"Тип: {this.GetType().Name}, Модель: {Model}, Розмір: {Size}";
    }

    public class Kurtka : Odyah
    {
        public Kurtka(string model, string size) : base(model, size) { }
        
        public override void Odiahatys()
        {
            Console.WriteLine($"[Метод Куртка]: Ви застібаєте блискавку на куртці '{Model}'.");
        }
    }

    public class Sorochka : Odyah
    {
        public Sorochka(string model, string size) : base(model, size) { }
        
        public override void Odiahatys()
        {
            Console.WriteLine($"[Метод Сорочка]: Ви застібаєте гудзики на сорочці '{Model}'.");
        }
    }

    public class Shtany : Odyah
    {
        public Shtany(string model, string size) : base(model, size) { }
        
        public override void Odiahatys()
        {
            Console.WriteLine($"[Метод Штани]: Ви вдягаєте штани '{Model}' та затягуєте ремінь.");
        }
    }

    public class Vzuttya : Odyah
    {
        public Vzuttya(string model, string size) : base(model, size) { }
        
        public override void Odiahatys()
        {
            Console.WriteLine($"[Метод Взуття]: Ви взуваєте '{Model}' та зав'язуєте шнурки.");
        }
    }

    public class WardrobeManager
    {
        private List<Odyah> _items = new List<Odyah>();

        public void AddItem(Odyah item)
        {
            Console.WriteLine($"[Метод WardrobeManager]: Додано {item.GetType().Name} до списку.");
            _items.Add(item);
        }

        public void VybratyOdyah()
        {
            Console.WriteLine("\n--- Вибір одягу зі списку ---");
            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
                item.Odiahatys(); 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WardrobeManager manager = new WardrobeManager();

            manager.AddItem(new Kurtka("Якась куртка", "L"));
            
            manager.AddItem(new Sorochka("Якась сорочка", "L"));

            manager.AddItem(new Vzuttya("Якесь взуття", "43"));
            
            manager.AddItem(new Shtany("Якісь штани", "M"));
            manager.VybratyOdyah();
        }
    }
}