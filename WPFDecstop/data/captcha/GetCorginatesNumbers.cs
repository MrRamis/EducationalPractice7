using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDecstop.data.captcha
{
    class GetCorginatesNumbers
    {

        public List<Point> getCorginatesNumbers(int number)
        {
            switch (number)
            {
                case 1: return new List<Point> {
                        new Point(20, 60),
                        new Point(70, 10),
                        new Point(70, 140),
                    };

                case 2: return new List<Point> {new Point(30, 40),  new Point(30, 20),  new Point(40, 10),  new Point(110, 10),  new Point(120, 20),  new Point(120, 40),  new Point(30, 130),  new Point(30, 140),  new Point(120, 140),  new Point(120, 130)};  
                case 3: 
                    return new List<Point> { new Point(30, 30), new Point(30, 20), new Point(40, 10),
                        new Point(100, 10), new Point(110, 20), new Point(110,
           60), new Point(100, 70), new Point(70, 70), new Point(70,70), new Point(100, 70), new Point(110, 80), new Point(110,30), new Point(100, 140), new Point(40, 140), new Point(30, 130), new Point(30, 110)};

                case 4: return new List<Point> { new Point(50, 80), new Point(120, 10), new Point(120, 10), new Point(120, 140), new Point(110, 140), new Point(130, 140), new Point(120, 140), new Point(120, 90), new Point(130, 90), new Point(50, 90), new Point(50, 80)}; 
                case 5: return new List<Point> { new Point(110, 10), new Point(30, 10), new Point(30, 40), new Point(40, 50), new Point(90, 50), new Point(110, 70), new Point(110, 120), new Point(90, 140), new Point(30, 140), new Point(30, 120)}; 
                case 6: return new List<Point> { new Point(120, 30), new Point(120, 20), new Point(110, 10), new Point(50, 10), new Point(40, 20), new Point(40, 130), new Point(50, 140), new Point(110, 140), new Point(120, 130), new Point(120, 90), new Point(110, 80), new Point(40, 80)}; 
                case 7: return new List<Point> { new Point(30, 20), new Point(30, 10), new Point(120, 10), new Point(120, 20), new Point(30, 110), new Point(30, 130)};
                case 8: return new List<Point> { new Point(40, 60), new Point(40, 30), new Point(50, 20), new Point(100, 20), new Point(110, 30), new Point(110, 60), new Point(100, 70), new Point(50, 70), new Point(40, 60), new Point(50, 70), new Point(40, 80), new Point(40, 120), new Point(50, 130), new Point(100, 130), new Point(110, 120), new Point(110, 80), new Point(100, 70)};
                case 9: return new List<Point> { new Point(100, 70), new Point(50, 70), new Point(40, 60), new Point(40, 30), new Point(50, 20), new Point(100, 20), new Point(110, 30), new Point(110, 60), new Point(100, 70), new Point(110, 80), new Point(110, 120), new Point(100, 130), new Point(50, 130), new Point(40, 120)};
                case 0: return new List<Point> { new Point(40, 30), new Point(50, 20), new Point(100, 20), new Point(110, 30), new Point(110, 120), new Point(100, 130), new Point(50, 130), new Point(40, 120), new Point(40, 30) };
                default: return new List<Point> { };
            }
        }
    }
}
