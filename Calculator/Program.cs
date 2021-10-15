using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MINIRÄKNARE";
            char[] operatorer = { '*', '/', '-', '+' }; //Operatorerna som vi letar efter i användarens inmatning
            List<string> svar = new List<string>(); //Listan som vi sparar alla uträkningar i

            Console.WriteLine("Hej och välkommen till miniräknaren i C#\nVar god skriv in ett tal, " +
                "följt av en operator \"+\", \"-\", \"*\" eller \"/\", följt av ett till tal." +
                "\nNär du vill avsluta, skriver du \"MARCUS\""); //OBS att endast en operator kan användas per uträkning.
                                                                 //Exempelvis funkar inte 1+1+1. Programmet kommer att räkna allt från första operatorn
                                                                 //till slutet av strängen som ett tal och misslyckas att konvertera till double. 
                                                                 //Felmeddelandet blir också "felformulerat" om man använder fler operatorer. Felet uppstår på grund av
                                                                 //mitt sätt att ta reda på de två olika talen där jag letar efter första operatorn som förekommer
                                                                 //och plockar ut det som finns på vardera sida av operatorn. Se raderna 40-42 och 44-49. 

            while (true)
            {
                string inmatning = Console.ReadLine(); //Användarens inmatning
                inmatning.Trim(); //Tar bort whitespaces för enklare hantering med substring senare 
                if (inmatning.Contains("MARCUS")) //Om strängen innehåller "MARCUS" så skrivs historiken ut och programmet avslutas
                {
                    Console.WriteLine("\nHej!\n\nHistorik:");
                    foreach (string historik in svar) //Går igenom alla sparade uträkningar och skriver ut dem
                    {
                        Console.WriteLine(historik);
                    }
                    break;
                }

                int index_operator = inmatning.IndexOfAny(operatorer); //Hitta index på operatorn användaren matat in
                if (index_operator != -1) //Om inte någon av operatorerna i vår array finns i inmatningen får användaren skriva om, se else-sats längst ner
                {
                    string forsta_talet = inmatning.Substring(0, index_operator); //Plocka ut första talet med hjälp av index på operatorn
                    string andra_talet = inmatning.Substring(index_operator + 1); //Plocka ut andra talet på samma sätt som tidigare, OBS blir fel om fler operatorer används
                    string vilken_operator = inmatning.Substring(index_operator, 1); //Plocka ut VILKEN operator som matats in 

                    if (!double.TryParse(forsta_talet, out double num1)) //Kolla strängen efter ett tal och gör om till double om det går, annars får användaren göra om
                    {
                        Console.WriteLine("Vafalls? " + "\"" + forsta_talet + "\"" + " är inget tal... försök igen!");
                        continue;
                    }
                    if (!double.TryParse(andra_talet, out double num2)) //Kolla strängen efter ett tal och gör om till double om det går, annars får användaren göra om 
                    {
                        Console.WriteLine("Nu tabbade du dig " + "\"" + andra_talet + "\"" + " är inget tal... försök igen!");
                        continue;
                    }
                    if (andra_talet == "0" && vilken_operator == "/") //Ser till att användaren inte dividerar med 0
                    {
                        Console.WriteLine("Du får inte dividera med 0! Försök igen!");
                        continue;
                    }

                    switch (vilken_operator) //Gör uträkningen, matar ut svaret och sparar det i listan
                    {
                        case "+":
                            double resultat = (num1 + num2);
                            Console.WriteLine(num1 + "+" + num2 + " = " + resultat + "\n");
                            svar.Add(num1 + "+" + num2 + " = " + resultat);
                            break;
                        case "-":
                            resultat = (num1 - num2);
                            Console.WriteLine(num1 + "-" + num2 + " = " + resultat + "\n");
                            svar.Add(num1 + "-" + num2 + " = " + resultat);
                            break;
                        case "*":
                            resultat = (num1 * num2);
                            Console.WriteLine(num1 + "*" + num2 + " = " + resultat + "\n");
                            svar.Add(num1 + "*" + num2 + " = " + resultat);
                            break;
                        case "/":
                            resultat = (num1 / num2);
                            Console.WriteLine(num1 + "/" + num2 + " = " + resultat + "\n");
                            svar.Add(num1 + "/" + num2 + " = " + resultat);
                            break;
                    }
                }
                else //Användaren har matat in något som inte innehåller en operator, får då göra om
                {
                    Console.WriteLine("Vad menar du med " + "\"" + inmatning + "\"" + "?\nMata in lite matte istället!");
                }
            }
        }
    }
}

