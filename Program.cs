﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraT3D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run(60.0); // Ejecutar el juego con un framerate objetivo de 60 FPS
            }
        }
    }
}
