using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDRSharp.Common;

namespace SDRSharp.TuningDial
{
    public partial class ControlPanel : UserControl
    {
        private readonly ISharpControl sharpControl;
       static int z;
        public ControlPanel(ISharpControl control)
        {
            sharpControl = control;

            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            FrequencyEncoder.DirectionChanged += FrequencyEncoder_DirectionChanged; //Frequency
            AudioGainEncoder.DirectionChanged += AudioGainEncoder_DirectionChanged; //Volume
            SquelchEncoder.DirectionChanged += SquelchEncoder_DirectionChanged; //Squelch
            ZoomEncoder.DirectionChanged += ZoomEncoder_DirectionChanged; //Zoom
            FilterBandWidthEncoder.DirectionChanged += FilterBandWidthEncoder_DirectionChanged; //Filter Bandwidth
        }

        private void FilterBandWidthEncoder_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {
            z += 1;

            if (z > 2) z = 0;

            int stepsize = FilterBandwidthDial.CustomStep;

            if (FilterBandwidthDial.UseAutoStep == true)
            {
                stepsize = sharpControl.StepSize;
            }
            switch (e.EncoderDirection)
            {
                case EncoderDirectionType.Zero:
                    break;
                case EncoderDirectionType.Negative:

                    try
                    {
                        if (z == 0) sharpControl.FilterBandwidth -= stepsize;
                    }
                    catch
                    {

                    }

                    break;
                case EncoderDirectionType.Positive:
                    try
                    {
                        if (z == 0) sharpControl.FilterBandwidth += stepsize;
                    }
                    catch
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        private void ZoomEncoder_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {
            z += 1;

            if (z > 2) z = 0;

            switch (e.EncoderDirection)
            {
                case EncoderDirectionType.Zero:
                    break;
                case EncoderDirectionType.Negative:

                    try
                    {
                        if (z == 0) sharpControl.Zoom -= 1;
                    }
                    catch
                    {

                    }

                    break;
                case EncoderDirectionType.Positive:
                    try
                    {
                        if (z == 0) sharpControl.Zoom += 1;
                    }
                    catch
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        private void SquelchEncoder_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {
            z += 1;

            if (z > 2) z = 0;

            switch (e.EncoderDirection)
            {
                case EncoderDirectionType.Zero:
                    break;
                case EncoderDirectionType.Negative:

                    try
                    {
                        if (z == 0) sharpControl.SquelchThreshold -= 1;
                    }
                    catch
                    {

                    }

                    break;
                case EncoderDirectionType.Positive:
                    try
                    {
                        if (z == 0) sharpControl.SquelchThreshold += 1;
                    }
                    catch
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        private void AudioGainEncoder_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {
            z += 1;
            
            if (z > 2) z = 0;

            switch (e.EncoderDirection)
            {
                case EncoderDirectionType.Zero:
                    break;
                case EncoderDirectionType.Negative:
                    
                    try
                    {
                        if (z == 0) sharpControl.AudioGain -= 1;
                    }
                    catch
                    {
                       
                    }
                    
                    break;
                case EncoderDirectionType.Positive:
                    try
                    {
                        if (z == 0) sharpControl.AudioGain += 1;
                    }
                    catch
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        private void FrequencyEncoder_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {
            int stepsize = FrequencyEncoder.CustomStep;

            if (FrequencyEncoder.UseAutoStep == true)
            {
                stepsize = sharpControl.StepSize;
            }

            switch (e.EncoderDirection)
            {
                case EncoderDirectionType.Zero:

                    break;

                case EncoderDirectionType.Negative:

                    try
                    { 
                        sharpControl.Frequency -= stepsize;
                    }
                    catch
                    {

                    }

                    break;

                case EncoderDirectionType.Positive:
                    
                    try
                    {
                        sharpControl.Frequency += stepsize;
                    }
                    catch
                    {

                    }
                   
                    break;

                default:
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            AudioGainEncoder.Visible = false;
            SquelchEncoder.Visible = false;
            ZoomEncoder.Visible = false;
            FilterBandWidthEncoder.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
         
            int width = this.Size.Width;

            if (width >= 374)
            {
                AudioGainEncoder.Visible = true;
                label2.Visible = true;
            }

            if (width >= 516)
            {
                SquelchEncoder.Visible = true;
                label3.Visible = true;
            }

            if (width >= 663)
            {
                ZoomEncoder.Visible = true;
                label4.Visible = true;
            }
            if (width >= 813)
            {
                FilterBandWidthEncoder.Visible = true;
                label5.Visible = true;
            }

            base.OnResize(e);
        }

        public VirtualEncoder FrequencyDial
        {
            get { return FrequencyEncoder; }
        }
        public VirtualEncoder VolumeDial
        {
            get { return AudioGainEncoder; }
        }
        public VirtualEncoder SquelchDial
        {
            get { return SquelchEncoder; }
        }
        public VirtualEncoder ZoomDial
        {
            get { return ZoomEncoder; }
        }
        public VirtualEncoder FilterBandwidthDial
        {
            get { return FilterBandWidthEncoder; }
        }
    }
}
