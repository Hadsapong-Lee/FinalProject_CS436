using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
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

        public void OnGet()
        {

            String Id = Request.Query["Id"];
            try
            {
                string connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT [dbo].[AspNetUsers].Id, [dbo].[AspNetUsers].FirstName, [dbo].[AspNetUsers].LastName, [dbo].[AspNetUsers].MobilePhone, [dbo].[AspNetUsers].UserName, [dbo].[AspNetUsers].Email, [dbo].[AspNetRoles].Name " +
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
                                UserId = reader.GetString(0);
                                FirstName = reader.GetString(1);
                                LastName = reader.GetString(2);
                                MobilePhone = reader.GetString(3);
                                UserName = reader.GetString(4);
                                Email = reader.GetString(5);
                                UserRole = reader.GetString(6);
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
