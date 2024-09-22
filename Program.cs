// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
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
                sw.WriteLine("ColorfulText = true");
                sw.WriteLine("SaveFilePath[JSON] = default");
                sw.WriteLine("SaveFilePath[Schema] = default");
                sw.WriteLine("SaveSchemaWithCustomNames = false");
                sw.WriteLine("DefaultCaseCorrection = true");
                sw.WriteLine("DescriptionsForSchemaProperties = false");
            }
        }

        // Display menu to the user
        Console.Write("What is your choice?\nSchema\nJSON\nConfigure Application\n\nYour Choice Here: ");
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

    public static void Schema()
    {
        Console.Clear();
        Console.WriteLine("What do you want to do?\nMake Schema\nEdit Schema\nSave Schema");
        string choice2 = Console.ReadLine();
        // Add your Schema logic here
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
    }


    // Helper method for prompting the user and updating the config value (for booleans)
    static string PromptUser(string promptMessage, bool currentValue)
    {
        Console.WriteLine($"{promptMessage} (Current value: {currentValue}) [y/n]:");
        string input = Console.ReadLine().Trim();

        if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
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

    // Helper method for prompting the user and updating the config value (for strings)
    static string PromptUser(string promptMessage, string currentValue)
    {
        Console.WriteLine($"{promptMessage} (Current value: {currentValue}) [enter a new value or press Enter to keep current]:");
        string input = Console.ReadLine().Trim();

        return string.IsNullOrEmpty(input) ? currentValue : input;
    }
}
