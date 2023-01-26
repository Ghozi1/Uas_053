using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uas_053
{
    class Node //clas untuk menyimpan data
    {
        public int id_barang;
        public string nama_barang;
        public string jenis_barang;
        public int harga_barang;
        public Node next;
    }

    class list // Single List 
    {
        Node START; //variable untuk menyimpan 

        public list() 
        {
            START = null;
        }

        public void insert()
        {
            int ib, hb; //variable id barang dan harga barang
            string nm, jb; //variable nama barang dan jenis barang
            Console.WriteLine("Masukan ID Barang    ");
            ib = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Nama Barang  ");
            nm = Console.ReadLine();
            Console.WriteLine("Masukan Jenis Barang ");
            jb = Console.ReadLine();
            Console.WriteLine("Masukan Harga Barang ");
            hb = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();

            newnode.id_barang = ib;
            newnode.nama_barang = nm;
            newnode.jenis_barang = jb;
            newnode.harga_barang = hb;

            if (START == null || ib <= START.id_barang)
            {
                if ((START != null) && (ib == START.id_barang))
                {
                    Console.WriteLine("Duplikat ID Barang tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }// jika variable start sama dengan null/kosong maka ib kr dr variable start.idb
             // jika vaarible strat tdk sama dengan null dan ib sm dgn variables start.idb maka tampilkan ..... lalu kembali
             // variable newnode.next sm dgn var start

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (ib >= current.id_barang))
            {
                if (ib == current.id_barang)
                {
                    Console.WriteLine("\nDuplikat ID Barang tidak diperbolehkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool cari(string jb, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while (current != null)
            {
                if (current.jenis_barang == jb)
                {
                    Console.WriteLine("\nData Ditemukan");
                    Console.WriteLine("\nID Barang : " + current.id_barang);
                    Console.WriteLine("\nNama Barang : " + current.nama_barang);
                    Console.WriteLine("\nJenis Barang : " + current.jenis_barang);
                    Console.WriteLine("\nHarga Barang : " + current.harga_barang);
                }
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }

        public void tampil()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList Data Toko Elektronik : ");
                Console.Write("ID Barang" + "   " + "Nama Barang" + "    " + "Jenis Barang" + "   " + "Harga Barang" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.id_barang + "    " + currentNode.nama_barang + "    " + currentNode.jenis_barang + "    " + currentNode.harga_barang + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("****      WELCOME DI TOKO ELEKTRONIK PAK SUKIEM      ****");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("\n                       MENU");
                    Console.WriteLine("");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. View all the records in the list");
                    Console.WriteLine("3. Search for a record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.tampil();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nmasukan  yang ingin dicari : ");
                                string jbg = Console.ReadLine();
                                if (obj.cari(jbg, ref previous, ref current) == false)
                                    Console.WriteLine("\n");
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for for the value entered");
                }
            }
        }
    }
}

//2. Single Link list (Karena hanya satu arah) 
//3. Front, dan Rear
//4. a. 5
//   b. - inorder pertama tampilkan data pada subtree di posisi kiri kemudian menampilkan akarnya dan yang terkahir menampilkan data yang ada di posisi kanan subtree
//        pada contoh di soal maka pembacaan datanya adalah 15, 20, 25, 31, 32, 35, 30, 48, 50, 66, 67, 69, 65, 94, 99, 98, 90, 70
//      - preorder pertama tampilkan akarnya (root) kemudian tampilkan data yang berada di posisi kiri dan yang terkahir menampilkan data yang berada di posisi kanan pada subtree
//        pada contoh di sola maka pembacaan datanya adalah 50, 48, 30, 20, 15, 15, 32, 32, 35, 70, 65, 67, 66, 69, 90, 98, 94, 99
