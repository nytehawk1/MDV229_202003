﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace BowmanBlain_ConvertedData
{
    class Animation
    {
        public static int mid = 0;
        //--------------------
        //Animated Bar Graph
        //--------------------
        //Think, the following examples:
        //...showing a loading proression bar
        //...showing the distance from the start to a goal
        //...showing amount of percentage downloaded


        //To animate the bar graph, we need to know the value of the graph, the size of the graph, the speed we want it to animate, and for how long we want to animate it.
        //To animate it in the console, we can just choose random numbers and draw the graph over and over again.
        //--------------------

        //Timer Variable
        //This creates the actual timer
        //Note this is outside of the Main()
        //Note that we added in "using System.Timers;" at the top
        public static System.Timers.Timer myAnimationTimer;
        //Timer Counter
        //This counter is used to stop the timer when we want it to
        //So, it helps to make the animation go longer/shorter, faster/slower
        //Note this is outside of the Main()
        private static int myTimerCounter = 0;

        //Counter for rating
        private static int iiii = 0;

        //Values name of restaurant
        public static string res_name = "";

        //Set Timer Properties
        public static void SetTimer()
        {
            //Set time to happen really fast 1,000 = 1 second
            //Start the function every 50/1000 seconds
            myAnimationTimer = new System.Timers.Timer(50);

            //At 50/1000, run this method "OnTimedEvent"
            //Every time it elapses, do it
            myAnimationTimer.Elapsed += OnTimedEvent;

            //Reset timer again after 50/1000, over and over again
            //False means to only run the timer one time
            myAnimationTimer.AutoReset = true;

            //The timer is enabled so it will work
            //False means the timer will not work
            myAnimationTimer.Enabled = true;

        }

        //Timer Method that runs every time the timer elapses
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //Setting the bar graph colors
            var myBackgroundColor = ConsoleColor.White;

            myTimerCounter++;

            // We assign rating values ​​to get animation
            var theRating = Rating(iiii);

            //Setting the colors of the histogram depending on the rating value
            Graphs g = new Graphs();
            var myBarGraphColor = g.Color(theRating);
            Console.BackgroundColor = myBarGraphColor;

            //Move the cursor back to the left, where it started to draw the animation to begin with.
            //Once we redraw, and redraw, and redraw, it will look animated.
            //We are doing this because we are uisng a Console.Write to stay on the same line, so we move back, and redraw over top of the old one.
            Console.CursorLeft = 40;

            //Create bar graph, not the bar graph background
            //We create the bar we want first, and the background second.
            for (int ii = 1; ii <= theRating; ii++)
            {
                //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                //Console.BackgroundColor = myBarGraphColor; 
                //This creates a colored bar graph of spaces, so if you have a 5/10, you will get 5 colored spaces.
                Console.Write(" ");
            }

            //Set total number for the length of the bar graph, which is also the background
            int myTotalNumber = 10;

            //Set bar graph background color
            //We can set the color once here, or set it over and over again in the loop below.
            Console.BackgroundColor = myBackgroundColor;

            //Draw bar graph background
            //The background is not seen around the edges of the bar, or also with the foreground color of the bar. We only see one color at a time.
            //So, we just start drawing the background after the final drawing of the bar graph based on the data.
            //For Example...if we have 5/10, then the bar graph is 1-5 and the background is 6-10.
            for (int iii = theRating; iii < myTotalNumber; iii++)
            {
                //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                //Console.BackgroundColor = myBackgroundColor;
                //This creates a colored background of spaces, so if you have a 5/10, you will get 5 colored spaces to make the background after the 5 colored spaces that made up the bar.
                Console.Write(" ");
            }

            //increase iii by 1 to get the next rating value
            iiii++;

            //After a bit of time, stop the animation
            //We change this as well for longer/shorter, faster/slower
            //Right now, the animation, or resetting/redrawing of the graph will happen 50 times, once every 50/1000 seconds.
            if (myTimerCounter == 99 || iiii > 100)
            {

                //Stop Timer
                myAnimationTimer.Stop();

                //Add in final database variable code here
                //If the database data says 8/10, you would set the variable to 8 here.
                //Once the animation is over, redraw the bar graph one more time with the actual bar graph data

                Console.BackgroundColor = g.Color(mid);
                Console.CursorLeft = 40;
                //Create bar graph, not the bar graph background
                //We create the bar we want first, and the background second.
                for (int ii = 1; ii <= mid; ii++)
                {
                    //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                    //Console.BackgroundColor = myBarGraphColor; 
                    //This creates a colored bar graph of spaces, so if you have a 5/10, you will get 5 colored spaces.
                    Console.Write(" ");
                }


                //Set bar graph background color
                //We can set the color once here, or set it over and over again in the loop below.
                Console.BackgroundColor = myBackgroundColor;


                //Draw bar graph background
                //The background is not seen around the edges of the bar, or also with the foreground color of the bar. We only see one color at a time.
                //So, we just start drawing the background after the final drawing of the bar graph based on the data.
                //For Example...if we have 5/10, then the bar graph is 1-5 and the background is 6-10.
                for (int iii = mid; iii < myTotalNumber; iii++)
                {
                    //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                    //Console.BackgroundColor = myBackgroundColor;
                    //This creates a colored background of spaces, so if you have a 5/10, you will get 5 colored spaces to make the background after the 5 colored spaces that made up the bar.
                    Console.Write(" ");
                }

                //Reset myTimerCounter to 0 for another restaurant 
                myTimerCounter = 0;
                //Reset iii to 0 for another restaurant
                iiii = 0;


                //Reset color
                Console.ResetColor();

                //Show the cursor again so the user can do what you need them to do.
                Console.CursorVisible = true;

            }




        }
        private static int Rating(int iiii)
        {
            List<int> vall = new List<int>();
            vall = Graphs.graphs[res_name];
            int theRat = vall[iiii];
            return theRat;
        }



    }
}
