using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur.ReadFile
{
    class Import
    {

        public static Tile[,] ImportTileMapCsv(string path)
        {
            int countLineCopied = 0;
            string[] Tligne ; // tableau qui va contenir les sous-chaines extraites d'une ligne.
            char[] splitter = { ',','\n' }; // délimiteur du fichier texte
            Tile[,] tileExport = null;
            // Code
            if (File.Exists(path))
            {
                StreamReader line = new StreamReader(path);
                string ligne = line.ReadLine();

                string[] size = ligne.Split(splitter);

                int x;
                int y;

                if(int.TryParse(size[0], out x) && int.TryParse(size[1], out y))
                {
                    Tligne = new string[x];
                    tileExport = new Tile[y, x];

                    for (int i = 0; i < y; i++)
                    {
                        ligne = line.ReadLine();
                        Tligne = ligne.Split(splitter);

                        for(int j = 0; j < x ; j++)
                        {
                            int cursor = j * 3;
                            char tempo = Tligne[cursor].ToCharArray()[0];
                            tileExport[i, j].tileChar = tempo;
                            tileExport[i, j].backgroundColor = (ConsoleColor)(int.Parse(Tligne[cursor + 1]));
                            tileExport[i, j].charColor = (ConsoleColor)(int.Parse(Tligne[cursor + 2]));
                        }
                    }
                    line.Close();
                }
            }
            
            return tileExport;
        }
    }
}
