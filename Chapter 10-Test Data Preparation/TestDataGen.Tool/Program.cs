using DataAccess.Core;
using System;

namespace TestDataGen.Tool
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Generating Users....");

            var usersFactory = new UsersFactory(new UsersRepository());
            usersFactory.GenerateUsers(5000);

            Console.WriteLine("DONE");
        }
    }
}
