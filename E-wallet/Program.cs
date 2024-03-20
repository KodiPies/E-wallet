using System;




class Inwestycje
{
    public double Gotowka { get; set; }
    public double Zloto { get; set; }
    public int Akcje { get; set; }
    public double Nieruchomosci { get; set; }
    public DateTime DataZakupuZlota { get; set; }
    public DateTime DataZakupuAkcji { get; set; }
    public DateTime DataZakupuNieruchomosci { get; set; }
}

class Program
{
    static string sciezkaPliku = "inwestycje.txt"; 

    static void Main(string[] args)
    {
        Inwestycje inwestycjeUzytkownika = WczytajInwestycje(); 

        
        Console.WriteLine("Stan Kontaaaaaaaaaaaaa: " + inwestycjeUzytkownika.Gotowka + " zł");
        Console.WriteLine("Ilość Złota: " + inwestycjeUzytkownika.Zloto + " gram (Zakupiono: " + inwestycjeUzytkownika.DataZakupuZlota.ToShortDateString() + ")");
        Console.WriteLine("Liczba Akcji: " + inwestycjeUzytkownika.Akcje + " (Zakupiono: " + inwestycjeUzytkownika.DataZakupuAkcji.ToShortDateString() + ")");
        Console.WriteLine("Wartość Nieruchomości: " + inwestycjeUzytkownika.Nieruchomosci + " zł (Zakupiono: " + inwestycjeUzytkownika.DataZakupuNieruchomosci.ToShortDateString() + ")");
        Console.WriteLine();

        
        Console.WriteLine("Co chcesz zrobić?");
        Console.WriteLine("1. Dodaj nową inwestycję");
        Console.WriteLine("2. Usuń inwestycję");
        Console.WriteLine("3. Usuń kwotę ze stanu konta");
        Console.WriteLine("4. Dodaj kwotę do stanu konta");

        int opcja;
        if (int.TryParse(Console.ReadLine(), out opcja))
        {
            switch (opcja)
            {
                case 1:
                    DodajInwestycje(inwestycjeUzytkownika);
                    break;
                case 2:
                    UsunInwestycje(inwestycjeUzytkownika);
                    break;
                case 3:
                    UsunStanKonta(inwestycjeUzytkownika);
                    break;
                case 4:
                    DodajStanKonta(inwestycjeUzytkownika);
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Niepoprawna opcja.");
        }

        ZapiszInwestycje(inwestycjeUzytkownika); 
    }

    static void DodajInwestycje(Inwestycje inwestycje)
    {
        Console.WriteLine("Co chcesz dodać?");
        Console.WriteLine("1. Złoto");
        Console.WriteLine("2. Akcje");
        Console.WriteLine("3. Nieruchomości");

        int opcja;
        if (int.TryParse(Console.ReadLine(), out opcja))
        {
            switch (opcja)
            {
                case 1:
                    Console.WriteLine("Podaj ilość złota do dodania:");
                    double iloscZlota;
                    if (double.TryParse(Console.ReadLine(), out iloscZlota))
                    {
                        inwestycje.Zloto += iloscZlota;
                        inwestycje.DataZakupuZlota = DateTime.Now;
                        Console.WriteLine("Dodano " + iloscZlota + " uncji złota.");
                        inwestycje.Gotowka -= iloscZlota * 1800; 
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Podaj ilość akcji do dodania:");
                    int iloscAkcji;
                    if (int.TryParse(Console.ReadLine(), out iloscAkcji))
                    {
                        inwestycje.Akcje += iloscAkcji;
                        inwestycje.DataZakupuAkcji = DateTime.Now;
                        Console.WriteLine("Dodano " + iloscAkcji + " akcji.");
                        inwestycje.Gotowka -= iloscAkcji * 100; 
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Podaj wartość nieruchomości do dodania:");
                    double wartoscNieruchomosci;
                    if (double.TryParse(Console.ReadLine(), out wartoscNieruchomosci))
                    {
                        inwestycje.Nieruchomosci += wartoscNieruchomosci;
                        inwestycje.DataZakupuNieruchomosci = DateTime.Now;
                        Console.WriteLine("Dodano nieruchomość o wartości " + wartoscNieruchomosci + " zł.");
                        inwestycje.Gotowka -= wartoscNieruchomosci;
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Niepoprawna opcja.");
        }
    }

    static void UsunInwestycje(Inwestycje inwestycje)
    {
        Console.WriteLine("Co chcesz usunąć?");
        Console.WriteLine("1. Złoto");
        Console.WriteLine("2. Akcje");
        Console.WriteLine("3. Nieruchomości");

        int opcja;
        if (int.TryParse(Console.ReadLine(), out opcja))
        {
            switch (opcja)
            {
                case 1:
                    Console.WriteLine("Podaj ilość złota do usunięcia:");
                    double iloscZlota;
                    if (double.TryParse(Console.ReadLine(), out iloscZlota))
                    {
                        inwestycje.Zloto -= iloscZlota;
                        Console.WriteLine("Usunięto " + iloscZlota + " uncji złota.");
                        inwestycje.Gotowka += iloscZlota * 1800; 
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Podaj ilość akcji do usunięcia:");
                    int iloscAkcji;
                    if (int.TryParse(Console.ReadLine(), out iloscAkcji))
                    {
                        inwestycje.Akcje -= iloscAkcji;
                        Console.WriteLine("Usunięto " + iloscAkcji + " akcji.");
                        inwestycje.Gotowka += iloscAkcji * 100; 
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Podaj wartość nieruchomości do usunięcia:");
                    double wartoscNieruchomosci;
                    if (double.TryParse(Console.ReadLine(), out wartoscNieruchomosci))
                    {
                        inwestycje.Nieruchomosci -= wartoscNieruchomosci;
                        Console.WriteLine("Usunięto nieruchomość o wartości " + wartoscNieruchomosci + " zł.");
                        inwestycje.Gotowka += wartoscNieruchomosci; 
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość.");
                    }
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Niepoprawna opcja.");
        }
    }

    static void UsunStanKonta(Inwestycje inwestycje)
    {
        Console.WriteLine("Podaj kwotę do usunięcia ze stanu konta:");
        double kwota;
        if (double.TryParse(Console.ReadLine(), out kwota))
        {
            if (kwota <= inwestycje.Gotowka)
            {
                inwestycje.Gotowka -= kwota;
                Console.WriteLine("Usunięto " + kwota + " zł ze stanu konta.");
            }
            else
            {
                Console.WriteLine("Nie masz wystarczającej ilości środków na koncie.");
            }
        }
        else
        {
            Console.WriteLine("Niepoprawna kwota.");
        }
    }

    static void DodajStanKonta(Inwestycje inwestycje)
    {
        Console.WriteLine("Podaj kwotę do dodania do stanu konta:");
        double kwota;
        if (double.TryParse(Console.ReadLine(), out kwota))
        {
            inwestycje.Gotowka += kwota;
            Console.WriteLine("Dodano " + kwota + " zł do stanu konta.");
        }
        else
        {
            Console.WriteLine("Niepoprawna kwota.");
        }
    }

    static Inwestycje WczytajInwestycje()
    {
        if (File.Exists(sciezkaPliku))
        {
            string[] lines = File.ReadAllLines(sciezkaPliku);
            return new Inwestycje
            {
                Gotowka = double.Parse(lines[0]),
                Zloto = double.Parse(lines[1]),
                Akcje = int.Parse(lines[2]),
                Nieruchomosci = double.Parse(lines[3]),
                DataZakupuZlota = DateTime.Parse(lines[4]),
                DataZakupuAkcji = DateTime.Parse(lines[5]),
                DataZakupuNieruchomosci = DateTime.Parse(lines[6])
            };
        }
        else
        {
            return new Inwestycje();
        }
    }

    static void ZapiszInwestycje(Inwestycje inwestycje)
    {
        string[] lines = {
            inwestycje.Gotowka.ToString(),
            inwestycje.Zloto.ToString(),
            inwestycje.Akcje.ToString(),
            inwestycje.Nieruchomosci.ToString(),
            inwestycje.DataZakupuZlota.ToString(),
            inwestycje.DataZakupuAkcji.ToString(),
            inwestycje.DataZakupuNieruchomosci.ToString()
        };
        File.WriteAllLines(sciezkaPliku, lines);
    }
}

