using GroceryList;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "purchaselist.json";
        string path1 = "optimalpurchaselist.json";
        string choose;
        PurchaseDB db = new PurchaseDB();
       db.MessegeHandler += ConsoleHelper.PrintMenu;
        bool exit = false;

        while(!exit)
        {
           db.StartMS();

            foreach(var p in db.purchases)
            {
                p.Remainвer();
                if (p.BestBefore <= 0)
                {
                    db.purchases.Remove(p);
                }
            }
            ConsoleHelper.PrintMenu();

            choose = ConsoleHelper.InputAnswer("");
          
            switch (choose)
            {
                case "1":
                    db.ImportFromJSON(path1, db.recomendedPurchase);
                    db.ShowAllStats(db.recomendedPurchase);
                    break;
                case "2":
                   
                    string name = ConsoleHelper.InputAnswer("Введите название");
                    int quantity=Convert.ToInt32(ConsoleHelper.InputAnswer("Введите количество"));
                    int cons = Convert.ToInt32(ConsoleHelper.InputAnswer("Расход?"));
                    int bestBefore = Convert.ToInt32(ConsoleHelper.InputAnswer("Cрок годности"));
                    var dq = Convert.ToInt32((ConsoleHelper.InputAnswer("Выбермте событие : 0 нет, 1 свидание, 2 вечеринка,3 уборка")));

                    db.AddPurchase(new Purchase(name, quantity, cons, bestBefore,(DayliQuest)dq));
                    break;
                case "3":
                    var x = Convert.ToInt32((ConsoleHelper.InputAnswer("Выбермте событие : 0 нет, 1 свидание, 2 вечеринка,3 уборка")));
                    var questList=db.ForQuest((DayliQuest)x);
                    foreach(var p in questList)
                    {
                        db.MessegeHandler += p.IsEnded;
                        db.MessegeHandler += p.IsDie;
                    }
                    var tipycalList=db.ForQuest((DayliQuest)0);
                    foreach(var p1 in tipycalList)
                    {
                        db.MessegeHandler-= p1.IsEnded;
                        db.MessegeHandler += p1.IsDie;
                    }
                   
                
                    db.AddList(questList);
                    db.AddList(tipycalList);
                    db.DeleteQuetList((DayliQuest)x);


                    break;
                case "5":
                    db.ExportToJSON(path, db.purchases);
                    break;
                case "6":
                    db.NewDay();
                   
                    break;
                case "0":
                    exit=true;
                    break;
            }
        }
}
}