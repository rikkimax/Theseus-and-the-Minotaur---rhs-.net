using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using TATM.SCB.models;

namespace TATM.SCB
{
    public class Storage
    {
        public static GameSettings settings { get; set; }
        public static Player currentPlayer { get; set; }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        public static string GetFilePath()
        {
            string path;
            if (IsRunningOnMono())
            {
                return "~/TATMRHS/";
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return path + "/TATMRHS";
            }
        }

        public static void Save()
        {
            CheckDirectory();
            string filename = "data.xml";
            if (!File.Exists(filename))
            {
                filename = GetFilePath() + "/data.xml";
            }

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameSettings));
                TextWriter writer = new StreamWriter(filename);
                ser.Serialize(writer, settings);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static GameSettings Load()
        {
            string filename = GetFilePath() + "/data.xml";
            if (!File.Exists(filename))
            {
                filename = "data.xml";
            }

            if (File.Exists(filename))
            {
                CheckDirectory();
                // Create an instance of the XmlSerializer.
                XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
                // Reading the XML document requires a FileStream.
                Stream reader = new FileStream(filename, FileMode.Open);
                // Call the Deserialize method to restore the object's state.
                settings = (GameSettings)serializer.Deserialize(reader);
            }
            else
            {
                settings = null;
            }

            if (Storage.settings == null || Storage.settings.maps.Count == 0)
            {
                settings = new GameSettings();

                GameBoard board = new GameBoard();
                board.level = 0;
                board.minotaur = new Entity(1, 0);
                board.theseus = new Entity(1, 2);
                board.width = 3;
                board.height = 3;
                board.cells = new List<Cell>();

                board.cells.Add(new Cell(0, 0, new Border(false, false), false, false));
                board.cells.Add(new Cell(1, 0, new Border(false, true), false, false));
                board.cells.Add(new Cell(2, 0, new Border(true, false), false, false));

                board.cells.Add(new Cell(0, 1, new Border(false, false), false, false));
                board.cells.Add(new Cell(1, 1, new Border(true, true), false, false));
                board.cells.Add(new Cell(2, 1, new Border(true, false), true, false));

                board.cells.Add(new Cell(0, 2, new Border(false, true), false, false));
                board.cells.Add(new Cell(1, 2, new Border(false, true), false, false));
                board.cells.Add(new Cell(2, 2, new Border(true, true), false, false));

                settings.maps.Add(board);

                board = new GameBoard();
                board.level = 1;
                board.minotaur = new Entity(1, 2);
                board.theseus = new Entity(1, 0);
                board.width = 3;
                board.height = 3;
                board.cells = new List<Cell>();

                board.cells.Add(new Cell(0, 0, new Border(false, false), false, false));
                board.cells.Add(new Cell(1, 0, new Border(false, true), false, false));
                board.cells.Add(new Cell(2, 0, new Border(true, false), false, false));

                board.cells.Add(new Cell(0, 1, new Border(false, false), false, false));
                board.cells.Add(new Cell(1, 1, new Border(true, true), false, false));
                board.cells.Add(new Cell(2, 1, new Border(true, false), true, false));

                board.cells.Add(new Cell(0, 2, new Border(false, true), false, false));
                board.cells.Add(new Cell(1, 2, new Border(false, true), false, false));
                board.cells.Add(new Cell(2, 2, new Border(true, true), false, false));

                settings.maps.Add(board);

                Player player = new Player();
                player.name = Environment.UserName;
                settings.players.Add(player);

                Storage.settings = settings;
                Storage.currentPlayer = player;

                Storage.Save();
            }

            Storage.currentPlayer = Storage.settings.players.Find(delegate(Player player)
            {
                return player.name == Environment.UserName;
            });

            return settings;
        }

        public static void CheckDirectory()
        {
            // does directory exist?
            // if not create
            String filePath = GetFilePath();
            //if the file doesnt exist
            if (!Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
        }
    }
}
