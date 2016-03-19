using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class ShapeGraphic
    {
        protected Color shapeColour;
        protected Point canvasPosition;
        protected ShapeGraphic childShapeGraphic;
        protected string type;
        public Point startPoint;
        public Point endPoint;
        public List<LineShape> freehandLineList;

        public ShapeGraphic()
        {
            childShapeGraphic = null;
        }

        public ShapeGraphic(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            childShapeGraphic = null;
        }

        public List<LineShape> getFreehandLineList()
        {
            return freehandLineList;
        }
        public string getShapeType()
        {
            return type;
        }

        public Point getStartPoint()
        {
            return startPoint;
        }
        public Point getEndPoint()
        {
            return endPoint;
        }
        public Color getShapeColor()
        {
            return shapeColour;
        }

        //Recursively find the child who doesn't have a child yet
        public void Pin(ShapeGraphic childToPin)
        {
            if (childToPin == null)
            {
                childShapeGraphic = childToPin;
            }
            else
            {
                childShapeGraphic.Pin(childToPin);
            }
        }

        //Check to see if child has a child
        public bool hasChild()
        {
            if(childShapeGraphic==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Recursively find the last child and separate it
        public ShapeGraphic Unpin()
        {
            if(childShapeGraphic.hasChild())
            {
                return childShapeGraphic.Unpin();
            }
            else
            {
                ShapeGraphic temp = childShapeGraphic;
                childShapeGraphic = null;
                return temp;
            }
        }

        //Draw function for the inherited
        public void draw()
        {

        }
    }
}
