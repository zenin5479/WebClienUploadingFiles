using System;
using System.IO;
using System.Net;

namespace WebClienUploadingFiles
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Загрузка...Пожалуйста, подождите...");
         // Для загрузки файла используется класс WebClient
         WebClient wc = new WebClient();
         // Метод DownloadFile() принимает два параметра - первый это путь к файлу,
         // который нужно скачать, а второй - локальное имя файла
         wc.DownloadFile("https://www.google.ru", "WebClienUploadingFiles.txt");
         Console.WriteLine("Загрузка завершена");
         // Получить вебстраницу в строку для последующей ее обработки
         // Cама процедура неэффективная - сначала загружаем страницу в файл, потом читаем текст из этого файла
         // Гораздо удобнее использовать метод OpenRead().
         var str = wc.OpenRead("https://www.google.ru");
         // Содержимое страницы будет загружено в переменную.
         // После этого можно использовать класс StreamReader для обработки потока.
         if (str != null)
         {
            var sr = new StreamReader(str);
            string s;
            while ((s = sr.ReadLine()) != null)
               Console.WriteLine(s);
         }

         Console.ReadLine();
      }
   }
}
