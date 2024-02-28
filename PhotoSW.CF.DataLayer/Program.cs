using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer
{
    public static class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Starting Demo Application");


            PhotoSWEntities db = new PhotoSWEntities();
           // CreateAndSeedDatabase();
           // PressEnterToExit();
        }

        public static PhotoSWEntities CreateAndSeedDatabase()
        {
            System.Console.WriteLine("Create and seed the database.");
            var context = new PhotoSWEntities();


           // System.Console.WriteLine("Completed.");
           // System.Console.WriteLine();
           // invoicetype ojgrp = new invoicetype();

           //// ojgrp.Id = 1;
           // ojgrp.Name = "Goods";

           // ojgrp.IsActive = true;
           // invoicetype ojgrp2 = new invoicetype();
           //// ojgrp2.Id = 2;
         
           // ojgrp2.Name = "Service";

           // ojgrp2.IsActive = true;

           // context.Set<invoicetype>().Add(ojgrp);
           // context.Set<invoicetype>().Add(ojgrp2);
           // context.SaveChanges();


            return context;
        }
        public static void PressEnterToExit()
        {
           
        }
    }
}
