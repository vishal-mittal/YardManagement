using System;
using CouplingManagement.Model;

namespace CouplingManagement
{
  /// <summary>
  /// This is our Main Execution Program Starting Point
  /// </summary>
  class YardManagement
  {
    static void Main(string[] args)
    {
      WriteToConsole("Please Choose any Command From List");
      WriteToConsole("1.Build Train");
      WriteToConsole("2.Run Building Test Train");
      Console.Title = typeof(YardManagement).Name;
      // We will add some set-up stuff here later...

      Run();
    }

    /// <summary>
    /// This Run our Program Suites
    /// </summary>
    static void Run()
    {
      while (true)
      {
        var consoleInput = ReadFromConsole();
        if (string.IsNullOrWhiteSpace(consoleInput)) continue;

        try
        {
          // Execute the command:
          string result = Execute(consoleInput);

          // Write out the result:
          WriteToConsole(result);
        }
        catch (Exception ex)
        {
          // OOPS! Something went wrong - Write out the problem:
          WriteToConsole(ex.Message);
        }
      }
    }

    /// <summary>
    /// This Funciton used for Execution of Command at run time
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    static string Execute(string command)
    {
      // We'll make this more interesting shortly:
      var buildFactory = new BuildTrainFactory();
      var train=buildFactory.GetBuildTrain(command);
      if (train != null)
      {
        train.Build();
      }
      else
      {
        WriteToConsole("Please Check your Command");
      }
      return string.Format("Executed the {0} Command", command);
    }

    /// <summary>
    /// This Function used for printing Message to console
    /// </summary>
    /// <param name="message"></param>
    public static void WriteToConsole(string message = "")
    {
      if (message.Length > 0)
      {
        Console.WriteLine(message);
      }
    }


    const string _readPrompt = "console> ";
    public static string ReadFromConsole(string promptMessage = "")
    {
      // Show a prompt, and get input:
      Console.Write(_readPrompt + promptMessage);
      return Console.ReadLine();
    }
  }
}
