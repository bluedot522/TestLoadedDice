using System;
using static System.Console;
class TestLoadedDice
{

    /*Design a Die class that can hold an integer data field for a value 
     * (from 1 to 6). Include an auto-implemented property that holds the
     * value of the die and a constructor that requires a value for the die. 
     * Create a LoadedDie class that descends from Die and that can be used to 
     * give a player a slight advantage. A LoadedDie never rolls a 1 or a 2; 
     * if a client attempts to assign 1 or 2 to a loaded die’s value, the value 
     * is forced to 3. Create a program named TestLoadedDice that generates random 
     * values to simulate rolling two Die objects against each other 1,000 times 
     * and counts the number of times the first Die has a higher value than the other Die.
     * Then, simulate rolling a Die object against a LoadedDie object 1,000 times and
     * count the number of times the unloaded Die wins. Display the results.
      */
    static void Main()
    {
        Random rand = new Random();

        // Write your code here
        Die die1 = new Die(rand.Next(1,7));
        Die die2 = new Die(rand.Next(1,7));

        int die1Wincount = 0;
        int die2Wincount = 0;

        for (int i = 0; i <= 1000; ++i)
        {
           
            //WriteLine("Die #1:" + die1.Num);
           // WriteLine("Die #2:" + die2.Num);

            if (die1.Num > die2.Num)
            {
                //WriteLine("Die #1 wins!\n");
                die1Wincount++;
            }
            else
            {
                //WriteLine("Die #2 wins!\n");
                die2Wincount++;
            }
            die1.Num = rand.Next(1, 7);
            die2.Num = rand.Next(1, 7);
        }
       
            WriteLine("Die #1 scored higher {0} time(s).", die1Wincount);
       
        
        Die die3 = new Die(rand.Next(1, 7));
        LoadedDie loadedDie = new LoadedDie(rand.Next(1, 7));

        int die3Wincount = 0;
        int loadedDieWincount = 0;

        for (int i = 0; i <= 1000; ++i)
        {

            //WriteLine("Die #1:" + die3.Num);
           // WriteLine("Die #2:" + loadedDie.Num);

            if (die3.Num > loadedDie.Num)
            {
                //WriteLine("Unloaded die wins!\n");
                die3Wincount++;
            }
            else if (die3.Num == loadedDie.Num)
            {
                //WriteLine("It's a tie!\n");
            }
            else
            {
                //WriteLine("Loaded die wins!\n");
                loadedDieWincount++;
            }
            die3.Num = rand.Next(1, 7);
            loadedDie.Num = rand.Next(1, 7);
        }

        WriteLine("Unloaded die scored higher than loaded die {0} time(s).\n", die3Wincount);
        

    }
}

class Die
{
    protected int num;                 
    public virtual int Num
    {
        get { return num; }
        set { num = value; }
    }

    public Die(int num)
    {
        this.num = num;                
    }
}

class LoadedDie : Die
{
    public override int Num
    {
        get { return num; }
        set
        {
            if (value < 3)
                num = 3;
            else
                num = value;
        }
    }
    public LoadedDie(int num) : base(num)
    {
        if (num < 3)
        { this.num = 3; }
    }
}
