using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class FreehandShape : ShapeGraphic
    {
        public FreehandShape(Color selectedColour, List<LineShape> passedFreehandLineList)
        {
            shapeColour = selectedColour;
            freehandLineList = passedFreehandLineList;
            type = "Freehand";
        }
    }
}
