using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;

namespace Project
{

    public class NewBaseType

    {
      
        static void Main(string[] args)
        {
            try{
                string url = "api";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response ;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }
            
                string[] Code = response.Split(':');
                double accessBalance = double.Parse(response.Split(':')[2], CultureInfo.InvariantCulture);
                double id = double.Parse(response.Split(':')[1], CultureInfo.InvariantCulture);
                Code[2] = Code[2].Remove(0,1);
                    if (Code[0] == "NO_BALANCE")
                    {
                        Console.WriteLine("Пополните счет!!!");
                
                    }   
                    else if (Code[0] == "NO_NUMBERS")
                    {
                        Console.WriteLine("Нет номеров");

                    }
                    else if (Code[0] == "ACCESS_NUMBER" ){
                        Console.WriteLine($"Успешно:+{Code[2]}");
                    }
                            try
                            {

                                string url1 = "api";
                                url1 = url1.Insert (107, Code[1]);
                                
                                for( int n = 0;n<100;n++)
                                {
                                HttpWebRequest httpWebRequest1 = (HttpWebRequest)WebRequest.Create(url1);
                                HttpWebResponse httpWebResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();
                                string response1 ;
                                using (StreamReader streamReader1 = new StreamReader(httpWebResponse1.GetResponseStream()))
                                {
                                    response1 = streamReader1.ReadToEnd();
                                }
                                
                                string[] answer = response1.Split(':');
                                if (answer[0] == "STATUS_WAIT_CODE")
                                {
                                    Console.WriteLine("Ждем");
                                    Thread.Sleep(1000);
                                }
                                else if(answer[0] == "STATUS_OK")
                                {
                                    Console.WriteLine($"Код активации  {answer[1]}");
                                    break;
                                }
                                }
                            }
                            catch (Exception)
                            {
                
                            //https://sms-activate.ru/stubs/handler_api.php?api_key=d5e5b88c52Aee3fc4d060e01de5609Af&action=setStatus&status=1&id={id}"
                    }
            }
            catch{

            }


            
        }
        
        
            
            
        
        
    }
}


