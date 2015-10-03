using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace SmsSender
{
    class XMLReder
    {

        public static string fileName = @"C:\sms\XMLFrom1C.xml";
        public string label1, tel, name, msg, dateContiniue, sex, com, summ = "";
        public static string log = @"C:\log.txt"; 
        static string destinationFile = @"C:\Program Files (x86)\1cv82\common\XMLFrom1C.xml";

       
       public XMLReder()
        {



          //  File.Move(fileName, destinationFile);

           //Создадим XML документ
             XmlDocument xmldoc = new XmlDocument();

             //Загрузим в документ наш xmlфайл

             xmldoc.Load(@destinationFile);

             //Выполняем доступ к корневому узлу
             XmlNode rootnode = xmldoc.DocumentElement;
           
             //Считаем из документа все его дочерние элементы первого уровня
             XmlNodeList childnodes = rootnode.ChildNodes;

             //для каждого дочернего элемента выведем его атрибуты
             foreach(XmlNode node in childnodes)
             {
             
               XmlNodeList childnodes1 = node.ChildNodes;

                   foreach (XmlNode node1 in childnodes1)
                   {
                      label1 = node1.Name; 
                    //  Console.Write(label1);

                      if (label1 == "tel") tel = node1.InnerText;
                      if (label1 == "name") name = node1.InnerText;
                      if (label1 == "summ") summ = node1.InnerText;
                      if (label1 == "sex") sex = node1.InnerText;
                      if (label1 == "ДатаПогашения") dateContiniue = node1.InnerText;
                      if (label1 == "com") com = node1.InnerText;
                      if (label1 == "msg")
                      {
                          msg = sex +" "+ name +" "+ node1.InnerText +" " + dateContiniue +", сумма задолжности "+summ ;

                         // Console.WriteLine(tel);
                          // int len = tel.Length;  -LF \""+ log +"\" -L 

                          if (tel != null)
                          {
                              string argument = "-Q -LF \"" + log + "\" -L  -P " + com + " " + tel + " " + " \"" + msg + "\"";

                             // Console.WriteLine(argument);
                              string filename = "cmd2phone.exe";
                              Console.WriteLine(argument);
                              // Console.WriteLine("Сообщение отправлено на номер " + tel);
                              System.Diagnostics.Process.Start(filename, argument);
                              Thread.Sleep(1000 * 10);
                          }

                          
                       
                      }
                  
                   }
                                
              }
           //  File.Delete(destinationFile);
             Console.ReadKey();
            

         }

   
      




     }
}
