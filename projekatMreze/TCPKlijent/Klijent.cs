using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Klase;

namespace TCPKlijent
{
    public class Klijent
    {
        static void Main(string[] args)
        {
            Socket klijentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 50001);
            byte[] buffer = new byte[1024];

            klijentSocket.Connect(serverEP);
            Console.WriteLine("Klijent uspesno povezan sa serverom!");

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            while (true)
            {
                Console.WriteLine("Unesite LBO: ");
                int LBO = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ime pacijenta: ");
                string imePacijenta = Console.ReadLine();
                Console.WriteLine("Prezime pacijenta: ");
                string prezimePacijenta = Console.ReadLine();
                Console.WriteLine("Adresa pacijenta: ");
                string adresaPacijenta = Console.ReadLine();
                Console.WriteLine("Izaberite  usugu: terapija, pregled, urgentna pomoc");
                string izbor = Console.ReadLine();

                Pacijent pacijent = new Pacijent
                {
                    LBO = LBO,
                    Ime = imePacijenta,
                    Prezime = prezimePacijenta,
                    Adresa = adresaPacijenta,
                    VrstaZahteva = izbor;

                using (MemoryStream ms = new MemoryStream())
                {
                    binaryFormatter.Serialize(ms, pacijent);
                    byte[] data = ms.ToArray();

                    klijentSocket.Send(data);
                }

                Console.WriteLine("Podaci o pacijentu su poslati!");

            }

            Console.WriteLine("Klijent zavrsava sa radom");
            Console.ReadKey();
            klijentSocket.Close();

        }
    }
}

