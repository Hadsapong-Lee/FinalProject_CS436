using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static FinalProject.Pages.AdminModel;

namespace FinalProject.Pages.UserManager
{
    public class EditUserModel : PageModel
    {

        public List<UserFullInfo> UserList = new List<UserFullInfo>();

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
                                UserFullInfo userInfo = new UserFullInfo();
                                userInfo.UserId = reader.GetString(0);
                                userInfo.UserName = reader.GetString(1);
                                userInfo.UserRole = reader.GetString(2);

                                UserList.Add(userInfo);

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

        public class UserFullInfo
        {
            public string UserId;
            public string FirstName;
            public string LastName;
            public string MobilePhone;
            public string UserName;
            public string Email;
            public string UserRole;
        }
    }
}
