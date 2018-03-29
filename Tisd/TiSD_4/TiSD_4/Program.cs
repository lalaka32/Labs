using System;
using System.Collections.Generic;
using System.Linq;

namespace TiSD_4
{
    struct Mail//Структура почта
    {
        public string town;
        public string street;
        public ushort house;
        public ushort apartment;
        public string receiver;
        public decimal value;
        public Mail(string town,string street,ushort house,ushort apartment,string receiver,decimal value)
        {
            this.town = town;
            this.street = street;
            this.house = house;
            this.apartment = apartment;
            this.receiver = receiver;
            this.value = value;
        }
        public override string ToString()
        {
            return "Adress : "+town+" "+street + " " + house + " " + apartment+" Receiver : "+receiver+" Value : "+value;
        }
        public string ToAdress()
        {
            return town + " " + street + " " + house + " " + apartment;
        }
    }
    class Program
    {
        static Mail[] Init()//Инициализация массива писем
        {
            Mail[] mail = new Mail[0];
            Console.WriteLine("Length :");
            try
            {
                mail = new Mail[Convert.ToInt32(Console.ReadLine())];//Длинна
            }
            catch (Exception)
            {
                Console.WriteLine("Nope");
                
            }
           
            for (int i = 0; i < mail.Length; i++)//Init
            {
                Console.WriteLine("string town,string street,ushort house,ushort apartment,string receiver,decimal value:");
                try
                {
                    mail[i] = new Mail(Console.ReadLine(), Console.ReadLine(), Convert.ToUInt16(Console.ReadLine()), Convert.ToUInt16(Console.ReadLine()), Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine("Nope");
                    
                }
                
                Console.Clear();
            }
            return mail;
        }
        static int CointMinsk(Mail[] mail)
        {
            int count = 0;
            foreach (Mail item in mail)
            {
                if (item.town.ToLower().Trim() == "minsk")//стравнивает не только строку но и ставит в нижний регистер и удаляет пробелы побокам
                {
                    count++;
                }
            }
            return count;
        }
        static string ReceiverAndCount(Mail[] mail)
        {

            string ans ="";
            int count = 1;
            for (int i = 0; i < mail.Length; i++)
            {
                if (mail[i].ToAdress() == null)
                {
                    continue;
                }
                for (int j = i+1; j < mail.Length; j++)
                {
                    if (mail[i].ToAdress().ToLower().Trim() == mail[j].ToAdress().ToLower().Trim())
                    {
                        count++;
                    }
                }
                for (int j = i + 1; j < mail.Length; j++)
                {
                    if (mail[i].ToAdress().ToLower().Trim() == mail[j].ToAdress().ToLower().Trim())
                    {

                        List<Mail> mail1= mail.ToList();//удаление посчитанных эл-ов
                        mail1.Remove(mail[j]);
                        mail = mail1.ToArray();
                    }
                }
                if (count!=1)
                {
                    ans += " " + mail[i].ToAdress()+" "+count+"\n";
                    count = 1;
                }

            }
            return ans;
        }

        static string More300CountAndAdress(Mail[] mail)
        {
            string ans = "";
            int count = 0;
            for (int i = 0; i < mail.Length; i++)
            {
                for (int j = 0; j < mail.Length; j++)
                {
                    if (mail[i].town.ToLower().Trim() == mail[j].town.ToLower().Trim() && mail[j].value>200)
                    {
                        count++;
                    }
                }
                for (int j = i + 1; j < mail.Length; j++)
                {
                    if (mail[i].ToAdress().ToLower().Trim() == mail[j].ToAdress().ToLower().Trim())
                    {

                        List<Mail> mail1 = mail.ToList();//удаление посчитанных эл-ов
                        mail1.Remove(mail[j]);
                        mail = mail1.ToArray();
                    }
                }
                if (count != 0)
                {
                    ans += " " + mail[i].town + " " + count;
                    count = 0;
                }

            }
            return ans;
        }
        static void Main(string[] args)
        {
            Mail[] m1 = { new Mail("minsk", "Mira", 1, 13, "Valya Mamaev", 100), new Mail("mogilev", "Mira", 1, 13, "Valya", 300),
                new Mail("minsk", "Mira", 1, 11, "Valya", 300),new Mail("mogilev", "Mira", 1, 13, "Valya", 100), };
            Console.WriteLine(ReceiverAndCount(m1));
            Console.Read();
        }
    }
}
