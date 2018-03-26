//Solution for http://www.codewars.com/kata/569e0778f3b6ef81b7000046/csharp


//namespace smile67Kata
//{
//    using System;

//    //Some general infos - you can use following preloaded "functions/vars" from the preloaded "Drawing"- Class:
//    //const int Width = 100, Height = 50; //Canvas size, here always fix, 0,0 is top,left
//    //static bool[,] Canvas; //your drawing Canvas with size [Width,Height], here you have to set your pixels;-)
//    //Clear() //clears Canvas for new drawing(s)
//    //ShowCanvas("Y", ref Drawing.Canvas) //here "Y" is the sign for your pixel as string output

//    //Example for drawing and showing the result - look at testcases (usable for own tests?):
//    //---------------------------------------------------------------------------------------
//    //Kata draw = new Kata();   //Canvas now has size 100x50, is empty and ready for drawing
//    //Drawing.Clear(); //clears Canvas (every pixel=false, after new not necessary)
//    //draw.drawLine(-100, -50, 200, 80); //your function: draw Line on Canvas and perhaps clip it (set Canvas pixels on true)
//    //Console.WriteLine(Drawing.ShowCanvas("Y", ref Drawing.Canvas)); //show Canvas/Image with your line in output window (symbol for pixel="Y")

//    public class Kata
//    {
//        private double calculateK(int x1, int y1, int x2, int y2)
//        {
//            return ((double)y1 - y2) / ((double)x1 - x2);

//        }
//        private double calculateB(int x1, int y1, double k)
//        {
//            return y1 - k * x1;
//        }
//        public void drawLine(int x1, int y1, int x2, int y2)
//        {
//            var k = calculateK(x1, y1, x2, y2);
//            var b = calculateB(x1, y1, k);
//            var minX = x2 > x1 ? x1 : x2;
//            var maxX = x1 >= x2 ? x1 : x2;
//            var xFrom = minX <= 0 ? 0 : minX;
//            var xTo = maxX >= Drawing.Width ? Drawing.Width : maxX;
//            for (var x = xFrom; x < xTo; x++)
//            {
//                var y = (int)(k * x + b);
//                if (y >= Drawing.Height || y < 0)
//                {
//                    continue;
//                }
//                Drawing.Canvas[x, y] = true;
//            }
//        }
//    }
//}
