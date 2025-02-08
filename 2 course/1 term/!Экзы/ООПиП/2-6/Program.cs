using System;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace exam
{
    public class Program
    {
        [Serializable]
         public class User : IComparable
        {
            private string email;
            private string password;
            public string status;

            public string Email { get { return email; }  }
            public string Password { get { return password; } set { password = value; } }
            public string Status { get { return status; } set { status = value; } }

            public User(string email, string password, string status) { 
                this.email = email;
                this.password = password;
                this.status = status;
            }


            public override string ToString()
            {
                return "It's ToString beeeeaaaaach";
            }

            public override bool Equals(object? obj)
            {
                if (obj is User user)
                {
                    return Email == user.Email;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return Password.GetHashCode();
            }

             public int CompareTo(object? obj)
             {

                if (obj is User user)
                {
                    return Email.CompareTo(user.Email);
                }
                else throw new ArgumentException("niggers");
            }
        }
        [Serializable]
        public class WebNet<T>
        {
            public static LinkedList<T> usersLinkedList = new LinkedList<T>();
            public void Adder(T us)
            {
                usersLinkedList.AddLast(us);

                Console.WriteLine($"Object {us} was added");
                Console.WriteLine("All the List:");
                foreach (T u in usersLinkedList)
                {
                    Console.WriteLine(u);
                }
            }

            public void Remover()
            {
                usersLinkedList.RemoveLast();
                Console.WriteLine($"Last object was removed");
                Console.WriteLine("All the List:");
                foreach (T u in usersLinkedList)
                {
                    Console.WriteLine(u);
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("zadanie2");
            User user1 = new User("email1", "123123", "signin");
            User user2 = new User("email2", "qwerty", "signin");
            User user3 = new User("email3", "hihihi", "singout");
            User user4 = new User("email4", "lalala", "signin");
            User user5 = new User("email5", "passer", "singout");

            List<User> userList = new List<User>();
            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);
            userList.Add(user5);

            foreach(User user in userList)
            {
                Console.WriteLine(user.CompareTo(user1));
                Console.WriteLine(user.CompareTo(user2));
                Console.WriteLine(user.CompareTo(user3));
                Console.WriteLine(user.CompareTo(user4));
                Console.WriteLine(user.CompareTo(user5));
            }

            Console.WriteLine("zadanie3");

            WebNet<User> github = new WebNet<User>();
            github.Adder(user1);
            github.Adder(user2);
            github.Adder(user3);
            github.Adder(user4);
            github.Adder(user5);
            github.Remover();
            github.Adder(user5);

            string[] names = { "alex", "kit" };

            Console.WriteLine("zadanie4");
            
            var result = from s in WebNet<User>.usersLinkedList
                         where s.status == "signin"
                         select s;
            Console.WriteLine(result.Count());

            Console.WriteLine("zadanie5");
            var jsonData = new DataContractJsonSerializer(typeof(WebNet<User>));

            using (var reader = new FileStream("JsonData.json", FileMode.OpenOrCreate))
            {
                jsonData.WriteObject(reader, github);
                Console.WriteLine("Данные сериализованы");
            }

            using (var reader = new FileStream("JsonData.json", FileMode.OpenOrCreate))
            {
                WebNet<User> newList = jsonData.ReadObject(reader) as WebNet<User>;
                Console.WriteLine("Данные десериализованы");
            }

        }
    }
}
