Console.OutputEncoding = System.Text.Encoding.Default;
int hours = 0, minutes = 0;
int coins = 0, money = 0, euro = 0, cent = 0;
string input = "set";

PrintWelcome();
while (input is not "d" and not "D" && money < 150)
{
    do
    {
        PrintParkingTime();
        EnterCoins();
        AddParkingTime();
    }
    while ((input is "d" or "D") && money < 30);
}
PrintTicket();
PrintDonation();

void PrintWelcome()
{
    Console.Clear();
    System.Console.WriteLine("🚗  Wilkommen, beim Parkscheinautomaten! 🚕");
    System.Console.WriteLine("Mindestparkdauer: 30 min; Höchstparkdauer 1:30 h\nTarif: 1€/h 💰");
    System.Console.WriteLine("🪙  Zugelassene Münzen: [5]c, [10]c, [20]c, [50]c, [1]€ oder [2]€ ");
    System.Console.WriteLine("🖨️  Drucken des Parkscheins mit [d] oder [D]\n");
}

void EnterCoins()
{
    System.Console.Write("Einwurf: ");
    input = Console.ReadLine()!;
}

void AddParkingTime()
{
    switch (input)
    {
        case "5":
            minutes += 3;
            coins = 5;
            break;
        case "10":
            minutes += 6;
            coins = 10;
            break;
        case "20":
            minutes += 12;
            coins = 20;
            break;
        case "50":
            minutes += 30;
            coins = 50;
            break;
        case "1":
            minutes += 60;
            coins = 100;
            break;
        case "2":
            minutes += 120;
            coins = 200;
            break;
        case "d" or "D":
            if (money < 50)
            {
                System.Console.WriteLine($"Sie müssen mindestens 50c einwerfen. Sie haben erst {money}c eingeworfen.");
            }
            break;
    }

    while (minutes >= 60)
    {
        hours++;
        minutes -= 60;
    }

    money += coins;
}

void PrintParkingTime()
{
    System.Console.WriteLine($"aktuelle Parkzeit ⏱️: {hours}:{minutes} Stunden");
}

void PrintTicket()
{
    if (money <= 150)
    {
        System.Console.WriteLine($" \nSie dürfen {hours}:{minutes} Stunden parken. 🅿️");
    }
    else
    {
        System.Console.WriteLine($"\nSie dürfen 1:30 Stunden parken. 🅿️");
    }
}

void PrintDonation()
{
    if (money > 150)
    {
        money -= 150;
        cent = money;
        while (cent >= 100)
        {
            euro++;
            cent -= 100;
        }
        System.Console.WriteLine($"Danke für Ihre Spende von {euro}€ {cent}c.");
    }
}
