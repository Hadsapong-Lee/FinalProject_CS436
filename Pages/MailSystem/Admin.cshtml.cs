using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalProject.Pages.MailSystem
{
    public class AdminModel : PageModel
    {
        public List<UserInfo> UserList= new List<UserInfo>();

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

                    String sql = $"SELECT FirstName, LastName FROM AspNetUsers";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.FirstName= "" + reader.GetString(0);
                                userInfo.LastName = reader.GetString(1);
                                userInfo.MobilePhone = reader.GetString(2);
                                userInfo.UserName = reader.GetString(3);
                                userInfo.Email = "" + reader.GetString(4);

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

        public class UserInfo
        {
            public String FirstName;
            public String LastName;
            public String MobilePhone;
            public String UserName;
            public String Email;
        }
    }
}
