using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_018
{

    class Node
    {

        public int NIM;
        public string name;
        public string kelas;
        public int buku;
        public Node next;
        public Node prev;

    }
    class LinkedList
    {

        Node LAST;

        public LinkedList()
        {
            LAST = null;
        }

        public void addNode()//menambahkan node atau data
        {

            int nomorinduksiswa;
            string namasiswa;
            string kelass;
            int bukuu;


            Console.WriteLine("\nMasukkan Nomer IndukSiswa : ");
            nomorinduksiswa = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("\nMasukkan Nama Murid : ");
            namasiswa = Console.ReadLine();


            Console.WriteLine("\nMasukkan Kelas  : ");
            kelass = Convert.ToString(Console.ReadLine());

            Console.WriteLine("\nMasukkan data buku : ");
            bukuu = Convert.ToInt32(Console.ReadLine());

            //membuat node untuk masing masing data
            Node newnode = new Node();
            newnode.NIM = nomorinduksiswa;
            newnode.name = namasiswa;
            newnode.kelas = kelass;
            newnode.buku = bukuu;

            if (LAST == null || nomorinduksiswa <= LAST.NIM)
            {
                newnode.next = LAST;
                LAST = newnode;
                return;
            }


            Node previous, current;
            for (current = previous = LAST; current != null && nomorinduksiswa >= current.NIM; previous = current, current = current.next) ;
            newnode.next = current;
            newnode.prev = previous;
            if (current == null)
            {
                newnode.next = null;
                previous = newnode;
                return;

            }
            newnode.next = current;
            previous.next = newnode;
        }

        public bool Serach(int bukuu, ref Node previous, ref Node current)
        {
            previous = LAST;
            current = LAST;

            while ((current != null) && (bukuu != current.buku))
            {

                previous = current;
                current = current.next;
            }

            if (current != null)
                return (false);
            else
                return (true);
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;

        }

        public void traverse()
        {
            if (listEmpty())

                Console.WriteLine("\nData tidak di temukan");

            else
            {
                
                Console.WriteLine("\n********* DATA Siswa *********\n");
                Node currentNode;
                for (currentNode = LAST; currentNode != null;
                    currentNode = currentNode.next
                    )
                    Console.WriteLine("Nomer Induk Siswa:" + currentNode.NIM + "\nNama siswa:" + currentNode.name +
                    "\nkelas : " + currentNode.kelas + "\nData buku : " + currentNode.buku + "\n");
            }

        }


        static void Main(string[] args)
        {
            LinkedList obj = new LinkedList();
            while (true)
            {

                try
                {
                    //membuat tampilan menu
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Masukkan data Murid ");
                    Console.WriteLine("2. Mencari Data Murid ");
                    Console.WriteLine("3. Menampilkan Data Murid ");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4):");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch) // membuat switch case
                    {
                        case '1':
                            {
                                obj.addNode();

                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData Tidak Di Temukan");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;

                                Console.Write("\nMasukkan Data Yang Akan dicari ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Serach(num, ref prev, ref curr) == false)

                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\n ******* DATA DITEMUKAN ******");
                                    Console.WriteLine("Data Buku: " + curr.buku);
                                    Console.WriteLine("Nim Murid: " + curr.NIM);
                                    Console.WriteLine("NAma Murid: " + curr.name);
                                    Console.WriteLine("kelass : " + curr.kelas);
                                }

                            }
                            break;

                        case '3':
                            {
                                obj.traverse();
                            }
                            break;

                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("pilihan kamu salah");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }



            }
        }
    }
}

//
//
//
//
//  2. Singel Linked List  
// 
//
//  3. A stack is a collection of data items that can be accessed at only one end, called top. 
//      Items can be inserted and deleted in a stack only at the top.
//
//  4. REAR,FRONT
//
//  5. a.    Kedalaman yang dimiliki adalah level 5
//     b.    pre order ( 50,48,30,20,15,25,32,31,35,70,65,67,66,69,90,98,94,99).
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
