// See https://aka.ms/new-console-template for more information
int GetValidInt()
{   
    int keuze;
    while (!int.TryParse(Console.ReadLine(), out keuze))
    {
        Console.WriteLine("Deze keuze is niet geldig.");
        Console.Write("Maak nogmaals uw keuze: ");
    }
    return keuze;
}

void LijstNaarConsole(List<string> regels)
{    
    if (regels.Count == 0)
    {
        Console.WriteLine("Geen items in lijst!");
    }
    int teller = 1;
    foreach (string regel in regels)
    {
        Console.WriteLine($"{teller}. {regel}");
        teller++;
    }       
}

int KeuzeMenu()
{
    Console.Clear();
    Console.WriteLine("Welkom bij mijn BucketList");
    Console.WriteLine("Menu");
    Console.WriteLine("1. Toevoegen");
    Console.WriteLine("2. Verwijderen");
    Console.WriteLine("3. Toon lijst");
    Console.WriteLine("4. Zoek item(s)");
    Console.WriteLine("9. Stop");
    Console.Write("Voer keuze in : ");
    return GetValidInt();
}

string KrijgToevoegTekst()
{
    Console.Clear();
    Console.WriteLine("TOEVOEGEN");
    Console.Write("Gewenste activiteit: ");
    return Console.ReadLine() ?? "";
}

int MaakVerwijderKeuze(List<string> regels)
{
    Console.Clear();
    Console.WriteLine("VERWIJDEREN ");
    LijstNaarConsole(regels);
    Console.Write("Kies optie om te verwijderen: ");
    return GetValidInt() - 1; // index ipv keuze
}

void ToonLijst(List<string> regels) 
{
    Console.Clear();
    Console.WriteLine("MIJN BUCKETLIST");
    LijstNaarConsole(regels);
    Console.WriteLine("Toets enter om door te gaan!");
    Console.ReadLine();
}

void FilterLijst(List<string> zoekLijst)
{    
    while (true)
    {   
        Console.Clear();
        Console.WriteLine("ZOEK FUNCTIE");
        Console.Write("Toets een term in om te zoeken (of stop):");
        string zoekTerm = Console.ReadLine()!;
        if (zoekTerm.ToUpper() == "STOP")
        {
            break;
        }            
        ToonLijst(zoekLijst.FindAll(item => item.Contains(zoekTerm)));
    }
}

List<String> bucketList = [];
int menuKeuze = 0;
do 
{
    menuKeuze = KeuzeMenu();
    switch (menuKeuze)
    {
        case 1: // toevoegen
            bucketList.Add(KrijgToevoegTekst());
            break;
        case 2: // verwijderen
            bucketList.RemoveAt(MaakVerwijderKeuze(bucketList));
            break;
        case 3: // toon lijst
            ToonLijst(bucketList);
            break;
        case 4: 
            FilterLijst(bucketList);
            break;
    }
} while (menuKeuze != 9);