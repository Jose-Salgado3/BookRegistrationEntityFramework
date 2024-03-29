﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    static class CustomerDb
    {
        /// <summary>
        /// Returns all Customers from the data base
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            //Create instance of DB context
            var db = new BookRegistrationEntities();

            //Use DB context to retrieve all Customers
            //Use LINQ to query database(cast to list)
            //Query syntax
            //List<Customer> customers =
            //    (from c in db.Customer
            //    select c).ToList();

            //LINQ Method Syntax -Same query as above
            List<Customer> customers =
                db.Customer
                .ToList();

            return customers;
        }

        /// <summary>
        /// Adds a customer. Returns the newly added customer with the Customer Id populated
        /// </summary>
        /// <param name="c">The new Customer to be added</param>
        /// <returns></returns>
        public static Customer AddCustomer(Customer c)
        {
            using (var context = new BookRegistrationEntities())
            {
                context.Customer.Add(c);
                //Save changes must be called for INSERTS UPDATES and DELETES
                context.SaveChanges();
                //Return newly added customer with CustomerId(Identity column) populated
                return c;
            }
        }
        public static Customer UpdateCustomer(Customer c)
        {
            // If a customer ID = 0 EF will know this is a new customer.
            using (var context = new BookRegistrationEntities())
            {
                //Adds to context, not DB(technically) so it starts tracking it
                context.Customer.Add(c);
                //Tell EF we are updating an existing entity
                context.Entry(c).State = EntityState.Modified;
                context.SaveChanges();
                return c;
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            using (var context = new BookRegistrationEntities)
            {
                //begin tracking
                context.Customer.Add(c);

                context.Entry(c).State = EntityState.Deleted;
                int rowsAffrected = context.SaveChanges();
            }
        }
    }
}
