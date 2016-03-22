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

        public void moveToHere(Point location)
        {
            endPoint.X = (endPoint.X - startPoint.X) + location.X;
            endPoint.Y = (endPoint.Y - startPoint.Y) + location.Y;
            startPoint.X = location.X;
            startPoint.Y = location.Y;
        }
        public void translate(Point displacement)
        {
            startPoint.X = startPoint.X + displacement.X; 
            startPoint.Y = startPoint.Y + displacement.Y;
            endPoint.X = endPoint.X + displacement.X;
            endPoint.Y = endPoint.Y + displacement.Y;
        }

        public void movePolygonOrFreehandToHere(Point location)
        {
            Point displacement = new Point(location.X - startPoint.X, location.Y - startPoint.Y);

            foreach(var myLine in freehandLineList)
            {
                myLine.translate(displacement);
            }
            startPoint.X = location.X ;
            startPoint.Y = location.Y;
            endPoint.X = endPoint.X + displacement.X;
            endPoint.Y = endPoint.Y + displacement.Y;
        }

        public bool checkIfCursorOn(Point location)
        {
            Point tempStart = startPoint;
            Point tempEnd = endPoint;
            if (startPoint.X <= tempEnd.X)
            {
                if (startPoint.Y <= tempEnd.Y)
                {
                    //Everything is fine
                }
                else //start is lower on screen than the end
                {
                    //Flip the y's
                    int tempY = tempStart.Y;
                    tempStart.Y = tempEnd.Y;
                    tempEnd.Y = tempY;
                }
            }
            else //start x > end x
            {
                //Flip the x's
                int tempX = tempStart.X;
                tempStart.X = tempEnd.X;
                tempEnd.X = tempX;

                if (startPoint.Y <= tempEnd.Y)
                {
                    //Its good
                }
                else
                {
                    //Flip the y's
                    int tempY = tempStart.Y;
                    tempStart.Y = tempEnd.Y;
                    tempEnd.Y = tempY;
                }
            }

            if (location.X > tempStart.X && location.X < tempEnd.X && location.Y > tempStart.Y && location.Y < tempEnd.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
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
