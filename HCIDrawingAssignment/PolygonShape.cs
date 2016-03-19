using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class PolygonShape : ShapeGraphic
    {
        public PolygonShape(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            type = "Polygon";
        }

        public PolygonShape(Color selectedColour, List<LineShape> passedFreehandLineList)
        {
            shapeColour = selectedColour;
            freehandLineList = passedFreehandLineList;
            type = "Polygon";
        }
    }
}
