// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;

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
        Console.Clear();
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", $"config.txt");
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
            }
        }
        JSONGrabber();
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
        }
        else
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
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", $"config.txt");
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
        string comma = ",";
        if (colorfulText != false)
        {
            Console.Clear();
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4] + "\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema\n* Back" + ResetColor + BoldColorList[3] + "\n\nYour choice Here: " + ResetColor);
            string choice2 = Console.ReadLine();
            // Schema Stuff
            if (choice2 == "Make Schema")
            {
                MakeSchema();
            }
            else if (choice2 == "Save Schema")
            {
                Console.WriteLine("Make a Schema First!");
            }
            else if (choice2 == "Back")
            {
                Main();
            } else
            {
                Schema();
            }
        }
        else
        {
            Console.Clear();
            Console.Write("What do you want to do?\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema\n* Back\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();

            if (choice2 == "Make Schema")
            {
                MakeSchema();
            }
            else if (choice2 == "Save Schema")
            {
                Console.WriteLine("Make a Schema First!");
            }
            else if (choice2 == "Back")
            {
                Main();
            }
            else
            {
                Schema();
            }
        }
    }
    public static void ReturningSchema(List<string> FinalSchema)
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", $"config.txt");
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
        string comma = ",";
        if (colorfulText != false)
        {
            Console.Clear();
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4] + "\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema\n* Back" + ResetColor + BoldColorList[3] + "\n\nYour choice Here: " + ResetColor);
            string choice2 = Console.ReadLine();
            // Schema Stuff
            if (choice2 == "Make Schema")
            {
                MakeSchema();
            }
            else if (choice2 == "Save Schema")
            {
                SaveSchema(FinalSchema);
            }
            else if (choice2 == "Back")
            {
                Main();
            }
            else
            {
                Schema();
            }
        }
        else
        {
            Console.Clear();
            Console.Write("What do you want to do?\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema\n* Back\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();

            if (choice2 == "Make Schema")
            {
                MakeSchema();
            }
            else if (choice2 == "Save Schema")
            {
                SaveSchema(FinalSchema);
            } else if (choice2 == "Back")
            {
                Main();
            }
            else
            {
                Schema();
            }
        }
    }
    public static void MakeSchema()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", $"config.txt");
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
        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");
        string comma = ",";
        List<string> Schema = new List<string> { "{" };
        if (colorfulText != false)
        {
            int Properties = 1;
            List<string> PropertiesList = new List<string> { };
            int CurrentProperties = 1;
            string type = "";
            // Schema Stuff
            Console.Clear();
            Schema.Add("\"$schema\": \"https://json-schema.org/draft-04/schema#\"");
            Schema.Add(comma);
            Console.Write(ResetColor + BoldColorList[3] + "What would you like to call your schema?: " + ResetColor);
            Schema.Add("\"title\": \"" + Console.ReadLine() + "\"");
            Schema.Add(comma);
            Console.Write(ResetColor + BoldColorList[3] + "How would you describe the purpose of this schema?: " + ResetColor);
            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
            Schema.Add(comma);
            Schema.Add("\"type\": \"object\"");
            Schema.Add(comma);
            Schema.Add("\"properties\": {");
            Console.Write(ResetColor + BoldColorList[6] + "How Many Properties would you like to have in the Schema? [Must be a Positive Integer]: " + ResetColor);
            Properties = int.Parse(Console.ReadLine());
            Properties = Properties + 1;
            while (Properties > CurrentProperties)
            {
                Console.WriteLine(ResetColor + HighIntensityUnderlineColorList[4] + "Properties: " + (Properties - 1) + ResetColor);
                Console.Write(ResetColor + BoldColorList[3] + "What do you want to call Property #" + CurrentProperties + "?: " + ResetColor);
                string PropertyName = Console.ReadLine();
                PropertiesList.Add(PropertyName);
                Schema.Add("\"" + PropertyName + "\": {");
                Console.Write(ResetColor + BoldColorList[6] + "What type should this property be? [Array, Boolean, Integer, Number, String, Object]: " + ResetColor);
                type = Console.ReadLine();
                if (type == "Array")
                {
                    Schema.Add("\"type\": \"array\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    // Specify the type of items in the array
                    Console.Write(ResetColor + BoldColorList[6] + "What type should the array items be? [Boolean, Integer, Number, String, Object]: " + ResetColor);
                    string itemType = Console.ReadLine();
                    Schema.Add("\"items\": { \"type\": \"" + itemType + "\" }");
                    Schema.Add(comma);
                    // Optional fields
                    Console.Write(ResetColor + BoldColorList[3] + "What is the minimum number of items allowed? [Enter a positive integer or press enter to skip]: " + ResetColor);
                    string minItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(minItems))
                    {
                        Schema.Add("\"minItems\": " + minItems);
                        Schema.Add(comma);
                    }
                    Console.Write(ResetColor + BoldColorList[3] + "What is the maximum number of items allowed? [Enter a positive integer or press enter to skip]: " + ResetColor);
                    string maxItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(maxItems))
                    {
                        Schema.Add("\"maxItems\": " + maxItems);
                        Schema.Add(comma);
                    }
                    Console.Write(ResetColor + BoldColorList[3] + "Should the items in the array be unique? [true/false]: " + ResetColor);
                    string uniqueItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(uniqueItems))
                    {
                        Schema.Add("\"uniqueItems\": " + uniqueItems);
                        Schema.Add(comma);
                    }
                    // Default value for array
                    Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this array? [If there should be none hit enter, otherwise enter it as an array e.g. [1,2,3]]: " + ResetColor);
                    string defaultArray = Console.ReadLine();
                    if (defaultArray.Contains("["))
                    {
                        Schema.Add("\"default\": " + defaultArray);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Got It!");
                    }
                    if (Schema.Any())
                    {
                        Schema.RemoveAt(Schema.Count - 1); // Remove last comma
                    }
                }
                else if (type == "Boolean")
                {
                    Schema.Add("\"type\": \"boolean\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "Should this bool be exactly one value being true or false?: " + ResetColor);
                    Schema.Add("\"const\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[true, false]']: " + ResetColor);
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Integer")
                {
                    Schema.Add("\"type\": \"integer\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the minimum value allowed for this field?: " + ResetColor);
                    Schema.Add("\"minimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the maximum value allowed for this field? [Can not be below the minimum value]: " + ResetColor);
                    Schema.Add("\"maximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "Should the minimum value exclude itself? [Must be a true or a false]: " + ResetColor);
                    Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "Should the maximum value exclude itself? [Must be a true or a false]: " + ResetColor);
                    Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: " + ResetColor);
                    Schema.Add("\"multipleOf\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: " + ResetColor);
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Number")
                {
                    Schema.Add("\"type\": \"number\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the minimum value allowed for this field?: " + ResetColor);
                    Schema.Add("\"minimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the maximum value allowed for this field? [Can not be below the minimum value]: " + ResetColor);
                    Schema.Add("\"maximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "Should the minimum value exclude itself? [Must be a true or a false]: " + ResetColor);
                    Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "Should the maximum value exclude itself? [Must be a true or a false]: " + ResetColor);
                    Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: " + ResetColor);
                    Schema.Add("\"multipleOf\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0,5, -9.5]']: " + ResetColor);
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "String")
                {
                    Schema.Add("\"type\": \"string\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the minimum length allowed for this field? [Must be a Positive Integer]: " + ResetColor);
                    Schema.Add("\"minLength\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "What is the maximum length allowed for this field? [Must be a Positive Integer]: " + ResetColor);
                    Schema.Add("\"maxLength\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: " + ResetColor);
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Object")
                {
                    Schema.Add("\"type\": \"object\"");
                    Schema.Add(comma);
                    Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Schema.Add("\"properties\": {");
                    Console.Write(ResetColor + BoldColorList[6] + "How many nested properties would you like in this object? [Positive Integer]: " + ResetColor);
                    int nestedProperties = int.Parse(Console.ReadLine());
                    int currentNestedProperties = 1;
                    // Loop for handling nested properties
                    while (nestedProperties >= currentNestedProperties)
                    {
                        Console.Write("What do you want to call nested Property #" + currentNestedProperties + "?: ");
                        string nestedPropertyName = Console.ReadLine();
                        Console.Write("What type should nested Property " + nestedPropertyName + " be? [Array, Boolean, Integer, Number, String, Object]: ");
                        string nestedPropertyType = Console.ReadLine();
                        Schema.Add("\"" + nestedPropertyName + "\": {");
                        // Handle specific types similarly to the main properties loop
                        if (nestedPropertyType == "Array")
                        {
                            Schema.Add("\"type\": \"array\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            // Specify the type of items in the array
                            Console.Write(ResetColor + BoldColorList[6] + "What type should the array items be? [Boolean, Integer, Number, String, Object]: " + ResetColor);
                            string itemType = Console.ReadLine();
                            Schema.Add("\"items\": { \"type\": \"" + itemType + "\" }");
                            Schema.Add(comma);
                            // Optional fields
                            Console.Write(ResetColor + BoldColorList[3] + "What is the minimum number of items allowed? [Enter a positive integer or press enter to skip]: " + ResetColor);
                            string minItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(minItems))
                            {
                                Schema.Add("\"minItems\": " + minItems);
                                Schema.Add(comma);
                            }
                            Console.Write(ResetColor + BoldColorList[3] + "What is the maximum number of items allowed? [Enter a positive integer or press enter to skip]: " + ResetColor);
                            string maxItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(maxItems))
                            {
                                Schema.Add("\"maxItems\": " + maxItems);
                                Schema.Add(comma);
                            }
                            Console.Write(ResetColor + BoldColorList[3] + "Should the items in the array be unique? [true/false]: " + ResetColor);
                            string uniqueItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(uniqueItems))
                            {
                                Schema.Add("\"uniqueItems\": " + uniqueItems);
                                Schema.Add(comma);
                            }
                            // Default value for array
                            Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this array? [If there should be none hit enter, otherwise enter it as an array e.g. [1,2,3]]: " + ResetColor);
                            string defaultArray = Console.ReadLine();
                            if (defaultArray.Contains("["))
                            {
                                Schema.Add("\"default\": " + defaultArray);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Got It!");
                            }
                            if (Schema.Any())
                            {
                                Schema.RemoveAt(Schema.Count - 1); // Remove last comma
                            }
                        }
                        else if (nestedPropertyType == "Boolean")
                        {
                            Schema.Add("\"type\": \"boolean\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "Should this bool be exactly one value being true or false?: " + ResetColor);
                            Schema.Add("\"const\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[true, false]']: " + ResetColor);
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "Integer")
                        {
                            Schema.Add("\"type\": \"integer\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the minimum value allowed for this field?: " + ResetColor);
                            Schema.Add("\"minimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the maximum value allowed for this field? [Can not be below the minimum value]: " + ResetColor);
                            Schema.Add("\"maximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "Should the minimum value exclude itself? [Must be a true or a false]: " + ResetColor);
                            Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "Should the maximum value exclude itself? [Must be a true or a false]: " + ResetColor);
                            Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: " + ResetColor);
                            Schema.Add("\"multipleOf\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: " + ResetColor);
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "Number")
                        {
                            Schema.Add("\"type\": \"number\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the minimum value allowed for this field?: " + ResetColor);
                            Schema.Add("\"minimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the maximum value allowed for this field? [Can not be below the minimum value]: " + ResetColor);
                            Schema.Add("\"maximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "Should the minimum value exclude itself? [Must be a true or a false]: " + ResetColor);
                            Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "Should the maximum value exclude itself? [Must be a true or a false]: " + ResetColor);
                            Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: " + ResetColor);
                            Schema.Add("\"multipleOf\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0,5, -9.5]']: " + ResetColor);
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "String")
                        {
                            Schema.Add("\"type\": \"string\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "How would you describe this property?: " + ResetColor);
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the minimum length allowed for this field? [Must be a Positive Integer]: " + ResetColor);
                            Schema.Add("\"minLength\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[3] + "What is the maximum length allowed for this field? [Must be a Positive Integer]: " + ResetColor);
                            Schema.Add("\"maxLength\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write(ResetColor + BoldColorList[6] + "What is the default value for this property? [If there should be none hit enter]: " + ResetColor);
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write(ResetColor + BoldColorList[6] + "What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: " + ResetColor);
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        // Finalize current nested property and move to the next one
                        Schema.Add("}");
                        if (currentNestedProperties < nestedProperties)
                        {
                            Schema.Add(comma);
                        }
                        currentNestedProperties++;
                    }
                    Schema.Add("}");
                }
                CurrentProperties++;
                if (CurrentProperties < Properties && CurrentProperties > 1)
                {
                    Schema.Add("}");
                    Schema.Add(comma);
                }
                else
                {
                    Schema.Add("}");
                }
            }
            Schema.Add("}");
            Console.Clear();
            Console.WriteLine(string.Join("\n", PropertiesList.Select(property => ResetColor + BoldColorList[6] + property + ResetColor)));
            Console.Write(ResetColor + HighIntensityUnderlineColorList[4] + "Of the above properties which ones are required? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: " + ResetColor);
            string Required = Console.ReadLine();
            if (Required.Contains('['))
            {
                Schema.Add(comma);
                Schema.Add("\"required\": " + Required);
            }
            else
            {
                Console.WriteLine("None Understood");
            }
            Schema.Add("}");
            Console.Clear();
            Console.WriteLine(string.Join("\n", Schema));
            Console.Clear();
            Console.WriteLine(ResetColor + HighIntensityUnderlineColorList[4] + "Warning, selecting Make Schema will Overwrite your current Schema." + ResetColor);
        }
        else
        {
            int Properties = 1;
            List<string> PropertiesList = new List<string> { };
            int CurrentProperties = 1;
            string type = "";
            // Schema Stuff
            Console.Clear();
            Schema.Add("\"$schema\": \"https://json-schema.org/draft-04/schema#\"");
            Schema.Add(comma);
            Console.Write("What would you like to call your schema?: ");
            Schema.Add("\"title\": \"" + Console.ReadLine() + "\"");
            Schema.Add(comma);
            Console.Write("How would you describe the purpose of this schema?: ");
            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
            Schema.Add(comma);
            Schema.Add("\"type\": \"object\"");
            Schema.Add(comma);
            Schema.Add("\"properties\": {");
            Console.Write("How Many Properties would you like to have in the Schema? [Must be a Positive Integer]: ");
            Properties = int.Parse(Console.ReadLine());
            Properties = Properties + 1;
            while (Properties > CurrentProperties)
            {
                Console.WriteLine("Properties: " + Properties);
                Console.Write("What do you want to call Property #" + CurrentProperties + "?: ");
                string PropertyName = Console.ReadLine();
                PropertiesList.Add(PropertyName);
                Schema.Add("\"" + PropertyName + "\": {");
                Console.Write("What type should this property be? [Array, Boolean, Integer, Number, String, Object]: ");
                type = Console.ReadLine();
                if (type == "Array")
                {
                    Schema.Add("\"type\": \"array\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    // Specify the type of items in the array
                    Console.Write("What type should the array items be? [Boolean, Integer, Number, String, Object]: ");
                    string itemType = Console.ReadLine();
                    Schema.Add("\"items\": { \"type\": \"" + itemType + "\" }");
                    Schema.Add(comma);
                    // Optional fields
                    Console.Write("What is the minimum number of items allowed? [Enter a positive integer or press enter to skip]: ");
                    string minItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(minItems))
                    {
                        Schema.Add("\"minItems\": " + minItems);
                        Schema.Add(comma);
                    }
                    Console.Write("What is the maximum number of items allowed? [Enter a positive integer or press enter to skip]: ");
                    string maxItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(maxItems))
                    {
                        Schema.Add("\"maxItems\": " + maxItems);
                        Schema.Add(comma);
                    }
                    Console.Write("Should the items in the array be unique? [true/false]: ");
                    string uniqueItems = Console.ReadLine();
                    if (!string.IsNullOrEmpty(uniqueItems))
                    {
                        Schema.Add("\"uniqueItems\": " + uniqueItems);
                        Schema.Add(comma);
                    }
                    // Default value for array
                    Console.Write("What is the default value for this array? [If there should be none hit enter, otherwise enter it as an array e.g. [1,2,3]]: ");
                    string defaultArray = Console.ReadLine();
                    if (defaultArray.Contains("["))
                    {
                        Schema.Add("\"default\": " + defaultArray);
                    }
                    else
                    {
                        Console.WriteLine("None Got It!");
                    }
                    if (Schema.Any())
                    {
                        Schema.RemoveAt(Schema.Count - 1); // Remove last comma
                    }
                }
                else if (type == "Boolean")
                {
                    Schema.Add("\"type\": \"boolean\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write("Should this bool be exactly one value being true or false?: ");
                    Schema.Add("\"const\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: ");
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Integer")
                {
                    Schema.Add("\"type\": \"integer\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write("What is the minimum value allowed for this field?: ");
                    Schema.Add("\"minimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the maximum value allowed for this field? [Can not be below the minimum value]: ");
                    Schema.Add("\"maximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("Should the minimum value exclude itself? [Must be a true or a false]: ");
                    Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("Should the maximum value exclude itself? [Must be a true or a false]: ");
                    Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: ");
                    Schema.Add("\"multipleOf\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: ");
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Number")
                {
                    Schema.Add("\"type\": \"number\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write("What is the minimum value allowed for this field?: ");
                    Schema.Add("\"minimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the maximum value allowed for this field? [Can not be below the minimum value]: ");
                    Schema.Add("\"maximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("Should the minimum value exclude itself? [Must be a true or a false]: ");
                    Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("Should the maximum value exclude itself? [Must be a true or a false]: ");
                    Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: ");
                    Schema.Add("\"multipleOf\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0,5, -9.5]']: ");
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "String")
                {
                    Schema.Add("\"type\": \"string\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Console.Write("What is the minimum length allowed for this field? [Must be a Positive Integer]: ");
                    Schema.Add("\"minLength\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the maximum length allowed for this field? [Must be a Positive Integer]: ");
                    Schema.Add("\"maxLength\": " + Console.ReadLine());
                    Schema.Add(comma);
                    Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                    string Default = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Default))
                    {
                        Schema.Add("\"default\": \"" + Default + "\"");
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("Empty Understood");
                    }
                    Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: ");
                    string Enums = Console.ReadLine();
                    if (Enums.Contains('['))
                    {
                        Schema.Add("\"enum\": " + Enums);
                        Schema.Add(comma);
                    }
                    else
                    {
                        Console.WriteLine("None Understood");
                    }
                    if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        Schema.RemoveAt(Schema.Count - 1);
                    }
                }
                else if (type == "Object")
                {
                    Schema.Add("\"type\": \"object\"");
                    Schema.Add(comma);
                    Console.Write("How would you describe this property?: ");
                    Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                    Schema.Add(comma);
                    Schema.Add("\"properties\": {");
                    Console.Write("How many nested properties would you like in this object? [Positive Integer]: ");
                    int nestedProperties = int.Parse(Console.ReadLine());
                    int currentNestedProperties = 1;
                    // Loop for handling nested properties
                    while (nestedProperties >= currentNestedProperties)
                    {
                        Console.Write("What do you want to call nested Property #" + currentNestedProperties + "?: ");
                        string nestedPropertyName = Console.ReadLine();
                        Console.Write("What type should nested Property " + nestedPropertyName + " be? [Array, Boolean, Integer, Number, String, Object]: ");
                        string nestedPropertyType = Console.ReadLine();
                        Schema.Add("\"" + nestedPropertyName + "\": {");
                        // Handle specific types similarly to the main properties loop
                        if (nestedPropertyType == "Array")
                        {
                            Schema.Add("\"type\": \"array\"");
                            Schema.Add(comma);
                            Console.Write("How would you describe this property?: ");
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            // Specify the type of items in the array
                            Console.Write("What type should the array items be? [Boolean, Integer, Number, String, Object]: ");
                            string itemType = Console.ReadLine();
                            Schema.Add("\"items\": { \"type\": \"" + itemType + "\" }");
                            Schema.Add(comma);
                            // Optional fields
                            Console.Write("What is the minimum number of items allowed? [Enter a positive integer or press enter to skip]: ");
                            string minItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(minItems))
                            {
                                Schema.Add("\"minItems\": " + minItems);
                                Schema.Add(comma);
                            }
                            Console.Write("What is the maximum number of items allowed? [Enter a positive integer or press enter to skip]: ");
                            string maxItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(maxItems))
                            {
                                Schema.Add("\"maxItems\": " + maxItems);
                                Schema.Add(comma);
                            }
                            Console.Write("Should the items in the array be unique? [true/false]: ");
                            string uniqueItems = Console.ReadLine();
                            if (!string.IsNullOrEmpty(uniqueItems))
                            {
                                Schema.Add("\"uniqueItems\": " + uniqueItems);
                                Schema.Add(comma);
                            }
                            // Default value for array
                            Console.Write("What is the default value for this array? [If there should be none hit enter, otherwise enter it as an array e.g. [1,2,3]]: ");
                            string defaultArray = Console.ReadLine();
                            if (defaultArray.Contains("["))
                            {
                                Schema.Add("\"default\": " + defaultArray);
                            }
                            else
                            {
                                Console.WriteLine("None Got It!");
                            }
                            if (Schema.Any())
                            {
                                Schema.RemoveAt(Schema.Count - 1); // Remove last comma
                            }
                        }
                        else if (nestedPropertyType == "Boolean")
                        {
                            Schema.Add("\"type\": \"boolean\"");
                            Schema.Add(comma);
                            Console.Write("How would you describe this property?: ");
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write("Should this bool be exactly one value being true or false?: ");
                            Schema.Add("\"const\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: ");
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "Integer")
                        {
                            Schema.Add("\"type\": \"integer\"");
                            Schema.Add(comma);
                            Console.Write("How would you describe this property?: ");
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write("What is the minimum value allowed for this field?: ");
                            Schema.Add("\"minimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the maximum value allowed for this field? [Can not be below the minimum value]: ");
                            Schema.Add("\"maximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("Should the minimum value exclude itself? [Must be a true or a false]: ");
                            Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("Should the maximum value exclude itself? [Must be a true or a false]: ");
                            Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: ");
                            Schema.Add("\"multipleOf\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0, -9]']: ");
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "Number")
                        {
                            Schema.Add("\"type\": \"number\"");
                            Schema.Add(comma);
                            Console.Write("How would you describe this property?: ");
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write("What is the minimum value allowed for this field?: ");
                            Schema.Add("\"minimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the maximum value allowed for this field? [Can not be below the minimum value]: ");
                            Schema.Add("\"maximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("Should the minimum value exclude itself? [Must be a true or a false]: ");
                            Schema.Add("\"exclusiveMinimum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("Should the maximum value exclude itself? [Must be a true or a false]: ");
                            Schema.Add("\"exclusiveMaximum\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What should this field be a multiple of? [If you want this to be set like a normal number set it to 1]: ");
                            Schema.Add("\"multipleOf\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[2, -6, 0,5, -9.5]']: ");
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        else if (nestedPropertyType == "String")
                        {
                            Schema.Add("\"type\": \"string\"");
                            Schema.Add(comma);
                            Console.Write("How would you describe this property?: ");
                            Schema.Add("\"description\": \"" + Console.ReadLine() + "\"");
                            Schema.Add(comma);
                            Console.Write("What is the minimum length allowed for this field? [Must be a Positive Integer]: ");
                            Schema.Add("\"minLength\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the maximum length allowed for this field? [Must be a Positive Integer]: ");
                            Schema.Add("\"maxLength\": " + Console.ReadLine());
                            Schema.Add(comma);
                            Console.Write("What is the default value for this property? [If there should be none hit enter]: ");
                            string Default = Console.ReadLine();
                            if (!string.IsNullOrEmpty(Default))
                            {
                                Schema.Add("\"default\": \"" + Default + "\"");
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("Empty Understood");
                            }
                            Console.Write("What enums should be shown for this property? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: ");
                            string Enums = Console.ReadLine();
                            if (Enums.Contains('['))
                            {
                                Schema.Add("\"enum\": " + Enums);
                                Schema.Add(comma);
                            }
                            else
                            {
                                Console.WriteLine("None Understood");
                            }
                            if (Schema.Any()) //prevent IndexOutOfRangeException for empty list
                            {
                                Schema.RemoveAt(Schema.Count - 1);
                            }
                        }
                        // Finalize current nested property and move to the next one
                        Schema.Add("}");
                        if (currentNestedProperties < nestedProperties)
                        {
                            Schema.Add(comma);
                        }
                        currentNestedProperties++;
                    }
                    Schema.Add("}");
                }
                CurrentProperties++;
                if (CurrentProperties < Properties && CurrentProperties > 1)
                {
                    Schema.Add("}");
                    Schema.Add(comma);
                }
                else
                {
                    Schema.Add("}");
                }
            }
            Schema.Add("}");
            Console.Clear();
            Console.WriteLine(string.Join("\n", PropertiesList));
            Console.Write("Of the above properties which ones are required? [If there should be none just press enter, if there are enter it in a format adjacent to '[\"Rhino\", \"Hippo\", \"Zebra\"]']: ");
            string Required = Console.ReadLine();
            if (Required.Contains('['))
            {
                Schema.Add(comma);
                Schema.Add("\"required\": " + Required);
            }
            else
            {
                Console.WriteLine("None Understood");
            }
            Schema.Add("}");
            Console.Clear();
            Console.WriteLine(string.Join("\n", Schema));
            Console.Clear();
            Console.WriteLine("Warning, selecting Make Schema will Overwrite your current Schema.");

        }
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
        ReturningSchema(Schema);
    }

    public static void SaveSchema(List<string> schema)
    {
        // Load configuration values from config.txt
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), "files", "config.txt");
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

        // Get the schema path and custom name setting from config
        string schemaDirectory = configValues.ContainsKey("SaveFilePath[Schema]")
            ? Path.Combine(Directory.GetCurrentDirectory(), configValues["SaveFilePath[Schema]"])
            : Path.Combine(Directory.GetCurrentDirectory(), "files", "schemas");

        bool useCustomNames = bool.TryParse(configValues.GetValueOrDefault("SaveSchemaWithCustomNames", "false"), out bool custom) && custom;

        // Ensure the directory exists
        Directory.CreateDirectory(schemaDirectory);

        // Determine file path based on custom name setting
        string filePath;
        if (useCustomNames)
        {
            Console.WriteLine("Enter a custom schema file name (without extension): ");
            string customName = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(customName) && customName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                filePath = Path.Combine(schemaDirectory, customName + ".json");
            }
            else
            {
                Console.WriteLine("Invalid file name. Using default name 'default_schema.json'.");
                filePath = Path.Combine(schemaDirectory, "default_schema.json");
            }
        }
        else
        {
            filePath = Path.Combine(schemaDirectory, "default_schema.json");
        }

        // Process schema to shift commas to the previous line
        List<string> processedSchema = new List<string>();
        for (int i = 0; i < schema.Count; i++)
        {
            string line = schema[i].TrimEnd();
            if (line.StartsWith(",") && i > 0)
            {
                // Append the comma to the previous line
                processedSchema[processedSchema.Count - 1] += line;
            }
            else
            {
                // Add the line as is
                processedSchema.Add(line);
            }
        }

        try
        {
            // Save processed schema to the determined file path
            File.WriteAllLines(filePath, processedSchema);
            Console.WriteLine($"Schema saved to file: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving schema to file: " + ex.Message);
        }

        int milliseconds = 2000;
        Thread.Sleep(milliseconds);

        Schema();
    }

    public static void JSONGrabber()
    {
        // Read configuration values
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", "config.txt");
        Dictionary<string, string> configValues = new Dictionary<string, string>();

        try
        {
            foreach (var line in File.ReadLines(configPath))
            {
                if (line.Contains("="))
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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the config file: {ex.Message}");
            return;
        }

        // Retrieve paths from config
        string jsonsDir = configValues.ContainsKey("SaveFilePath[JSON]")
            ? Path.Combine(Directory.GetCurrentDirectory(), configValues["SaveFilePath[JSON]"])
            : Path.Combine(Directory.GetCurrentDirectory() + "/files", "jsons");

        string schemasDir = configValues.ContainsKey("SaveFilePath[Schema]")
            ? Path.Combine(Directory.GetCurrentDirectory(), configValues["SaveFilePath[Schema]"])
            : Path.Combine(Directory.GetCurrentDirectory() + "/files", "schemas");

        List<string> JsonFiles = new List<string>();
        List<string> Schemas = new List<string>();

        if (Directory.Exists(jsonsDir))
        {
            JsonFiles.AddRange(Directory.GetFiles(jsonsDir, "*.json").Select(Path.GetFileName));
        }
        else
        {
            Console.WriteLine($"The JSON directory does not exist: {jsonsDir}");
        }

        if (Directory.Exists(schemasDir))
        {
            Schemas.AddRange(Directory.GetDirectories(schemasDir).Select(dir => new DirectoryInfo(dir).Name));
        }
        else
        {
            Console.WriteLine($"The Schemas directory does not exist: {schemasDir}");
        }

        // Path for saving the output file
        string tempListSaveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "files", "templistsave.txt");

        try
        {
            using (StreamWriter writer = new StreamWriter(tempListSaveFilePath, false))
            {
                writer.WriteLine("JSON Files:");
                JsonFiles.ForEach(writer.WriteLine);

                writer.WriteLine("\nSchema Directories:");
                Schemas.ForEach(writer.WriteLine);
            }

            Console.WriteLine($"Lists saved to file: {tempListSaveFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving lists to file: {ex.Message}");
        }
    }

    private static string generatedJson = string.Empty; // Store the generated JSON here
    private static bool jsonGenerated = new bool();
    public static void JSON()
    {
        // Read config settings
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", "config.txt");
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

        // Read necessary config values
        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");
        string saveFilePath = configValues.ContainsKey("SaveFilePath") ? configValues["SaveFilePath"] : "jsons";
        bool saveWithCustomNames = bool.Parse(configValues.ContainsKey("SaveSchemaWithCustomNames") ? configValues["SaveSchemaWithCustomNames"] : "true");
        bool defaultCaseCorrection = bool.Parse(configValues.ContainsKey("DefaultCaseCorrection") ? configValues["DefaultCaseCorrection"] : "true");

        // Show the menu
        Console.Clear();
        if (colorfulText)
        {
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4] +
                "\n\n* Make JSON\n* Edit JSON [FUTURE]\n* Save JSON\n* Back" + ResetColor + BoldColorList[3] +
                "\n\nYour choice Here: " + ResetColor);
        }
        else
        {
            Console.Write("What do you want to do?\n\n* Make JSON\n* Edit JSON [FUTURE]\n* Save JSON\n* Back\n\nYour choice Here: ");
        }

        string choice2 = Console.ReadLine();
        Console.WriteLine("You selected: " + choice2); // Debugging line to see if input is read correctly

        if (choice2 == "Make JSON")
        {
            generatedJson = MakeJSON(configValues); // Generate JSON
            if (!string.IsNullOrEmpty(generatedJson))
            {
                jsonGenerated = true; // Set flag to true
                JSON();
            }
        }
        else if (choice2 == "Save JSON")
        {
            if (!jsonGenerated)
            {
                Console.WriteLine("First, generate the JSON by selecting 'Make JSON'.");
            }
            else
            {
                Console.WriteLine("Generated JSON: " + generatedJson);
                SaveJSON(generatedJson, saveFilePath, saveWithCustomNames, defaultCaseCorrection); // Save the JSON
                JSON();
            }
        } 
        else if (choice2 == "Back")
        {
            Main();
        }
        else
        {
            JSON(); // Retry if the user provides invalid input
        }
    }

    public static void SaveJSON(string jsonContent, string saveFilePath, bool saveWithCustomNames, bool defaultCaseCorrection)
    {
        // Read configuration values
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), "files", "config.txt");
        Dictionary<string, string> configValues = new Dictionary<string, string>();

        try
        {
            foreach (var line in File.ReadLines(configPath))
            {
                if (line.Contains("="))
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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the config file: {ex.Message}");
            return;
        }

        // Retrieve JSON save directory from config
        saveFilePath = configValues.ContainsKey("SaveFilePath[JSON]")
            ? Path.Combine(Directory.GetCurrentDirectory(), configValues["SaveFilePath[JSON]"])
            : Path.Combine(Directory.GetCurrentDirectory(), "files", "jsons");

        // Ensure the directory exists
        string fullSavePath = Path.Combine(Directory.GetCurrentDirectory(), saveFilePath);
        if (!Directory.Exists(fullSavePath))
        {
            Directory.CreateDirectory(fullSavePath);
        }

        string fileName = "output.json"; // Default file name

        // If saveWithCustomNames is true, ask for the custom file name
        if (saveWithCustomNames)
        {
            Console.WriteLine("Enter the custom name for the JSON file (without extension): ");
            string customFileName = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(customFileName) && customFileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                fileName = customFileName + ".json"; // Valid custom name
            }
            else
            {
                Console.WriteLine("Invalid file name. Using default file name.");
            }
        }

        // Apply case correction if enabled
        if (defaultCaseCorrection == true)
        {
            jsonContent = ApplyCaseCorrection(jsonContent);
        }

        string filePath = Path.Combine(fullSavePath, fileName);

        try
        {
            File.WriteAllText(filePath, jsonContent);
            Console.WriteLine($"\nJSON successfully saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the JSON file: {ex.Message}");
        }

        int milliseconds = 2000;
        Thread.Sleep(milliseconds);

        JSON(); // After saving, return to the JSON menu
    }


    public static string MakeJSON(Dictionary<string, string> configValues)
    {
        // Read the "ColorfulText" option from configValues
        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");

        // Other options from configValues
        bool showDescriptions = bool.Parse(configValues.ContainsKey("ShowDescriptions") ? configValues["ShowDescriptions"] : "true");
        bool showSyntax = bool.Parse(configValues.ContainsKey("ShowSyntax") ? configValues["ShowSyntax"] : "true");
        bool showFieldType = bool.Parse(configValues.ContainsKey("ShowFieldType") ? configValues["ShowFieldType"] : "true");
        List<string> files = new List<string> { };

        List<string> SCHEMAS = new List<string>();
        string SchemaDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "files/schemas"));

        foreach (string file in Directory.GetFiles(SchemaDir))
        {
            string filename = new DirectoryInfo(file).Name;
            SCHEMAS.Add(filename);
            Console.WriteLine(filename);
        }
        Console.Write("From the above schemas choose the one you want to make the JSON with.");
        string ReadFile = Console.ReadLine();

        string schemaPath = Path.Combine(Directory.GetCurrentDirectory(), "files/schemas", ReadFile);

        // Ensure schema file exists
        if (!File.Exists(schemaPath))
        {
            Console.WriteLine($"Schema file not found: {schemaPath}");
            return null;
        }

        try
        {
            // Read and parse the schema file
            string schemaContent = File.ReadAllText(schemaPath);
            var schema = JsonConvert.DeserializeObject<Dictionary<string, object>>(schemaContent);

            if (schema == null || !schema.ContainsKey("properties"))
            {
                Console.WriteLine("Invalid schema format. Ensure it has a 'properties' section.");
                return null;
            }

            // Process schema properties with validation
            var properties = schema["properties"] as Newtonsoft.Json.Linq.JObject;
            if (properties == null)
            {
                Console.WriteLine("Schema 'properties' section is not valid.");
                return null;
            }

            // Generate JSON data with validation enabled
            var jsonData = ProcessSchema(properties);

            // Serialize to JSON (formatting with indents)
            string jsonOutput = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            int milliseconds = 2000;
            Thread.Sleep(milliseconds);

            // Return the generated JSON as a string instead of printing it
            return jsonOutput;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing the schema: {ex.Message}");
            return null;
        }
    }

    private static object GetFieldValue(Newtonsoft.Json.Linq.JObject attributes, string fieldName, string type, int level = 0)
    {
        string input;
        object value = null;

        // Create indentation based on the nesting level
        string indent = new string(' ', level * 2);

        // Display the main field information with indentation
        Console.WriteLine($"{indent}{fieldName} ({type})");

        // Display Validation Syntax for all types
        Console.WriteLine($"{indent}Validation Syntax:");
        AddValidationSyntax(attributes, level);

        // Display the description for the field
        string description = attributes.GetValue("description")?.ToString() ?? $"{fieldName} Description";
        Console.WriteLine($"{indent}{description}:");

        // Process based on the type of the field
        switch (type.ToLower())
        {
            case "integer":
            case "number":
                // Loop until a valid input is provided
                while (true)
                {
                    string valueType = type.ToLower();
                    Console.Write($"{indent}Enter a {valueType} value for {fieldName} (or press Enter to use the default): ");
                    input = Console.ReadLine();

                    // Handle default value
                    if (string.IsNullOrWhiteSpace(input) && attributes.ContainsKey("default"))
                    {
                        value = attributes["default"];
                        Console.WriteLine($"{indent}Using default value: {value}");
                        break;
                    }

                    // Try parsing the input as either an integer or a number
                    if (double.TryParse(input, out double parsedValue))
                    {
                        // Ensure integers are whole numbers if the type is "integer"
                        if (type.ToLower() == "integer" && parsedValue % 1 != 0)
                        {
                            Console.WriteLine($"{indent}Value must be a whole number. Try again.");
                            continue;
                        }

                        if (ValidateNumber(attributes, parsedValue, indent))
                        {
                            value = type.ToLower() == "integer" ? (int)parsedValue : parsedValue;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{indent}Invalid {valueType}. Please enter a valid {valueType}.");
                    }
                }
                break;

            case "string":
                while (true)
                {
                    string valueType = type.ToLower();
                    Console.Write($"{indent}Enter a {valueType} value for {fieldName} (or press Enter to use the default): ");
                    input = Console.ReadLine()?.Trim(); // Ensure input is trimmed and not null

                    // Check for default value if input is empty
                    if (string.IsNullOrWhiteSpace(input) && attributes.ContainsKey("default"))
                    {
                        value = attributes["default"];
                        Console.WriteLine($"{indent}Using default value: {value}");
                        break;
                    }

                    // Validate length constraints
                    if (attributes.ContainsKey("maxLength") && input.Length > (int)attributes["maxLength"])
                    {
                        Console.WriteLine($"{indent}Value must be less than or equal to {(int)attributes["maxLength"]} characters. Try again.");
                        continue;
                    }

                    if (attributes.ContainsKey("minLength") && input.Length < (int)attributes["minLength"])
                    {
                        Console.WriteLine($"{indent}Value must be greater than or equal to {(int)attributes["minLength"]} characters. Try again.");
                        continue;
                    }

                    // If valid, assign the input to value and exit the loop
                    value = input;
                    break;
                }
                break;

            case "boolean":
                while (true)
                {
                    string valueType = type.ToLower();
                    Console.Write($"{indent}Enter a {valueType} value for {fieldName} (true/false, or press Enter to use the default): ");
                    input = Console.ReadLine(); // Ensure input is trimmed and not null

                    // Check for default value if input is empty
                    if (string.IsNullOrWhiteSpace(input) && attributes.ContainsKey("default"))
                    {
                        value = attributes["default"];
                        Console.WriteLine($"{indent}Using default value: {value}");
                        break;
                    }

                    // Validate the input as a boolean
                    if (bool.TryParse(input, out bool boolResult))
                    {
                        value = boolResult; // Assign the parsed value
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{indent}Invalid input. Please enter 'true' or 'false'.");
                    }
                }
                break;

            case "array":
                while (true)
                {
                    Console.Write($"{indent}Enter the array value for {fieldName} in JSON format (or press Enter to use the default): ");
                    input = Console.ReadLine()?.Trim(); // Ensure input is trimmed and not null

                    // Check for default value if input is empty
                    if (string.IsNullOrWhiteSpace(input) && attributes.ContainsKey("default"))
                    {
                        value = attributes["default"];
                        Console.WriteLine($"{indent}Using default value: {value}");
                        break;
                    }

                    // Validate the array input
                    try
                    {
                        // Parse input as JSON array
                        var array = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(input);

                        // Validate constraints if defined
                        if (attributes.ContainsKey("minItems") && array.Count < (int)attributes["minItems"])
                        {
                            Console.WriteLine($"{indent}Array must contain at least {(int)attributes["minItems"]} items. Try again.");
                            continue;
                        }

                        if (attributes.ContainsKey("maxItems") && array.Count > (int)attributes["maxItems"])
                        {
                            Console.WriteLine($"{indent}Array must contain no more than {(int)attributes["maxItems"]} items. Try again.");
                            continue;
                        }

                        if (attributes.ContainsKey("uniqueItems") && (bool)attributes["uniqueItems"] && array.Count != array.Distinct().Count())
                        {
                            Console.WriteLine($"{indent}Array items must be unique. Try again.");
                            continue;
                        }

                        value = array; // Assign validated array
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{indent}Invalid array input. Ensure it's in correct JSON format. Error: {ex.Message}");
                    }
                }
                break;

            case "enum":
                value = ProcessEnum(attributes, fieldName, level);
                break;

            case "object":
                value = ProcessObject(attributes, fieldName, level);
                break;
        }

        return value;
    }

    private static bool ValidateNumber(Newtonsoft.Json.Linq.JObject attributes, double value, string indent)
    {
        // Minimum and exclusiveMinimum checks
        if (attributes.ContainsKey("minimum") && value < (double)attributes["minimum"])
        {
            Console.WriteLine($"{indent}Value must be greater than or equal to {(double)attributes["minimum"]}. Try again.");
            return false;
        }
        if (attributes.ContainsKey("exclusiveMinimum") && (bool)attributes["exclusiveMinimum"] && value <= (double)attributes["minimum"])
        {
            Console.WriteLine($"{indent}Value must be greater than {(double)attributes["minimum"]}. Try again.");
            return false;
        }

        // Maximum and exclusiveMaximum checks
        if (attributes.ContainsKey("maximum") && value > (double)attributes["maximum"])
        {
            Console.WriteLine($"{indent}Value cannot be greater than {(double)attributes["maximum"]}. Try again.");
            return false;
        }
        if (attributes.ContainsKey("exclusiveMaximum") && (bool)attributes["exclusiveMaximum"] && value >= (double)attributes["maximum"])
        {
            Console.WriteLine($"{indent}Value must be less than {(double)attributes["maximum"]}. Try again.");
            return false;
        }

        // Enum validation
        if (attributes.ContainsKey("enum"))
        {
            var validValues = attributes["enum"].Select(v => (double)v).ToArray();
            if (!validValues.Contains(value))
            {
                Console.WriteLine($"{indent}Value must be one of the following: {string.Join(", ", validValues)}. Try again.");
                return false;
            }
        }

        // MultipleOf validation
        if (attributes.ContainsKey("multipleOf") && value % (double)attributes["multipleOf"] != 0)
        {
            Console.WriteLine($"{indent}Value must be a multiple of {(double)attributes["multipleOf"]}. Try again.");
            return false;
        }

        return true; // Value is valid
    }

    private static void AddValidationSyntax(Newtonsoft.Json.Linq.JObject attributes, int level)
    {
        var validationAttributes = new[] { "minimum", "maximum", "exclusiveMinimum", "exclusiveMaximum", "multipleOf", "enum", "minLength", "maxLength", "minItems", "maxItems", "uniqueItems" };
        string indent = new string(' ', level * 2);

        // Check and print validation attributes for any field
        foreach (var attr in validationAttributes)
        {
            if (attributes.ContainsKey(attr))
            {
                Console.WriteLine($"{indent}  - {attr}: {attributes[attr]}");
            }
        }

        // If the type is array, check for items
        if (attributes.ContainsKey("type") && attributes["type"].ToString().ToLower() == "array" && attributes.ContainsKey("items"))
        {
            Console.WriteLine($"{indent}  - items: {attributes["items"]}");
        }
    }

    private static object ProcessEnum(Newtonsoft.Json.Linq.JObject attributes, string fieldName, int level)
    {
        var enumValues = attributes.GetValue("enum") as Newtonsoft.Json.Linq.JArray;
        if (enumValues == null || enumValues.Count == 0)
        {
            Console.WriteLine($"{new string(' ', level * 2)}No enum values defined. Defaulting to string.");
            return null;
        }

        string indent = new string(' ', level * 2);
        Console.WriteLine($"{indent}Available values for {fieldName}:");
        for (int i = 0; i < enumValues.Count; i++)
        {
            Console.WriteLine($"{indent}  {i + 1}. {enumValues[i]}");
        }

        int choice;
        while (true)
        {
            Console.Write($"{indent}{fieldName} (choose a number): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= enumValues.Count)
            {
                return enumValues[choice - 1];
            }
            Console.WriteLine($"{indent}Invalid choice. Please select a valid number.");
        }
    }

    private static object ProcessObject(Newtonsoft.Json.Linq.JObject attributes, string fieldName, int level)
    {
        string indent = new string(' ', level * 2);
        Console.WriteLine($"{indent}Processing nested object for {fieldName}...");
        var nestedProperties = attributes.GetValue("properties") as Newtonsoft.Json.Linq.JObject;
        if (nestedProperties != null)
        {
            return ProcessSchema(nestedProperties, level + 1);
        }

        return null;
    }

    private static object ProcessSchema(Newtonsoft.Json.Linq.JObject properties, int level = 0)
    {
        var result = new Dictionary<string, object>();

        foreach (var property in properties.Properties())
        {
            var attributes = property.Value as Newtonsoft.Json.Linq.JObject;
            if (attributes == null) continue;

            string type = attributes.GetValue("type")?.ToString() ?? "string";
            string fieldName = property.Name;

            // Validate and collect value
            var value = GetFieldValue(attributes, fieldName, type, level);
            result[property.Name] = value;
        }

        return result;
    }

    public static string ApplyCaseCorrection(string jsonContent)
    {
        // Implement case correction logic here (for example, convert to camelCase)
        var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
        var correctedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

        return correctedJson; // This should be the JSON with corrected key casing (e.g., camelCase)
    }

public static void ConfigureApplication()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory() + "/files", $"config.txt");
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
        string saveFilePathJson = GetConfigValue("SaveFilePath[JSON]", "files/jsons");
        string saveFilePathSchema = GetConfigValue("SaveFilePath[Schema]", "files/schemas");
        bool saveSchemaWithCustomNames = bool.Parse(GetConfigValue("SaveSchemaWithCustomNames", "false"));
        bool defaultCaseCorrection = bool.Parse(GetConfigValue("DefaultCaseCorrection", "true"));
        bool saveJSONSWithCustomNames = bool.Parse(GetConfigValue("SaveJSONSWithCustomNames", "false"));
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
        configValues["SaveJSONSWithCustomNames"] = PromptUser("Should JSONS be saved with custom names?", saveJSONSWithCustomNames);
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
