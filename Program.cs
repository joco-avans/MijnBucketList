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

int KeuzeMenu()
{
    Console.Clear();
    Console.WriteLine("Welkom bij mijn BucketList");
    Console.WriteLine("Menu");
    Console.WriteLine("1. Toevoegen");
    Console.WriteLine("2. Verwijderen");
    Console.WriteLine("3. Toon lijst");
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

void LijstNaarConsole(List<string> regels)
{
    
    int teller = 1;
    foreach (string regel in regels)
    {
        Console.WriteLine($"{teller}. {regel}");
        teller++;
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
    }
} while (menuKeuze != 9);