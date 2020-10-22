using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        private static IDatabase userDb;

        static void Main(string[] args)
        {


            
        }

        public async static Task<User> GetUser(int id)
        {
            var user = await userDb.GetUser(id);

            return user;
        }
    }

    interface IDatabase
    {
        abstract Task<User> GetUser(int id);
    }
    
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
