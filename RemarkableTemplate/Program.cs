using System;
using System.Drawing;


namespace SVGCreate
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();

            shape.Grid(10,"verytinygrid.svg");
            shape.Grid(20, "tinygrid.svg");
            shape.Grid(40, "smallgrid.svg");

            shape.RightGrid(10, "verytinyrightgrid.svg");
            shape.RightGrid(20,"tinyrightgrid.svg");
            shape.RightGrid(40, "smallrightgrid.svg");

            shape.Triangle(10, "verytinytriange.svg");
            shape.Triangle(20, "tinytriange.svg");
            shape.Triangle(40, "smalltriange.svg");
            
            shape.Hexagon(10, "verytinyhexagon.svg");
            shape.Hexagon(20, "tinyhexagon.svg");
            shape.Hexagon(40, "smallhexagon.svg");

        }
    }
}
