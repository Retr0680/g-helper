﻿namespace GHelper
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkStartup = new System.Windows.Forms.CheckBox();
            this.trackBattery = new System.Windows.Forms.TrackBar();
            this.labelBattery = new System.Windows.Forms.Label();
            this.labelBatteryLimit = new System.Windows.Forms.Label();
            this.pictureBattery = new System.Windows.Forms.PictureBox();
            this.labelGPUFan = new System.Windows.Forms.Label();
            this.tableGPU = new System.Windows.Forms.TableLayoutPanel();
            this.buttonUltimate = new System.Windows.Forms.Button();
            this.buttonStandard = new System.Windows.Forms.Button();
            this.buttonEco = new System.Windows.Forms.Button();
            this.labelGPU = new System.Windows.Forms.Label();
            this.pictureGPU = new System.Windows.Forms.PictureBox();
            this.labelCPUFan = new System.Windows.Forms.Label();
            this.tablePerf = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTurbo = new System.Windows.Forms.Button();
            this.buttonBalanced = new System.Windows.Forms.Button();
            this.buttonSilent = new System.Windows.Forms.Button();
            this.picturePerf = new System.Windows.Forms.PictureBox();
            this.labelPerf = new System.Windows.Forms.Label();
            this.checkGPU = new System.Windows.Forms.CheckBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBattery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBattery)).BeginInit();
            this.tableGPU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGPU)).BeginInit();
            this.tablePerf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePerf)).BeginInit();
            this.SuspendLayout();
            // 
            // checkStartup
            // 
            this.checkStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkStartup.AutoSize = true;
            this.checkStartup.Location = new System.Drawing.Point(34, 640);
            this.checkStartup.Name = "checkStartup";
            this.checkStartup.Size = new System.Drawing.Size(206, 36);
            this.checkStartup.TabIndex = 2;
            this.checkStartup.Text = "Run on Startup";
            this.checkStartup.UseVisualStyleBackColor = true;
            this.checkStartup.CheckedChanged += new System.EventHandler(this.checkStartup_CheckedChanged);
            // 
            // trackBattery
            // 
            this.trackBattery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBattery.LargeChange = 20;
            this.trackBattery.Location = new System.Drawing.Point(23, 532);
            this.trackBattery.Maximum = 100;
            this.trackBattery.Minimum = 50;
            this.trackBattery.Name = "trackBattery";
            this.trackBattery.Size = new System.Drawing.Size(702, 90);
            this.trackBattery.SmallChange = 10;
            this.trackBattery.TabIndex = 3;
            this.trackBattery.TickFrequency = 10;
            this.trackBattery.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBattery.Value = 100;
            // 
            // labelBattery
            // 
            this.labelBattery.AutoSize = true;
            this.labelBattery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBattery.Location = new System.Drawing.Point(83, 486);
            this.labelBattery.Name = "labelBattery";
            this.labelBattery.Size = new System.Drawing.Size(248, 32);
            this.labelBattery.TabIndex = 4;
            this.labelBattery.Text = "Battery Charge Limit";
            // 
            // labelBatteryLimit
            // 
            this.labelBatteryLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBatteryLimit.AutoSize = true;
            this.labelBatteryLimit.Location = new System.Drawing.Point(647, 484);
            this.labelBatteryLimit.Name = "labelBatteryLimit";
            this.labelBatteryLimit.Size = new System.Drawing.Size(73, 32);
            this.labelBatteryLimit.TabIndex = 5;
            this.labelBatteryLimit.Text = "100%";
            // 
            // pictureBattery
            // 
            this.pictureBattery.Image = global::GHelper.Properties.Resources.icons8_charging_battery_48;
            this.pictureBattery.Location = new System.Drawing.Point(32, 478);
            this.pictureBattery.Name = "pictureBattery";
            this.pictureBattery.Size = new System.Drawing.Size(48, 48);
            this.pictureBattery.TabIndex = 6;
            this.pictureBattery.TabStop = false;
            // 
            // labelGPUFan
            // 
            this.labelGPUFan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGPUFan.AutoSize = true;
            this.labelGPUFan.Location = new System.Drawing.Point(566, 242);
            this.labelGPUFan.Name = "labelGPUFan";
            this.labelGPUFan.Size = new System.Drawing.Size(155, 32);
            this.labelGPUFan.TabIndex = 8;
            this.labelGPUFan.Text = "GPU Fan : 0%";
            // 
            // tableGPU
            // 
            this.tableGPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableGPU.ColumnCount = 3;
            this.tableGPU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableGPU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableGPU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableGPU.Controls.Add(this.buttonUltimate, 2, 0);
            this.tableGPU.Controls.Add(this.buttonStandard, 1, 0);
            this.tableGPU.Controls.Add(this.buttonEco, 0, 0);
            this.tableGPU.Location = new System.Drawing.Point(23, 289);
            this.tableGPU.Name = "tableGPU";
            this.tableGPU.RowCount = 1;
            this.tableGPU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableGPU.Size = new System.Drawing.Size(702, 106);
            this.tableGPU.TabIndex = 7;
            // 
            // buttonUltimate
            // 
            this.buttonUltimate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUltimate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUltimate.FlatAppearance.BorderSize = 0;
            this.buttonUltimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUltimate.Location = new System.Drawing.Point(478, 10);
            this.buttonUltimate.Margin = new System.Windows.Forms.Padding(10);
            this.buttonUltimate.Name = "buttonUltimate";
            this.buttonUltimate.Size = new System.Drawing.Size(214, 86);
            this.buttonUltimate.TabIndex = 2;
            this.buttonUltimate.Text = "Ultimate";
            this.buttonUltimate.UseVisualStyleBackColor = false;
            // 
            // buttonStandard
            // 
            this.buttonStandard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStandard.FlatAppearance.BorderSize = 0;
            this.buttonStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStandard.Location = new System.Drawing.Point(244, 10);
            this.buttonStandard.Margin = new System.Windows.Forms.Padding(10);
            this.buttonStandard.Name = "buttonStandard";
            this.buttonStandard.Size = new System.Drawing.Size(214, 86);
            this.buttonStandard.TabIndex = 1;
            this.buttonStandard.Text = "Standard";
            this.buttonStandard.UseVisualStyleBackColor = false;
            // 
            // buttonEco
            // 
            this.buttonEco.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEco.CausesValidation = false;
            this.buttonEco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEco.FlatAppearance.BorderSize = 0;
            this.buttonEco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEco.Location = new System.Drawing.Point(10, 10);
            this.buttonEco.Margin = new System.Windows.Forms.Padding(10);
            this.buttonEco.Name = "buttonEco";
            this.buttonEco.Size = new System.Drawing.Size(214, 86);
            this.buttonEco.TabIndex = 0;
            this.buttonEco.Text = "Eco";
            this.buttonEco.UseVisualStyleBackColor = false;
            // 
            // labelGPU
            // 
            this.labelGPU.AutoSize = true;
            this.labelGPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGPU.Location = new System.Drawing.Point(82, 242);
            this.labelGPU.Name = "labelGPU";
            this.labelGPU.Size = new System.Drawing.Size(136, 32);
            this.labelGPU.TabIndex = 9;
            this.labelGPU.Text = "GPU Mode";
            // 
            // pictureGPU
            // 
            this.pictureGPU.Image = global::GHelper.Properties.Resources.icons8_video_card_48;
            this.pictureGPU.Location = new System.Drawing.Point(29, 234);
            this.pictureGPU.Name = "pictureGPU";
            this.pictureGPU.Size = new System.Drawing.Size(48, 48);
            this.pictureGPU.TabIndex = 10;
            this.pictureGPU.TabStop = false;
            // 
            // labelCPUFan
            // 
            this.labelCPUFan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCPUFan.AutoSize = true;
            this.labelCPUFan.Location = new System.Drawing.Point(568, 39);
            this.labelCPUFan.Name = "labelCPUFan";
            this.labelCPUFan.Size = new System.Drawing.Size(154, 32);
            this.labelCPUFan.TabIndex = 12;
            this.labelCPUFan.Text = "CPU Fan : 0%";
            // 
            // tablePerf
            // 
            this.tablePerf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePerf.ColumnCount = 3;
            this.tablePerf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePerf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePerf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePerf.Controls.Add(this.buttonTurbo, 2, 0);
            this.tablePerf.Controls.Add(this.buttonBalanced, 1, 0);
            this.tablePerf.Controls.Add(this.buttonSilent, 0, 0);
            this.tablePerf.Location = new System.Drawing.Point(23, 90);
            this.tablePerf.Name = "tablePerf";
            this.tablePerf.RowCount = 1;
            this.tablePerf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tablePerf.Size = new System.Drawing.Size(702, 106);
            this.tablePerf.TabIndex = 11;
            // 
            // buttonTurbo
            // 
            this.buttonTurbo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTurbo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTurbo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTurbo.FlatAppearance.BorderSize = 0;
            this.buttonTurbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurbo.Location = new System.Drawing.Point(478, 10);
            this.buttonTurbo.Margin = new System.Windows.Forms.Padding(10);
            this.buttonTurbo.Name = "buttonTurbo";
            this.buttonTurbo.Size = new System.Drawing.Size(214, 86);
            this.buttonTurbo.TabIndex = 2;
            this.buttonTurbo.Text = "Turbo";
            this.buttonTurbo.UseVisualStyleBackColor = false;
            // 
            // buttonBalanced
            // 
            this.buttonBalanced.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBalanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBalanced.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonBalanced.FlatAppearance.BorderSize = 0;
            this.buttonBalanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBalanced.Location = new System.Drawing.Point(244, 10);
            this.buttonBalanced.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBalanced.Name = "buttonBalanced";
            this.buttonBalanced.Size = new System.Drawing.Size(214, 86);
            this.buttonBalanced.TabIndex = 1;
            this.buttonBalanced.Text = "Balanced";
            this.buttonBalanced.UseVisualStyleBackColor = false;
            // 
            // buttonSilent
            // 
            this.buttonSilent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSilent.CausesValidation = false;
            this.buttonSilent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSilent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSilent.FlatAppearance.BorderSize = 0;
            this.buttonSilent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSilent.Location = new System.Drawing.Point(10, 10);
            this.buttonSilent.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSilent.Name = "buttonSilent";
            this.buttonSilent.Size = new System.Drawing.Size(214, 86);
            this.buttonSilent.TabIndex = 0;
            this.buttonSilent.Text = "Silent";
            this.buttonSilent.UseVisualStyleBackColor = false;
            // 
            // picturePerf
            // 
            this.picturePerf.Image = global::GHelper.Properties.Resources.icons8_speed_48;
            this.picturePerf.Location = new System.Drawing.Point(30, 29);
            this.picturePerf.Name = "picturePerf";
            this.picturePerf.Size = new System.Drawing.Size(48, 48);
            this.picturePerf.TabIndex = 14;
            this.picturePerf.TabStop = false;
            // 
            // labelPerf
            // 
            this.labelPerf.AutoSize = true;
            this.labelPerf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPerf.Location = new System.Drawing.Point(83, 37);
            this.labelPerf.Name = "labelPerf";
            this.labelPerf.Size = new System.Drawing.Size(234, 32);
            this.labelPerf.TabIndex = 13;
            this.labelPerf.Text = "Performance Mode";
            // 
            // checkGPU
            // 
            this.checkGPU.AutoSize = true;
            this.checkGPU.Location = new System.Drawing.Point(34, 400);
            this.checkGPU.Name = "checkGPU";
            this.checkGPU.Size = new System.Drawing.Size(614, 36);
            this.checkGPU.TabIndex = 15;
            this.checkGPU.Text = "Switch to Eco on battery and Standard when plugged";
            this.checkGPU.UseVisualStyleBackColor = true;
            this.checkGPU.CheckedChanged += new System.EventHandler(this.checkGPU_CheckedChanged);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonQuit.Location = new System.Drawing.Point(602, 634);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(120, 46);
            this.buttonQuit.TabIndex = 16;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 704);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.checkGPU);
            this.Controls.Add(this.picturePerf);
            this.Controls.Add(this.labelPerf);
            this.Controls.Add(this.labelCPUFan);
            this.Controls.Add(this.tablePerf);
            this.Controls.Add(this.pictureGPU);
            this.Controls.Add(this.labelGPU);
            this.Controls.Add(this.labelGPUFan);
            this.Controls.Add(this.tableGPU);
            this.Controls.Add(this.pictureBattery);
            this.Controls.Add(this.labelBatteryLimit);
            this.Controls.Add(this.labelBattery);
            this.Controls.Add(this.trackBattery);
            this.Controls.Add(this.checkStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G14 Helper";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBattery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBattery)).EndInit();
            this.tableGPU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureGPU)).EndInit();
            this.tablePerf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePerf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CheckBox checkStartup;
        private TrackBar trackBattery;
        private Label labelBattery;
        private Label labelBatteryLimit;
        private PictureBox pictureBattery;
        private Label labelGPUFan;
        private TableLayoutPanel tableGPU;
        private Button buttonUltimate;
        private Button buttonStandard;
        private Button buttonEco;
        private Label labelGPU;
        private PictureBox pictureGPU;
        private Label labelCPUFan;
        private TableLayoutPanel tablePerf;
        private Button buttonTurbo;
        private Button buttonBalanced;
        private Button buttonSilent;
        private PictureBox picturePerf;
        private Label labelPerf;
        private CheckBox checkGPU;
        private Button buttonQuit;
    }
}