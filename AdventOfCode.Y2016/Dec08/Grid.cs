using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Y2016.Dec08
{
    internal class Grid
    {
        public int Width { get; }
        public int Height { get; }

        private readonly bool[] _grid;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            _grid = new bool[Height * Width];
        }

        public long CountLit() => _grid.Count(g => g);

        public void FillRect(int width, int height)
        {
            for (var row = 0; row < height; row++)
                Array.Fill(_grid, true, row * Width, width);
        }

        public void ShiftHorizontal(int row, int amount)
        {
            var newValues = new bool[Width];
            for (var i = 0; i < Width; i++)
            {
                var oldIdx = (row * Width) + i;
                var newIdx = (i + amount) % Width;
                newValues[newIdx] = _grid[oldIdx];
            }

            newValues.CopyTo(_grid, row * Width);
        }

        public void ShiftVertical(int col, int amount)
        {
            var newValues = new bool[Height];
            for (var i = 0; i < Height; i++)
            {
                var oldIdx = (i * Width) + col;
                var newIdx = (i + amount) % Height;
                newValues[newIdx] = _grid[oldIdx];
            }

            for (var i = 0; i < Height; i++)
                _grid[(i * Width) + col] = newValues[i];
        }

        public void Output()
        {
            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                    Console.Write(_grid[row * Width + col] ? '#' : ' ');
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Transform(GridTransform transform)
        {
            switch (transform.Op)
            {
                case GridTransformType.Rect:
                    FillRect(transform.Arg0, transform.Arg1);
                    break;
                case GridTransformType.ShiftVertical:
                    ShiftVertical(transform.Arg0, transform.Arg1);
                    break;
                case GridTransformType.ShiftHorizontal:
                    ShiftHorizontal(transform.Arg0, transform.Arg1);
                    break;
            }
        }

        public static GridTransform ParseTransform(string command)
        {
            var sliceable = command.AsSpan().Trim();

            GridTransformType op;
            int arg0, arg1;

            if (sliceable.StartsWith("rect"))
            {
                op = GridTransformType.Rect;

                var delim = sliceable.LastIndexOf('x');
                arg1 = int.Parse(sliceable.Slice(delim + 1));

                sliceable = sliceable.Slice(0, delim);
                var secondDelim = sliceable.LastIndexOf(' ');
                arg0 = int.Parse(sliceable.Slice(secondDelim + 1));
            }
            else
            {
                op = sliceable.StartsWith("rotate column") ? GridTransformType.ShiftVertical : GridTransformType.ShiftHorizontal;

                var delim = sliceable.LastIndexOf(' ');
                arg1 = int.Parse(sliceable.Slice(delim + 1));

                sliceable = sliceable.Slice(0, delim - " by".Length);
                var secondDelim = sliceable.LastIndexOf('=');
                arg0 = int.Parse(sliceable.Slice(secondDelim + 1));
            }

            return new GridTransform(op, arg0, arg1);
        }

        public enum GridTransformType
        {
            Rect,
            ShiftVertical,
            ShiftHorizontal
        }

        public record struct GridTransform(GridTransformType Op, int Arg0, int Arg1);
    }
}
