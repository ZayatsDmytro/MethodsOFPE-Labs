namespace TrajectorySimulator
{
    partial class EnteringDataForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VTextBox = new TextBox();
            AngleTextBox = new TextBox();
            XTextBox = new TextBox();
            YTextBox = new TextBox();
            xLabelInfo = new Label();
            YLabelInfo = new Label();
            AngleLabelInfo = new Label();
            VLabelInfo1 = new Label();
            WarningForX = new Label();
            WarningForY = new Label();
            WarningForAngle = new Label();
            WarningForV = new Label();
            CoordinateAxesExamplePictureBox = new PictureBox();
            DrawTrajectoryButton = new Button();
            ClearTrajectoryButton = new Button();
            WarningForAllData = new Label();
            colorDialog1 = new ColorDialog();
            SelectColorButton = new Button();
            HeaderLabel = new Label();
            VLabelInfo2 = new Label();
            DrawCoordinateAxesButton = new Button();
            Save = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TimeValueLabel = new Label();
            DistanceValueLabel = new Label();
            HeightValueLabel = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)CoordinateAxesExamplePictureBox).BeginInit();
            SuspendLayout();
            // 
            // VTextBox
            // 
            VTextBox.BackColor = Color.FromArgb(255, 192, 255);
            VTextBox.Location = new Point(134, 366);
            VTextBox.Name = "VTextBox";
            VTextBox.Size = new Size(233, 27);
            VTextBox.TabIndex = 0;
            VTextBox.TextChanged += VTextBox_TextChanged;
            // 
            // AngleTextBox
            // 
            AngleTextBox.BackColor = Color.FromArgb(255, 192, 255);
            AngleTextBox.Location = new Point(134, 277);
            AngleTextBox.Name = "AngleTextBox";
            AngleTextBox.Size = new Size(233, 27);
            AngleTextBox.TabIndex = 1;
            AngleTextBox.TextChanged += AngleTextBox_TextChanged;
            // 
            // XTextBox
            // 
            XTextBox.BackColor = Color.FromArgb(255, 192, 255);
            XTextBox.Location = new Point(134, 101);
            XTextBox.Name = "XTextBox";
            XTextBox.Size = new Size(233, 27);
            XTextBox.TabIndex = 2;
            XTextBox.TextChanged += XTextBox_Changed;
            // 
            // YTextBox
            // 
            YTextBox.BackColor = Color.FromArgb(255, 192, 255);
            YTextBox.Location = new Point(135, 188);
            YTextBox.Name = "YTextBox";
            YTextBox.Size = new Size(233, 27);
            YTextBox.TabIndex = 4;
            YTextBox.TextChanged += YTextBox_TextChanged;
            // 
            // xLabelInfo
            // 
            xLabelInfo.AutoSize = true;
            xLabelInfo.Location = new Point(56, 101);
            xLabelInfo.Name = "xLabelInfo";
            xLabelInfo.Size = new Size(79, 20);
            xLabelInfo.TabIndex = 6;
            xLabelInfo.Text = "x0(meters)";
            // 
            // YLabelInfo
            // 
            YLabelInfo.AutoSize = true;
            YLabelInfo.Location = new Point(56, 191);
            YLabelInfo.Name = "YLabelInfo";
            YLabelInfo.Size = new Size(79, 20);
            YLabelInfo.TabIndex = 7;
            YLabelInfo.Text = "y0(meters)";
            // 
            // AngleLabelInfo
            // 
            AngleLabelInfo.AutoSize = true;
            AngleLabelInfo.Location = new Point(1, 284);
            AngleLabelInfo.Name = "AngleLabelInfo";
            AngleLabelInfo.Size = new Size(127, 20);
            AngleLabelInfo.TabIndex = 8;
            AngleLabelInfo.Text = "Angle(In degrees)";
            // 
            // VLabelInfo1
            // 
            VLabelInfo1.AutoSize = true;
            VLabelInfo1.Location = new Point(-3, 367);
            VLabelInfo1.Name = "VLabelInfo1";
            VLabelInfo1.Size = new Size(106, 20);
            VLabelInfo1.TabIndex = 9;
            VLabelInfo1.Text = "InnitialVelocity";
            // 
            // WarningForX
            // 
            WarningForX.AutoSize = true;
            WarningForX.ForeColor = Color.Red;
            WarningForX.Location = new Point(134, 131);
            WarningForX.Name = "WarningForX";
            WarningForX.Size = new Size(94, 20);
            WarningForX.TabIndex = 11;
            WarningForX.Text = "WarningForX";
            // 
            // WarningForY
            // 
            WarningForY.AutoSize = true;
            WarningForY.ForeColor = Color.Red;
            WarningForY.Location = new Point(135, 218);
            WarningForY.Name = "WarningForY";
            WarningForY.Size = new Size(93, 20);
            WarningForY.TabIndex = 12;
            WarningForY.Text = "WarningForY";
            // 
            // WarningForAngle
            // 
            WarningForAngle.AutoSize = true;
            WarningForAngle.ForeColor = Color.Red;
            WarningForAngle.Location = new Point(134, 307);
            WarningForAngle.Name = "WarningForAngle";
            WarningForAngle.Size = new Size(124, 20);
            WarningForAngle.TabIndex = 13;
            WarningForAngle.Text = "WarningForAngle";
            // 
            // WarningForV
            // 
            WarningForV.AutoSize = true;
            WarningForV.ForeColor = Color.Red;
            WarningForV.Location = new Point(134, 396);
            WarningForV.Name = "WarningForV";
            WarningForV.Size = new Size(94, 20);
            WarningForV.TabIndex = 14;
            WarningForV.Text = "WarningForV";
            // 
            // CoordinateAxesExamplePictureBox
            // 
            CoordinateAxesExamplePictureBox.BackColor = Color.Transparent;
            CoordinateAxesExamplePictureBox.Image = Properties.Resources.images;
            CoordinateAxesExamplePictureBox.Location = new Point(739, 46);
            CoordinateAxesExamplePictureBox.Name = "CoordinateAxesExamplePictureBox";
            CoordinateAxesExamplePictureBox.Size = new Size(476, 408);
            CoordinateAxesExamplePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CoordinateAxesExamplePictureBox.TabIndex = 16;
            CoordinateAxesExamplePictureBox.TabStop = false;
            CoordinateAxesExamplePictureBox.Visible = false;
            // 
            // DrawTrajectoryButton
            // 
            DrawTrajectoryButton.BackColor = Color.FromArgb(255, 192, 192);
            DrawTrajectoryButton.Location = new Point(409, 281);
            DrawTrajectoryButton.Name = "DrawTrajectoryButton";
            DrawTrajectoryButton.Size = new Size(170, 29);
            DrawTrajectoryButton.TabIndex = 17;
            DrawTrajectoryButton.Text = "Draw Trajectory";
            DrawTrajectoryButton.UseVisualStyleBackColor = false;
            DrawTrajectoryButton.Click += DrawButton_Click;
            // 
            // ClearTrajectoryButton
            // 
            ClearTrajectoryButton.BackColor = Color.FromArgb(255, 192, 192);
            ClearTrajectoryButton.Location = new Point(414, 383);
            ClearTrajectoryButton.Name = "ClearTrajectoryButton";
            ClearTrajectoryButton.Size = new Size(170, 29);
            ClearTrajectoryButton.TabIndex = 18;
            ClearTrajectoryButton.Text = "Clear trajectory, axes";
            ClearTrajectoryButton.UseVisualStyleBackColor = false;
            ClearTrajectoryButton.Click += ClearButton_Click;
            // 
            // WarningForAllData
            // 
            WarningForAllData.AutoSize = true;
            WarningForAllData.ForeColor = Color.Red;
            WarningForAllData.Location = new Point(408, 313);
            WarningForAllData.Name = "WarningForAllData";
            WarningForAllData.Size = new Size(171, 20);
            WarningForAllData.TabIndex = 19;
            WarningForAllData.Text = "Not all data is perceived";
            // 
            // SelectColorButton
            // 
            SelectColorButton.BackColor = Color.FromArgb(255, 192, 255);
            SelectColorButton.ForeColor = SystemColors.ActiveCaptionText;
            SelectColorButton.Location = new Point(414, 483);
            SelectColorButton.Name = "SelectColorButton";
            SelectColorButton.Size = new Size(175, 79);
            SelectColorButton.TabIndex = 20;
            SelectColorButton.Text = "Select Color for Trajectory";
            SelectColorButton.UseVisualStyleBackColor = false;
            SelectColorButton.Click += SelectColorButton_Click;
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HeaderLabel.Location = new Point(36, 29);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(459, 38);
            HeaderLabel.TabIndex = 21;
            HeaderLabel.Text = "ENTER DATA ABOUT MOVEMENT";
            // 
            // VLabelInfo2
            // 
            VLabelInfo2.AutoSize = true;
            VLabelInfo2.Location = new Point(18, 387);
            VLabelInfo2.Name = "VLabelInfo2";
            VLabelInfo2.Size = new Size(117, 20);
            VLabelInfo2.TabIndex = 22;
            VLabelInfo2.Text = "(meters/second)";
            // 
            // DrawCoordinateAxesButton
            // 
            DrawCoordinateAxesButton.BackColor = Color.FromArgb(255, 192, 192);
            DrawCoordinateAxesButton.Location = new Point(409, 225);
            DrawCoordinateAxesButton.Name = "DrawCoordinateAxesButton";
            DrawCoordinateAxesButton.Size = new Size(170, 29);
            DrawCoordinateAxesButton.TabIndex = 24;
            DrawCoordinateAxesButton.Text = "Draw Coordinate Axes";
            DrawCoordinateAxesButton.UseVisualStyleBackColor = false;
            DrawCoordinateAxesButton.Click += DrawCoordinateAxesButton_Click;
            // 
            // Save
            // 
            Save.BackColor = Color.FromArgb(255, 192, 192);
            Save.Location = new Point(408, 337);
            Save.Name = "Save";
            Save.Size = new Size(170, 29);
            Save.TabIndex = 25;
            Save.Text = "Save File";
            Save.UseVisualStyleBackColor = false;
            Save.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 483);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 26;
            label1.Text = "Body flight range:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 517);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 27;
            label2.Text = "Maximum height:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 453);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 28;
            label3.Text = "Flight time:";
            // 
            // TimeValueLabel
            // 
            TimeValueLabel.AutoSize = true;
            TimeValueLabel.Location = new Point(93, 453);
            TimeValueLabel.Name = "TimeValueLabel";
            TimeValueLabel.Size = new Size(114, 20);
            TimeValueLabel.TabIndex = 29;
            TimeValueLabel.Text = "TimeValueLabel";
            TimeValueLabel.Visible = false;
            // 
            // DistanceValueLabel
            // 
            DistanceValueLabel.AutoSize = true;
            DistanceValueLabel.Location = new Point(149, 483);
            DistanceValueLabel.Name = "DistanceValueLabel";
            DistanceValueLabel.Size = new Size(138, 20);
            DistanceValueLabel.TabIndex = 30;
            DistanceValueLabel.Text = "DistanceValueLabel";
            DistanceValueLabel.Visible = false;
            // 
            // HeightValueLabel
            // 
            HeightValueLabel.AutoSize = true;
            HeightValueLabel.Location = new Point(135, 517);
            HeightValueLabel.Name = "HeightValueLabel";
            HeightValueLabel.Size = new Size(126, 20);
            HeightValueLabel.TabIndex = 31;
            HeightValueLabel.Text = "HeightValueLabel";
            HeightValueLabel.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Location = new Point(414, 432);
            button1.Name = "button1";
            button1.Size = new Size(170, 29);
            button1.TabIndex = 32;
            button1.Text = "Show flight info";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ShowFlightInfoButton_Click;
            // 
            // EnteringDataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(1235, 567);
            Controls.Add(button1);
            Controls.Add(HeightValueLabel);
            Controls.Add(DistanceValueLabel);
            Controls.Add(TimeValueLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Save);
            Controls.Add(DrawCoordinateAxesButton);
            Controls.Add(VLabelInfo2);
            Controls.Add(HeaderLabel);
            Controls.Add(SelectColorButton);
            Controls.Add(WarningForAllData);
            Controls.Add(ClearTrajectoryButton);
            Controls.Add(DrawTrajectoryButton);
            Controls.Add(CoordinateAxesExamplePictureBox);
            Controls.Add(WarningForV);
            Controls.Add(WarningForAngle);
            Controls.Add(WarningForY);
            Controls.Add(WarningForX);
            Controls.Add(VLabelInfo1);
            Controls.Add(AngleLabelInfo);
            Controls.Add(YLabelInfo);
            Controls.Add(xLabelInfo);
            Controls.Add(YTextBox);
            Controls.Add(XTextBox);
            Controls.Add(AngleTextBox);
            Controls.Add(VTextBox);
            Name = "EnteringDataForm";
            Text = "git";
            Load += EnteringDataForm_Load;
            Paint += EnteringDataForm_Paint;
            ((System.ComponentModel.ISupportInitialize)CoordinateAxesExamplePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox VTextBox;
        private TextBox AngleTextBox;
        private TextBox XTextBox;
        private TextBox YTextBox;
        private Label xLabelInfo;
        private Label YLabelInfo;
        private Label AngleLabelInfo;
        private Label VLabelInfo1;
        private Label WarningForX;
        private Label WarningForY;
        private Label WarningForAngle;
        private Label WarningForV;
        private PictureBox CoordinateAxesExamplePictureBox;
        private Button DrawTrajectoryButton;
        private Button ClearTrajectoryButton;
        private Label WarningForAllData;
        private ColorDialog colorDialog1;
        private Button SelectColorButton;
        private Label HeaderLabel;
        private Label VLabelInfo2;
        private Button DrawCoordinateAxesButton;
        private Button Save;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label TimeValueLabel;
        private Label DistanceValueLabel;
        private Label HeightValueLabel;
        private Button button1;
    }
}
