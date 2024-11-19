using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static FinalProject.Pages.AdminModel;

namespace FinalProject.Pages
{
    public class UsersModel : PageModel
    {

        public List<UserInfo> UserList = new List<UserInfo>();
        public void OnGet()
        {

            try
            {
                string connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string username = "";
                    if (User.Identity.Name == null)
                    {
                        username = "";
                    }
                    else
                    {
                        username = User.Identity.Name;
                    }

                    Console.WriteLine(username);

                    string sql = "SELECT [dbo].[AspNetUsers].Id, [dbo].[AspNetUsers].UserName, [dbo].[AspNetRoles].Name FROM [dbo].[AspNetUsers]" +
                                    " INNER JOIN [dbo].[AspNetUserRoles] ON [dbo].[AspNetUsers].Id = [dbo].[AspNetUserRoles].UserId" +
                                    " INNER JOIN [dbo].[AspNetRoles] ON [dbo].[AspNetUserRoles].RoleId = [dbo].[AspNetRoles].Id" +
                                    " WHERE NOT [dbo].[AspNetRoles].Name=\'admin\'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.UserId = reader.GetString(0);
                                userInfo.UserName = reader.GetString(1);
                                userInfo.UserRole = reader.GetString(2);

                                UserList.Add(userInfo);
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

    }
}
