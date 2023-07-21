using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroceryList
{
    public class PurchaseDB
    {
        public List<Purchase> recomendedPurchase;

        public List<Purchase> purchases;

        public int DayCounter { get; set; }

        public delegate void Handler();

        public event Handler MessegeHandler;

        public PurchaseDB()
        {
            purchases=new List<Purchase>();
            recomendedPurchase=new List<Purchase>();
            DayCounter = 0;
        }
        

        public void AddPurchase(Purchase purchase)
        {
            recomendedPurchase.Add(purchase);
        }
        public void RemovePurchase(Purchase purchase)
        {
            recomendedPurchase.Remove(purchase);
        }
        public void ExportToJSON(string path,List<Purchase>pur)
        {
            var js=JsonSerializer.Serialize(pur);
            File.WriteAllText(path, js);
        }

        public void ImportFromJSON(string path, List<Purchase> pur)
        {
            var js=File.ReadAllText(path);
            var newList=JsonSerializer.Deserialize<List<Purchase>>(js);

            recomendedPurchase.AddRange(newList);
            recomendedPurchase.Distinct();


        }
        public void TransitPurchse()
        {
            var newList = recomendedPurchase.Except(purchases).ToList();
            purchases.AddRange(newList);
            purchases.Distinct();
        }

        public Purchase? FindPurchase(string name)
        {
            var pur=recomendedPurchase.FirstOrDefault(x=>x.Name==name);

            return pur;
        }
        public List<Purchase>? ForQuest(DayliQuest dayliQuest)
        {
            var questList=purchases.Where(x=>x.dayliQuest==dayliQuest).ToList();

            return questList;
        }
        public void DeleteQuetList(DayliQuest dq)
        {
            var newList=purchases.SkipWhile(x=>x.dayliQuest==dq).ToList();
            purchases.Clear();
            purchases.AddRange(newList);
        }
        public void AddList(List<Purchase> pur)
        {
            purchases.AddRange(pur);
        }
        
       
        public void ShowAllStats(List<Purchase> pur)
        {
            foreach(var p in pur)
                p.ShowStats();
        }
        public void NewDay()
        {
            DayCounter++;
            Console.Clear();
            ConsoleHelper.PrintLine($"День {DayCounter}, список покупок на сегодня ",ConsoleColor.Blue);

            foreach (var p in purchases)
                p.BestBefore--;
        }
        public void StartMS()
        {
            MessegeHandler?.Invoke();
        }
        
    }

}
