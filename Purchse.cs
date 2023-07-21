using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroceryList
{
    public class Purchase : IDie
    {
        public string Name { get; init; }

        public int Quantity { get; init; }

        public int Consumptoion { get; init; }

        public int BestBefore { get; set; }

        [JsonIgnore]

        public DayliQuest dayliQuest { get; init; }

        public Purchase(string name, int quantity, int consumptoion, int bestBefore, DayliQuest dayliQuest)
        {
            Name = name;
            Quantity = quantity;
            Consumptoion = consumptoion;
            BestBefore = bestBefore;
            this.dayliQuest = dayliQuest;
        }

        public int Remainвer() => Quantity - Consumptoion;

        public void IsEnded()
        {
            int remainder = Quantity - Consumptoion;
            if (remainder<+ 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} закончился, нужно добавить в список покупок");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} осталось{Quantity}");
                Console.ResetColor();
            }
        }
        public void IsDie()
        {
            if(BestBefore<= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Срок годности {Name}");
                Console.ResetColor();
            }
            if(BestBefore<10&&BestBefore>0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name}срок годности- {BestBefore}");
                Console.ResetColor();
            }

        }
        public void ShowStats()
        {
            Console.WriteLine($"{Name}- количество : {Quantity} расход в день :{Consumptoion} срок годности : {BestBefore}");
        }


     
        
       
    }
}
