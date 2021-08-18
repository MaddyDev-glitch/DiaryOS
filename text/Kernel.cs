/*
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Core;
using Cosmos.Common;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.HAL.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.Debug.Kernel;
namespace voiceassistantos
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;

        public static Cosmos.HAL.VGADriver screen = new Cosmos.HAL.VGADriver();
        private uint ux = 1024;
        private uint uy = 768;
        private int x = 512;
        private int y = 384;

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Let's go in Graphic Mode");
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            canvas.Clear(Color.Blue);
            Sys.MouseManager.ScreenHeight = uy;
            Sys.MouseManager.ScreenWidth = ux;

            // A red Point 
            Pen pen = new Pen(Color.Black);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 30, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 130, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 220, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 320, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 420, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 520, 80, 60);
            //Button
            canvas.DrawFilledRectangle(pen, 40, 620, 80, 60);
        }

        protected override void Run()
        {
            mDebugger.Send("x: " + Sys.MouseManager.ScreenWidth + "y: " + Sys.MouseManager.ScreenHeight);

            x = Convert.ToInt32(Sys.MouseManager.X);
            y = Convert.ToInt32(Sys.MouseManager.Y);

            mDebugger.Send("mouse x: " + x + "mouse y: " + y);

            Pen pen = new Pen(Color.Red);
            canvas.DrawCircle(pen, x + 10, y + 10, 5);
            canvas.Clear();

        }

    }
}
*/
using System;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Cosmos.Common;
using System.Drawing;
using Cosmos.HAL.Drivers;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.Debug.Kernel;
namespace MIV
{
    public class Kernel : Sys.Kernel
    {
        private static Sys.FileSystem.CosmosVFS FS;
        public static string file;
        Canvas canvas;
//-------------------
        public static Cosmos.HAL.VGADriver screen = new Cosmos.HAL.VGADriver();
        private uint ux = 1024;
        private uint uy = 768;
        private int x = 512;
        private int y = 384;
//-------------------


        protected override void BeforeRun()
        {
            //---------------------
            Console.WriteLine("Cosmos booted successfully. Let's go in Graphic Mode");
            canvas = FullScreenCanvas.GetFullScreenCanvas();

          //  canvas.Clear(Color.Blue);
            Sys.MouseManager.ScreenHeight = uy;
            Sys.MouseManager.ScreenWidth = ux;

            // A red Point 
            Pen pen = new Pen(Color.Black);


            //--------------------

            FS = new Sys.FileSystem.CosmosVFS(); Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS); FS.Initialize();
            /* If all works correctly you should not really see this :-) */
            Console.WriteLine("Cosmos booted successfully. Let's go in Graphic Mode");

            canvas = FullScreenCanvas.GetFullScreenCanvas();
           // canvas.Clear(System.Drawing.Color.Black);

            Pen pennew = new Pen(System.Drawing.Color.Red);
            canvas.DrawPoint(pennew, 0, 0);

            Pen pen1 = new Pen(System.Drawing.Color.Red);
            canvas.DrawPoint(pen, 1000, 0);
            Pen pen2 = new Pen(System.Drawing.Color.Red);
            canvas.DrawPoint(pen, 0, 720);
            Pen pen3 = new Pen(System.Drawing.Color.Red);
            canvas.DrawPoint(pen, 720, 720);


            pen.Color = System.Drawing.Color.PaleVioletRed;
            canvas.DrawRectangle(pen, 1, 1, 1080, 720);

            pen.Color = System.Drawing.Color.FromArgb(255, 145, 89, 89);
            canvas.DrawFilledRectangle(pen, 50, 260, 210, 210);

            pen.Color = System.Drawing.Color.Black;
            canvas.DrawFilledRectangle(pen, 72, 282, 166, 166);

            pen.Color = System.Drawing.Color.FromArgb(255, 145, 89, 89);
            canvas.DrawFilledRectangle(pen, 94, 304, 122, 122);

            //------------------------
            pen.Color = System.Drawing.Color.FromArgb(255, 145, 89, 89);
            canvas.DrawFilledRectangle(pen, 770, 50, 210, 210);

            pen.Color = System.Drawing.Color.Black;
            canvas.DrawFilledRectangle(pen, 792, 72, 166, 166);

            pen.Color = System.Drawing.Color.FromArgb(255, 145, 89, 89);
            canvas.DrawFilledRectangle(pen, 814, 94, 122, 122);
            //--------------
            pen.Color = System.Drawing.Color.FromArgb(255, 97, 9, 9);
            canvas.DrawFilledRectangle(pen, 342, 1, 20, 720);
            canvas.DrawFilledRectangle(pen, 397, 1, 20, 680);
            canvas.DrawFilledRectangle(pen, 452, 260, 20, 460);
            canvas.DrawFilledRectangle(pen, 507, 1, 20, 720);

            canvas.DrawFilledRectangle(pen, 562, 130, 20, 460);
            canvas.DrawFilledRectangle(pen, 617, 1, 20, 320);
            canvas.DrawFilledRectangle(pen, 672, 1, 20, 720);

            pen.Color = System.Drawing.Color.WhiteSmoke;

            canvas.DrawRectangle(pen, 155, 190, 700, 170);
            canvas.DrawRectangle(pen, 175, 210, 660, 130);

            canvas.DrawFilledRectangle(pen, 155, 520, 250, 110);
            canvas.DrawFilledRectangle(pen, 615, 520, 250, 110);

            pen.Color = System.Drawing.Color.FromArgb(255, 119, 8, 10);
            canvas.DrawFilledRectangle(pen, 157, 522, 246, 106);
            canvas.DrawFilledRectangle(pen, 617, 522, 246, 106);


        }

        protected override void Run()
        {
           
            //-----------------------------
           
            //------------------
            try
            {
                mDebugger.Send("x: " + Sys.MouseManager.ScreenWidth + "y: " + Sys.MouseManager.ScreenHeight);

                x = Convert.ToInt32(Sys.MouseManager.X);
                y = Convert.ToInt32(Sys.MouseManager.Y);

                mDebugger.Send("mouse x: " + x + "mouse y: " + y);
                Pen penm = new Pen(Color.Red);
                canvas.DrawCircle(penm, x + 10, y + 10, 5);

                if(x>150 && x<400 &&y>519 && y<610)
                {
                    mDebugger.Send("OVER HERE-----------------------------");

                    if (Sys.MouseManager.MouseState==  Sys.MouseState.Left)
                    {
                        mDebugger.Send("YAAY-----------------------------");
                         // var xyz = Console.ReadKey();
                        canvas.Disable();
                        MIV.Home();
                    }
                }

            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                mDebugger.Send(e.Message);
                Stop();
            }
        }

    }
}


