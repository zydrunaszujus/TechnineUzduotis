
using TechnineUzduotis.Modeliai;
using TechnineUzduotis.Servisai;

var saliuSarasas = await SaliuApiServisas.GautiSaliuSarasaAsync();
var saliuModeliai = saliuSarasas.ConvertAll(x => new Salis(x));

Klientas klientas;
Tiekejas tiekejas;
string vardas;
string pavarde;
StatusasEnum statusas;
Salis salis;
double uzsakymoSuma;
bool pvmMoketojas;
double pvm;

//*** Kliento duomenys ***

Console.WriteLine("Įvesti kliento duomenis : ");

Console.WriteLine("Kliento vardas ; ");
vardas=Console.ReadLine() ?? string.Empty;

Console.WriteLine("Kliento pavardė : ");
pavarde=Console.ReadLine() ?? string.Empty;

Console.WriteLine("0 - Fizinis asmuo");
Console.WriteLine("1 - Juridinis asmuo");

Console.WriteLine("Kliento statusas : (įrašyti numerį)");
statusas = (StatusasEnum)GautiNumeri(1);

for(int i = 0; i < saliuModeliai.Count; i++)
{
    Console.WriteLine(i+" - "+saliuModeliai[i].Pavadinimas);
}

Console.WriteLine("Kliento salis : (įrašyti numerį)");
salis = saliuModeliai[GautiNumeri(saliuModeliai.Count)];

klientas = new Klientas(vardas, pavarde, statusas, salis);


//*** Uzsakymo suma***


Console.WriteLine("Užsakymo suma : (Eurais) pvz: 200.99");
uzsakymoSuma = GautiNumeriDouble();


//*** Tiekejo duomenys ***

Console.WriteLine("Ivesti tiekejo duomenis :");

Console.WriteLine("Tiekejo vardas (Pavadinimas) : ");
vardas=Console.ReadLine() ?? string.Empty;

Console.WriteLine("Tiekejo pavarde (Pavadinimas, nebutina) : ");
pavarde = Console.ReadLine() ?? string.Empty;

for(int i = 0; i < saliuModeliai.Count; i++)
{
    Console.WriteLine(i + " - " + saliuModeliai[i].Pavadinimas);
}

Console.WriteLine("Tiekejo salis : (irasyti numeri)");
salis = saliuModeliai[GautiNumeri(saliuModeliai.Count)];

Console.WriteLine("0 - Nera PVM moketojas");
Console.WriteLine("1 - Yra PVM moketojas");

Console.WriteLine("Tiekejo PVM statusas : (irasyti numeri)");
pvmMoketojas = GautiNumeri(1) == 1;

tiekejas=new Tiekejas(vardas, pavarde, salis,pvmMoketojas);



//*** PVM skaiciavimas ***


pvm=PvmSkaiciavimoServisas.SkaiciuotiPVM(uzsakymoSuma,klientas,tiekejas);


//*** Galutine informacija ***

Console.WriteLine($"Saskaita faktura   {DateTime.Now}");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Klientas  {klientas.Vardas}  {klientas.Pavarde} ({klientas.Statusas})");
Console.WriteLine($"[{klientas.Salis.Pavadinimas}, {klientas.Salis.Regionas}]");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Uzsakymas : {uzsakymoSuma} Eur");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Tiekejas{tiekejas.Vardas} {tiekejas.Pavarde} ({tiekejas.Statusas})");
Console.WriteLine($"[{tiekejas.Salis.Pavadinimas}, {tiekejas.Salis.Regionas}]");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Priskaiciuota PVM : {pvm} Eur.");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Galutine suma : {uzsakymoSuma+pvm}  Eur.");
Console.WriteLine("---------------------------------------------------");

int GautiNumeri(int numerisIki)
{
    int x = -1;
    while(int.TryParse(Console.ReadLine(), out x) == false || x < 0)
    {
        Console.WriteLine("Netinkamai ivesta reiksme, prasome pabandyti dar karta");
    }
    return x;
}

double GautiNumeriDouble()
{
    double x = -1;

    while(double.TryParse(Console.ReadLine(), out x) == false || x < 0)
    {
        Console.WriteLine("Netinkamai ivesta reiksme, prasome bandyti dar karta.");
    }
    return x;
}
 


