using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrajectorySimulator 
{
    public partial class EnteringDataForm : Form
    {
        private const double TimeInterval = 2;
        private double x0, y0, angle, v0, acceleration;
        private static Graphics graphics;
        private Color trajectoryColor = Color.Blue;

        public EnteringDataForm()
        {
            InitializeComponent();
            WarningForAllData.Visible = false;
            WarningForX.Visible = false;
            WarningForY.Visible = false;
            WarningForA.Visible = false;
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

        private void ATextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator.ValidateInput(ATextBox, ref acceleration, WarningForA);
        }

        private bool IsDataEntered()
        {
            return WarningForX.Visible == false
                && WarningForY.Visible == false
                && WarningForA.Visible == false
                && WarningForAngle.Visible == false
                && WarningForV.Visible == false;
        }

        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrEmpty(XTextBox.Text)
                && !string.IsNullOrEmpty(YTextBox.Text)
                && !string.IsNullOrEmpty(AngleTextBox.Text)
                && !string.IsNullOrEmpty(VTextBox.Text)
                && !string.IsNullOrEmpty(ATextBox.Text);
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

        private void EnteringDataForm_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
        }

        private void DrawTrajectory()
        {
            graphics = CreateGraphics();
            GraphicsHelper.DrawTrajectory(graphics, x0, y0, angle, v0, acceleration, trajectoryColor);
        }

        private void DrawCoordinateAxesButton_Click(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
            GraphicsHelper.DrawCoordinateAxes(graphics);
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
    }
    public static class GraphicsHelper
    {
        public static void DrawTrajectory(Graphics graphics, double x0, double y0, double angle, double v0, double acceleration, Color trajectoryColor)
        {
            const double TimeInterval = 2;
            const int InitialXOffset = 600;
            const int InitialYOffset = 10;
            const int AxesXSize = 500;
            const int AxesYSize = 500;

            Pen pen = new Pen(trajectoryColor, 2);
            double alpha = (360 - angle) * Math.PI / 180;
            double time = 0;
            double x = x0 + InitialXOffset + AxesXSize / 2;
            double y = -y0 + InitialYOffset + AxesYSize / 2;
            double startX = x;
            double startY = y;

            while (x >= InitialXOffset && x <= InitialXOffset + AxesXSize && y >= InitialYOffset && y <= InitialYOffset + AxesYSize)
            {
                x = startX + v0 * time * Math.Cos(alpha) + 0.5 * acceleration * time * time * Math.Cos(alpha);
                y = startY + v0 * time * Math.Sin(alpha) + 0.5 * acceleration * time * time * Math.Sin(alpha);
                graphics.FillEllipse(pen.Brush, (float)x, (float)y, 6, 6);
                time += TimeInterval;
            }
        }

        public static void DrawCoordinateAxes(Graphics graphics)
        {
            const int InitialXOffset = 600;
            const int InitialYOffset = 10;
            const int AxesXSize = 500;
            const int AxesYSize = 500;

            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            graphics.DrawString("0", font, brush, InitialXOffset + (AxesXSize / 2) + 5, InitialYOffset + (AxesYSize / 2) + 5);

            Pen gridPen = new Pen(Color.LightGray, 1f);
            Pen basicPen = new Pen(Color.Black, 3f);

            for (int x = InitialXOffset; x <= InitialXOffset + AxesXSize; x += 50)
                graphics.DrawLine(gridPen, x, InitialYOffset, x, InitialYOffset + AxesYSize);

            for (int y = InitialYOffset; y <= InitialYOffset + AxesYSize; y += 50)
                graphics.DrawLine(gridPen, InitialXOffset, y, InitialXOffset + AxesXSize, y);

            graphics.DrawLine(basicPen, InitialXOffset, InitialYOffset + AxesYSize / 2, InitialXOffset + AxesXSize, InitialYOffset + AxesYSize / 2);
            graphics.DrawLine(basicPen, InitialXOffset + AxesXSize / 2, InitialYOffset, InitialXOffset + AxesXSize / 2, InitialYOffset + AxesYSize);

            for (int x = InitialXOffset, i = -AxesXSize / 2; x <= InitialXOffset + AxesXSize - 1; x += 50, i += 50)
            {
                graphics.DrawLine(basicPen, x, InitialYOffset + AxesYSize / 2 - 7, x, InitialYOffset + AxesYSize / 2 + 7);
                if (i != 0) graphics.DrawString(i.ToString(), font, brush, x - 10, InitialYOffset + AxesYSize / 2 + 8);
            }

            for (int y = InitialYOffset + AxesYSize, i = -AxesYSize / 2; y > InitialYOffset; y -= 50, i += 50)
            {
                graphics.DrawLine(basicPen, InitialXOffset + AxesXSize / 2 - 7, y, InitialXOffset + AxesXSize / 2 + 7, y);
                if (i != 0) graphics.DrawString(i.ToString(), font, brush, InitialXOffset + AxesXSize / 2 + 5, y);
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
