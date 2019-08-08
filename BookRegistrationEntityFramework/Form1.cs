using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
            PopulateBookList();
        }

        private void PopulateBookList()
        {
            List<Book> books = BookDb.GetBooks();

            cboBooks.DataSource = books;
            cboBooks.DisplayMember = nameof(Book.Title);
        }

        /// <summary>
        /// Populates customer list from the database
        /// </summary>
        private void PopulateCustomerList()
        {
            List<Customer> customers = CustomerDb.GetCustomers();

            cboCustomers.DataSource = customers;
            cboCustomers.DisplayMember = nameof(Customer.FullName);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Hard code customer for testing purposes
            Customer c = new Customer()
            {
                FirstName = "J",
                LastName = "Doe", 
                DateOfBirth = DateTime.Now,
                Title = "Prof"
            };

            CustomerDb.AddCustomer(c);

            string output = $"Added {c.CustomerID} {c.FullName}";
            MessageBox.Show(output);

            PopulateCustomerList();
        }
    }
}
