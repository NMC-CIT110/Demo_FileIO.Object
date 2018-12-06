using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataPath = @"Data\Data.csv";

            //
            // debug: save seed data to the data file
            //
            //SeedDataFile(dataPath);

            DisplayOpeningScreen();
            DisplayMenu(dataPath);
            DisplayClosingScreen();
        }

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu(string dataPath)
        {
            string menuChoice;
            bool exiting = false;
            List<Character> characters = null;

            //
            // debug: initialize the character list with character objects
            //
            characters = InitializeListOfCharacters();

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\ta) Display All Characters");
                Console.WriteLine("\tb) Add a Character");
                Console.WriteLine("\tc) Delete a Character");
                Console.WriteLine("\td) Edit a Character");
                Console.WriteLine("\te) Display Character Info");
                Console.WriteLine("\tf) Save Characters to a File");
                Console.WriteLine("\tg) Load Characters from a File");
                Console.WriteLine("\tq) Quit");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice.ToLower())
                {
                    case "a":
                        DisplayAllCharacters(characters);
                        break;

                    case "b":
                        DisplayAddCharacter(characters);
                        break;

                    case "c":
                        DisplayDeleteCharacter(characters);
                        break;

                    case "d":
                        DisplayEditCharacter(characters);
                        break;

                    case "e":
                        DisplayCharacterDetail(characters);
                        break;

                    case "f":
                        DisplaySaveCharactersToFile(dataPath, characters);
                        break;

                    case "g":
                        characters = DisplayLoadCharactersFromFile(dataPath);
                        break;

                    case "q":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// display all of the properties of a character
        /// </summary>
        /// <param name="characters">list of characters</param>
        private static void DisplayCharacterDetail(List<Character> characters)
        {
            DisplayHeader("Character Information");

            Console.WriteLine("\t--------------");
            Console.WriteLine("\tNot Implemented");
            Console.WriteLine("\t--------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// user adds a character
        /// </summary>
        /// <param name="characters">list of characters</param>
        private static void DisplayAddCharacter(List<Character> characters)
        {
            DisplayHeader("Add a Character");

            Console.WriteLine("\t--------------");
            Console.WriteLine("\tNot Implemented");
            Console.WriteLine("\t--------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// user deletes a character
        /// </summary>
        /// <param name="characters">list of characters</param>
        private static void DisplayDeleteCharacter(List<Character> characters)
        {
            DisplayHeader("Delete a Character");

            Console.WriteLine("\t--------------");
            Console.WriteLine("\tNot Implemented");
            Console.WriteLine("\t--------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// user edits a character
        /// </summary>
        /// <param name="characters">list of characters</param>
        private static void DisplayEditCharacter(List<Character> characters)
        {
            DisplayHeader("Edit a Character");

            Console.WriteLine("\t--------------");
            Console.WriteLine("\tNot Implemented");
            Console.WriteLine("\t--------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// save character list to the data file
        /// </summary>
        /// <param name="dataPath">data path</param>
        /// <param name="characters">list of characters</param>
        private static void DisplaySaveCharactersToFile(string dataPath, List<Character> characters)
        {
            DisplayHeader("Save Characters to File");

            Console.WriteLine($"\tThe list of characters will be saved to '{dataPath}'.");
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();

            //
            // try to write the list of characters to the file
            //
            try
            {
                WriteCharactersToCsvFile(dataPath, characters);
                Console.WriteLine("\tThe characters were successfully saved to the file.");
            }
            catch (Exception e)// catch any exception thrown by the write method
            {
                Console.WriteLine("\tThe following error occurred when writing to the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// load character list from data file
        /// </summary>
        /// <param name="dataPath">data path</param>
        /// <returns>list of characters</returns>
        private static List<Character> DisplayLoadCharactersFromFile(string dataPath)
        {
            List<Character> characters = new List<Character>();

            DisplayHeader("Load Characters from File");

            Console.WriteLine($"\tThe list of characters will be loaded from '{dataPath}'.");
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();

            //
            // try to read the characters from the data file into a list
            //
            try
            {
                characters = ReadCharactersFromCsvFile(dataPath);
                Console.WriteLine("/tThe characters were successfully loaded from the file.");
            }
            catch (Exception e) // catch any exception thrown by the read method
            {
                Console.WriteLine("/tThe following error occurred when reading from the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();

            return characters;
        }

        /// <summary>
        /// display all characters
        /// </summary>
        /// <param name="characters">list of characters</param>
        private static void DisplayAllCharacters(List<Character> characters)
        {
            DisplayHeader("All Flintstone Characters");

            if (characters != null)
            {
                foreach (Character character in characters)
                {
                    Console.WriteLine($"\t{character.FullName()}");
                }
            }
            else
            {
                Console.WriteLine("\tThere are currently no characters available.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// load seed data into data file
        /// </summary>
        static void SeedDataFile(string dataPath)
        {
            WriteCharactersToCsvFile(dataPath, InitializeListOfCharacters());
        }

        /// <summary>
        /// initialize a list of seed characters
        /// </summary>
        /// <returns>list of characters</returns>
        static List<Character> InitializeListOfCharacters()
        {
            List<Character> characters = new List<Character>();

            Character character1 = new Character();
            character1.Id = 1;
            character1.LastName = "Flintstone";
            character1.FirstName = "Fred";
            character1.Address = "301 Cobblestone Way";
            character1.City = "Bedrock";
            character1.State = "MI";
            character1.Zip = "70777";
            character1.Age = 28;
            character1.Gender = Character.GenderType.MALE;
            characters.Add(character1);

            Character character2 = new Character();
            character2.Id = 2;
            character2.LastName = "Rubble";
            character2.FirstName = "Barney";
            character2.Address = "303 Cobblestone Way";
            character2.City = "Bedrock";
            character2.State = "MI";
            character2.Zip = "70777";
            character2.Age = 28;
            character2.Gender = Character.GenderType.FEMALE;
            characters.Add(character2);

            return characters;
        }

        /// <summary>
        /// display all character properties
        /// </summary>
        /// <param name="characters">character object</param>
        static void DisplayCharacterDetail(Character character)
        {
            Console.WriteLine();
            Console.WriteLine($"\tId: {character.Id}");
            Console.WriteLine($"\tLast Name: {character.LastName}");
            Console.WriteLine($"\tFirst Name: {character.FirstName}");
            Console.WriteLine($"\tAddress: {character.Address}");
            Console.WriteLine($"\tCity: {character.City}");
            Console.WriteLine($"\tState: {character.State}");
            Console.WriteLine($"\tZip: {character.Zip}");
            Console.WriteLine($"\tAge: {character.Age}");
            Console.WriteLine($"\tGender: {character.Gender}");
            Console.WriteLine();
        }

        /// <summary>
        /// save list of characters to a file
        /// </summary>
        /// <param name="characterClassLIst">list of characters</param>
        /// <param name="dataPath">data path</param>
        static void WriteCharactersToCsvFile(string dataPath, List<Character> characterClassLIst)
        {
            string characterString;

            List<string> characterStringList = new List<string>();

            //
            // build the list to write to the text file line by line
            //
            foreach (var character in characterClassLIst)
            {
                characterString =
                    character.Id + "," +
                    character.LastName + "," +
                    character.FirstName + "," +
                    character.Address + "," +
                    character.City + "," +
                    character.State + "," +
                    character.Zip + "," +
                    character.Age + "," +
                    character.Gender;

                characterStringList.Add(characterString);
            }

            //
            // write the list of strings (characters) to the data file
            //
            try
            {
                File.WriteAllLines(dataPath, characterStringList);
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

        }

        /// <summary>
        /// load all characters from a file
        /// </summary>
        /// <param name="dataFile">data path</param>
        /// <returns>list of characters</returns>
        static List<Character> ReadCharactersFromCsvFile(string dataFile)
        {
            const char delineator = ',';

            List<string> characterStringList = new List<string>();
            List<Character> characterObjectList = new List<Character>();
            Character tempCharacter = new Character();

            //
            // read each line and put it into an array and convert the array to a list
            //
            try
            {
                characterStringList = File.ReadAllLines(dataFile).ToList();
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

            //
            // create character object for each line of data read and fill in the property values
            //
            foreach (string characterString in characterStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = characterString.Split(delineator);

                tempCharacter.Id = Convert.ToInt32(properties[0]);
                tempCharacter.LastName = properties[1];
                tempCharacter.FirstName = properties[2];
                tempCharacter.Address = properties[3];
                tempCharacter.City = properties[4];
                tempCharacter.State = properties[5];
                tempCharacter.Zip = properties[6];
                tempCharacter.Age = Convert.ToInt32(properties[7]);
                tempCharacter.Gender = (Character.GenderType)Enum.Parse(typeof(Character.GenderType), properties[8]);

                characterObjectList.Add(tempCharacter);
            }

            return characterObjectList;
        }

        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Flintstone Characters Database");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for using Flintstone Characters Database.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }

        #endregion


    }
}
