using System;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci i dati del contribuente:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();

        Console.Write("Data di nascita (formato dd/mm/yyyy): ");
        DateTime dataNascita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Codice Fiscale: ");
        string codiceFiscale = Console.ReadLine();

        Console.Write("Sesso (M/F): ");
        char sesso = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        Console.Write("Comune di residenza: ");
        string comuneResidenza = Console.ReadLine();

        decimal redditoAnnuale;
        do
        {
            Console.Write("Reddito annuale: ");
        } while (!decimal.TryParse(Console.ReadLine(), out redditoAnnuale) || redditoAnnuale < 0); // Continua a chiedere il reddito annuale finché non è un numero positivo

        Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

        decimal imposta = contribuente.CalcolaImposta();

        Console.WriteLine("=============================");
        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
        Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
        Console.WriteLine($"nato il {contribuente.DataNascita:dd/MM/yyyy} Sesso: {contribuente.Sesso}"); ; // Quando si digita il tipo di sesso non c'è bisogno di inviare il comando per l'altra operazione
        Console.WriteLine($"residente in {contribuente.ComuneResidenza},");
        Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato: € {contribuente.RedditoAnnuale}");
        Console.WriteLine($"IMPOSTA DA VERSARE: € {imposta}");
    }
}
public class Contribuente
{
    private string nome;
    private string cognome;
    private DateTime dataNascita;
    private string codiceFiscale;
    private char sesso;
    private string comuneResidenza;
    private decimal redditoAnnuale;

    public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        CodiceFiscale = codiceFiscale;
        Sesso = sesso;
        ComuneResidenza = comuneResidenza;
        RedditoAnnuale = redditoAnnuale;
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Cognome
    {
        get { return cognome; }
        set { cognome = value; }
    }

    public DateTime DataNascita
    {
        get { return dataNascita; }
        set { dataNascita = value; }
    }

    public string CodiceFiscale
    {
        get { return codiceFiscale; }
        set { codiceFiscale = value; }
    }

    public char Sesso
    {
        get { return sesso; }
        set { sesso = value; }
    }

    public string ComuneResidenza
    {
        get { return comuneResidenza; }
        set { comuneResidenza = value; }
    }

    public decimal RedditoAnnuale
    {
        get { return redditoAnnuale; }
        set
        {
            if (value >= 0)
                redditoAnnuale = value;
            else
                throw new ArgumentException("Il reddito annuale non può essere negativo.");
        }
    }

    public decimal CalcolaImposta()
    {
        decimal imposta = 0;
        if (RedditoAnnuale <= 15000)
        {
            imposta = RedditoAnnuale * 0.23m;
        }
        else if (RedditoAnnuale <= 28000)
        {
            imposta = 3450 + (RedditoAnnuale - 15000) * 0.27m;
        }
        else if (RedditoAnnuale <= 55000)
        {
            imposta = 6960 + (RedditoAnnuale - 28000) * 0.38m;
        }
        else if (RedditoAnnuale <= 75000)
        {
            imposta = 17220 + (RedditoAnnuale - 55000) * 0.41m;
        }
        else
        {
            imposta = 25420 + (RedditoAnnuale - 75000) * 0.43m;
        }
        return imposta;
    }
}



