
namespace Seminarski
{
    partial class Forma
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
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.shipTimer = new System.Windows.Forms.Timer(this.components);
            this.bulletTimer = new System.Windows.Forms.Timer(this.components);
            this.chickenTimer = new System.Windows.Forms.Timer(this.components);
            this.livesLabel = new System.Windows.Forms.Label();
            this.eggTimer = new System.Windows.Forms.Timer(this.components);
            this.modeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 25);
            this.scoreLabel.TabIndex = 2;
            // 
            // shipTimer
            // 
            this.shipTimer.Interval = 20;
            this.shipTimer.Tick += new System.EventHandler(this.shipTick);
            // 
            // bulletTimer
            // 
            this.bulletTimer.Interval = 20;
            this.bulletTimer.Tick += new System.EventHandler(this.bulletTick);
            // 
            // chickenTimer
            // 
            this.chickenTimer.Interval = 20;
            this.chickenTimer.Tick += new System.EventHandler(this.chickenTick);
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.BackColor = System.Drawing.Color.Transparent;
            this.livesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.livesLabel.Location = new System.Drawing.Point(755, 18);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(0, 25);
            this.livesLabel.TabIndex = 3;
            // 
            // eggTimer
            // 
            this.eggTimer.Interval = 20;
            this.eggTimer.Tick += new System.EventHandler(this.EggTimerTick);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(708, 10);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(0, 13);
            this.modeLabel.TabIndex = 4;
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Seminarski.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(884, 458);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Name = "Forma";
            this.Text = "Chicken Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_Down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.key_Up);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer shipTimer;
        private System.Windows.Forms.Timer bulletTimer;
        private System.Windows.Forms.Timer chickenTimer;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Timer eggTimer;
        private System.Windows.Forms.Label modeLabel;
    }
}

