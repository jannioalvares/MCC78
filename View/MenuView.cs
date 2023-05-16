using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class MenuView
    {
        public void Insert()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.Write("Pilih tabel yang akan di insert data : ");
        }

        public void Select()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.Write("Pilih tabel yang akan di tampilkan : ");
        }

        public void Update()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.Write("Pilih tabel yang akan di Update : ");
        }

        public void Delete()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.Write("Pilih tabel yang akan di hapus : ");
        }

        public void Menu()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|                  MENU                 |");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| 1.   Insert                           |");
            Console.WriteLine("| 2.   Select                           |");
            Console.WriteLine("| 3.   Update                           |");
            Console.WriteLine("| 4.   Delete                           |");
            Console.WriteLine("| 5.   Insert to ALL                    |");
            Console.WriteLine("| 6.   Get Employee                     |");
            Console.WriteLine("| 7.   Get Profiling                    |");
            Console.WriteLine("| 8.   Get GPA = 4                      |");
            Console.WriteLine("| 9.   Get All                          |");
            Console.WriteLine("| 10.  Exit                             |");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Pilih menu : ");
        }
    }
}
