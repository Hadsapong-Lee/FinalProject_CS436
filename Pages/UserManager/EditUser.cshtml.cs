using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static FinalProject.Pages.AdminModel;

namespace FinalProject.Pages.UserManager
{
    public class EditUserModel : PageModel
    {
        public String UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MobilePhone { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserRole { get; set; }

        public IActionResult OnGet(string userId)
        {
            try
            {
                string connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT [dbo].[AspNetUsers].Id, [dbo].[AspNetUsers].UserName, [dbo].[AspNetRoles].Name FROM [dbo].[AspNetUsers]" +
                                    " INNER JOIN [dbo].[AspNetUserRoles] ON [dbo].[AspNetUsers].Id = [dbo].[AspNetUserRoles].UserId" +
                                    " INNER JOIN [dbo].[AspNetRoles] ON [dbo].[AspNetUserRoles].RoleId = [dbo].[AspNetRoles].Id" +
                                    " WHERE [dbo].[AspNetRoles].Id=\'"+userId+"\'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                UserId = reader.GetString(0);
                                FirstName = reader.GetString(1);
                                LastName = reader.GetString(2);
                                MobilePhone = reader.GetString(3);
                                UserName = reader.GetString(4);
                                Email = reader.GetString(5);
                                UserRole = reader.GetString(6);

                                return Page();
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToPage("/Admin");
        }
    }
}
