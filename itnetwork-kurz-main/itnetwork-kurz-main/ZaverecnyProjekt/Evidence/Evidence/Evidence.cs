using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace EvidencePojisteni
{ 
    internal class Evidence
    { 
        private Databaze databaze;

        public Evidence()
        {
            databaze = new Databaze();
        }
        public void PridejPojisteneho()
        {
            string jmeno = ziskejJmeno(); // vytvořené metody k zabránění duplicitního kódu
            string prijmeni = ziskejPrijmeni();

            Console.WriteLine("Zadejte telefonní číslo:");
            string telefon;
            while (string.IsNullOrEmpty(telefon = Console.ReadLine()))
            {
                Console.WriteLine("Chybné zadání, zadejte číslo znovu");
            } 

            Console.WriteLine("Zadejte věk");
            int vek;
            
            while(!int.TryParse(Console.ReadLine(), out  vek))
            {
                Console.WriteLine("Chybné zadání, zadejte věk znovu");
            }
            databaze.PridejPojisteneho(jmeno, prijmeni, telefon, vek);
            Console.WriteLine();
            Console.WriteLine("Data byla uložena, pokračujte libovolnou klávesou..");
        }
       
        public void VypisVsechnyPojistene()
        {
            List<Pojistenec> pojistenci = databaze.VratVsechnyPojistene();
            foreach (Pojistenec p in pojistenci) 
                Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine("Pokračujte libovolnou klávesou");
        } 

        public void VyhledejPojisteneho()
        { 
            string jmeno = ziskejJmeno();
            string prijmeni = ziskejPrijmeni();
            Pojistenec p = databaze.VyhledejPojisteneho(jmeno, prijmeni);
            Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine("Pokračujte libovolnou klávesou");
        }
        
        public void VypisUvodniObrazovku()
        {
            Console.Clear();
            Console.WriteLine("--------------------\n" +
                "Evidence pojištěných\n" +
                "--------------------");
            Console.WriteLine(); 
        } 
        private string ziskejJmeno()  // metoda pro získání jména
        {
            Console.WriteLine("Zadejte jméno");
            string jmeno;
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine()))  // ošetření vstupu od uživatele
            {
                Console.WriteLine("Zadej text znovu:");
            }
            return jmeno;
        }
        private string ziskejPrijmeni() // metoda pro získání příjmení
        {
            Console.WriteLine("Zadejte příjmení");
            string prijmeni;
            while (string.IsNullOrWhiteSpace(prijmeni = Console.ReadLine()))  // ošetření vstupu od uživatele
            {
                Console.WriteLine("Zadej text znovu:");
            }
            return prijmeni;
        }
    }
}
