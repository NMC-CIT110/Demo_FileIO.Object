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
            string textFilePath = @"Data\Data.csv";

            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu()
        {
            string menuChoice;
            bool exiting = false;

            List<Character> characters = InitializeListOfCharacters();

            string dataPath = @"Data\Data.csv";

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
                        DisplayCharacterInfo(characters);
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



        private static void DisplayCharacterInfo(List<Character> characters)
        {
            throw new NotImplementedException();
        }

        private static void DisplayAddCharacter(List<Character> characters)
        {
            throw new NotImplementedException();
        }

        private static void DisplayDeleteCharacter(List<Character> characters)
        {
            throw new NotImplementedException();
        }

        private static void DisplayEditCharacter(List<Character> characters)
        {
            throw new NotImplementedException();
        }

        private static void DisplaySaveCharactersToFile(string dataPath, List<Character> characters)
        {
            DisplayHeader("Save Characters to File");

            Console.WriteLine($"The list of characters will be saved to '{dataPath}'.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //
            // catch all exceptions thrown by the write data method and display a message
            //
            try
            {
                WriteCharactersToCsvFile(dataPath, characters);
                Console.WriteLine("The characters were successfully saved to the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The following error occurred when writing to the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();
        }

        private static List<Character> DisplayLoadCharactersFromFile(string dataPath)
        {
            List<Character> characters = new List<Character>();

            DisplayHeader("Load Characters from File");

            Console.WriteLine($"The list of characters will be loaded from '{dataPath}'.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //
            // catch all exceptions thrown by the read data method and display a message
            //
            try
            {
                characters = ReadCharactersFromCsvFile(dataPath);
                Console.WriteLine("The characters were successfully loaded from the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The following error occurred when reading from the file.");
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

            foreach (Character character in characters)
            {
                Console.WriteLine($"\t{character.FullName()}");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// initialize a list of seed characters
        /// </summary>
        /// <returns>list of characters</returns>
        static List<Character> InitializeListOfCharacters()
        {
            List<Character> CharacterList = new List<Character>()
            {
                new Character()
                {
                    Id = 1,
                    LastName = "Flintstone",
                    FirstName = "Fred",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 28,
                    Gender = Character.GenderType.MALE
                },
                new Character()
                {
                    Id = 2,
                    LastName = "Rubble",
                    FirstName = "Barney",
                    Address = "303 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777",
                    Age = 28,
                    Gender = Character.GenderType.FEMALE
                }
            };

            return CharacterList;
        }

        /// <summary>
        /// display all character properties
        /// </summary>
        /// <param name="characters">character object</param>
        static void DisplayCharacters(List<Character> characters)
        {
            foreach (Character character in characters)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {character.Id}");
                Console.WriteLine($"Last Name: {character.LastName}");
                Console.WriteLine($"First Name: {character.FirstName}");
                Console.WriteLine($"Address: {character.Address}");
                Console.WriteLine($"City: {character.City}");
                Console.WriteLine($"State: {character.State}");
                Console.WriteLine($"Zip: {character.Zip}");
                Console.WriteLine($"Age: {character.Age}");
                Console.WriteLine($"Gender: {character.Gender}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// save list of characters to a file
        /// </summary>
        /// <param name="characterClassLIst">list of characters</param>
        /// <param name="dataPath">data path</param>
        static void WriteCharactersToCsvFile(string dataPath, List<Character> characterClassLIst)
        {
            string characterString;

            List<string> charactersStringListWrite = new List<string>();

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

                charactersStringListWrite.Add(characterString);
            }

            //
            // catch all errors when writing to the file and pass the exception to the calling method
            //
            try
            {
                File.WriteAllLines(dataPath, charactersStringListWrite);
            }
            catch (Exception)
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

            List<string> CharacterStringList = new List<string>();

            List<Character> CharacterClassList = new List<Character>();

            //
            // read each line and put it into an array and convert the array to a list
            //
            CharacterStringList = File.ReadAllLines(dataFile).ToList();

            //
            // create character object for each line of data read and fill in the property values
            //
            foreach (string characterString in CharacterStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = characterString.Split(delineator);

                CharacterClassList.Add(
                    new Character()
                    {
                        Id = Convert.ToInt32(properties[0]),
                        LastName = properties[1],
                        FirstName = properties[2],
                        Address = properties[3],
                        City = properties[4],
                        State = properties[5],
                        Zip = properties[6],
                        Age = Convert.ToInt32(properties[7]),
                        Gender = (Character.GenderType)Enum.Parse(typeof(Character.GenderType), properties[8])
                    });
            }

            return CharacterClassList;
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
