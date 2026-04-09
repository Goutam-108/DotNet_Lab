using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Enter the email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Enter the phone number")]
        public string Phone { get; set; } = "";

        public string ErrorMessage = "";

        // ==========================
        // STEP 3 : OnGet (Load Data)
        // ==========================
        public void OnGet(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Goutam@#4455;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "SELECT * FROM Customers WHERE id = @Id",
                        connection);

                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = reader.GetInt32(0);
                            Name = reader.GetString(1);
                            Email = reader.GetString(2);
                            Phone = reader.GetString(3);
                        }
                        else
                        {
                            ErrorMessage = "Customer not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        // ==========================
        // STEP 4 : OnPost (Update)
        // ==========================
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "UPDATE Customers SET name=@Name, email=@Email, phone=@Phone WHERE id=@Id",
                        connection);

                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Id", Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error updating customer: " + ex.Message;
                return Page();
            }

            return RedirectToPage("/Customers/Index");
        }
    }
}