
namespace SDRSharp.TuningDial
{
    partial class ControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FilterBandWidthEncoder = new SDRSharp.TuningDial.VirtualEncoder();
            this.ZoomEncoder = new SDRSharp.TuningDial.VirtualEncoder();
            this.SquelchEncoder = new SDRSharp.TuningDial.VirtualEncoder();
            this.AudioGainEncoder = new SDRSharp.TuningDial.VirtualEncoder();
            this.FrequencyEncoder = new SDRSharp.TuningDial.VirtualEncoder();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Frequency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Audio Gain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Squelch Level";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(524, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zoom";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(668, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Filter Bandwidth";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilterBandWidthEncoder
            // 
            this.FilterBandWidthEncoder.AllowStepChanges = false;
            this.FilterBandWidthEncoder.CustomStep = 1;
            this.FilterBandWidthEncoder.GlowColor = SDRSharp.TuningDial.IlluminationColor.Yellow;
            this.FilterBandWidthEncoder.Location = new System.Drawing.Point(670, 87);
            this.FilterBandWidthEncoder.Name = "FilterBandWidthEncoder";
            this.FilterBandWidthEncoder.ShowGlow = true;
            this.FilterBandWidthEncoder.Size = new System.Drawing.Size(122, 131);
            this.FilterBandWidthEncoder.TabIndex = 4;
            this.FilterBandWidthEncoder.UseAutoStep = false;
            // 
            // ZoomEncoder
            // 
            this.ZoomEncoder.AllowStepChanges = false;
            this.ZoomEncoder.CustomStep = 1;
            this.ZoomEncoder.GlowColor = SDRSharp.TuningDial.IlluminationColor.Orange;
            this.ZoomEncoder.Location = new System.Drawing.Point(527, 87);
            this.ZoomEncoder.Name = "ZoomEncoder";
            this.ZoomEncoder.ShowGlow = true;
            this.ZoomEncoder.Size = new System.Drawing.Size(122, 131);
            this.ZoomEncoder.TabIndex = 3;
            this.ZoomEncoder.UseAutoStep = false;
            // 
            // SquelchEncoder
            // 
            this.SquelchEncoder.AllowStepChanges = false;
            this.SquelchEncoder.CustomStep = 1;
            this.SquelchEncoder.GlowColor = SDRSharp.TuningDial.IlluminationColor.Green;
            this.SquelchEncoder.Location = new System.Drawing.Point(384, 87);
            this.SquelchEncoder.Name = "SquelchEncoder";
            this.SquelchEncoder.ShowGlow = true;
            this.SquelchEncoder.Size = new System.Drawing.Size(122, 131);
            this.SquelchEncoder.TabIndex = 2;
            this.SquelchEncoder.UseAutoStep = false;
            // 
            // AudioGainEncoder
            // 
            this.AudioGainEncoder.AllowStepChanges = false;
            this.AudioGainEncoder.CustomStep = 1;
            this.AudioGainEncoder.GlowColor = SDRSharp.TuningDial.IlluminationColor.Red;
            this.AudioGainEncoder.Location = new System.Drawing.Point(241, 87);
            this.AudioGainEncoder.Name = "AudioGainEncoder";
            this.AudioGainEncoder.ShowGlow = true;
            this.AudioGainEncoder.Size = new System.Drawing.Size(122, 131);
            this.AudioGainEncoder.TabIndex = 1;
            this.AudioGainEncoder.UseAutoStep = false;
            // 
            // FrequencyEncoder
            // 
            this.FrequencyEncoder.AllowStepChanges = false;
            this.FrequencyEncoder.CustomStep = 1;
            this.FrequencyEncoder.GlowColor = SDRSharp.TuningDial.IlluminationColor.Blue;
            this.FrequencyEncoder.Location = new System.Drawing.Point(21, 40);
            this.FrequencyEncoder.Name = "FrequencyEncoder";
            this.FrequencyEncoder.ShowGlow = true;
            this.FrequencyEncoder.Size = new System.Drawing.Size(184, 195);
            this.FrequencyEncoder.TabIndex = 0;
            this.FrequencyEncoder.UseAutoStep = false;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterBandWidthEncoder);
            this.Controls.Add(this.ZoomEncoder);
            this.Controls.Add(this.SquelchEncoder);
            this.Controls.Add(this.AudioGainEncoder);
            this.Controls.Add(this.FrequencyEncoder);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(837, 263);
            this.ResumeLayout(false);

        }

        #endregion

        private VirtualEncoder FrequencyEncoder;
        private VirtualEncoder AudioGainEncoder;
        private VirtualEncoder SquelchEncoder;
        private VirtualEncoder ZoomEncoder;
        private VirtualEncoder FilterBandWidthEncoder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
