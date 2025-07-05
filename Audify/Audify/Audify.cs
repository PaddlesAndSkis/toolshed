/* 
 * Audify.cs
 */

// Import Libraries.
//
using System.Collections;
using System.Media;
using Microsoft.Win32;

/*
 *Audify belongs in the toolshed.
 */
namespace toolshed
{

    /*
     * Class: Audify
     */
    class Audify
    {

        public Audify()
        {
            // Do nothing.
            //

        }


        private void playDefault() 
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default\Notification.Default\.Current"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue(null); // pass null to get (Default)
                        if (o != null)
                        {
                            SoundPlayer theSound = new SoundPlayer((String)o);
                            theSound.Play();                        }
                    }
                }
                
            }

            catch (System.Exception)
            {
                
                throw;
            }
        }


        /* 
         * Main - application main driver
         */
        public static void Main(string[] args)
        {
            String[] acceptedSounds = ["Asterisk", "Beep", "Exclamation", "Hand", "Question"];

            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Audify -s <Asterisk|Beep|Exclamation|Hand|Question>");
            }
            else
            {
                if (args[0] != "-s")
                {
                    Console.WriteLine("Usage: Audify -s <Asterisk|Beep|Exclamation|Hand|Question>");
                }
                else
                {
                    String soundToPlay = args[1];
                    bool validSound = false;

                    foreach (String acceptedSound in acceptedSounds)
                    {
                        if (soundToPlay == acceptedSound)
                        {
                            Console.WriteLine("soundToPlay = " + soundToPlay + " and acceptedSound = " +acceptedSound);
                            validSound = true;

                            switch (soundToPlay)
                            {
                                case "Asterix":     SystemSounds.Asterisk.Play(); break;
                                case "Beep":        SystemSounds.Beep.Play(); break;
                                case "Exclamation": SystemSounds.Exclamation.Play(); break;
                                case "Hand":        SystemSounds.Hand.Play(); break;
                                case "Question":    SystemSounds.Question.Play(); break;
                                default:            SystemSounds.Beep.Play(); break;
                            }

                            // Sound has been found and played.
                            //
                            break;
                        }
                    }

                    if (!validSound)
                    {
                        Console.WriteLine("Usage: Audify -s <Asterisk|Beep|Exclamation|Hand|Question>");
                    }
                }
            }
        }

    }

}