// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        string comma = ",";
        if (colorfulText != false)
        {
            Console.Clear();
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4] + "\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema" + ResetColor + BoldColorList[3] + "\n\nYour choice Here: " + ResetColor);
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
        }
        else
        {
            Console.Clear();
            Console.Write("What do you want to do?\n\n* Make Schema\n* Edit Schema [FUTURE]\n* Save Schema\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();

            if (choice2 == "Make Schema")
            {
                MakeSchema();
            }
            else if (choice2 == "Save Schema")
            {
                Console.WriteLine("Make a Schema First!");
            }
        }
    }
    public static void ReturningSchema(List<string> FinalSchema)
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
        }
    }
    public static void MakeSchema()
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
        ReturningSchema(Schema);
    }

    public static void SaveSchema(List<string> schema)
    {
        // Load configuration values from config.txt
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
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
        string schemaDirectory = configValues.GetValueOrDefault("SaveFilePath[Schema]", Directory.GetCurrentDirectory());
        bool useCustomNames = bool.TryParse(configValues.GetValueOrDefault("SaveSchemaWithCustomNames", "false"), out bool custom) && custom;

        // Ensure the directory exists
        Directory.CreateDirectory(schemaDirectory);

        // Determine file path based on custom name setting
        string filePath;
        if (useCustomNames)
        {
            Console.WriteLine("Enter a custom schema file name (without extension): ");
            string customName = Console.ReadLine().Trim();
            filePath = Path.Combine(schemaDirectory, customName + ".json");
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
        Schema();
    }

    public static void JSONGrabber()
    {
        List<string> JsonFiles = new List<string>();
        List<string> Schemas = new List<string>();

        string jsonsDir = Path.Combine(Directory.GetCurrentDirectory(), "jsons");
        string schemasDir = Path.Combine(Directory.GetCurrentDirectory(), "schemas");

        if (Directory.Exists(jsonsDir))
        {
            JsonFiles.AddRange(Directory.GetFiles(jsonsDir, "*.json").Select(Path.GetFileName));
        }
        else
        {
            Console.WriteLine("The 'jsons' folder does not exist.");
        }

        if (Directory.Exists(schemasDir))
        {
            Schemas.AddRange(Directory.GetDirectories(schemasDir).Select(dir => new DirectoryInfo(dir).Name));
        }
        else
        {
            Console.WriteLine("The 'schemas' folder does not exist.");
        }

        string tempListSaveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "templistsave.txt");

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

    private static int GetValidUserInput(int min, int max)
    {
        while (true)
        {
            Console.Write($"Enter a number between {min} and {max}: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    public static void JSON()
    {
        string configPath = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
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

        // Retrieve the configuration values for JSON saving
        string saveFilePath = configValues.ContainsKey("SaveFilePath[JSON]") ? configValues["SaveFilePath[JSON]"] : "jsons";
        bool defaultCaseCorrection = bool.Parse(configValues.ContainsKey("DefaultCaseCorrection") ? configValues["DefaultCaseCorrection"] : "true");
        bool saveSchemaWithCustomNames = bool.Parse(configValues.ContainsKey("SaveJSONSWithCustomNames") ? configValues["SaveJSONSWithCustomNames"] : "false");
        bool colorfulText = bool.Parse(configValues.ContainsKey("ColorfulText") ? configValues["ColorfulText"] : "true");
        string schemaFilePath = Path.Combine(Directory.GetCurrentDirectory(), "schemas", "default_schema.json");

        // Existing color configuration and prompts
        if (colorfulText)
        {
            Console.Clear();
            Console.Write(ResetColor + BoldColorList[3] + "What do you want to do?" + ResetColor + HighIntensityUnderlineColorList[4] +
                "\n\n* Make JSON\n* Edit JSON [FUTURE]\n* Save JSON\n* Back" + ResetColor + BoldColorList[3] +
                "\n\nYour choice Here: " + ResetColor);
            string choice2 = Console.ReadLine();

            // Handle JSON actions
            if (choice2 == "Make JSON")
            {
                MakeJSON(schemaFilePath);
            }
            else if (choice2 == "Save JSON")
            {
                // Prompt for the JSON content generated from MakeJSON
                string jsonContent = GenerateJSONContent(schemaFilePath); // Generate content based on the schema
                SaveJSON(jsonContent, saveFilePath, saveSchemaWithCustomNames, defaultCaseCorrection);
            } else if (choice2 == "Back")
            {
                Main();
            }
        }
        else
        {
            Console.Clear();
            Console.Write("What do you want to do?\n\n* Make JSON\n* Edit JSON [FUTURE]\n* Save JSON\n* Back\n\nYour choice Here: ");
            string choice2 = Console.ReadLine();

            if (choice2 == "Make JSON")
            {
                MakeJSON(schemaFilePath);
            }
            else if (choice2 == "Save JSON")
            {
                // Placeholder for saving
                string jsonContent = GenerateJSONContent(schemaFilePath); // This method generates the JSON data
                SaveJSON(jsonContent, saveFilePath, saveSchemaWithCustomNames, defaultCaseCorrection);
            }
            else if (choice2 == "Back")
            {
                Main();
            }
        }

        // Handle schema file selection if required
        if (saveSchemaWithCustomNames)
        {
            string tempListSaveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "templistsave.txt");

            if (!File.Exists(tempListSaveFilePath))
            {
                Console.WriteLine("The file 'templistsave.txt' does not exist.");
                return;
            }

            try
            {
                List<string> schemas = new List<string>();
                using (StreamReader reader = new StreamReader(tempListSaveFilePath))
                {
                    string line;
                    bool readingSchemas = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Schema Directories:"))
                        {
                            readingSchemas = true;
                            continue;
                        }

                        if (readingSchemas && !string.IsNullOrWhiteSpace(line))
                        {
                            schemas.Add(line.Trim());
                        }
                    }
                }

                Console.WriteLine("\nSchema Directories:");
                for (int i = 0; i < schemas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {schemas[i]}");
                }

                Console.WriteLine("Select a Schema directory by number (or 0 to skip):");
                int selectedSchemaIndex = GetValidUserInput(0, schemas.Count) - 1;

                schemaFilePath = selectedSchemaIndex >= 0
                    ? Path.Combine(Directory.GetCurrentDirectory(), "schemas", schemas[selectedSchemaIndex], "default_schema.json")
                    : Path.Combine(Directory.GetCurrentDirectory(), "schemas", "default_schema.json");

                Console.WriteLine($"Selected Schema Path: {schemaFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing the file: {ex.Message}");
                return;
            }
        }

        // Ensure schema file exists before proceeding
        if (File.Exists(schemaFilePath))
        {
            // Proceed to make or save JSON
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Provide me a JSON Schema or I can't do anything for you!");
            Console.WriteLine("To provide me one, go to this app's directory and add a file called 'schemas/default_schema.json'. Make sure there is info inside the file.");
            Console.ReadLine();
            Main();
        }
    }

    public static void SaveJSON(string jsonContent, string saveFilePath, bool saveWithCustomNames, bool defaultCaseCorrection)
    {
        // Ensure the directory exists
        string fullSavePath = Path.Combine(Directory.GetCurrentDirectory(), saveFilePath);
        if (!Directory.Exists(fullSavePath))
        {
            Directory.CreateDirectory(fullSavePath);
        }

        string fileName = saveWithCustomNames ? "custom_output.json" : "output.json";

        // Apply case correction if enabled
        if (defaultCaseCorrection)
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
        JSON();
    }



    public static void MakeJSON(string schemaPath)
    {
        // Ensure schema file exists
        if (!File.Exists(schemaPath))
        {
            Console.WriteLine($"Schema file not found: {schemaPath}");
            return;
        }

        try
        {
            // Read and parse the schema file
            string schemaContent = File.ReadAllText(schemaPath);
            var schema = JsonConvert.DeserializeObject<Dictionary<string, object>>(schemaContent);

            if (schema == null || !schema.ContainsKey("properties"))
            {
                Console.WriteLine("Invalid schema format. Ensure it has a 'properties' section.");
                return;
            }

            // Process schema properties
            var properties = schema["properties"] as Newtonsoft.Json.Linq.JObject;
            if (properties == null)
            {
                Console.WriteLine("Schema 'properties' section is not valid.");
                return;
            }

            // Generate JSON data
            var jsonData = ProcessSchema(properties);

            // Serialize to JSON (formatting with indents)
            string jsonOutput = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            // Output the generated JSON to console (you can choose to save it later in the 'Save JSON [FUTURE]' section)
            Console.WriteLine("\nGenerated JSON:");
            Console.WriteLine(jsonOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing the schema: {ex.Message}");
        }
        JSON();
    }


    public static string ApplyCaseCorrection(string jsonContent)
    {
        // Implement case correction logic here (for example, convert to camelCase)
        var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
        var correctedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

        return correctedJson; // This should be the JSON with corrected key casing (e.g., camelCase)
    }

    public static string GenerateJSONContent(string schemaPath)
    {
        // This method generates the JSON content based on the schema
        string schemaContent = File.ReadAllText(schemaPath);
        var schema = JsonConvert.DeserializeObject<Dictionary<string, object>>(schemaContent);
        var properties = schema["properties"] as Newtonsoft.Json.Linq.JObject;
        var jsonData = ProcessSchema(properties);

        return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
    }

    private static object ProcessSchema(Newtonsoft.Json.Linq.JObject properties)
    {
        var result = new Dictionary<string, object>();

        foreach (var property in properties.Properties())
        {
            var attributes = property.Value as Newtonsoft.Json.Linq.JObject;
            if (attributes == null) continue;

            string type = attributes.GetValue("type")?.ToString() ?? "string";

            result[property.Name] = type switch
            {
                "object" => ProcessSchema(attributes.GetValue("properties") as Newtonsoft.Json.Linq.JObject),
                "array" => ProcessArray(attributes, property.Name),
                _ => GetFieldValue(attributes, property.Name, type)
            };
        }

        return result;
    }

    private static object GetFieldValue(Newtonsoft.Json.Linq.JObject attributes, string fieldName, string type)
    {
        Console.Write($"{fieldName} ({type}): ");
        string input = Console.ReadLine();

        if (type == "integer" && int.TryParse(input, out int intValue))
        {
            return intValue;
        }

        return input; // Default to string if type is unsupported
    }

    private static List<object> ProcessArray(Newtonsoft.Json.Linq.JObject attributes, string fieldName)
    {
        var items = new List<object>();
        Console.WriteLine($"Enter values for array '{fieldName}'. Type 'done' to finish.");

        while (true)
        {
            Console.Write($"Item {items.Count + 1}: ");
            string input = Console.ReadLine();
            if (input?.ToLower() == "done") break;

            items.Add(input);
        }

        return items;
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
        string saveFilePathJson = GetConfigValue("SaveFilePath[JSON]", "jsons");
        string saveFilePathSchema = GetConfigValue("SaveFilePath[Schema]", "schemas");
        bool saveSchemaWithCustomNames = bool.Parse(GetConfigValue("SaveSchemaWithCustomNames", "false"));
        bool defaultCaseCorrection = bool.Parse(GetConfigValue("DefaultCaseCorrection", "true"));
        bool descriptionsForSchemaProperties = bool.Parse(GetConfigValue("DescriptionsForSchemaProperties", "false"));
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
        configValues["DescriptionsForSchemaProperties"] = PromptUser("Should Schema Properties have descriptions?", descriptionsForSchemaProperties);
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
