/* 
 * Toasty.cs
 *
 * A simple console app that creates a toast Windows notification. 
 */

// Import libraries.
//
using System;
using Microsoft.Toolkit.Uwp.Notifications;
using static Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder;

/*
 * Class: Toasty
 */
public class Toasty
{

    /*
     * Main - application main driver
     */
    public static void Main(string[] args)
    {
        // Declare and define local variables.
        //
        String messenger = "";
        String textMessage = "";
        int startIndex = 0;

        // Check the number of arguments.
        //
        if (args.Length <= 2)
        {
            // There needs to be at least two arguments: -t <text_message>
            // Therefore, display usage information.
            //
            Console.WriteLine("Usage: Toasty [-m <messenger>] -t <text_message>");
        }
        else
        {
            // There are at least two arguments.  Check to see if the messenger was
            // specified.
            //
            if (args[0] == "-m")
            {
                // It was and as it is guaranteed that there are two arguments,
                // the messenger will be the second argument.
                //
                messenger = args[1];
                startIndex = 2;
            }
            else
            {
                // No messenger was specified; therefore, default to Console.
                //
                messenger = "Console";
                startIndex = 0;
            }

            // Parse the message text.
            //
            if (args[startIndex] != "-t")
            {
                // The text message needs the -t switch.  Display the usage.
                //
                Console.WriteLine("Usage: Toasty [-m <messenger>] -t <text_message>");
            }
            else
            {
                // Iterate over the remaining arguments to build the message.  The message
                // will start at the 'startIndex' depending on if a messenger was specified
                // or not.
                //
                for (int i = startIndex+1; i < args.Length; i++)
                {
                    textMessage += args[i] + " ";
                }

                // Display the toast message in the system.
                //
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText(messenger)
                    .AddText(textMessage)
                    .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater

            }
        }
    }

}