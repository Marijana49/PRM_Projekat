using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Klase;


namespace TCPKlijent
{
    public class Klijent
    {
        static void Main(string[] args)
        {
            Socket klijentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 50001);
            klijentSocket.Connect(serverEP);
            Console.WriteLine("Klijent uspešno povezan sa serverom!");

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            while (true)
            {
                Console.Write("Unesite LBO: ");
                int LBO = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ime pacijenta: ");
                string imePacijenta = Console.ReadLine();

                Console.Write("Prezime pacijenta: ");
                string prezimePacijenta = Console.ReadLine();

                Console.Write("Adresa pacijenta: ");
                string adresaPacijenta = Console.ReadLine();

                Console.Write("Izaberite uslugu (terapija, pregled, urgentna pomoć): ");
                string izbor = Console.ReadLine();

                Pacijent pacijent = new Pacijent
                {
                    LBO = LBO,
                    Ime = imePacijenta,
                    Prezime = prezimePacijenta,
                    Adresa = adresaPacijenta,
                    VrstaZahteva = izbor
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    binaryFormatter.Serialize(ms, pacijent);
                    byte[] data = ms.ToArray();
                    klijentSocket.Send(data);
                }

                Console.WriteLine("Podaci o pacijentu su poslati!");

                Console.WriteLine("Da li želite da unesete još jednog pacijenta? (da/ne)");
                string odgovor = Console.ReadLine().ToLower();
                if (odgovor != "da")
                    break;
            }

            Console.WriteLine("Klijent završava sa radom.");
            klijentSocket.Close();
            Console.ReadKey();
        }
    }
}
