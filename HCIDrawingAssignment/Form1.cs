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
using System.IO;

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
        int selectedIndex;
        bool selectNotFound;

        Caretaker shapeCaretaker;
        
        List<ShapeGraphic> canvasGraphicList;
        List<LineShape> freehandLineList;

        ShapeGraphic copiedGraphic;

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
            shapeCaretaker = new Caretaker();
            selectedIndex = -1;
            selectNotFound = true;
        }

        private void freehandButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
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
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }
            currentMode = "Select";
            modeLabel.Text = "Select";
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }

            if (canvasGraphicList.Any() && selectedIndex >= 0)
            {
                copiedGraphic = canvasGraphicList.ElementAt(selectedIndex);

                currentMode = "Select";
                modeLabel.Text = selectedIndex + " Copied";
            }
        }

        private void cutChildFirst(ShapeGraphic parent)
        {
            if(parent.hasChild())
            {
                cutChild(parent.getChild());
            }
        }
        private void cutChild(ShapeGraphic parent)
        {
            if (parent.hasChild())
            {
                cutChild(parent.getChild());
            }
            canvasGraphicList.Remove(parent);
        }
        private void cutParentFirst(ShapeGraphic child)
        {
            if (child.hasParent())
            {
                cutParent(child.getParent());
            }
        }
        private void cutParent(ShapeGraphic child)
        {
            if (child.hasParent())
            {
                cutParent(child.getParent());
            }
            canvasGraphicList.Remove(child);
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }

            if (canvasGraphicList.Any() && selectedIndex >= 0)
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                copiedGraphic = canvasGraphicList.ElementAt(selectedIndex);

                cutParentFirst(copiedGraphic);
                cutChildFirst(copiedGraphic);

                canvasGraphicList.RemoveAt(selectedIndex);
                currentMode = "Select";
                modeLabel.Text = selectedIndex + " Cut";
                isDrawing = true;
                redrawAllGraphics();
                isDrawing = false;
                selectedIndex = -1;
            }
        }

        private ShapeGraphic pasteChild(ShapeGraphic copiedParent, ShapeGraphic newParent)
        {
            ShapeGraphic newShape = null;

            
                //Create the shape
                if (copiedParent.getChild().getShapeType() == "Freehand")
                {
                    //Get the lines
                    freehandLineList = new List<LineShape>();
                    List<LineShape> tempLineList = copiedParent.getFreehandLineList();

                    foreach (var myLine in tempLineList)
                    {
                        freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                    }

                    newShape = new FreehandShape(copiedParent.getShapeColor(), freehandLineList);
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.movePolygonOrFreehandToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                if (copiedParent.getChild().hasChild())
                {
                    newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                }
                freehandLineList = new List<LineShape>();

                }
                if (copiedParent.getShapeType() == "Line")
                {
                    newShape = new LineShape(copiedParent.getShapeColor(), copiedParent.getStartPoint(), copiedParent.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.moveToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedParent.getChild().hasChild())
                    {
                        newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                    }
                }
                if (copiedParent.getShapeType() == "Rectangle" || copiedParent.getShapeType() == "Square")
                {
                    

                    if (copiedParent.getShapeType() == "Square")
                    {
                        newShape = new SquareShape(copiedParent.getShapeColor(), copiedParent.getStartPoint(), copiedParent.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        newShape.moveToHere(midScreen);
                        canvasGraphicList.Add(newShape);
                        if (copiedParent.getChild().hasChild())
                        {
                            newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                        }
                }
                    else if (copiedParent.getShapeType() == "Rectangle")
                    {
                        newShape = new RectangleShape(copiedParent.getShapeColor(), copiedParent.getStartPoint(), copiedParent.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        newShape.moveToHere(midScreen);
                        canvasGraphicList.Add(newShape);
                        if (copiedParent.getChild().hasChild())
                        {
                            newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                        }
                }

                    
                }

                if (copiedParent.getShapeType() == "Ellipse" || copiedParent.getShapeType() == "Circle")
                {
                

                    if (copiedParent.getShapeType() == "Circle")
                    {
                        newShape = new CircleShape(copiedParent.getShapeColor(), copiedParent.getStartPoint(), copiedParent.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        newShape.moveToHere(midScreen);
                        canvasGraphicList.Add(newShape);
                        if (copiedParent.getChild().hasChild())
                        {
                            newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                        }
                }
                    else if (copiedParent.getShapeType() == "Ellipse")
                    {
                        newShape = new EllipseShape(copiedParent.getShapeColor(), copiedParent.getStartPoint(), copiedParent.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        newShape.moveToHere(midScreen);
                        canvasGraphicList.Add(newShape);
                        if (copiedParent.getChild().hasChild())
                        {
                            newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                        }
                }
                    
                }
                if (copiedParent.getShapeType() == "Polygon")
                {
                    //Get the lines
                    freehandLineList = new List<LineShape>();
                    List<LineShape> tempLineList = copiedParent.getFreehandLineList();

                    foreach (var myLine in tempLineList)
                    {
                        freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                    }

                    newShape = new PolygonShape(copiedParent.getShapeColor(), freehandLineList);
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.movePolygonOrFreehandToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedParent.getChild().hasChild())
                    {
                        newShape.giveChild(pasteChild(copiedParent.getChild(), newShape));
                    }
                freehandLineList = new List<LineShape>();
                    
                }
                

            

            //return the shape
            return newShape;
        }
        private ShapeGraphic pasteParent(ShapeGraphic copiedChild, ShapeGraphic newChild)
        {
            ShapeGraphic newShape = null;


            //Create the shape
            if (copiedChild.getParent().getShapeType() == "Freehand")
            {
                //Get the lines
                freehandLineList = new List<LineShape>();
                List<LineShape> tempLineList = copiedChild.getFreehandLineList();

                foreach (var myLine in tempLineList)
                {
                    freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                }

                newShape = new FreehandShape(copiedChild.getShapeColor(), freehandLineList);
                Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                newShape.movePolygonOrFreehandToHere(midScreen);
                canvasGraphicList.Add(newShape);
                if (copiedChild.getParent().hasParent())
                {
                    newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                }
                freehandLineList = new List<LineShape>();

            }
            if (copiedChild.getShapeType() == "Line")
            {
                newShape = new LineShape(copiedChild.getShapeColor(), copiedChild.getStartPoint(), copiedChild.getEndPoint());
                Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                newShape.moveToHere(midScreen);
                canvasGraphicList.Add(newShape);
                if (copiedChild.getParent().hasParent())
                {
                    newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                }
            }
            if (copiedChild.getShapeType() == "Rectangle" || copiedChild.getShapeType() == "Square")
            {


                if (copiedChild.getShapeType() == "Square")
                {
                    newShape = new SquareShape(copiedChild.getShapeColor(), copiedChild.getStartPoint(), copiedChild.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.moveToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedChild.getParent().hasParent())
                    {
                        newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                    }
                }
                else if (copiedChild.getShapeType() == "Rectangle")
                {
                    newShape = new RectangleShape(copiedChild.getShapeColor(), copiedChild.getStartPoint(), copiedChild.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.moveToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedChild.getParent().hasParent())
                    {
                        newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                    }
                }


            }

            if (copiedChild.getShapeType() == "Ellipse" || copiedChild.getShapeType() == "Circle")
            {


                if (copiedChild.getShapeType() == "Circle")
                {
                    newShape = new CircleShape(copiedChild.getShapeColor(), copiedChild.getStartPoint(), copiedChild.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.moveToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedChild.getParent().hasParent())
                    {
                        newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                    }
                }
                else if (copiedChild.getShapeType() == "Ellipse")
                {
                    newShape = new EllipseShape(copiedChild.getShapeColor(), copiedChild.getStartPoint(), copiedChild.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    newShape.moveToHere(midScreen);
                    canvasGraphicList.Add(newShape);
                    if (copiedChild.getParent().hasParent())
                    {
                        newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                    }
                }

            }
            if (copiedChild.getShapeType() == "Polygon")
            {
                //Get the lines
                freehandLineList = new List<LineShape>();
                List<LineShape> tempLineList = copiedChild.getFreehandLineList();

                foreach (var myLine in tempLineList)
                {
                    freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                }

                newShape = new PolygonShape(copiedChild.getShapeColor(), freehandLineList);
                Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                newShape.movePolygonOrFreehandToHere(midScreen);
                canvasGraphicList.Add(newShape);
                if (copiedChild.getParent().hasParent())
                {
                    newShape.giveParent(pasteParent(copiedChild.getParent(), newShape));
                }
                freehandLineList = new List<LineShape>();

            }




            //return the shape
            return newShape;
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }

            if (currentMode == "Freehand")
            {
                currentMode = "Paste";
            }

            if(copiedGraphic != null)
            {
                if (copiedGraphic.getShapeType() == "Freehand")
                {
                    //Create the momento
                    shapeCaretaker.add(new Momento(canvasGraphicList));
                    //Get the lines
                    freehandLineList = new List<LineShape>();
                    List<LineShape> tempLineList = copiedGraphic.getFreehandLineList();

                    foreach(var myLine in tempLineList)
                    {
                        freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                    }

                    FreehandShape tempShape = new FreehandShape(copiedGraphic.getShapeColor(), freehandLineList);
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    tempShape.movePolygonOrFreehandToHere(midScreen);
                    
                    if(copiedGraphic.hasChild())
                    {
                        tempShape.giveChild(pasteChild(copiedGraphic, tempShape));
                    }
                    if(copiedGraphic.hasParent())
                    {
                        tempShape.giveParent(pasteParent(copiedGraphic, tempShape));
                    }
                    canvasGraphicList.Add(tempShape);
                    
                    freehandLineList = new List<LineShape>();
                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;

                }
                if (copiedGraphic.getShapeType() == "Line")
                {
                    shapeCaretaker.add(new Momento(canvasGraphicList));
                    LineShape tempLine = new LineShape(copiedGraphic.getShapeColor(), copiedGraphic.getStartPoint(), copiedGraphic.getEndPoint());
                    Point midScreen = new Point(canvasBox.Width/2,canvasBox.Height/2);
                    tempLine.moveToHere(midScreen);
                    canvasGraphicList.Add(tempLine);
                    pasteChild(copiedGraphic, tempLine);
                    pasteParent(copiedGraphic, tempLine);
                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;
                }
                if (copiedGraphic.getShapeType() == "Rectangle" || copiedGraphic.getShapeType() == "Square")
                {
                    shapeCaretaker.add(new Momento(canvasGraphicList));

                    if (copiedGraphic.getShapeType() == "Square")
                    {
                        SquareShape tempShape = new SquareShape(copiedGraphic.getShapeColor(), copiedGraphic.getStartPoint(), copiedGraphic.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        tempShape.moveToHere(midScreen);
                        canvasGraphicList.Add(tempShape);
                        pasteChild(copiedGraphic, tempShape);
                        pasteParent(copiedGraphic, tempShape);
                    }
                    else if (copiedGraphic.getShapeType() == "Rectangle")
                    {
                        RectangleShape tempShape = new RectangleShape(copiedGraphic.getShapeColor(), copiedGraphic.getStartPoint(), copiedGraphic.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        tempShape.moveToHere(midScreen);
                        canvasGraphicList.Add(tempShape);
                        pasteChild(copiedGraphic, tempShape);
                        pasteParent(copiedGraphic, tempShape);
                    }

                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;
                }

                if (copiedGraphic.getShapeType() == "Ellipse" || copiedGraphic.getShapeType() == "Circle")
                {
                   
                    shapeCaretaker.add(new Momento(canvasGraphicList));

                    if (copiedGraphic.getShapeType() == "Circle")
                    {
                        CircleShape tempShape = new CircleShape(copiedGraphic.getShapeColor(), copiedGraphic.getStartPoint(), copiedGraphic.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        tempShape.moveToHere(midScreen);
                        canvasGraphicList.Add(tempShape);
                        pasteChild(copiedGraphic, tempShape);
                        pasteParent(copiedGraphic, tempShape);
                    }
                    else if (copiedGraphic.getShapeType() == "Ellipse")
                    {
                        EllipseShape tempShape = new EllipseShape(copiedGraphic.getShapeColor(), copiedGraphic.getStartPoint(), copiedGraphic.getEndPoint());
                        Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                        tempShape.moveToHere(midScreen);
                        canvasGraphicList.Add(tempShape);
                        pasteChild(copiedGraphic, tempShape);
                        pasteParent(copiedGraphic, tempShape);
                    }
                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;
                }
                if (copiedGraphic.getShapeType() == "Polygon")
                {
                    //Create the momento
                    shapeCaretaker.add(new Momento(canvasGraphicList));
                    //Get the lines
                    freehandLineList = new List<LineShape>();
                    List<LineShape> tempLineList = copiedGraphic.getFreehandLineList();

                    foreach (var myLine in tempLineList)
                    {
                        freehandLineList.Add(new LineShape(myLine.getShapeColor(), myLine.getStartPoint(), myLine.getEndPoint()));
                    }

                    PolygonShape tempShape = new PolygonShape(copiedGraphic.getShapeColor(), freehandLineList);
                    Point midScreen = new Point(canvasBox.Width / 2, canvasBox.Height / 2);
                    tempShape.movePolygonOrFreehandToHere(midScreen);
                    canvasGraphicList.Add(tempShape);
                    pasteChild(copiedGraphic, tempShape);
                    pasteParent(copiedGraphic, tempShape);
                    freehandLineList = new List<LineShape>();
                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;
                }
            }

            if (currentMode == "Paste")
            {
                currentMode = "Freehand";
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (shapeCaretaker.checkIfCanUndo())
            {
                List<ShapeGraphic> tempList = shapeCaretaker.undo(new Momento(canvasGraphicList)).getCanvasGraphicList();
                canvasGraphicList = new List<ShapeGraphic>();
                foreach (var myGraphic in tempList)
                {
                    canvasGraphicList.Add(myGraphic);
                }
                isDrawing = true;
                redrawAllGraphics();
                isDrawing = false;
            }
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            if (shapeCaretaker.checkIfCanRedo())
            {
                List<ShapeGraphic> tempList = shapeCaretaker.redo().getCanvasGraphicList();
                canvasGraphicList = new List<ShapeGraphic>();
                foreach (var myGraphic in tempList)
                {
                    canvasGraphicList.Add(myGraphic);
                }
                isDrawing = true;
                redrawAllGraphics();
                isDrawing = false;
            }
        }

        private void pinButton_Click(object sender, EventArgs e)
        {
            if (currentMode == "Polygon")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new PolygonShape(selectedColor, freehandLineList));
                redrawAllGraphics();
                freehandLineList = new List<LineShape>();
                isDrawing = false;
                firstPolygonPoint = true;
            }

            if (selectedIndex >= 0)
            {
                currentMode = "Pin";
                modeLabel.Text = "Pin";
            }
        }

        private void unpinButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            drawingSaveDialog.ShowDialog();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string fileContent = "";

            OpenFileDialog drawingOpenFileDialog = new OpenFileDialog();
            drawingOpenDialog.Filter = "Text Files (.txt)|*.txt";
            drawingOpenDialog.FilterIndex = 0;

            if(drawingOpenDialog.ShowDialog() == DialogResult.OK)
            {
                string wantedFile = drawingOpenDialog.FileName;

                fileContent = File.ReadAllText(wantedFile);

                //Split with the lines
                string[] shapeLines = fileContent.Split('\n');
                string mode = "Type";
                canvasGraphicList = new List<ShapeGraphic>();
                freehandLineList = new List<LineShape>();
                Color readColor = Color.FromName("Black");
                Point readSP;
                Point readEP;

                foreach (string shapeEntry in shapeLines)
                {
                    if(mode == "Type")
                    {
                        mode = shapeEntry;
                    }
                    else if(mode == "Pin")
                    {
                        //Split up the line containing the child and parent information
                        string[] childParentInfo = shapeEntry.Split(',');

                        //Assign the shapes their parents and children
                        int currentInfoIndex = 0;
                        foreach (var graphicNeedingRelation in canvasGraphicList)
                        {
                            string[] childAndParent = childParentInfo[currentInfoIndex].Split(' ');
                            if(childAndParent[0] != "null")
                            {
                                graphicNeedingRelation.giveChild(canvasGraphicList.ElementAt(Int32.Parse(childAndParent[0])));
                            }
                            if (childAndParent[1] != "null")
                            {
                                graphicNeedingRelation.giveParent(canvasGraphicList.ElementAt(Int32.Parse(childAndParent[1])));
                            }

                            currentInfoIndex++;
                        }
                    }
                    else if(mode == "Freehand")
                    {
                        if(shapeEntry == "FreehandDone")
                        {
                            mode = "Type";
                            canvasGraphicList.Add(new FreehandShape(readColor, freehandLineList));
                            freehandLineList = new List<LineShape>();
                        }
                        else
                        {
                            string[] shapeStats = shapeEntry.Split(',');
                            //readColor = Color.FromName(shapeStats[0]);
                            readColor = ColorTranslator.FromHtml(shapeStats[0]);
                            readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                            readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                            freehandLineList.Add(new LineShape(readColor, readSP, readEP));
                        }
                    }
                    else if (mode == "Polygon")
                    {
                        if (shapeEntry == "PolygonDone")
                        {
                            mode = "Type";
                            canvasGraphicList.Add(new PolygonShape(readColor, freehandLineList));
                            freehandLineList = new List<LineShape>();
                        }
                        else
                        {
                            string[] shapeStats = shapeEntry.Split(',');
                            readColor = ColorTranslator.FromHtml(shapeStats[0]);
                            readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                            readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                            freehandLineList.Add(new LineShape(readColor, readSP, readEP));
                        }
                    }
                    else if (mode == "Line")
                    {
                        string[] shapeStats = shapeEntry.Split(',');
                        readColor = ColorTranslator.FromHtml(shapeStats[0]);
                        readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                        readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                        mode = "Type";
                        canvasGraphicList.Add(new LineShape(readColor, readSP, readEP));
                    }
                    else if (mode == "Rectangle")
                    {
                        string[] shapeStats = shapeEntry.Split(',');
                        readColor = ColorTranslator.FromHtml(shapeStats[0]);
                        readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                        readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                        mode = "Type";
                        canvasGraphicList.Add(new RectangleShape(readColor, readSP, readEP));
                    }
                    else if (mode == "Square")
                    {
                        string[] shapeStats = shapeEntry.Split(',');
                        readColor = ColorTranslator.FromHtml(shapeStats[0]);
                        readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                        readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                        mode = "Type";
                        canvasGraphicList.Add(new SquareShape(readColor, readSP, readEP));
                    }
                    else if (mode == "Ellipse")
                    {
                        string[] shapeStats = shapeEntry.Split(',');
                        readColor = ColorTranslator.FromHtml(shapeStats[0]);
                        readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                        readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                        mode = "Type";
                        canvasGraphicList.Add(new EllipseShape(readColor, readSP, readEP));
                    }
                    else if (mode == "Circle")
                    {
                        string[] shapeStats = shapeEntry.Split(',');
                        readColor = ColorTranslator.FromHtml(shapeStats[0]);
                        readSP = new Point(Int32.Parse(shapeStats[1]), Int32.Parse(shapeStats[2]));
                        readEP = new Point(Int32.Parse(shapeStats[3]), Int32.Parse(shapeStats[4]));
                        mode = "Type";
                        canvasGraphicList.Add(new CircleShape(readColor, readSP, readEP));
                    }
                }

                //Redraw all the objects
                isDrawing = true;
                if(currentMode == "Freehand")
                {
                    currentMode = "Loading";
                }
                redrawAllGraphics();
                if(currentMode == "Loading")
                {
                    currentMode = "Freehand";
                }
                isDrawing = false;
            }
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

            if(currentMode == "Pin")
            {
                if (selectedIndex >= 0)
                {
                    shapeCaretaker.add(new Momento(canvasGraphicList));
                    copiedGraphic = canvasGraphicList.ElementAt(selectedIndex);
                    canvasGraphicList.RemoveAt(selectedIndex);

                    int wantedIndex = 0;
                    foreach (var myGraphic in canvasGraphicList)
                    {
                        if (myGraphic.checkIfCursorOn(e.Location) && wantedIndex != selectedIndex)
                        {
                            canvasGraphicList.ElementAt(selectedIndex).Pin(myGraphic);
                            currentMode = "Select";
                            modeLabel.Text = "Shapes Pinned";
                            break;
                        }
                        else
                        {
                            wantedIndex++;
                        }
                    }
                    
                    isDrawing = true;
                    redrawAllGraphics();
                    isDrawing = false;
                    selectedIndex = -1;
                }
            }
            if (currentMode == "Select")
            {
                if (isDrawing)
                {
                    if (selectNotFound)
                    {
                        int wantedIndex = 0;
                        foreach (var myGraphic in canvasGraphicList)
                        {
                            if (myGraphic.checkIfCursorOn(e.Location))
                            {
                                shapeCaretaker.add(new Momento(canvasGraphicList));
                                selectedIndex = wantedIndex;
                                selectedLabel.Text = selectedIndex.ToString();
                                selectNotFound = false;
                            }
                            else
                            {
                                wantedIndex++;
                            }
                        }
                    }
                }
            }
        }

        private void canvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(currentMode != "Polygon")
            {
                isDrawing = false;
            }
            

            if(currentMode == "Select")
            {
                shapeCaretaker.add(new Momento(canvasGraphicList));
                selectNotFound = true;
                redrawAllGraphics();
            }
            if (currentMode == "Freehand")
            {
                // canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                //freehandLineList.Add(new LineShape(selectedColor, startPosition, e.Location));

                //Create the momento
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new FreehandShape(selectedColor, freehandLineList));
                freehandLineList = new List<LineShape>();
                redrawAllGraphics();

            }
            if (currentMode == "Line")
            {
                //canvasGraphic = canvasBox.CreateGraphics();
                //canvasGraphic.DrawLine(drawingPen, startPosition, e.Location);
                shapeCaretaker.add(new Momento(canvasGraphicList));
                canvasGraphicList.Add(new LineShape(selectedColor, startPosition, e.Location));
                redrawAllGraphics();

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

                shapeCaretaker.add(new Momento(canvasGraphicList));

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

                shapeCaretaker.add(new Momento(canvasGraphicList));

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
            if(currentMode == "Select")
            {
                if (isDrawing)
                {
                    if (selectNotFound)
                    {
                        int wantedIndex = 0;
                        foreach (var myGraphic in canvasGraphicList)
                        {
                            if (myGraphic.checkIfCursorOn(e.Location))
                            {
                                selectedIndex = wantedIndex;
                                selectedLabel.Text = selectedIndex.ToString();
                                selectNotFound = false;
                            }
                            else
                            {
                                wantedIndex++;
                            }
                        }
                    }
                    else
                    {
                        if (canvasGraphicList.ElementAt(selectedIndex).getShapeType() == "Freehand" || canvasGraphicList.ElementAt(selectedIndex).getShapeType() == "Polygon")
                        {
                            canvasGraphicList.ElementAt(selectedIndex).movePolygonOrFreehandToHere(e.Location);
                        }
                        else
                        {
                            canvasGraphicList.ElementAt(selectedIndex).moveToHere(e.Location);
                        }
                        redrawAllGraphics();
                    }
                }
            }
            else if (currentMode == "Freehand")
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

        private void drawingSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            string pictureName = drawingSaveDialog.FileName;
            string fileContent = "";

            //Assign Id to each
            int idToAssign = 0;
            foreach (var myGraphic in canvasGraphicList)
            {
                myGraphic.assignId(idToAssign);
                idToAssign++;
            }

            foreach (var myGraphic in canvasGraphicList)
            {
                if (myGraphic.getShapeType() == "Freehand")
                {
                    fileContent = fileContent + "Freehand\n";

                    List<LineShape> tempFreehandLineList = myGraphic.getFreehandLineList();
                    foreach (var myLine in tempFreehandLineList)
                    {
                        //string colorName = myLine.getShapeColor().Name;
                        //string[] leftSplit = colorName.Split('[');
                        //string[] rightSplit = leftSplit[1].Split(']');
                        string hexColor = "#" + myLine.getShapeColor().R.ToString("X2") + myLine.getShapeColor().G.ToString("X2") + myLine.getShapeColor().B.ToString("X2");
                        fileContent = fileContent + hexColor + "," + myLine.getStartPoint().X.ToString() + "," + myLine.getStartPoint().Y.ToString() + "," + myLine.getEndPoint().X.ToString() + "," + myLine.getEndPoint().Y.ToString() + "\n";
                    }

                    fileContent = fileContent + "FreehandDone\n";
                }
                else if (myGraphic.getShapeType() == "Polygon")
                {
                    fileContent = fileContent + "Polygon\n";

                    List<LineShape> tempFreehandLineList = myGraphic.getFreehandLineList();
                    foreach (var myLine in tempFreehandLineList)
                    {
                        //string colorName = myLine.getShapeColor().Name;
                        //string[] leftSplit = colorName.Split('[');
                        string hexColor = "#" + myLine.getShapeColor().R.ToString("X2") + myLine.getShapeColor().G.ToString("X2") + myLine.getShapeColor().B.ToString("X2");

                        fileContent = fileContent + hexColor + "," + myLine.getStartPoint().X.ToString() + "," + myLine.getStartPoint().Y.ToString() + "," + myLine.getEndPoint().X.ToString() + "," + myLine.getEndPoint().Y.ToString() + "\n";
                    }

                    fileContent = fileContent + "PolygonDone\n";

                }
                else if (myGraphic.getShapeType() == "Line")
                {
                    fileContent = fileContent + "Line\n";
                    //string colorName = myGraphic.getShapeColor().Name;
                    //string[] leftSplit = colorName.Split('[');
                    string hexColor = "#" + myGraphic.getShapeColor().R.ToString("X2") + myGraphic.getShapeColor().G.ToString("X2") + myGraphic.getShapeColor().B.ToString("X2");

                    fileContent = fileContent + hexColor + "," + myGraphic.getStartPoint().X.ToString() + "," + myGraphic.getStartPoint().Y.ToString() + "," + myGraphic.getEndPoint().X.ToString() + "," + myGraphic.getEndPoint().Y.ToString() + "\n";
                }
                else if (myGraphic.getShapeType() == "Rectangle" || myGraphic.getShapeType() == "Square")
                {
                    if (myGraphic.getShapeType() == "Square")
                    {
                        fileContent = fileContent + "Square\n";
                    }
                    else if (myGraphic.getShapeType() == "Rectangle")
                    {
                        fileContent = fileContent + "Rectangle\n";
                    }

                    //string colorName = myGraphic.getShapeColor().Name;
                    //string[] leftSplit = colorName.Split('[');
                    string hexColor = "#" + myGraphic.getShapeColor().R.ToString("X2") + myGraphic.getShapeColor().G.ToString("X2") + myGraphic.getShapeColor().B.ToString("X2");

                    fileContent = fileContent + hexColor + "," + myGraphic.getStartPoint().X.ToString() + "," + myGraphic.getStartPoint().Y.ToString() + "," + myGraphic.getEndPoint().X.ToString() + "," + myGraphic.getEndPoint().Y.ToString() + "\n";
                }
                else if (myGraphic.getShapeType() == "Ellipse" || myGraphic.getShapeType() == "Circle")
                {
                    if (myGraphic.getShapeType() == "Circle")
                    {
                        fileContent = fileContent + "Circle\n";
                    }
                    else if (myGraphic.getShapeType() == "Ellipse")
                    {
                        fileContent = fileContent + "Ellipse\n";
                    }
                    //string colorName = myGraphic.getShapeColor().Name;
                    //string[] leftSplit = colorName.Split('[');
                    string hexColor = "#" + myGraphic.getShapeColor().R.ToString("X2") + myGraphic.getShapeColor().G.ToString("X2") + myGraphic.getShapeColor().B.ToString("X2");

                    fileContent = fileContent + hexColor + "," + myGraphic.getStartPoint().X.ToString() + "," + myGraphic.getStartPoint().Y.ToString() + "," + myGraphic.getEndPoint().X.ToString() + "," + myGraphic.getEndPoint().Y.ToString() + "\n";
                }
            }

            //Add the last line to keep track of which shapes are pinned to one another
            fileContent = fileContent + "Pin\n";
            //child parent, child parent,etc.  if null -> null, 
            foreach (var myGraphic in canvasGraphicList)
            {
                if(myGraphic.hasChild())
                {
                    fileContent = fileContent + myGraphic.getChild().getId().ToString() + " ";
                }
                else
                {
                    fileContent = fileContent + "null ";
                }
                if(myGraphic.hasParent())
                {
                    fileContent = fileContent + myGraphic.getParent().getId().ToString() + ",";
                }
                else
                {
                    fileContent = fileContent + "null,";
                }
            }

            fileContent = fileContent + "\n";

            //Put the content into the file
            pictureName = pictureName + ".txt";
            System.IO.File.WriteAllText(@pictureName, fileContent);

        }

        private void drawingOpenDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
