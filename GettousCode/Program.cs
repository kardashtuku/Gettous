using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Xml.Linq;
using System.Net;

namespace Horrible
{
    class Program
    {
        static void Type(string text, int speed)
        {
            char[] textBox = text.ToCharArray();
            for (int i = 0; i < textBox.Length; i++)
            {
                Thread.Sleep(speed);
                Console.Write(textBox[i]);
            }
            Console.WriteLine();
        }


        static void Unfinished()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Type("Unfinished Feature", 20);
        }

        static void Sl()
        {
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string localAccount = ("Data\\_me.txt");
            string[] localVariables = File.ReadAllLines(localAccount);

            // Start profile-reading

            string profile;
            string profileFile;

            while (localVariables[0] != "logged")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Type("What is your account?", 20);
                profile = Console.ReadLine();
                File.WriteAllText(localAccount, "logged" + Environment.NewLine + profile + Environment.NewLine);
                localVariables = File.ReadAllLines(localAccount);
            }

            profile = localVariables[1];
            profileFile = ("Data\\Profiles\\" + profile + ".txt");


            string systemFile = ("Data\\System.txt");


            Type("Hello " + profile, 10);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Type("Please provide a command:", 20);

                //Dealing with input
                string[] inputN = Console.ReadLine().Split(' ');

                if (inputN.Length != 4)
                {
                    inputN = ["GET", "FAILED_PACKAGE", "TO", "SELF"];
                }
                char fL = '#';
                string name;

                if (inputN[2] == "TO")
                {
                    name = profile;
                }
                else if (inputN[2] == "OUT")
                {
                    name = "ANON";
                }
                else
                {
                    name = "p:" + inputN[2];
                }


                string givenFile = "";

                //Dealing with receiver
                if (inputN[3] == "SYSTEM")
                {
                    givenFile = systemFile;
                }
                else if (inputN[3] == "SELF")
                {
                    givenFile = profileFile;
                }
                else
                {
                    char[] otherType = inputN[3].ToCharArray();
                    if (otherType[0] == '@')
                    {
                        givenFile = "Data\\Communities\\" + inputN[3] + ".txt";
                    }
                    else if (otherType[0] == '_')
                    {
                        givenFile = "Data\\Profiles\\" + inputN[3] + ".txt";
                    }
                    else
                    {
                        givenFile = profileFile;
                    }
                }
                File.AppendAllText(givenFile, "");
                string[] givenFileLines = File.ReadAllLines(givenFile);

                //INPUT
                Console.ForegroundColor = ConsoleColor.Blue;
                string finalRecord = "";
                if (inputN[1] == "IMAGE")
                {
                    Unfinished();
                }
                else if (inputN[1] == "RECENT")
                {
                    finalRecord = givenFileLines[givenFileLines.Length - 1];
                    Type("This is the most recent input in " + inputN[3], 20);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Type(finalRecord, 20);
                }
                else
                {
                    char[] removeUnder = inputN[1].ToCharArray();
                    for (int i = 0; i < removeUnder.Length; i++)
                    {
                        fL = removeUnder[i];
                        if (removeUnder[i] == ',')
                        {
                            fL = ' ';
                        }
                        finalRecord = finalRecord + fL;
                    }
                }

                //Dealing with command
                if (inputN[0] == "GET")
                {
                    finalRecord = (name + ": " + finalRecord);
                }
                else if (inputN[0] == "CHANGE")
                {
                    File.WriteAllText(givenFile, "");
                    for (int i = 0; i < givenFileLines.Length - 1; i++)
                    {
                        File.AppendAllText(givenFile, givenFileLines[i] + Environment.NewLine);
                    }
                    finalRecord = ("(" + givenFileLines[givenFileLines.Length - 1] + " | " + finalRecord + ")");

                }
                else if (inputN[0] == "DELETE")
                {
                    File.WriteAllText(givenFile, "");
                    for (int i = 0; i < givenFileLines.Length - 1; i++)
                    {
                        File.AppendAllText(givenFile, givenFileLines[i] + Environment.NewLine);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Type("Unknown command", 20);
                }

                //Dealing with output
                Console.ForegroundColor = ConsoleColor.Cyan;

                // Test
                if (inputN[1] != "RECENT")
                {
                    File.AppendAllText(givenFile, finalRecord + Environment.NewLine);
                    Type("Received Input: " + finalRecord, 20);
                }


                Sl();
            }

        }
    }
}