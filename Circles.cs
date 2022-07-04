using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectRPVS
{
    internal class Circles
    {
        internal static void DrawRecursiveCircle(Pen pen, Graphics e, int circles, int dept, float radius, float dec, float x, float y)
        { 
            e.DrawArc(pen, new RectangleF(x - radius, y - radius, radius * 2, radius * 2), 0, 360); 
            if (dept == 0)
                return;
            dept--;
            for (int i = 0; i < circles; i++)
            {
                float newx = (float)Math.Cos(2 * Math.PI * i / circles) * radius + x;
                float newy = (float)Math.Sin(2 * Math.PI * i / circles) * radius + y;
                /*
                circles - количество окружностей
                dept    - глубина рекурсиия
                radius  - радиус первой окружности
                dec     - коэффициент для последующих окружностей
                x,y     - координаты первой окружности 
                */
                DrawRecursiveCircle(pen, e, circles, dept, radius * dec, dec, newx, newy);
            }
        }
        
        internal static void ColorChoose(Pen pen)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            pen.Color = colorDialog.Color;
        }
    }
}
