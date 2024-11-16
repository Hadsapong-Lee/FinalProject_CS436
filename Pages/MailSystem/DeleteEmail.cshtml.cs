using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace FinalProject.Pages
{
    public class DeleteEmailModel : PageModel
    {
        public IActionResult OnGet(string emailid)
        {
            try
            {
                String connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String deleteSql = $"DELETE FROM emails WHERE emailid = '{emailid}'";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    return RedirectToPage("/Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToPage("/Index");
            }
        }
    }
}
