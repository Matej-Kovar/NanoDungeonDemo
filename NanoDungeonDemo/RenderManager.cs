using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal class RenderManager
    {
        static ColoredChar[,] _CurrentFrame = new ColoredChar[Console.WindowHeight, Console.WindowWidth];
        static ConsoleColor _CurrentTextColor = ConsoleColor.Gray;
        static ConsoleColor _CurrentBackgroundColor = ConsoleColor.Black;
        public int _FrameHeight;
        public int _FrameWidth;
        int _OffsetTop;
        int _OffsetLeft;

        public RenderManager(int frameHeight, int frameWidth, int offsetTop, int offsetLeft)
        {
            _FrameHeight = frameHeight;
            _FrameWidth = frameWidth;
            _OffsetTop = offsetTop;
            _OffsetLeft = offsetLeft;
        }

        public void RenderFrame(ColoredChar[,] NewFrame)
        {
            _FrameHeight = Math.Min(NewFrame.GetLength(0), Console.WindowHeight);
            _FrameWidth = Math.Min(NewFrame.GetLength(1), Console.WindowWidth);
            string rowBuilder = string.Empty;
            for (int i = 0; i < _FrameHeight; i++)
            {
                int windowRow = i + _OffsetTop;
                for (int j = 0; j < _FrameWidth; j++)
                {
                    int windowColumn = j + _OffsetLeft;
                    var newChar = NewFrame[i, j];
                    var currentChar = _CurrentFrame[windowRow, windowColumn];
                    if (newChar != currentChar)
                    {
                        if(newChar.TextColor != _CurrentTextColor || newChar.BackgroundColor != _CurrentBackgroundColor)
                        {
                            if (rowBuilder.Length > 0)
                            {
                                Console.Write(rowBuilder);
                                rowBuilder = string.Empty;
                                Console.SetCursorPosition(j, i);
                            }
                            if (newChar.TextColor != _CurrentTextColor)
                            {
                                Console.ForegroundColor = newChar.TextColor;
                                _CurrentTextColor = newChar.TextColor;
                            }
                            if (newChar.BackgroundColor != _CurrentBackgroundColor)
                            {
                                Console.BackgroundColor = newChar.BackgroundColor;
                                _CurrentBackgroundColor = newChar.BackgroundColor;
                            }
                        }
                        if(rowBuilder.Length == 0)
                        {
                            Console.SetCursorPosition(windowColumn, windowRow);
                        }
                        rowBuilder += newChar.Char.ToString();
                        _CurrentFrame[windowRow, windowColumn].Char = newChar.Char;
                        _CurrentFrame[windowRow, windowColumn].TextColor = newChar.TextColor;
                        _CurrentFrame[windowRow, windowColumn].BackgroundColor = newChar.BackgroundColor;
                        
                    } 
                    else
                    {
                        if (rowBuilder.Length > 0)
                        {
                            Console.Write(rowBuilder);
                            rowBuilder = string.Empty;
                            Console.SetCursorPosition(j, i);
                        }
                    }
                }
                Console.Write(rowBuilder);
                rowBuilder = string.Empty;
            }
        }
    }
}
