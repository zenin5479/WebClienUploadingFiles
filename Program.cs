using System;
using System.IO;
using System.Net;

namespace WebClienUploadingFiles
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Загрузка...\nПожалуйста, подождите...");
         // Для загрузки файла используется класс WebClient
         WebClient Client = new WebClient();
         // Метод DownloadFile() принимает два параметра - первый это путь к файлу,
         // который нужно скачать, а второй - локальное имя файла
         Client.DownloadFile("https://www.google.ru", "WebClienUploadingFiles.txt");
         Console.WriteLine("Загрузка завершена");
         // Получить вебстраницу в строку для последующей ее обработки
         // Cама процедура неэффективная - сначала загружаем страницу в файл, потом читаем текст из этого файла
         // Гораздо удобнее использовать метод OpenRead()
         Stream str = Client.OpenRead("https://www.google.ru");
         // Содержимое страницы будет загружено в переменную
         // После этого можно использовать класс StreamReader для обработки потока
         if (str != null)
         {
            StreamReader reader = new StreamReader(str);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               Console.WriteLine(line);
            }
         }

         Console.ReadLine();
      }
   }
}
