using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 
/// This program has been created to demonstrate the user of the timer component. On
/// the designer there are 2 timers, (countTimer and watchTimer). Each one used for 
/// a different part of the program.
/// 
/// The countTimer is set to an interval of 500. That means that when it is enabled 
/// every 500ms its tick method will run. Each iteration of the tick method it will 
/// add 1 to a counter variable, display that value of that variable, and also change 
/// the colour of a label based on that value in the variable. 
/// 
/// The watchTiemr is set to an interval of 10. That means that when it is enabled 
/// every 10ms its tick method will run. Each iteration of the tick method it adds 
/// to the total time elapsed and displays it to the screen as a stopwatch.
/// 
/// NOTE: The stopwatch is not truly accurate, however it demonstrates the use of 
/// the timer component well.
/// 
/// </summary>

namespace StopWatchApp
{
    public partial class Form1 : Form
    {
        // will be incremented to using the countTimer
        int counter = 0;

        // used for stopwatch
        int hundredsCounter = 0;
        int secondsCounter = 0;
        int minutesCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        #region counter

        private void countButton_Click(object sender, EventArgs e)
        {
            // if the countTimer is not running start it and change the button text to "Pause"
            if (countTimer.Enabled == false)
            {
                countTimer.Enabled = true;
                countButton.Text = "Pause";
            }
            // if the countTimer is running stop it and set button text to "Start"
            else 
            {
                countTimer.Enabled = false;
                countButton.Text = "Start";
            }

        }

        /// <summary>
        /// This tick method will run each time the countTimer gets to the set interval
        /// </summary>
        private void countTimer_Tick(object sender, EventArgs e)
        {
            // add 1 to the counter and display the current value
            counter++;
            counterLabel.Text = counter + "";

            // based on the value of the counter a different colour is shown
            if (counter % 3 == 0) // if counter divided by 3 has remainder of 0 
            {
                colourLabel.BackColor = Color.LightGreen;
            }
            else if (counter % 3 == 1) // if counter divided by 3 has a remainder of 1
            {
                colourLabel.BackColor = Color.DodgerBlue;
            }
            else
            {
                colourLabel.BackColor = Color.Yellow;
            }

        }

        #endregion

        #region stopwatch code

        private void startStopButton_Click(object sender, EventArgs e)
        {
            // if the watchTimer is not running, start it and change the button text to "Stop"
            if (watchTimer.Enabled == false)
            {
                watchTimer.Enabled = true;
                startStopButton.Text = "Stop";
            }
            else // if the WatchTimer is running, stop it and change the button text to "Start"
            {
                watchTimer.Enabled = false;
                startStopButton.Text = "Start";
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // if the watchTimer is not running reset all variables and labels to 0
            if (watchTimer.Enabled == false)
            {
                hundredsCounter = 0;
                secondsCounter = 0;
                minutesCounter = 0;

                hundredsLabel.Text = ":00";
                secondsLabel.Text = ":00";
                minutesLabel.Text = "00";
            }
        }

        /// <summary>
        /// This tick method will run each time the countTimer gets to the set interval
        /// </summary>
        private void watchTimer_Tick(object sender, EventArgs e)
        {
            // add 1 to the hundreds counter
            hundredsCounter++;

            // Since the tick method runs every 10 ms, if the hundreds counter gets to 100 
            // we have gotten to one second, 100 * 10 = 1000ms = 1s.
            if (hundredsCounter == 100)
            {
                hundredsCounter = 0; //reset the hundreds counter
                secondsCounter++; // add 1 to seconds
            }
            // When we get to 60 seconds reset the seconds counter and add 1 to minutes
            if (secondsCounter == 60) 
            {
                secondsCounter = 0;
                minutesCounter++;
            }

            // update all the labels with the latest times
            hundredsLabel.Text = hundredsCounter.ToString(":00");
            secondsLabel.Text = secondsCounter.ToString(":00");
            minutesLabel.Text = minutesCounter.ToString("00");

        }

        #endregion

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
