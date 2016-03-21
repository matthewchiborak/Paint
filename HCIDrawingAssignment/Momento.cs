using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIDrawingAssignment
{
    class Momento
    {
        List<ShapeGraphic> canvasGraphicList;

        public Momento(List<ShapeGraphic> passedCanvasGraphicList)
        {
            canvasGraphicList = new List<ShapeGraphic>();
            foreach (var myGraphic in passedCanvasGraphicList)
            {
                canvasGraphicList.Add(myGraphic);
            }
        }

        public List<ShapeGraphic> getCanvasGraphicList()
        {
            return canvasGraphicList;
        }
    }
}
