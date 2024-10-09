// Include code libraries you need below (use the namespace)
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        //bool variable for if the cup has been placed
        bool isCupPlaced = false;

        //declaring variables that will culminate in the coffee cup 

        // trapezoid1 = cup variable
        // will declare its 4 points that the draw.lines will intersect later in the code
        float[] cupTopLeft = { 350, 400 };
        float[] cupTopRight = { 450, 400 };
        float[] cupBottomLeft = { 300, 200 };
        float[] cupBottomRight = { 500, 200 };

        //trapezoid2 = label variable
        //declaring its 4 points 
        //coordinates were revised for these 4 points
        //the old coordinates had the label trapezoid not fully blend into the coffee trapezoid
        float[] labelTopLeft = { 312, 250 }; //old coordinates = (310, 250)
        float[] labelTopRight = { 488, 250 }; //OC = (490, 250)
        float[] labelBottomLeft = { 338, 350 }; //OC = (340, 350)
        float[] labelBottomRight = { 462, 350 };  //OC = (460, 350)

        //coffee bean/circle shape within the label
        float coffeeBeanX = 400;
        float coffeeBeanY = 300;
        float coffeeBeanRadius = 15;

        //declaring variables for the two rectangle shapes that comprise the first portion of the lid
        //rectangle 1 = bottom rectangle/lid
        float lidRectangle1X = 280;
        float lidRectangle1Y = 180;
        float lidRectangle1Width = 240;
        float lidRectangle1Height = 10 * 2; //same note as the height multiplier on rectangle2
        //rectangle 2 = top rectangle/lid
        float lidRectangle2X = 300;
        float lidRectangle2Y = 160;
        float lidRectangle2Width = 200;
        float lidRectangle2Height = 10 * 2; // multiplied the height by 2 b/c the previous height was smaller than anticipated (needed to double it)

        //declaring variables for the straw (rectangle)
        //the rectangle should intersect/overlap the rectangle2/top rectangle lid
        float strawRectangleX = 390;
        float strawRectangleY = 30;
        float strawRectangleWidth = 20;
        float strawRectangleHeight = 150;

        //declaring colour variables for the respective coffee cup shapes
        Color cupColor;
        Color labelColor;
        Color coffeeBeanColor;
        Color lidColor;
        Color strawColor;

        bool isMousePressed;
        //declaring user space bar input variable
        bool isSpacebarPressed;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Caffeine Addiction");
            Window.SetSize(800, 600);

            //intializing the cup colour variables
            //these will be the base colours for the coffee cup
            //the plan is to add a spacebar input that will result in the randomization of the colours of the coffee cup.
            cupColor = new Color(245, 222, 179); // cup colour is beige
            labelColor = new Color(60, 179, 113); //label colour is olive green
            coffeeBeanColor = new Color(111, 78, 55); //coffeebean colour is coffee brown
            lidColor = new Color(0, 0, 128); //lid colour is navy blue
            strawColor = new Color(255, 20, 147); //straw colour is pink
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            //check if left mouse button has been clicked/pressed
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                isCupPlaced = true;
            }

            //check if cup has been placed on the 800x600 window
            if (isCupPlaced)
            {
                //create Vector2 instances from float cupCoordinates established earlier
                Vector2 cupTopLeftVec = new Vector2(cupTopLeft[0], cupTopLeft[1]);
                Vector2 cupTopRightVec = new Vector2(cupTopRight[0], cupTopRight[1]);
                Vector2 cupBottomRightVec = new Vector2(cupBottomRight[0], cupBottomRight[1]);
                Vector2 cupBottomLeftVec = new Vector2(cupBottomLeft[0], cupBottomLeft[1]);

                //drawing out the coffee trapezoid outline using the vectors created
                Draw.PolyLine(cupTopLeftVec.X, cupTopLeftVec.Y, cupTopRightVec.X, cupTopRightVec.Y); //top
                Draw.PolyLine(cupTopRightVec.X, cupTopRightVec.Y, cupBottomRightVec.X, cupBottomRightVec.Y); //right
                Draw.PolyLine(cupBottomRightVec.X, cupBottomRightVec.Y, cupBottomLeftVec.X, cupBottomLeftVec.Y); //bottom
                Draw.PolyLine(cupBottomLeftVec.X, cupBottomLeftVec.Y, cupTopLeftVec.X, cupTopLeftVec.Y); //left

                //declaring variables for the cup quad
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = cupColor;

                //Drawing cup quad
                Draw.Quad(cupTopLeftVec.X, cupTopLeftVec.Y,
                    cupTopRightVec.X, cupTopRightVec.Y,
                    cupBottomRightVec.X, cupBottomRightVec.Y,
                    cupBottomLeftVec.X, cupBottomLeftVec.Y);

                //fill in the shape with the declared cupColor 
                //trying to figure out how to fill in a shape that's created by line function

                //declare the colors for the polyline
                //not working as i thought it would...
                //will just leave as-is until further notice.
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = labelColor;

                //convert label trapezoid points to Vector2
                Vector2 labelTopLeftVec = new Vector2(labelTopLeft[0], labelTopLeft[1]);
                Vector2 labelTopRightVec = new Vector2(labelTopRight[0], labelTopRight[1]);
                Vector2 labelBottomLeftVec = new Vector2(labelBottomLeft[0], labelBottomLeft[1]);
                Vector2 labelBottomRightVec = new Vector2(labelBottomRight[0], labelBottomRight[1]);

                //draw the outline of the label trapezoid
                //label was switched into a quad.
                Draw.Quad(labelTopLeftVec.X, labelTopLeftVec.Y, labelTopRightVec.X,
                    labelTopRightVec.Y, labelBottomRightVec.X, labelBottomRightVec.Y,
                    labelBottomLeftVec.X, labelBottomLeftVec.Y);

                //fill in the shape with declared labelColor
                //work-in progress

                //draw out the coffeebean circle
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = coffeeBeanColor;
                Draw.Circle(coffeeBeanX, coffeeBeanY, coffeeBeanRadius);
                //fill colour will be the coffeeBeanColor established earlier.

                //draw out the two rectangles that make up the lid
                //the original dimensions of the rectangles were incorrect = they were too thin. 
                //need thicker rectangles that will mimic the shape of a coffee lid.

                //draw rectangle = bottom rectangle
                // the dimensions of the rectangle from my grid don't translate into code
                //correct the dimensions*
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = lidColor;
                Draw.Rectangle(lidRectangle1X, lidRectangle1Y, lidRectangle1Width, lidRectangle1Height);
                //fill colour of rectangle

                //draw top lid
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = lidColor;
                Draw.Rectangle(lidRectangle2X, lidRectangle2Y, lidRectangle2Width, lidRectangle2Height);
                //fill colour of rectangle 

                //draw the straw rectangle (final shape of the coffee cup)
                //the straw was previously thicker than the lid
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = strawColor;
                Draw.Rectangle(strawRectangleX, strawRectangleY, strawRectangleWidth, strawRectangleHeight);
            }

            //check for the spacebar input = randomized coffee cup colors
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
           
            }


        }
    }
}