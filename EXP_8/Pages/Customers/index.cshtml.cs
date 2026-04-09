using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
    // ✅ CLASS NAME MUST BE IndexModel
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<CustomerInfo> ListCustomers { get; set; } = new List<CustomerInfo>();

        public void OnGet()
        {
            try
            {
                ListCustomers = new List<CustomerInfo>();

                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Goutam@#4455;"))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(
                        "SELECT * FROM customers", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListCustomers.Add(new CustomerInfo
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Phone = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving customers: {ex.Message}");
            }
        }

        // Inner Model Class
        public class CustomerInfo
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
            public string Phone { get; set; } = "";
        }
    }
}