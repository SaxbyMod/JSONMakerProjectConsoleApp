// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    // Color Lists
    public static readonly string[] ColorList = ["\u001b[0;30m", "\u001b[0;31m", "\u001b[0;32m", "\u001b[0;33m", "\u001b[0;34m", "\u001b[0;35m", "\u001b[0;36m", "\u001b[0;37m"];
    public static readonly string[] BoldColorList = ["\u001b[1;30m", "\u001b[1;31m", "\u001b[1;32m", "\u001b[1;33m", "\u001b[1;34m", "\u001b[1;35m", "\u001b[1;36m", "\u001b[1;37m"];
    public static readonly string[] DarkenedColorList = ["\u001b[2;30m", "\u001b[2;31m", "\u001b[2;32m", "\u001b[2;33m", "\u001b[2;34m", "\u001b[2;35m", "\u001b[2;36m", "\u001b[2;37m"];
    public static readonly string[] ItalicColorList = ["\u001b[3;30m", "\u001b[3;31m", "\u001b[3;32m", "\u001b[3;33m", "\u001b[3;34m", "\u001b[3;35m", "\u001b[3;36m", "\u001b[3;37m"];
    public static readonly string[] UnderlineColorList = ["\u001b[4;30m", "\u001b[4;31m", "\u001b[4;32m", "\u001b[4;33m", "\u001b[4;34m", "\u001b[4;35m", "\u001b[4;36m", "\u001b[4;37m"];
    public static readonly string[] FlashyColorList = ["\u001b[5;30m", "\u001b[5;31m", "\u001b[5;32m", "\u001b[5;33m", "\u001b[5;34m", "\u001b[5;35m", "\u001b[5;36m", "\u001b[5;37m"];
    public static readonly string[] HighlighterColorText = ["\u001b[7;30m", "\u001b[7;31m", "\u001b[7;32m", "\u001b[7;33m", "\u001b[7;34m", "\u001b[7;35m", "\u001b[7;36m", "\u001b[7;37m"];
    public static readonly string[] InvisibleColorText = ["\u001b[8;30m", "\u001b[8;31m", "\u001b[8;32m", "\u001b[8;33m", "\u001b[8;34m", "\u001b[8;35m", "\u001b[8;36m", "\u001b[8;37m"];
    public static readonly string[] StrikethroughColorText = ["\u001b[9;30m", "\u001b[9;31m", "\u001b[9;32m", "\u001b[9;33m", "\u001b[9;34m", "\u001b[9;35m", "\u001b[9;36m", "\u001b[9;37m"];
    public static readonly string[] BackgroundColorList = ["\u001b[40m", "\u001b[41m", "\u001b[42m", "\u001b[43m", "\u001b[44m", "\u001b[45m", "\u001b[46m", "\u001b[47m"];
    public static readonly string[] HighInstensityBsckgroundColorList = ["\u001b[0;100m", "\u001b[0;101m", "\u001b[0;102m", "\u001b[0;103m", "\u001b[0;104m", "\u001b[0;105m", "\u001b[0;106m", "\u001b[0;107m"];
    public static readonly string[] HighIntensityColorList = ["\u001b[0;90m", "\u001b[0;91m", "\u001b[0;92m", "\u001b[0;93m", "\u001b[0;94m", "\u001b[0;95m", "\u001b[0;96m", "\u001b[0;97m"];
    public static readonly string[] HighIntensityBoldColorList = ["\u001b[1;90m", "\u001b[1;91m", "\u001b[1;92m", "\u001b[1;93m", "\u001b[1;94m", "\u001b[1;95m", "\u001b[1;96m", "\u001b[1;97m"];
    public static readonly string[] HighIntensityDarkenedColorList = ["\u001b[2;90m", "\u001b[2;91m", "\u001b[2;92m", "\u001b[2;93m", "\u001b[2;94m", "\u001b[2;95m", "\u001b[2;96m", "\u001b[2;97m"];
    public static readonly string[] HighIntensityItalicColorList = ["\u001b[9;90m", "\u001b[9;91m", "\u001b[9;92m", "\u001b[9;93m", "\u001b[9;94m", "\u001b[9;95m", "\u001b[9;96m", "\u001b[9;97m"];
    public static readonly string[] HighIntensityUnderlineColorList = ["\u001b[4;90m", "\u001b[4;91m", "\u001b[4;92m", "\u001b[4;93m", "\u001b[4;94m", "\u001b[4;95m", "\u001b[4;96m", "\u001b[4;97m"];
    public static readonly string[] HighIntensityFlashyColorList = ["\u001b[5;90m", "\u001b[5;91m", "\u001b[5;92m", "\u001b[5;93m", "\u001b[5;94m", "\u001b[5;95m", "\u001b[5;96m", "\u001b[5;97m"];
    public static readonly string[] HighIntensityHighlighterColorText = ["\u001b[7;90m", "\u001b[7;91m", "\u001b[7;92m", "\u001b[7;93m", "\u001b[7;94m", "\u001b[7;95m", "\u001b[7;96m", "\u001b[7;97m"];
    public static readonly string[] HighIntensityInvisibleColorText = ["\u001b[8;90m", "\u001b[8;91m", "\u001b[8;92m", "\u001b[8;93m", "\u001b[8;94m", "\u001b[8;95m", "\u001b[8;96m", "\u001b[8;97m"];
    public static readonly string[] HighIntensityStrikethroughColorText = ["\u001b[9;90m", "\u001b[9;91m", "\u001b[9;92m", "\u001b[9;93m", "\u001b[9;94m", "\u001b[9;95m", "\u001b[9;96m", "\u001b[9;97m"];
    public static readonly string ResetColor = "\u001b[0m";

    public static void Main()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), $"config.txt");

        // Check if config file exists, if not create and populate it
        if (!File.Exists(configPath))
        {
            using (StreamWriter sw = new StreamWriter(File.Create(configPath)))
            {
                sw.WriteLine("PropertyDescriptions = true");
                sw.WriteLine("PropertySyntaxShown = true");
                sw.WriteLine("ShowFieldTypeAsName = true");
                sw.WriteLine("JsonExtentsionType = .json");
                sw.WriteLine("ColorfulText = false");
                sw.WriteLine("SaveFilePath[JSON] = default");
                sw.WriteLine("SaveFilePath[Schema] = default");
                sw.WriteLine("SaveSchemaWithCustomNames = false");
                sw.WriteLine("DefaultCaseCorrection = true");
                sw.WriteLine("DescriptionsForSchemaProperties = false");
            }
        }

        Dictionary<string, string> configValues = new Dictionary<string, string>();
        foreach (var line in File.ReadLines(configPath))
        {
            if (line.Contains(" = "))
            {
                string[] parts = line.Split(new string[] { " = " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim().Trim(';');
                    configValues[key] = value;
                }
            }
        }

        // Config Values:

        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");

        // Display menu to the user
        if (colorfulText != false)
        {
            Console.Write(ResetColor + BoldColorList[3] + "What is your choice?\n" + ResetColor + HighIntensityUnderlineColorList[4] + "\n* Schema\n* JSON\n* Configure Application" + ResetColor + BoldColorList[3] + "\n\nYour choice Here: " + ResetColor);
            string choice = Console.ReadLine();

            if (choice == "Schema")
            {
                Schema();
            }
            else if (choice == "JSON")
            {
                JSON();
            }
            else if (choice == "Configure Application")
            {
                ConfigureApplication();
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(ResetColor + ItalicColorList[1] + BoldColorList[1] + "Not a Valid option." + ResetColor);
                    Main();
                }
            }
        } else
        {
            Console.Write("What is your choice?\n\n* Schema\n* JSON\n* Configure Application\n\nYour choice Here: ");
            string choice = Console.ReadLine();

            if (choice == "Schema")
            {
                Schema();
            }
            else if (choice == "JSON")
            {
                JSON();
            }
            else if (choice == "Configure Application")
            {
                ConfigureApplication();
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Not a Valid option.");
                    Main();
                }
            }
        }
    }

    public static void Schema()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), $"config.txt");

        Dictionary<string, string> configValues = new Dictionary<string, string>();
        foreach (var line in File.ReadLines(configPath))
        {
            if (line.Contains(" = "))
            {
                string[] parts = line.Split(new string[] { " = " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim().Trim(';');
                    configValues[key] = value;
                }
            }
        }

        // Config Values:

        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");
        char comma = ',';
        if (colorfulText != false)
        {
            Console.Clear();
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4]+"\n\n* Make Schema\n* Edit Schema\n* Save Schema" + ResetColor + BoldColorList[3] + "\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();

            // Schema Stuff
            if (choice2 == "Make Schema")
            {
                string[] Schema = ["{"];

            }
        } else
        {
            Console.Clear();
            Console.Write("What do you want to do?\n\n* Make Schema\n* Edit Schema\n* Save Schema\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();
            int Properties = 1;
            int CurrentProperties = 1;
            string type = "";

            // Schema Stuff
            if (choice2 == "Make Schema")
            {
                Console.Clear();
                List<string> Schema = new List<string> { "{" };
                Schema.Add("\"$schema\": \"https://json-schema.org/draft-04/schema#\"" + comma);
                Console.Write("What would you like to call your schema?: ");
                Schema.Add("\"title\": \"" + Console.ReadLine() + "\"" + comma);
                Console.Write("How would you describe the purpose of this schema?: ");
                Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                Schema.Add("\"type\": \"object\"" + comma);
                Schema.Add("\"properties\": {");
                Console.Write("How Many Properties would you like to have in the Schema? [Must be a Positive Integer]: ");
                Properties = int.Parse(Console.ReadLine());
                Properties = Properties + 1;
                while (Properties > CurrentProperties) {
                    Console.WriteLine("Properties: " + Properties);
                    if (CurrentProperties < 1)
                    {
                        Schema.Add(",");
                    }
                    Console.Write("What do you want to call Property #" + CurrentProperties + "?: ");
                    Schema.Add("\"" + Console.ReadLine() + "\": {");
                    Console.Write("What type should this property be? [Array, Boolean, Integer, Number, String, Object]: ");
                    type = Console.ReadLine();
                    if (type == "Array")
                    {
                        Schema.Add("\"type\": \"array\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                    } else if (type == "Boolean")
                    {
                        Schema.Add("\"type\": \"boolean\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                    } else if (type == "Integer")
                    {
                        Schema.Add("\"type\": \"integer\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                    }
                    else if (type == "Number")
                    {
                        Schema.Add("\"type\": \"number\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                    }
                    else if (type == "String")
                    {
                        Schema.Add("\"type\": \"string\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                        Console.Write("What is the minimum length allowed for this field? [Must be a Positive Integer]: ");
                        Schema.Add("\"minLength\": " + Console.ReadLine()  + comma);
                        Console.Write("What is the maximum length allowed for this field? [Must be a Positive Integer]: ");
                        Schema.Add("\"maxLength\": " + Console.ReadLine()  + comma);
                        Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                        if (Console.ReadLine() != "")
                        {
                            Schema.Add("\"default\": \"" + Console.ReadLine() + "\"" + comma);
                        }
                        Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: ");
                        if (Console.ReadLine().Contains('['))
                        {
                            Schema.Add("\"enum\": " + Console.ReadLine());
                        }
                    }
                    else if (type == "Object")
                    {
                        Schema.Add("\"type\": \"object\"" + comma);
                        Console.Write("How would you describe this property?: ");
                        Schema.Add("\"description\": \"" + Console.ReadLine() + "\"" + comma);
                    }
                    CurrentProperties++;
                    if (CurrentProperties < Properties && CurrentProperties > 1)
                    {
                        Schema.Add("}" + comma);
                    } else
                    {
                        Schema.Add("}");
                    }
                }
                Schema.Add("}");
                Schema.Add("}");
                Console.Clear();
                Console.WriteLine(string.Join("\n", Schema));
            }
        }
    }

    public static void JSON()
    {
        string schemaFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"schema.json");

        if (File.Exists(schemaFilePath))
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?\nMake JSON\nEdit JSON\nSave JSON");
            string choice3 = Console.ReadLine();
            // Add your JSON logic here
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Provide me A Json Schema or I can't do anything for You!");
            Console.WriteLine("To Provide me one, go to this app's directory and add a file called 'schema.json'. Make sure there is info inside the file.");
            Console.ReadLine();
            Main();
        }
    }

    public static void ConfigureApplication()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), $"config.txt");

        // Dictionary to store config key-value pairs
        Dictionary<string, string> configValues = new Dictionary<string, string>();

        // Read config file
        foreach (var line in File.ReadLines(configPath))
        {
            if (line.Contains(" = "))
            {
                string[] parts = line.Split(new string[] { " = " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim().Trim(';');
                    configValues[key] = value;
                }
            }
        }

        // Function to safely get a config value, with a default fallback
        string GetConfigValue(string key, string defaultValue)
        {
            return configValues.ContainsKey(key) ? configValues[key] : defaultValue;
        }

        // Parse config values with defaults if the key doesn't exist
        bool propertyDescriptions = bool.Parse(GetConfigValue("PropertyDescriptions", "true"));
        bool propertySyntaxShown = bool.Parse(GetConfigValue("PropertySyntaxShown", "true"));
        bool showFieldTypeAsName = bool.Parse(GetConfigValue("ShowFieldTypeAsName", "true"));
        string jsonExtensionType = GetConfigValue("JsonExtentsionType", ".json");
        bool colorfulText = bool.Parse(GetConfigValue("ColorfulText", "true"));
        string saveFilePathJson = GetConfigValue("SaveFilePath[JSON]", "default");
        string saveFilePathSchema = GetConfigValue("SaveFilePath[Schema]", "default");
        bool saveSchemaWithCustomNames = bool.Parse(GetConfigValue("SaveSchemaWithCustomNames", "false"));
        bool defaultCaseCorrection = bool.Parse(GetConfigValue("DefaultCaseCorrection", "true"));
        bool descriptionsForSchemaProperties = bool.Parse(GetConfigValue("DescriptionsForSchemaProperties", "false"));

        // Prompt user for input and update the config values
        configValues["PropertyDescriptions"] = PromptUser("Should Property Descriptions be shown?", propertyDescriptions);
        configValues["PropertySyntaxShown"] = PromptUser("Should Property Syntax be shown?", propertySyntaxShown);
        configValues["ShowFieldTypeAsName"] = PromptUser("Should Field Type be shown as names?", showFieldTypeAsName);
        configValues["JsonExtentsionType"] = PromptUser("What is the JSON extension type?", jsonExtensionType);
        configValues["ColorfulText"] = PromptUser("Should Text be colorful?", colorfulText);
        configValues["SaveFilePath[JSON]"] = PromptUser("What is the save file path for JSON?", saveFilePathJson);
        configValues["SaveFilePath[Schema]"] = PromptUser("What is the save file path for Schema?", saveFilePathSchema);
        configValues["SaveSchemaWithCustomNames"] = PromptUser("Should schemas be saved with custom names?", saveSchemaWithCustomNames);
        configValues["DefaultCaseCorrection"] = PromptUser("Should default case correction be applied?", defaultCaseCorrection);
        configValues["DescriptionsForSchemaProperties"] = PromptUser("Should Schema Properties have descriptions?", descriptionsForSchemaProperties);

        // Save the updated config values back to the config file
        using (StreamWriter sw = new StreamWriter(configPath))
        {
            foreach (var entry in configValues)
            {
                sw.WriteLine($"{entry.Key} = {entry.Value};");
            }
        }

        Console.WriteLine("Config has been updated successfully.");
        Console.Clear();
        Main();
    }

    // Helper methods remain the same as in your original code
    static string PromptUser(string promptMessage, bool currentValue)
    {
        Console.WriteLine($"{promptMessage} (Current value: {currentValue}) [y/n]:");
        string input = Console.ReadLine().Trim();

        if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            return "true";
            return "true";
        }
        else if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
        {
            return "false";
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
            return PromptUser(promptMessage, currentValue); // Recursively call until valid input
        }
    }

    static string PromptUser(string promptMessage, string currentValue)
    {
        Console.WriteLine($"{promptMessage} (Current value: {currentValue}) [enter a new value or press enter to keep current value]:");
        string input = Console.ReadLine().Trim();

        if (string.IsNullOrEmpty(input))
        {
            return currentValue; // Keep the current value if the user presses enter
        }
        return input;
    }
}