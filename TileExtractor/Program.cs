using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TileExtractor
{
    class Program
    {
        static int widthCount = 11;
        static int heightCount = 4;
        static int widthCorrection = -5;
        static int heightCorrection = -10;

        static void Main(string[] args)
        {
            Bitmap table = new Bitmap("Saboteur.png");
            int tileWidth = table.Width / widthCount + widthCorrection;
            int tileHeight = table.Height / heightCount + heightCorrection;

            Rectangle extractedRegion = new Rectangle(0, 0, tileWidth, tileHeight);
            //Rectangle smallRegion = new Rectangle(0, 0, tileWidth / 2, tileHeight / 2 + 1);

            for (int i = 0; i < heightCount; i++)
            {
                for (int j = 0; j < widthCount; j++)
                {
                    int srcX = j * tileWidth + 20;
                    int srcY = i * tileHeight + 25;
                    Bitmap tile = new Bitmap(tileWidth, tileHeight);
                    //Bitmap smallTile = new Bitmap(tileWidth / 2, tileHeight / 2);
                    Graphics g = Graphics.FromImage(tile);
                    //Graphics smallG = Graphics.FromImage(smallTile);
                    g.DrawImage(table, extractedRegion, srcX, srcY, extractedRegion.Width, extractedRegion.Height, GraphicsUnit.Pixel);
                    //smallG.DrawImage(table, smallRegion, srcX, srcY, extractedRegion.Width, extractedRegion.Height, GraphicsUnit.Pixel);
                    //smallTile.Save(char.ConvertFromUtf32(i + 65) + j + ".png", ImageFormat.Png);
                    tile.Save(char.ConvertFromUtf32(i + 65) + j + ".png", ImageFormat.Png);
                }
            }


            Console.WriteLine("Done");
        }
    }
}
