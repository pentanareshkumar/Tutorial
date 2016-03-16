using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.Show();
            Singleton.Instance.Show();

            Console.ReadKey();
        }

        /// <summary>
        /// The 'Singleton' class
        /// </summary>
        public class Singleton
        {
            private static Singleton instance = null;
            private string Name { get; set; }
            private string IP { get; set; }

            private Singleton()
            {
                Console.WriteLine("Singleton Instance..");
                Name = "Server1";
                IP = "192.168.1.23";
            }

            // Lock synchronization object
            private static object syncLock = new object();

            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            public static Singleton Instance
            {
                get
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new Singleton();
                        return instance;
                    }
                }
            }

            public void Show()
            {
                Console.WriteLine("Server Information is Name: {0} & IP: {1}", Name, IP);
            }

        }
        //eager initialization of singleton
        public class Singleton_Eager
        {
            private static Singleton_Eager instance = new Singleton_Eager();
            private Singleton_Eager() { }

            public static Singleton_Eager GetInstance
            {
                get
                {
                    return instance;
                }
            }
        }

        //Lazy initialization of Singleton
        public class Singleton_Lazy
        {
            private static Singleton_Lazy instance = null;
            private Singleton_Lazy() { }

            public static Singleton_Lazy GetInstance
            {
                get
                {
                    if (instance == null)
                        instance = new Singleton_Lazy();
                    return instance;
                }

            }
        }

        //Thread-safe (Double-checked Locking) initialization of singleton
        public class Singleton_ThreadSafe
        {
            private static Singleton_ThreadSafe instance = null;
            private Singleton_ThreadSafe() { }
            private static object lockThis = new object();

            public static Singleton_ThreadSafe GetInstance
            {
                get
                {
                    lock (lockThis)
                    {
                        if (instance == null)
                            instance = new Singleton_ThreadSafe();
                        return instance;
                    }
                }
            }
        }
    }
}
