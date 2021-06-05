using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace PBL3.General
{
    public class Utility
    {
        public static int limitData {get; set;} = 1;
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static void sendMail(string email, string content)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("CodeTop1.Net@gmail.com", "codetop1"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("CodeTop1.Net@gmail.com"),
                Subject = "Wellcome to CodeTop1",
                Body = content,
            };
            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }
        public static bool DifferentList(List<int> a, List<int> b)
        {
            if(a.Count != b.Count)
            {
                return true;
            }
            a.Sort();
            b.Sort();
            for(int i = 0; i < a.Count; i++)
            {
                if(a[i] != b[i])
                    return true;
            }
            return false;
        }
    }
}

