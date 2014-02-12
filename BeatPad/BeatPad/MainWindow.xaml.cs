using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using System.Threading;
//using System.Windows.Forms.Timer;

namespace BeatPad
{
    public static class ButtonExtension
    {
        public static void PerformClick(this System.Windows.Controls.Button button)
        {
            var buttonPeer = new System.Windows.Automation.Peers.ButtonAutomationPeer(button);
            var invoker = buttonPeer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invoker.Invoke();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // mp3 player objects for each key
        MP3Player player1 = null;
        MP3Player player2 = null;
        MP3Player player3 = null;
        MP3Player player4 = null;
        MP3Player player5 = null;
        MP3Player player6 = null;
        MP3Player player7 = null;
        MP3Player player8 = null;
        MP3Player player9 = null;
        MP3Player player10 = null;
        MP3Player player11 = null;
        MP3Player player12 = null;
        MP3Player player13 = null;
        MP3Player player14 = null;
        MP3Player player15 = null;
        MP3Player player16 = null;

        //some variables
        Boolean keepPlaying = true;
        Boolean storeNote = false;
        Int64 loopLength = 0;
        //list of loopevent objects
        List<loopEvent> eventList = new List<loopEvent>();
        
        System.Windows.Forms.Timer loopTimer;
        Int64 tickCount = 0;
        int isShift = 0;

        //constructor
        public MainWindow()
        {
            InitializeComponent();
            loopTimer = new System.Windows.Forms.Timer();
            loopTimer.Interval = 25;
            
            loopTimer.Tick += new EventHandler(tickEventHandler);

            player1 = new MP3Player(Dispatcher);
            player2 = new MP3Player(Dispatcher);
            player3 = new MP3Player(Dispatcher);
            player4 = new MP3Player(Dispatcher);
            player5 = new MP3Player(Dispatcher);
            player6 = new MP3Player(Dispatcher);
            player7 = new MP3Player(Dispatcher);
            player8 = new MP3Player(Dispatcher);
            player9 = new MP3Player(Dispatcher);
            player10 = new MP3Player(Dispatcher);
            player11 = new MP3Player(Dispatcher);       
            player12 = new MP3Player(Dispatcher);         
            player13 = new MP3Player(Dispatcher);
            player14 = new MP3Player(Dispatcher);          
            player15 = new MP3Player(Dispatcher);
            player16 = new MP3Player(Dispatcher);
            
        }
        //increments counter every timer tick
        private void tickEventHandler(object sender, System.EventArgs e)
        {    
            tickCount++;
            Console.WriteLine("Tick " + tickCount);                      
        }
        //stimulates button presses when key is hit *really wanted the buttons to visually depress but this didnt do it
        private void click_handle(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Console.WriteLine("Argument is: "+e.Key.ToString());
            switch (e.Key)
            {
                case Key.Q:
                    e.Handled = true;
                    Button1.PerformClick();                   
                    break;
                case Key.W:
                    e.Handled = true;
                    Button2.PerformClick();
                    break;
                case Key.E:
                    e.Handled = true;
                    Button3.PerformClick();
                    break;
                case Key.R:
                    e.Handled = true;
                    Button4.PerformClick();
                    break;
                case Key.A:
                    e.Handled = true;
                    Button5.PerformClick();
                    break;
                case Key.S:
                    e.Handled = true;
                    Button6.PerformClick();
                    break;
                case Key.D:
                    e.Handled = true;
                    Button7.PerformClick();
                    break;
                case Key.F:
                    e.Handled = true;
                    Button8.PerformClick();
                    break;
                case Key.Y:
                    e.Handled = true;
                    Button9.PerformClick();
                    break;
                case Key.U:
                    e.Handled = true;
                    Button10.PerformClick();
                    break;
                case Key.I:
                    e.Handled = true;
                    Button11.PerformClick();
                    break;
                case Key.O:
                    e.Handled = true;
                    Button12.PerformClick();
                    break;
                case Key.H:
                    e.Handled = true;
                    Button13.PerformClick();
                    break;
                case Key.J:
                    e.Handled = true;
                    Button14.PerformClick();
                    break;
                case Key.K:
                    e.Handled = true;
                    Button15.PerformClick();
                    break;
                case Key.L:
                    e.Handled = true;
                    Button16.PerformClick();
                    break;
                case Key.LeftShift:
                    e.Handled = true;
                    if (isShift == 0)
                    {
                        Loop();
                    }
                    else
                    {
                        storeLoop();

                    }
                    break;
            }    
        }
        private void playBackPress(string key)
        {
            switch (key)
            {
                case "Q":
                    Button1.PerformClick();
                    break;
                case "W":
                    Button2.PerformClick();
                    break;
                case "E":
                    Button3.PerformClick();
                    break;
                case "R":
                    Button4.PerformClick();
                    break;
                case "A":
                    Button5.PerformClick();
                    break;
                case "S":
                    Button6.PerformClick();
                    break;
                case "D":
                    Button7.PerformClick();
                    break;
                case "F":
                    Button8.PerformClick();
                    break;
                case "Y":
                    Button9.PerformClick();
                    break;
                case "U":
                    Button10.PerformClick();
                    break;
                case "I":
                    Button11.PerformClick();
                    break;
                case "O":
                    Button12.PerformClick();
                    break;
                case "H":
                    Button13.PerformClick();
                    break;
                case "J":
                    Button14.PerformClick();
                    break;
                case "K":
                    Button15.PerformClick();
                    break;
                case "L":
                    Button16.PerformClick();
                    break;
            }
        }

        //menu exit
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //method tells program to start recording key presses/notes
        private void Loop()
        {
            storeNote = true;
            loopTimer.Start();
            isShift = 1;
            Console.WriteLine("Started.");
        }
        //stop recording 
        private void storeLoop()
        {
            storeNote = false;
            timerStop();
            isShift = 0;
            tickCount = 0;
            Console.WriteLine("Loop stored.");

            Task.Factory.StartNew(() =>playLoop(loopLength));

        }

        
        //plays back previously recorded loop
        private void playLoop(Int64 loopLength)
        {
            Action action = () => clearLoopButton.IsEnabled = false;
            Dispatcher.BeginInvoke(action);
            action = () => stopLoopButton.IsEnabled = true;
            Dispatcher.BeginInvoke(action);
            //default: the loop should continue looping
            keepPlaying = true;
            Console.WriteLine("Loop length is: "+loopLength);
            Console.WriteLine("Starting loop playback.");
            //start the timer to compare against. Because you cant record while playing back a loop, looptimer can be used
            action = () => loopTimer.Start();
            Dispatcher.BeginInvoke(action);
            
            while (keepPlaying==true)
            {             
                foreach (loopEvent note in eventList)
                {                    
                    while (keepPlaying == true)
                    {
                        if (note.getTick() == tickCount)
                        {
                            //make sure that there is minimal delay between trying to end loop and loop actually ending
                            if (keepPlaying == true)
                            {

                                string key = null;
                                key = note.getKey().ToString();
                                Console.WriteLine("key is: "+key);
                                //SendKeys.SendWait(key);
                                action = () => playBackPress(key);
                                Dispatcher.BeginInvoke(action);
                                Console.WriteLine("Time: " + note.getTick() + "/Key: " + note.getKey());
                                Console.WriteLine("~~~~~~~~");
                            }
                            break;
                        }
                        if (tickCount >= loopLength)
                        {
                            break;
                        }
                    }
                }
                if (keepPlaying == true)
                {
                    if (tickCount >= loopLength)
                    {
                        tickCount = 0;
                        continue;
                    }
                    while (tickCount != 0)
                    {
                        Console.WriteLine("running out timer");
                        if (tickCount == loopLength)
                        {
                            tickCount = 0;
                            break;
                        }
                    }
                }
                tickCount = 0;
            }
            action = () => loopTimer.Stop();
            Dispatcher.BeginInvoke(action);
        }

        public void timerStop()
        {
            loopTimer.Stop();
            loopLength = tickCount;

        }
        //stops the play loop, kinda a shitty way to do it
        private void stopLoop(object sender, RoutedEventArgs e)
        {
            keepPlaying = false;
            Action action = () => clearLoopButton.IsEnabled=true;
            Dispatcher.BeginInvoke(action);
            action = () => playLoopButton.IsEnabled = true;
            Dispatcher.BeginInvoke(action);
            action = () => stopLoopButton.IsEnabled = false;
            Dispatcher.BeginInvoke(action);
        }
        //click functions, all identical(aside from filepaths), refer to button1 for comments
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //assign soundbite to path
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4_Snares_080.mp3");
            Console.WriteLine("Button1 clicked.");
            //this would need to be changed should the keys be remapped
            System.Windows.Input.Key key = Key.Q;
            try
            {
                //play soundbite located at path
                player1.Play(path);
                //check to see that its turning on rather than off
                if (storeNote == true)
                {
                    //create new loopevent object and add to list
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4_Snares_072.mp3");
            Console.WriteLine("Button2 clicked.");
            System.Windows.Input.Key key = Key.W;
            try
            {
                player2.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4_Snares_106.mp3");
            Console.WriteLine("Button3 clicked.");
            System.Windows.Input.Key key = Key.E;
            try
            {
                player3.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }


            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"Clap & Snare 08.mp3");
            Console.WriteLine("Button4 clicked.");
            System.Windows.Input.Key key = Key.R;
            try
            {
                player4.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Hi-Hat_1.mp3");
            Console.WriteLine("Button5 clicked.");
            System.Windows.Input.Key key = Key.A;
            try
            {
                player5.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Kick_02.mp3");
            Console.WriteLine("Button6 clicked.");
            System.Windows.Input.Key key = Key.S;
            try
            {
                player6.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Kick_04.mp3");
            Console.WriteLine("Button7 clicked.");
            System.Windows.Input.Key key = Key.D;
            try
            {
                player7.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Percussion_01.mp3");
            Console.WriteLine("Button8 clicked.");
            System.Windows.Input.Key key = Key.F;
            try
            {
                player8.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Percussion_08.mp3");
            Console.WriteLine("Button9 clicked.");
            System.Windows.Input.Key key = Key.Y;
            try
            {
                player9.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FL_GaiB_OneShots_Snares-Claps_08.mp3");
            Console.WriteLine("Button10 clicked.");
            System.Windows.Input.Key key = Key.U;
            try
            {
                player10.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"FloorTom ElektroAc.mp3");
            Console.WriteLine("Button11 clicked.");
            System.Windows.Input.Key key = Key.I;
            try
            {
                player11.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"Hat 03.mp3");
            Console.WriteLine("Button12 clicked.");
            System.Windows.Input.Key key = Key.O;
            try
            {
                player12.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button13_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"Hat 12.mp3");
            Console.WriteLine("Button13 clicked.");
            System.Windows.Input.Key key = Key.H;
            try
            {
                player13.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button14_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4 Crash 02.mp3");
            Console.WriteLine("Button14 clicked.");
            System.Windows.Input.Key key = Key.J;
            try
            {
                player14.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }
        private void Button15_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4 Rides 26.mp3");
            Console.WriteLine("Button15 clicked.");
            System.Windows.Input.Key key = Key.K;
            try
            {
                player15.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }

        private void Button16_Click(object sender, RoutedEventArgs e)
        {
            String basePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"audio\");
            String path = System.IO.Path.Combine(basePath, @"VEC4 Rides 27.mp3");
            Console.WriteLine("Button16 clicked.");
            System.Windows.Input.Key key = Key.L;
            try
            {
                player16.Play(path);
                if (storeNote == true)
                {
                    eventList.Add(new loopEvent(tickCount, key));
                    Console.WriteLine("Added key: " + key + " at " + tickCount);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("error: " + exp);
            }
        }

        private void clearLoop(object sender, RoutedEventArgs e)
        {
            eventList.Clear();
            Action action = () => clearLoopButton.IsEnabled = false;
            Dispatcher.BeginInvoke(action);
            action = () => playLoopButton.IsEnabled = false;
            Dispatcher.BeginInvoke(action);
        }

        private void playButton(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => playLoop(loopLength));
            Action action = () => playLoopButton.IsEnabled = false;
            Dispatcher.BeginInvoke(action);
        }

    }
}
