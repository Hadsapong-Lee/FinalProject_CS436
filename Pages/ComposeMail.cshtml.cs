using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FinalProject.Pages
{
public class ComposeMailModel : PageModel
{
    [BindProperty]
    public string EmailSubject { get; set; }

    [BindProperty]
    public string EmailMessage { get; set; }

    [BindProperty]
    public string EmailSender { get; set; }

    [BindProperty]
    public string EmailReceiver { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

   public IActionResult OnPost()
{
    try
    {
        TimeZoneInfo thaiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        string connectionString = "Server=tcp:datapj.database.windows.net,1433;Initial Catalog=datapj;Persist Security Info=False;User ID=fproject;Password=Final12Proj3ct;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string username = User.Identity.Name ?? "";

            DateTime thaiTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, thaiTimeZone);

            string insertSql = "INSERT INTO emails (emailsubject, emailmessage, emaildate, emailisread, emailsender, emailreceiver) VALUES (@EmailSubject, @EmailMessage, @ThaiTime, 0, @Username, @EmailReceiver)";

            using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
            {
                insertCommand.Parameters.AddWithValue("@EmailSubject", EmailSubject);
                insertCommand.Parameters.AddWithValue("@EmailMessage", EmailMessage);
                insertCommand.Parameters.AddWithValue("@ThaiTime", thaiTime);
                insertCommand.Parameters.AddWithValue("@Username", username);
                insertCommand.Parameters.AddWithValue("@EmailReceiver", EmailReceiver);

                insertCommand.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    return RedirectToPage("/EmailSent");
}
}
}