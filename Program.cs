using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Xml.Linq;

string localAccount = ("C:\\Users\\karda\\OneDrive\\Documents\\CodingProjects\\C#Base\\Pseudop\\Pseudop\\Data\\_me.txt");
string[] localVariables = File.ReadAllLines(localAccount);

// Start profile-reading

string profile;
string profileFile;

while (localVariables[0] != "logged")
{
    Type("What is your account?", 20);
    profile = Console.ReadLine();
    File.WriteAllText(localAccount, "logged" + Environment.NewLine + profile + Environment.NewLine);
    localVariables = File.ReadAllLines(localAccount);
}

profile = localVariables[1];
profileFile = ("C:\\Users\\karda\\OneDrive\\Documents\\CodingProjects\\C#Base\\Pseudop\\Pseudop\\Data\\Profiles\\" + profile + ".txt");


string systemFile = ("C:\\Users\\karda\\OneDrive\\Documents\\CodingProjects\\C#Base\\Pseudop\\Pseudop\\Data\\System.txt");

void Type(string text, int speed)
{
    char[] textBox = text.ToCharArray();
    for (int i = 0; i < textBox.Length; i++)
    {
        Thread.Sleep(speed);
        Console.Write(textBox[i]);
    }
    Console.WriteLine();
}


void Unfinished()
{
    Type("Unfinished Feature", 20);
}

Type("Hello " + profile, 10);

while(true)
    {
    Type("Please provide a command:", 20);
    // Commands

    string[] usable_commands = //0
    {
    "GET", //Transfer data
    "CHANGE", //Change data
    "DELETE" //Remove data
};

    string[] usable_subjections =  //1
    {
    "IMAGE", // Image
    "RECENT", // Most recent
    "_text_" // Plaintext

};

    string[] usable_interactions = //2
    { // Send | Change most recent | See most recent | Delete most recent
    "TO", // as self
    "OUT" // as anon
};

    string[] usable_objections = //3
    {
    "SYSTEM", // the world
    "SELF", // self
    "_name", // _anyUsername
    "@community" // __anyCommunity
};


    //Dealing with input
    string[] inputN = Console.ReadLine().Split(' ');
    string input = "";
    char fL = '#';
    string name;

    if (inputN[2] == "TO")
    {
        name = profile;
    } else if (inputN[2] == "OUT")
    {
        name = "ANON";
    } else
    {
        name = "p:" + inputN[2];
    }


    string givenFile = "";

    //Dealing with receiver
    if (inputN[3] == "SYSTEM")
    {
        givenFile = systemFile;
    } else if (inputN[3] == "SELF")
    {
        givenFile = profileFile;
    } else
    {
        char[] otherType = inputN[3].ToCharArray();
        if (otherType[0] == '@')
        {
            givenFile = "C:\\Users\\karda\\OneDrive\\Documents\\CodingProjects\\C#Base\\Pseudop\\Pseudop\\Data\\Communities\\" + inputN[3] + ".txt";
        } else if (otherType[0] == '_')
        {
            givenFile = "C:\\Users\\karda\\OneDrive\\Documents\\CodingProjects\\C#Base\\Pseudop\\Pseudop\\Data\\Profiles\\" + inputN[3] + ".txt";
        } else
        {
            givenFile = profileFile;
        }
    }
    File.AppendAllText(givenFile, "");
    string[] givenFileLines = File.ReadAllLines(givenFile);

    //INPUT
    if (inputN[1] == "IMAGE")
    {
        Unfinished();
    }
    else if (inputN[1] == "RECENT")
    {
        string recentText = givenFileLines[givenFileLines.Length - 1];
        Type(recentText, 20);
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
            input = input + fL;
        }
    }

    //Dealing with command
    if (inputN[0] == "GET")
    {
        if (inputN[1] != "RECENT")
        {
            File.AppendAllText(givenFile, (name + ": " + input) + Environment.NewLine);
        }

    }
    else if (inputN[0] == "CHANGE")
    {
        File.WriteAllText(givenFile, "");
        for (int i = 0; i < givenFileLines.Length - 1; i++)
        {
            File.AppendAllText(givenFile, givenFileLines[i] + Environment.NewLine);
            File.AppendAllText(givenFile, (name + " changed: " + givenFileLines[givenFileLines.Length] + " to " + input) + Environment.NewLine);
        }

    }
    else if (inputN[0] == "DELETE")
    {
        File.WriteAllText(givenFile, "");
        for (int i = 0; i < givenFileLines.Length; i++)
        {
            File.AppendAllText(givenFile, givenFileLines[i] + Environment.NewLine);
        }
    }
    else
    {
        Type("Unknown command", 20);
    }

    //Dealing with output


    // Test
    Type(input, 20);
}