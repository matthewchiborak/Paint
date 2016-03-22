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
                if (myGraphic.getShapeType() == "Freehand" || myGraphic.getShapeType() == "Polygon")
                {
                    List<LineShape> tempLineList = new List<LineShape>();
                    List<LineShape> passedLineList = myGraphic.getFreehandLineList();
                    foreach (var myLine in passedLineList)
                    {
                        tempLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                    }

                    if(myGraphic.getShapeType() == "Freehand")
                    {
                        canvasGraphicList.Add(new FreehandShape(myGraphic.getShapeColor(), tempLineList));
                    }
                    else if (myGraphic.getShapeType() == "Polygon")
                    {
                        canvasGraphicList.Add(new PolygonShape(myGraphic.getShapeColor(), tempLineList));
                    }
                }
                else
                {
                    if (myGraphic.getShapeType() == "Line")
                    {
                        canvasGraphicList.Add(new LineShape(myGraphic.getShapeColor(), myGraphic.getStartPoint(), myGraphic.getEndPoint()));
                    }
                    else if (myGraphic.getShapeType() == "Square")
                    {
                        canvasGraphicList.Add(new SquareShape(myGraphic.getShapeColor(), myGraphic.getStartPoint(), myGraphic.getEndPoint()));
                    }
                    else if (myGraphic.getShapeType() == "Rectangle")
                    {
                        canvasGraphicList.Add(new RectangleShape(myGraphic.getShapeColor(), myGraphic.getStartPoint(), myGraphic.getEndPoint()));
                    }
                    else if (myGraphic.getShapeType() == "Circle")
                    {
                        canvasGraphicList.Add(new CircleShape(myGraphic.getShapeColor(), myGraphic.getStartPoint(), myGraphic.getEndPoint()));
                    }
                    else if (myGraphic.getShapeType() == "Ellipse")
                    {
                        canvasGraphicList.Add(new EllipseShape(myGraphic.getShapeColor(), myGraphic.getStartPoint(), myGraphic.getEndPoint()));
                    }
                }
            }
        }

        public List<ShapeGraphic> getCanvasGraphicList()
        {
            return canvasGraphicList;
        }
    }
}
