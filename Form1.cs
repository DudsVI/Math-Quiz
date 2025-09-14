using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // Random number generator
        Random randomizer = new Random();

        // Addition numbers
        int addend1;
        int addend2;

        // Subtraction numbers
        int minuend;
        int subtrahend;

        // Multiplication numbers
        int multiplicand;
        int multiplier;

        // Division numbers
        int dividend;
        int divisor;

        // Timer variable
        int timeLeft;

        // Declare the timer
        Timer timer1;

        public Form1()
        {
            InitializeComponent();

            // Initialize the timer
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 second
            timer1.Tick += timer1_Tick;

          

            // Hook the Enter event for all NumericUpDown answer boxes
            sum.Enter += answer_Enter;
            difference.Enter += answer_Enter;
            product.Enter += answer_Enter;
            quotient.Enter += answer_Enter;
        }

        /// <summary>
        /// Selects all text when the user enters a NumericUpDown control
        /// </summary>
        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        /// <summary>
        /// Check the answers to see if the user got everything right.
        /// </summary>
        private bool CheckTheAnswer()
        {
            return (addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value);
        }

        /// <summary>
        /// Timer tick event: check answers or countdown.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                timeLabel.BackColor = Color.Red; // 🔴 Turn red only when time is done
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }


        /// <summary>
        /// Start the quiz by filling in all of the problem values and starting the timer. 
        /// </summary>
        public void StartTheQuiz()
        {
            // Addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            differenceLeftLabel.Text = minuend.ToString();
            differenceRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            productLeftLabel.Text = multiplicand.ToString();
            productRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            quotientLeftLabel.Text = dividend.ToString();
            quotientRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // --- Auto-generated empty handlers ---
        private void timeText_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void sum_ValueChanged(object sender, EventArgs e) {
            if (addend1 + addend2 == sum.Value)
            {
                SystemSounds.Beep.Play(); // play sound when correct
            }
        }
        private void difference_ValueChanged(object sender, EventArgs e) {
            if (minuend - subtrahend == difference.Value)
            {
                SystemSounds.Beep.Play();
            }
        }
        private void product_ValueChanged(object sender, EventArgs e) {
            if (multiplicand * multiplier == product.Value)
            {
                SystemSounds.Beep.Play();
            }
        }
        private void quotient_ValueChanged(object sender, EventArgs e) {
            if (dividend / divisor == quotient.Value)
            {
                SystemSounds.Beep.Play();
            }
        }
        private void plusLeftLabel_Click(object sender, EventArgs e) { }
        private void differencRightLabel_Click(object sender, EventArgs e) { }
        private void differencLeftLabel_Click(object sender, EventArgs e) { }
        private void differenceLeftLabel_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void quotientLeftLabel_Click(object sender, EventArgs e) { }
        private void productLeftLabel_Click(object sender, EventArgs e) { }
        private void quotientRightLabel_Click(object sender, EventArgs e) { }
        private void productRightLabel_Click(object sender, EventArgs e) { }
        private void differenceRightLabel_Click(object sender, EventArgs e) { }
        private void plusRightLabel_Click(object sender, EventArgs e) { }
        private void timeLabel_Click(object sender, EventArgs e) { }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
    }
}
