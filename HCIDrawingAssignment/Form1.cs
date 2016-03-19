using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace HCIDrawingAssignment
{
    public partial class Form1 : Form
    {
        Graphics canvasGraphic;
        Pen drawingPen;
        Color selectedColor;
        Point startPosition;
        bool isDrawing;
        string currentMode;
        Image prevImage;
        bool firstPolygonPoint;

        //List<Graphics> canvasGraphicList;
        List<ShapeGraphic> canvasGraphicList;
        List<LineShape> freehandLineList;

        public Form1()
        {
            InitializeComponent();
            selectedColor = Color.Black;
            drawingPen = new Pen(selectedColor);
            startPosition = new Point(0, 0);
            isDrawing = false;
            currentMode = "Freehand";
            canvasGraphicList = new List<ShapeGraphic>();
            freehandLineList = new List<LineShape>();
            prevImage = canvasBox.Image;
            firstPolygonPoint = true;
        }

        private void freehandButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }

            isDrawing = true;
            redrawAllGraphics();
            isDrawing = false;

            currentMode = "Freehand";
            modeLabel.Text = "Freehand";
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Line";
            modeLabel.Text = "Line";
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Rectangle";
            modeLabel.Text = "Rectangle";
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Square";
            modeLabel.Text = "Square";
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Ellipse";
            modeLabel.Text = "Ellipse";
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Circle";
            modeLabel.Text = "Circle";
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Polygon";
            modeLabel.Text = "Polygon";
        }

        private void colourButton_Click(object sender, EventArgs e)
        {
            //Pop up the color choser
            //Set the color that was selected
            ColorDialog myDialog = new ColorDialog();
            myDialog.AllowFullOpen = false;
            myDialog.Color = selectedColor;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = myDialog.Color;
                drawingPen.Color = selectedColor;
                selectedColorBox.BackColor = selectedColor;
            }

        }

        private void selectButton_Click(object sender, EventArgs e)
        {

        }

        private void copyButton_Click(object sender, EventArgs e)
        {

        }

        private void cutButton_Click(object sender, EventArgs e)
        {

        }

        private void pasteButton_Click(object sender, EventArgs e)
        {

        }

        private void undoButton_Click(object sender, EventArgs e)
        {

        }

        private void redoButton_Click(object sender, EventArgs e)
        {

        }

        private void pinButton_Click(object sender, EventArgs e)
        {

        }

        private void unpinButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }

        private void canvasBox_Click(object sender, EventArgs e)
        {

        }

        private void canvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(currentMode == "Polygon")
            {
                if (!firstPolygonPoint)
                {
                    canvasGraphic = canvasBox.CreateGraphics();
                    canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                    freehandLineList.Add(new LineShape(selectedColor, startPosition, e.Location));
                }
                else
                {
                    firstPolygonPoint = false;
                }
            }

            startPosition = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                //Make it so will only draw while moving if the mouse if clicked
                isDrawing = true;
            }
        }

        private void canvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(currentMode != "Polygon")
            {
                isDrawing = false;
            }
            


            if (currentMode == "Freehand")
            {
                // canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                //freehandLineList.Add(new LineShape(selectedColor, startPosition, e.Location));
                canvasGraphicList.Add(new FreehandShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
            }
            if (currentMode == "Line")
            {
                //canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                canvasGraphicList.Add(new LineShape(selectedColor, startPosition, e.Location));
            }
            if (currentMode == "Rectangle" || currentMode == "Square")
            {
                Point tempStart = startPosition;
                Point tempEnd = e.Location;
                if (startPosition.X <= tempEnd.X)
                {
                    if (startPosition.Y <= tempEnd.Y)
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

                    if (startPosition.Y <= tempEnd.Y)
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
                //canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawRectangle(drawingPen, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);

                if (currentMode == "Square")
                {
                    tempEnd.Y = tempEnd.X;
                    canvasGraphicList.Add(new SquareShape(selectedColor, tempStart, tempEnd));
                }
                else if (currentMode == "Rectangle")
                {
                    canvasGraphicList.Add(new RectangleShape(selectedColor, tempStart, tempEnd));
                }
            }

            if (currentMode == "Ellipse" || currentMode == "Circle")
            {
                Point tempStart = startPosition;
                Point tempEnd = e.Location;
                if (startPosition.X <= tempEnd.X)
                {
                    if (startPosition.Y <= tempEnd.Y)
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

                    if (startPosition.Y <= tempEnd.Y)
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
                //canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawRectangle(drawingPen, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);

                if (currentMode == "Circle")
                {
                    tempEnd.Y = tempEnd.X;
                    canvasGraphicList.Add(new CircleShape(selectedColor, tempStart, tempEnd));
                }
                else if (currentMode == "Ellipse")
                {
                    canvasGraphicList.Add(new EllipseShape(selectedColor, tempStart, tempEnd));
                }
            }

            //Commit
            //prevImage = canvasBox.Image;
        }

        private void canvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMode == "Freehand")
            {
                if (isDrawing)
                {
                    //Draw on the canvas
                    canvasGraphic = canvasBox.CreateGraphics();
                    canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                    freehandLineList.Add(new LineShape(selectedColor, startPosition, e.Location));
                }
                //Reset the start position
                startPosition = e.Location;
            }
            else if (currentMode == "Polygon")
            {
                if (isDrawing)
                {
                    redrawAllGraphics();
                    //Draw on the canvas
                    canvasGraphic = canvasBox.CreateGraphics();
                    canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                }
            }
            else if (currentMode == "Line")
            {
                if (isDrawing)
                {
                    //Refresh the canvas
                    redrawAllGraphics();
                    //canvasBox.Image = prevImage;

                    //Draw on the canvas
                    canvasGraphic = canvasBox.CreateGraphics();
                    canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                }
            }
            else if (currentMode == "Rectangle" || currentMode == "Square")
            {
                if (isDrawing)
                {
                    //Refresh the canvas
                    redrawAllGraphics();
                    //canvasBox.Image = prevImage;

                    canvasGraphic = canvasBox.CreateGraphics();
                    Point tempStart = startPosition;
                    Point tempEnd = e.Location;
                    if (startPosition.X <= tempEnd.X)
                    {
                        if (startPosition.Y <= tempEnd.Y)
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

                        if (startPosition.Y <= tempEnd.Y)
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
                    SolidBrush tempBrush = new SolidBrush(selectedColor);
                    if (currentMode == "Rectangle")
                    {
                        canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                    }
                    else if(currentMode == "Square")
                    {
                        canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.X - tempStart.X);
                    }
                }
            }
            else if (currentMode == "Ellipse" || currentMode == "Circle")
            {
                if (isDrawing)
                {
                    //Refresh the canvas
                    redrawAllGraphics();
                    //canvasBox.Image = prevImage;

                    canvasGraphic = canvasBox.CreateGraphics();
                    Point tempStart = startPosition;
                    Point tempEnd = e.Location;
                    if (startPosition.X <= tempEnd.X)
                    {
                        if (startPosition.Y <= tempEnd.Y)
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

                        if (startPosition.Y <= tempEnd.Y)
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
                    SolidBrush tempBrush = new SolidBrush(selectedColor);
                    if (currentMode == "Ellipse")
                    {
                        canvasGraphic.FillEllipse(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                    }
                    else if (currentMode == "Circle")
                    {
                        canvasGraphic.FillEllipse(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.X - tempStart.X);
                    }
                }
            }

        }
        

        private void redrawAllGraphics()
        {
            if (isDrawing && currentMode!="Freehand")
            {
                //Clear the canvas
                //canvasBox.Invalidate();
                if (canvasGraphic != null)
                {
                    canvasGraphic.Clear(Color.White);
                }

                //Redraw all the objects
                foreach (var myGraphic in canvasGraphicList)
                {
                    if (myGraphic.getShapeType() == "Freehand")
                    {
                        List<LineShape> tempFreehandLineList = myGraphic.getFreehandLineList();
                        foreach (var myLine in tempFreehandLineList)
                        {
                            canvasGraphic = canvasBox.CreateGraphics();
                            Pen tempPen = new Pen(myGraphic.getShapeColor());
                            canvasGraphic.DrawLine(tempPen, myLine.getStartPoint(), myLine.getEndPoint());
                        }

                    }
                    else if (myGraphic.getShapeType() == "Polygon")
                    {
                        List<LineShape> tempFreehandLineList = myGraphic.getFreehandLineList();
                        foreach (var myLine in tempFreehandLineList)
                        {
                            canvasGraphic = canvasBox.CreateGraphics();
                            Pen tempPen = new Pen(myGraphic.getShapeColor());
                            canvasGraphic.DrawLine(tempPen, myLine.getStartPoint(), myLine.getEndPoint());
                        }

                    }
                    else if (myGraphic.getShapeType() == "Line")
                    {
                        canvasGraphic = canvasBox.CreateGraphics();
                        Pen tempPen = new Pen(myGraphic.getShapeColor());
                        canvasGraphic.DrawLine(tempPen, myGraphic.getStartPoint(), myGraphic.getEndPoint());
                    }
                    else if (myGraphic.getShapeType() == "Rectangle" || myGraphic.getShapeType() == "Square")
                    {
                        canvasGraphic = canvasBox.CreateGraphics();
                        Pen tempPen = new Pen(myGraphic.getShapeColor());
                        Point tempStart = myGraphic.getStartPoint();
                        Point tempEnd = myGraphic.getEndPoint();
                        //canvasGraphic.DrawRectangle(tempPen, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        SolidBrush tempBrush = new SolidBrush(myGraphic.getShapeColor());

                        if (myGraphic.getShapeType() == "Square")
                        {
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.X - tempStart.X);
                        }
                        else if (myGraphic.getShapeType() == "Rectangle")
                        {
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                    }
                    else if (myGraphic.getShapeType() == "Ellipse" || myGraphic.getShapeType() == "Circle")
                    {
                        canvasGraphic = canvasBox.CreateGraphics();
                        Pen tempPen = new Pen(myGraphic.getShapeColor());
                        Point tempStart = myGraphic.getStartPoint();
                        Point tempEnd = myGraphic.getEndPoint();
                        //canvasGraphic.DrawRectangle(tempPen, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        SolidBrush tempBrush = new SolidBrush(myGraphic.getShapeColor());

                        if (myGraphic.getShapeType() == "Circle")
                        {
                            canvasGraphic.FillEllipse(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.X - tempStart.X);
                        }
                        else if (myGraphic.getShapeType() == "Ellipse")
                        {
                            canvasGraphic.FillEllipse(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                    }
                }

                //If in polygon redraw the currently draw lines
                if(currentMode == "Polygon")
                {
                    foreach (var myLine in freehandLineList)
                    {
                        canvasGraphic = canvasBox.CreateGraphics();
                        Pen tempPen = new Pen(myLine.getShapeColor());
                        canvasGraphic.DrawLine(tempPen, myLine.getStartPoint(), myLine.getEndPoint());
                    }
                }
            }
        }

        private void selectedColorBox_Click(object sender, EventArgs e)
        {
            //Pop up the color choser
            //Set the color that was selected
            ColorDialog myDialog = new ColorDialog();
            myDialog.AllowFullOpen = false;
            myDialog.Color = selectedColor;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = myDialog.Color;
                drawingPen.Color = selectedColor;
                selectedColorBox.BackColor = selectedColor;
            }
        }
    }
}
