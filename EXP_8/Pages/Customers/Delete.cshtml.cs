using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = "";

        // =========================
        // OnGet → Display Id
        // =========================
        public void OnGet(int id)
        {
            Id = id;
        }

        // =========================
        // OnPost → Delete Record
        // =========================
        public IActionResult OnPost()
        {
            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Goutam@#4455;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "DELETE FROM customers WHERE id = @Id",
                        connection);

                    command.Parameters.AddWithValue("@Id", Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error deleting customer: " + ex.Message;
                return Page();
            }

            return RedirectToPage("/Customers/Index");
        }
    }
}