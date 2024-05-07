/*
 
 Vogliamo realizzare un programma che permetta di gestire i videogiochi che verranno utilizzati nei tornei.

 Creiamo quindi una console app che all'avvio mostra un menu con la possibilità di :
 1 inserire un nuovo videogioco
 2 ricercare un videogioco per id
 3 ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
 4 cancellare un videogioco
 5 chiudere il programma

 In base alla voce selezionata richiedere le informazioni necessarie per effettuare l'operazione desiderata.

 Prevedere tutti i controlli di validazione dei dati (ad esempio non si può inserire un videogioco senza specificare il nome).
 In caso di errori lanciare un'eccezione (che deve essere gestita a più alto livello).

 Creare una classe VideogameManager che esponga tutti i metodi necessari al programma (es. InserisciVideogame(…), GetVideogameById(..), etc…).

 Creare una classe Videogame da passare come parametro al metodo di inserimento nuovo videogioco e che venga restituita dai metodi di ricerca.
 
*/

using System;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VideogameManager manager = new VideogameManager();

            bool running = true;
            while (running)
            {
                Console.WriteLine("Seleziona un'opzione:");
                Console.WriteLine("1. Inserire un nuovo videogioco");
                Console.WriteLine("2. Ricercare un videogioco per ID");
                Console.WriteLine("3. Ricercare tutti i videogioco aventi il nome contenente una determinata stringa");
                Console.WriteLine("4. Cancellare un videogioco");
                Console.WriteLine("5. Chiudere il programma");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            string name = CheckString("\nInserisci il nome del videogioco: ");

                            string overview = CheckString("\nInserisci una descrizione: ");

                            DateTime date = CheckDate("\nInserisci data rilascio: ");

                            int id = CheckIdSoftware("Inserisci id Software di riferimento: ", manager);

                            try
                            {
                                manager.InserisciVideogame(name,overview,date,id);
                                Console.WriteLine("Videogioco inserito con successo.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Errore: {ex.Message}");
                            }
                            break;
                        case 2:

                            int idVideogame = CheckIdGame("\nInserisci l'ID del videogioco da cercare: ");

                            manager.GetVideogameById(idVideogame);

                            break;
                        case 3:
                            
                            string searchTerm = CheckString("\n Inserisci una parola: ");

                            manager.GetVideogamesByString(searchTerm);
                            
                            break;
                        case 4:

                            int idVideogameDel = CheckIdGame("\nInserisci l'ID del videogioco da cancellare: ");

                            manager.DelVideogame(idVideogameDel);

                            Console.WriteLine("Cancellazione avvenuta con successo.");

                            break;
                        case 5:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }

                Console.WriteLine();
            }
        }

        static string CheckString(string message)
        {
            string input;
            Console.WriteLine(message);
            while (true)
            {
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\n La stringa è vuota. Inserisci una stringa valida.");
                    Console.WriteLine(message);
                }
            }
        }

        static DateTime CheckDate(string message)
        {
            DateTime input;
            Console.WriteLine(message);
            while (!DateTime.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("\n Sintassi errata. Inserisci una data corretta");
                Console.WriteLine(message);
            }
            return input;
        }

        static int CheckIdSoftware(string message, VideogameManager manager)
        {
            int num;
            Console.WriteLine();
            Console.WriteLine("Lista Software_House");
            manager.ViewSoftwareHouse();

            Console.WriteLine();

            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero intero");
                Console.WriteLine(message);
            }
            return num;

        }

        static int CheckIdGame(string message)
        {
            int num;
        
            Console.WriteLine();

            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero intero");
                Console.WriteLine(message);
            }
            return num;

        }

    }

}
