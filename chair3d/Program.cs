using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace chair3d
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500, 500);

            Game game = new Game(window);
        }
    }
}
