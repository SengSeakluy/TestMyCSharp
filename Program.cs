using System;
using System.Text.RegularExpressions;

class Program
{
     static void Main()
     {
          Console.WriteLine("Enter the notification title:");
          string? input = Console.ReadLine();
          if (string.IsNullOrEmpty(input))
          {
               Console.WriteLine("The input is empty.");
          }else{
               string result = ParseNotificationChannels(input);
               Console.WriteLine(result);
          }
     }

     static string ParseNotificationChannels(string input)
     {
          // List of valid channels
          var validChannels = new HashSet<string> { "BE", "FE", "QA", "Urgent" };
          var matches = Regex.Matches(input, @"\[(.*?)\]");
          var channels = new List<string>();

          foreach (Match match in matches)
          {
               string tag = match.Groups[1].Value;
               if (validChannels.Contains(tag))
               {
                    channels.Add(tag);
               }
          }

          if (channels.Count > 0)
          {
               return "Receive channels: " + string.Join(", ", channels);
          }else{
               return "No channels found.";
          }
     }
}
