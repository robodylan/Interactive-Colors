using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Import SFML
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
namespace Interactive_Colors
{
    class Game
    {

        public static int pixelSize = 16, MouseX, MouseY, Width = 1080, Height = 720, Count;
        public static RenderWindow window;
        public static List<Pixel> pixels;
        public static Sprite pixelSprite = new Sprite(new Texture("Content/Pixel.png"), new IntRect(0,0,pixelSize,pixelSize));
        public static void Start()
        {
            pixels = new List<Pixel>();
            window = new RenderWindow(new VideoMode((uint)Width,(uint)Height), "I Am Goc");
            window.SetFramerateLimit(120);
            Load();
            window.MouseMoved += setMousePos;
            while (window.IsOpen()){
                window.SetActive();
                window.DispatchEvents();
                Update();
                window.Display();
                Count++;
            }
        }

        public static void Update()
        {
            foreach (Pixel c in pixels)
            {
                /*
                if(MouseX > c.x && MouseX < c.x + pixelSize && MouseY > c.y && MouseY < c.y + pixelSize)
                {
                    c.Brightness = 0;
                }
                if (c.Brightness <= 255)
                {
                    c.Brightness = c.Brightness + 1;
                }
                 * */
                if (MouseX > c.x && MouseX < c.x + pixelSize && MouseY > c.y && MouseY < c.y + pixelSize)
                {
                    c.Activated = false;
                }
                if(c.Activated)
                {
                    //c.R = Count;
                    //c.R = c.R / 5;
                }
                else
                {
                    c.B = MouseY;
                    c.B = c.B / 5;
                }

                pixelSprite.Color = new Color((byte)c.R,(byte)c.G,(byte)c.B);
                pixelSprite.Position = new Vector2f(c.x, c.y);
                window.Draw(pixelSprite);
                c.R = c.R * 5;
                c.R = c.R * 5;
            }
        }

        public static void Load()
        {
            for(int x = 0; x < Width / pixelSize; x++){
                for (int y = 0; y < Height / pixelSize; y++ )
                {
                    pixels.Add(new Pixel(x * pixelSize,y *pixelSize));
                }
            }
        }

        public static void setMousePos(Object sender, MouseMoveEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
    }
}
