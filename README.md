## Json Maker Console App

You may be wondering what this does and thats pretty complex to answer. But I will start off by providing some background. This project was made for a science fair, and the inspiration was from JSON Loader from the Inscryption Modding scene and the Json Editor site.

### What this App can do

* SCHEMA
- Make a Schema from scratch no its not automated its user input based.
- Save a Schema, you must create it first.
* JSON
- Make a JSON from any provided schemas with validation and syntax.
- Save JSONs based on the JSON you create

### What can be configured:

- Colorful Text - Basically if text should be printed with color.
- Property Descriptions - Toggle whether descriptions are shown on properties in json making.
- Property Syntax - Toggle whether property syntax is shown in json making.
- Show the Field Type with Name - Toggle whether the property type is shown by the name in json making.
- JSON Extension Type - Change the exported extension type [Let me know if this is not working]
- Save File Path - You can change where files are saved to on both the json and schema iirc its still tied to the directory's folder so to go out you'll have to add some `../` to the definition.
- Save with Custom Names - Toggle whether JSONS or SCHEMAS will be saved with custom names.
- Case Correction - Toggle whether Case Correction will occur on saving.

### How to setup by default:

1. Install Net 8.0 https://dotnet.microsoft.com/en-us/download
2. Install the latest release.
3. Unzip the zip to a folder of your liking.
4. Run the application and configure it.
5. Select JSON or Schema and select `make` after select `save`.

### How to add Schemas to your application

1. Navigate to `files/schemas`
2. Get all your schemas
3. Make sure they end with the `JSON Extenstion Type`'s value
4. Run The Application
5. Test it by making a JSON

### How you can Contribute:

* Sharing
* Contributing via PR's
* Showcasing
* Spreading the word
* Testing it out
* Providing Feedback
