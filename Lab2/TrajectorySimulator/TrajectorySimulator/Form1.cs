using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrajectorySimulator 

{

    public partial class EnteringDataForm : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        
        private double x0, y0, angle, v0;
        private static Graphics graphics;
        private Color trajectoryColor = Color.Blue;

        public EnteringDataForm()
        {
            InitializeComponent();
            AllocConsole();
            WarningForAllData.Visible = false;
            WarningForX.Visible = false;
            WarningForY.Visible = false;
            WarningForAngle.Visible = false;
            WarningForV.Visible = false;
        }

        private void XTextBox_Changed(object sender, EventArgs e)
        {
            InputValidator.ValidateInput(XTextBox, ref x0, WarningForX, (-250), (250));
        }

        private void YTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator.ValidateInput(YTextBox, ref y0, WarningForY, (-250), (250));
        }

        private void AngleTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator.ValidateInput(AngleTextBox, ref angle, WarningForAngle, 0, 360);
        }

        private void VTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator.ValidateInput(VTextBox, ref v0, WarningForV);
        }


        private bool IsDataEntered()
        {
            return WarningForX.Visible == false
                && WarningForY.Visible == false
                && WarningForAngle.Visible == false
                && WarningForV.Visible == false;
        }

        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrEmpty(XTextBox.Text)
                && !string.IsNullOrEmpty(YTextBox.Text)
                && !string.IsNullOrEmpty(AngleTextBox.Text)
                && !string.IsNullOrEmpty(VTextBox.Text);
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (!IsDataEntered() || !AreTextBoxesFilled())
            {
                WarningForAllData.Visible = true;
            }
            else
            {
                WarningForAllData.Visible = false;
                DrawTrajectory();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!IsDataEntered() || !AreTextBoxesFilled())
            {
                WarningForAllData.Visible = true;
            }
            else
            {
                WarningForAllData.Visible = false;
                SaveTrajectoryWithAxes();
            }
        }

        private void EnteringDataForm_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
        }

        private void DrawTrajectory()
        {
            graphics = CreateGraphics();
            GraphicsHorizonHelper.DrawTrajectory(graphics, x0, y0, angle, v0, trajectoryColor);

        }

        private void SaveTrajectoryWithAxes()
        {
            graphics = CreateGraphics();
            string fileName = "trajectory_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "trajectory_images", fileName);
            ImageGraphicsHelper.DrawTrajectoryAndSaveToFile(x0, y0, angle, v0, trajectoryColor, path);
            Console.WriteLine("File with trajectory and coordinate axes saved to:" + path);
        }



        private void DrawCoordinateAxesButton_Click(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
            GraphicsHorizonHelper.DrawCoordinateAxes(graphics);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Invalidate();
            WarningForAllData.Visible = false;
        }

        private void SelectColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    trajectoryColor = colorDialog.Color;
                }
            }
        }

        private void ShowFlightInfoButton_Click(object sender, EventArgs e)
        {
            if (!IsDataEntered() || !AreTextBoxesFilled())
            {
                WarningForAllData.Visible = true;
            }
            else
            {
                WarningForAllData.Visible = false;
                ShowFlightInfo();
            }
        }

        private void ShowFlightInfo()
        {
            (double height, double range, double time) = HorizonFlightCalculator.GetFlightData(y0, angle, v0);
            TimeValueLabel.Text = time.ToString();
            HeightValueLabel.Text = height.ToString();
            DistanceValueLabel.Text = range.ToString();
            TimeValueLabel.Visible = true;
            HeightValueLabel.Visible = true;
            DistanceValueLabel.Visible = true;

        }

        private void EnteringDataForm_Load(object sender, EventArgs e)
        {

        }
    }

    public static class HorizonFlightCalculator
    {
        const double g = 9.81;
        public static double CalculateTime(double y0, double angle, double v0)
        {
            double alpha = (angle * Math.PI) / 180;
            double flightTime = (v0 * Math.Sin(alpha) + Math.Sqrt(Math.Pow(v0 * Math.Sin(alpha), 2) + (2 * g * y0))) / g;
            return flightTime;
        }

        public static double CalculateMaximumHeight(double y0, double angle, double v0)
        {
            double alpha = (angle * Math.PI) / 180;
            double maxHeight = y0 + (Math.Pow(v0 * Math.Sin(alpha), 2) / (2 * g));
            return maxHeight;
        }

        public static double CalculateMaxRange(double y0, double angle, double v0)
        {
            double alpha = (angle * Math.PI) / 180;
            double sinBeta = Math.Sin(alpha);
            double cosBeta = Math.Cos(alpha);

            return v0 * cosBeta * CalculateTime(y0, angle, v0);
        }

        public static (double height, double range, double time) GetFlightData(double y0,  double angle, double v0)
        {
            double maxH = CalculateMaximumHeight(y0, angle, v0);
            double maxL = CalculateMaxRange(y0, angle, v0);
            double flightT = CalculateTime(y0, angle, v0);

            return (maxH, maxL, flightT);
        }
    }

    public static class GraphicsHorizonHelper
    {
        const int InitialXOffset = 600;
        const int InitialYOffset = 10;
        const int AxesXSize = 500;
        const int AxesYSize = 500;
        const int MarksValue = 25;
        const int ScaleValue = 50;
        const double TimeInterval = 0.1;
        const double g = 9.81;
        static double ScaleDifference;
        public static void DrawTrajectory(Graphics graphics, double x0, double y0, double angle, double v0, Color trajectoryColor)
        {
            ScaleDifference = ScaleValue / MarksValue;
            Pen pen = new Pen(trajectoryColor, 2);
            double alpha = (360 - angle) * Math.PI / 180;
            double time = 0;
            double x = x0*ScaleDifference + InitialXOffset;
            double y = -y0*ScaleDifference + AxesYSize + InitialYOffset;
            double startX = x;
            double startY = y;
            x = 0;
            y = 0;
            while (true)
            {
                graphics.FillEllipse(pen.Brush, (float)(startX + x*ScaleDifference), (float)(startY + y * ScaleDifference), 6, 6);
                x = (v0 * time * Math.Cos(alpha));
                y = (v0 * time * Math.Sin(alpha) + 0.5 * g * time * time);
                time += TimeInterval;
                if (startX + x * ScaleDifference > InitialXOffset + AxesXSize || startY + y * ScaleDifference > InitialYOffset + AxesYSize)
                {
                    break;
                }
            }
        }

        public static void DrawCoordinateAxes(Graphics graphics)
        {

            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            graphics.DrawString("0", font, brush, InitialXOffset + 5, InitialYOffset + AxesYSize - 15);

            Pen gridPen = new Pen(Color.LightGray, 1f);
            Pen basicPen = new Pen(Color.Black, 3f);

            for (int x = InitialXOffset; x <= InitialXOffset + AxesXSize; x += ScaleValue)
                graphics.DrawLine(gridPen, x, InitialYOffset, x, InitialYOffset + AxesYSize);

            for (int y = InitialYOffset; y <= InitialYOffset + AxesYSize; y += ScaleValue)
                graphics.DrawLine(gridPen, InitialXOffset, y, InitialXOffset + AxesXSize, y);

            graphics.DrawLine(basicPen, InitialXOffset, InitialYOffset + AxesYSize, InitialXOffset + AxesXSize, InitialYOffset + AxesYSize); 
            graphics.DrawLine(basicPen, InitialXOffset, InitialYOffset, InitialXOffset, InitialYOffset + AxesYSize); 

            for (int x = InitialXOffset + ScaleValue, i = MarksValue; x <= InitialXOffset + AxesXSize; x += ScaleValue, i += MarksValue)
            {
                graphics.DrawLine(basicPen, x, InitialYOffset + AxesYSize - 7, x, InitialYOffset + AxesYSize + 7);
                graphics.DrawString(i.ToString(), font, brush, x - 10, InitialYOffset + AxesYSize + 10);
            }

            for (int y = InitialYOffset + AxesYSize - ScaleValue, i = MarksValue; y >= InitialYOffset; y -= ScaleValue, i += MarksValue)
            {
                graphics.DrawLine(basicPen, InitialXOffset - 7, y, InitialXOffset + 7, y);
                graphics.DrawString(i.ToString(), font, brush, InitialXOffset + 10, y - 5);
            }
        }

    }
    public static class ImageGraphicsHelper
    {
        const int InitialXOffset = 600;
        const int InitialYOffset = 10;
        const int AxesXSize = 500;
        const int AxesYSize = 500;
        const int MarksValue = 25;
        const int ScaleValue = 50;
        const double TimeInterval = 0.1;
        const double g = 9.81;
        static double ScaleDifference;

        public static void DrawTrajectoryAndSaveToFile(double x0, double y0, double angle, double v0, Color trajectoryColor, string filePath)
        {
            const int InitialXOffset = 600;
            const int InitialYOffset = 10;
            const int AxesXSize = 500;
            const int AxesYSize = 500;

            Bitmap bitmap = new Bitmap(InitialXOffset + AxesXSize, InitialYOffset + AxesYSize);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                DrawCoordinateAxes(graphics);

                ScaleDifference = ScaleValue / MarksValue;
                Pen pen = new Pen(trajectoryColor, 2);
                double alpha = (360 - angle) * Math.PI / 180;
                double time = 0;
                double x = x0 * ScaleDifference + InitialXOffset;
                double y = -y0 * ScaleDifference + AxesYSize + InitialYOffset;
                double startX = x;
                double startY = y;
                x = 0;
                y = 0;
                while (true)
                {
                    graphics.FillEllipse(pen.Brush, (float)(startX + x * ScaleDifference), (float)(startY + y * ScaleDifference), 6, 6);
                    x = (v0 * time * Math.Cos(alpha));
                    y = (v0 * time * Math.Sin(alpha) + 0.5 * g * time * time);
                    time += TimeInterval;
                    if (time > 20) break;
                }

                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public static void DrawCoordinateAxes(Graphics graphics)
        {

            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            graphics.DrawString("0", font, brush, InitialXOffset + 5, InitialYOffset + AxesYSize - 15);

            Pen gridPen = new Pen(Color.LightGray, 1f);
            Pen basicPen = new Pen(Color.Black, 3f);

            for (int x = InitialXOffset; x <= InitialXOffset + AxesXSize; x += ScaleValue)
                graphics.DrawLine(gridPen, x, InitialYOffset, x, InitialYOffset + AxesYSize);

            for (int y = InitialYOffset; y <= InitialYOffset + AxesYSize; y += ScaleValue)
                graphics.DrawLine(gridPen, InitialXOffset, y, InitialXOffset + AxesXSize, y);

            graphics.DrawLine(basicPen, InitialXOffset, InitialYOffset + AxesYSize, InitialXOffset + AxesXSize, InitialYOffset + AxesYSize);
            graphics.DrawLine(basicPen, InitialXOffset, InitialYOffset, InitialXOffset, InitialYOffset + AxesYSize);

            for (int x = InitialXOffset + ScaleValue, i = MarksValue; x <= InitialXOffset + AxesXSize; x += ScaleValue, i += MarksValue)
            {
                graphics.DrawLine(basicPen, x, InitialYOffset + AxesYSize - 7, x, InitialYOffset + AxesYSize + 7);
                graphics.DrawString(i.ToString(), font, brush, x - 10, InitialYOffset + AxesYSize + 10);
            }

            for (int y = InitialYOffset + AxesYSize - ScaleValue, i = MarksValue; y >= InitialYOffset; y -= ScaleValue, i += MarksValue)
            {
                graphics.DrawLine(basicPen, InitialXOffset - 7, y, InitialXOffset + 7, y);
                graphics.DrawString(i.ToString(), font, brush, InitialXOffset + 10, y - 5);
            }
        }
    }


    public static class InputValidator
    {
        public static void ValidateInput(TextBox textBox, ref double value, Label warningLabel, double? minValue = null, double? maxValue = null)
        {
            if (double.TryParse(textBox.Text, out value))
            {
                if (minValue.HasValue && value < minValue.Value)
                {
                    warningLabel.Text = $"Value should be greater than {minValue.Value}.";
                    warningLabel.Visible = true;
                }
                else if (maxValue.HasValue && value > maxValue.Value)
                {
                    warningLabel.Text = $"Value should be less than {maxValue.Value}.";
                    warningLabel.Visible = true;
                }
                else
                {
                    warningLabel.Visible = false;
                    warningLabel.Text = string.Empty;
                }
            }
            else if (string.IsNullOrEmpty(textBox.Text))
            {
                warningLabel.Visible = true;
                warningLabel.Text = $"An empty {textBox.Name} textbox.";
            }
            else
            {
                warningLabel.Visible = true;
                warningLabel.Text = $"Invalid data in {textBox.Name} textbox.";
            }
        }
    }
}
