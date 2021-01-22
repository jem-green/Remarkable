using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Svg;

namespace SVGCreate
{
    public class Shape
    {
        // 1404x1872 Supposidly the size of the page
        // Set the centre of the page to be zero, Zero 

        int _width = 1404;
        int _height = 1872;

        public Shape()
        {
        }

        public Shape(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Grid(int _spacing, string filename)
        {
            SvgDocument svgDoc;

            // 1404x1872 Supposidly the size of the page
            // Set the centre of the page to be zero, Zero 

            int _width = 1404;
            int _height = 1872;

            // Grid co-ordinates

            int _left = -(int)(_spacing * Math.Round((double)(_width / 2 / _spacing)));
            int _top = -(int)(_spacing * Math.Round((double)(_height / 2 / _spacing)));
            int _right = -_left;
            int _bottom = -_top;

            // Test generating a SVG grid so that i can create a png in InkScape

            svgDoc = new SvgDocument
            {
                Width = _width,
                Height = _height,
                ViewBox = new SvgViewBox(-_width / 2, -_height / 2, _width, _height),
            };

            var group = new SvgGroup();
            svgDoc.Children.Add(group);

            for (int i = _left; i <= _right; i = i + _spacing)
            {
                // Verical lines

                group.Children.Add(new SvgLine
                {
                    StartX = i,
                    EndX = i,
                    StartY = _top,
                    EndY = _bottom,
                    Stroke = new SvgColourServer(Color.LightGray),
                    StrokeWidth = 1
                });

                for (int j = _top; j <= _bottom; j = j + _spacing)
                {
                    // Horizontal lines

                    group.Children.Add(new SvgLine
                    {
                        StartX = _left,
                        EndX = _right,
                        StartY = j,
                        EndY = j,
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });
                }
            }
            svgDoc.Write(filename);
        }
       
        public void RightGrid(int _spacing, string filename)
        {
            SvgDocument svgDoc;

            // Grid co-ordinates

            int _left = -(int)(_spacing * Math.Round((double)(_width / 2 / _spacing)));
            int _top = -(int)(_spacing * Math.Round((double)(_height / 2 / _spacing)));
            int _right = -_left;
            int _bottom = -_top;

            // Test generating a SVG grid so that i can create a png in InkScape

            svgDoc = new SvgDocument
            {
                Width = _width,
                Height = _height,
                ViewBox = new SvgViewBox(-_width / 2, -_height / 2, _width, _height),
            };

            var group = new SvgGroup();
            svgDoc.Children.Add(group);

            for (int i = _left; i < _right; i = i + _spacing)
            {
                for (int j = _top; j < _bottom; j = j + _spacing)
                {
                    group.Children.Add(new SvgRectangle
                    {
                        X = i,
                        Y = j,
                        Width = _spacing,
                        Height = _spacing,
                        Stroke = new SvgColourServer(Color.LightGray),
                        FillOpacity = 0,
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = i,
                        EndX = i + _spacing,
                        StartY = j + _spacing,
                        EndY = j,
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });
                }
            }
            svgDoc.Write(filename);
        }

        public void Triangle(int _spacing, string filename)
        {
            SvgDocument svgDoc;

            // Grid co-ordinates

            double vertical = Math.Sqrt(3) / 2 * _spacing;
            int _left = -(int)(_spacing * Math.Round((double)(1 + _width / 2 / _spacing)));
            int _top = -(int)(vertical * Math.Round((double)(1 + _height / 2 / vertical)));
            int _right = -_left;
            int _bottom = -_top;

            // Test generating a SVG grid so that i can create a png in InkScape

            svgDoc = new SvgDocument
            {
                Width = _width,
                Height = _height,
                ViewBox = new SvgViewBox(-_width / 2, -_height / 2, _width, _height),
            };

            var group = new SvgGroup();
            svgDoc.Children.Add(group);

            for (double i = _left; i < _right; i = i + _spacing)
            {
                bool even = false;

                for (double j = _top; j < _bottom; j = j + vertical)
                {
                    double offset = 0;
                    if (even == true)
                    {
                        offset = _spacing / 2;
                        even = false;
                    }
                    else
                    {
                        even = true;
                    }

                    // Triangle

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + offset),
                        EndX = (int)(i + _spacing + offset),
                        StartY = (int)j,
                        EndY = (int)j,
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + offset),
                        EndX = (int)(i + _spacing / 2 + offset),
                        StartY = (int)j,
                        EndY = (int)(j + vertical),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + _spacing + offset),
                        EndX = (int)(i + _spacing / 2 + offset),
                        StartY = (int)j,
                        EndY = (int)(j + vertical),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                }
            }
            svgDoc.Write(filename);
        }

        public void Hexagon(int _spacing, string filename)
        {
            SvgDocument svgDoc;

            // Grid co-ordinates

            double vertical = Math.Sqrt(3) / 2 * _spacing;
            double horizontal = _spacing;
            int _left = -(int)(_spacing * Math.Round((double)(_width / 2 / _spacing)) + (int)(_spacing / 4));
            int _top = -(int)(vertical * Math.Round((double)(_height / 2 / vertical)) - (int)(vertical / 2));
            int _right = -_left + _spacing;
            int _bottom = -_top;

            // Test generating a SVG grid so that i can create a png in InkScape

            svgDoc = new SvgDocument
            {
                Width = _width,
                Height = _height,
                ViewBox = new SvgViewBox(-_width / 2, -_height / 2, _width, _height),
            };

            var group = new SvgGroup();
            svgDoc.Children.Add(group);

            bool even = false;

            for (double i = _left; i < _right; i = i + _spacing * 1.5)
            {
                double offset = 0;
                if (even == true)
                {
                    offset = vertical;
                    even = false;
                }
                else
                {
                    even = true;
                }

                for (double j = _top; j < _bottom; j = j + vertical * 2)
                {

                    // Hexagon

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + _spacing / 2),
                        EndX = (int)(i + _spacing),
                        StartY = (int)(j + vertical + offset),
                        EndY = (int)(j + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + _spacing),
                        EndX = (int)(i + _spacing / 2),
                        StartY = (int)(j + offset),
                        EndY = (int)(j - vertical + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i + _spacing / 2),
                        EndX = (int)(i - _spacing / 2),
                        StartY = (int)(j - vertical + offset),
                        EndY = (int)(j - vertical + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i - _spacing / 2),
                        EndX = (int)(i - _spacing),
                        StartY = (int)(j - vertical + offset),
                        EndY = (int)(j + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i - _spacing),
                        EndX = (int)(i - _spacing / 2),
                        StartY = (int)(j + offset),
                        EndY = (int)(j + vertical + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });

                    group.Children.Add(new SvgLine
                    {
                        StartX = (int)(i - _spacing / 2),
                        EndX = (int)(i + _spacing / 2),
                        StartY = (int)(j + vertical + offset),
                        EndY = (int)(j + vertical + offset),
                        Stroke = new SvgColourServer(Color.LightGray),
                        StrokeWidth = 1
                    });
                }
            }
            svgDoc.Write(filename);
        }
    }
}
