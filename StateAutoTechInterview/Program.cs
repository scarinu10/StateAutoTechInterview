using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateAutoTechInterview
{
    class Game
    {
        
        List<int> ballsRolled = new List<int>(21); //creates new list of balls to keep track of each ball rolled
        
        static void Main(string[] args)
        {
            Game newGame = new Game(); //creates instance of new game, 
            Random random = new Random(); //creates instance of Random class, is used to generate random throws
            int frameCount = 1; //frame counter, is uesd to increment through frames as ball rolls are taking place

            //defunct code below, brainstorming
            //newGame.Roll(random.Next(11));
            /*foreach (int ball in newGame.ballsRolled)
            {
                newGame.ballsRolled.Add(random.Next(11));
            }*/
            /*for (int i = 0; i<newGame.ballsRolled.Count; i++)
            {
                newGame.ballsRolled.Add(random.Next(11));
            }*/

            while (frameCount <= 10) //stops iterating through loop after 10 frames are scored.
            {
                if (frameCount != 10) //executes if frame count is 1-9
                {
                    int pinsStanding = 10; //set pins up
                    int ballScore = random.Next(pinsStanding + 1); //generates random number between 0 and 10 and stores in ball score
                    newGame.Roll(ballScore); //calls roll method, passes ball score in
                    pinsStanding -= ballScore; //rake knocked down pins, pins left standing

                    if (pinsStanding != 0) //executes if pins were left standing after first throw
                    {
                        ballScore = random.Next(pinsStanding + 1); //generates random number between 0 and pins left standing
                        newGame.Roll(ballScore); //knocks pins down
                    }
                    frameCount++; //frame 1-9 over after max of two throws. 
                }
                else
                {
                    //some repeating code in this loop, 10th frame is really special case in such that as strike does not start a new frame.
                    int pinsStanding = 10; //sets pins up
                    int ballScore = random.Next(pinsStanding + 1); //generates random number 0-10 and stores in a variable
                    newGame.Roll(ballScore); //throw ball
                    pinsStanding -= ballScore; //knock pins down

                    if (pinsStanding== 0) //sets pins back up if all pins were knocked down
                    {
                        pinsStanding = 10;
                    }
                    
                    ballScore = random.Next(pinsStanding + 1); //gerates random number 0-pins left standing (or 10 if a strike)
                    newGame.Roll(ballScore); //throw ball
                    pinsStanding -= ballScore; //knock pins down

                    if (pinsStanding==0) //sets pins back up and throws third ball if spare or strike was thrown in 10th frame
                    {
                        pinsStanding = 10;
                        ballScore = random.Next(pinsStanding + 1);
                        newGame.Roll(ballScore);
                        frameCount++; //increments frame count to 11 to escape while loop
                    }
                    else //stores 0 in the final index of the ballsRolled list if the third ball was not needed to keep scoring logic in tact to prevent index out of bounds
                    {
                        newGame.Roll(0); 
                        frameCount++; //increments frame count to 11 to escape while loop
                    }
                }
            }
            
            foreach (int roll in newGame.ballsRolled) //itereates throw each roll in ballsRolled list
                Console.WriteLine(roll); //outputs number of pins each ball knocked down. 
            int score = newGame.Score(); //calls score method on the list of scores stored earlier
            Console.WriteLine(score); //outputs score to console
            Console.ReadLine(); //waiting for enter, keeps console open to see output
        
        }
        public void Roll(int pins) //ball roll method, takes random number of pins as input
        {
            ballsRolled.Add(pins);
            
        }

        public int Score()
        {
            int score = 0; //bowling game starts at score of 0, keeps track of score while iterating through list of balls rolled. 
            int counter = 0; //counter that references the index in ballsRolled list
            int frameNumber = 1; //keeps track of frame number while iterating through ballsRolled list 
            while (frameNumber < 10) //executes for frames 1-9
            {
                if (ballsRolled[counter] == 10) //if ball rolled score at index/counter is 10 (STRIKE!), adds the next two balls at index+1 and +2 to generate final strike score
                {
                    score += ballsRolled[counter] + ballsRolled[counter + 1] + ballsRolled[counter + 2]; //stores total score for strike plus the following two balls
                    counter++; //increments index by 1 because the ball referencing the strike is no longer needed for any scoring.
                }
                else if (ballsRolled[counter] + ballsRolled[counter + 1] == 10) // balls rolled score at the index and index +1 add to 10 (SPARE) adds those two balls plus index+2 to generate final spare score
                {
                    score += ballsRolled[counter] + ballsRolled[counter + 1] + ballsRolled[counter + 2]; //stores total score for ball 1 in frame plus ball 2 that lead to spare, plus one ball following
                    counter += 2; //increments index by 2 because the two balls it took to roll a spare is no longer for any scoring purpose.
                }
                else //executes if strike or spare is not thrown
                {
                    score += ballsRolled[counter] + ballsRolled[counter + 1]; //adds two balls in frame to score with no bonus balls
                    counter += 2;// increments index by 2 because the two balls it took to roll a regular frame are no longer needed.
                }
                frameNumber++; //increments frame number by one, loop repeats through frame 9
            }
            while (frameNumber == 10) //executes on frame 10
            {
                score += ballsRolled[counter] + ballsRolled[counter + 1] + ballsRolled[counter + 2]; //totals the three balls (or third ball is 0, if not thrown) in frame 10
                frameNumber++;
            }
            return score;
        }
    }

    //defunct code, was working on ideas to get logic working correctly.  
        /*static void Main(string[] args)
        {
            List<int> scores = new List<int>();
            int frameNumber = 1;
            Random randomPins = new Random();
            while (frameNumber <= 10)
            {
                
                int frameScore;
                int firstRoll;
                int secondRoll = 0;
                firstRoll = randomPins.Next(11);
                if (firstRoll == 10)
                {
                    frameScore = firstRoll;
                }
                else
                {
                    secondRoll = randomPins.Next(11-firstRoll);
                    frameScore = firstRoll + secondRoll;
                }

                scores.Add(frameScore);
                frameNumber++;
            }
            Console.ReadLine();
        }

        public void Roll (int pins)
        {
            
        }

        public void Score()
        {
           
        }
    }*/
}

