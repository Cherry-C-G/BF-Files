using System;

namespace StructExample
{
    struct Album
    {
        string _title;
        string _singer;
        string _date;

       
        public Album(string title, string singer, string date)
        {
            _title = title;
            _singer = singer;
            _date = date;
        }

        public void GetReleaseDate()
        {
            Console.WriteLine(_date);
        }
    }
    internal class Program
    {
 
        static void Main(string[] args)
        {
            Album albumA;
            // we need to use new keyword to create an album instance
            Album album = new Album("Recovery", "Eminem", "2010-06-18");
            //call the method in the struct and write the release date in the console
            album.GetReleaseDate(); // 2010-06-18
            int a = 1;
           
        }
    }
}
