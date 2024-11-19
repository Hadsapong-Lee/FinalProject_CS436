using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static FinalProject.Pages.AdminModel;

namespace FinalProject.Pages.UserManager
{
    public class EditUserModel : PageModel
    {

        [BindProperty]
        public String FirstName { get; set; }

        [BindProperty]
        public String LastName { get; set; }

        [BindProperty]
        public String MobilePhone { get; set; }

        [BindProperty]
        public String UserName { get; set; }

        [BindProperty]
        public String Email { get; set; }

        [BindProperty]
        public String UserRole { get; set; }

        public void OnGet()
        {

            String Id = Request.Query["Id"];
            try
            {
                string connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT [dbo].[AspNetUsers].FirstName, [dbo].[AspNetUsers].LastName, [dbo].[AspNetUsers].MobilePhone, [dbo].[AspNetUsers].UserName, [dbo].[AspNetUsers].Email, [dbo].[AspNetRoles].Name " +
                                    "FROM [dbo].[AspNetUsers] " +
                                    "INNER JOIN [dbo].[AspNetUserRoles] ON [dbo].[AspNetUsers].Id = [dbo].[AspNetUserRoles].UserId " +
                                    "INNER JOIN [dbo].[AspNetRoles] ON [dbo].[AspNetUserRoles].RoleId = [dbo].[AspNetRoles].Id " +
                                    "WHERE [dbo].[AspNetUsers].Id=@Id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FirstName = reader.GetString(0);
                                LastName = reader.GetString(1);
                                MobilePhone = reader.GetString(2);
                                UserName = reader.GetString(3);
                                Email = reader.GetString(4);
                                UserRole = reader.GetString(5);
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void OnPost() { 
        
        }
    }
}
