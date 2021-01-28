using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDRSharp.TuningDial
{
    public partial class VirtualEncoder : UserControl
    {
        private int diameter = 0;

        private Rectangle bezel = new Rectangle();
        private Rectangle highlight = new Rectangle();
        private Rectangle backGround = new Rectangle();
        private Rectangle glow = new Rectangle();
        private Rectangle dial = new Rectangle();
        private Rectangle detent = new Rectangle();
        private Point KnobCenter = new Point();

        private bool _IsRotating = false;
        private double _CurrentAngle = 270;
        private double _OldAngle = 0;
        private bool _showGlow = true;
        private IlluminationColor glowType = IlluminationColor.Blue;
        private Color glowColor;
        private bool _autoStep;
        
        private EncoderDirectionType EncoderDirection;

        private bool _AllowStepChanges = false;
        private int _stepSize = 1;
        
        public delegate void DirectionChangedEventHandler(object sender, DirectionChangedEventArgs e);
        public event DirectionChangedEventHandler DirectionChanged;
       
        public VirtualEncoder()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this._IsRotating = false;
            this._CurrentAngle = 270.0;
            this.EncoderDirection = EncoderDirectionType.Zero;
            GlowColor = IlluminationColor.Blue;    
        }        
        
        private void SetDimensions()
        {
            if (Width >= Height)
            {
                diameter = Height - 1;
            }
            else
            { 
                diameter = Width - 1;
            }

            bezel = new Rectangle(0, 0, diameter, diameter);
            highlight = new Rectangle(10, 10, diameter -20, diameter-20);
            backGround = new Rectangle(12, 12, diameter - 24, diameter - 24);
            glow = new Rectangle(10, 11, diameter - 20, diameter - 20);
            dial = new Rectangle(14, 13, diameter - 27, diameter - 27);
            //detent = new Rectangle(40, 40, (int)(diameter * 0.15), (int)(diameter * 0.15));
            Size detentSize = new Size(20, 20);
               
           
            KnobCenter = new Point(checked((int)Math.Round(unchecked((double)this.bezel.Left + (double)this.bezel.Width / 2.0  )-10)), checked((int)Math.Round(unchecked((double)this.bezel.Top + (double)this.bezel.Height / 2.0 )-10)));
            Point detentLocation = this.LocatePointer();
            detent = new Rectangle(detentLocation, detentSize);   
        }
        protected virtual void OnDirectionChanged(DirectionChangedEventArgs e)
        {
            DirectionChangedEventHandler handler = DirectionChanged;
            handler?.Invoke(this, e);
        }
        private void DrawControl(Graphics e)
        {
            e.Clear(this.BackColor);

            using (Brush bezelBrush = (Brush)new LinearGradientBrush(bezel, Color.White, Color.Black, LinearGradientMode.ForwardDiagonal))
            {
                e.FillEllipse(bezelBrush, bezel);
            };

            using (var knobBrush = (Brush)new LinearGradientBrush(bezel, Color.Black, Color.White, LinearGradientMode.ForwardDiagonal))
            {
                e.FillEllipse(knobBrush, highlight);
            };

            e.FillEllipse(Brushes.Black, backGround);

            if (ShowGlow)
            {
                using (var ellipsePath = new GraphicsPath())
                {
                    ellipsePath.AddEllipse(glow);

                    using (var brush = new PathGradientBrush(ellipsePath))
                    {
                        brush.CenterPoint = new PointF(glow.Width / 2f, glow.Height / 1f);
                        brush.CenterColor = Color.Transparent;
                        brush.SurroundColors = new[] { Color.FromArgb(210, glowColor) };
                        brush.FocusScales = new PointF(0.75f, 1.0f);

                        e.FillRectangle(brush, glow);
                    }
                }
            }
            using (var buttonBrush = (Brush)new LinearGradientBrush(dial, Color.FromArgb(200, Color.White), Color.Black, LinearGradientMode.ForwardDiagonal))
            {
                e.FillEllipse(buttonBrush, dial);
            };

            using (var detentBrush = (Brush)new LinearGradientBrush(detent, Color.Black, Color.Black, LinearGradientMode.BackwardDiagonal))
            {
                e.FillEllipse(detentBrush, detent);
            };

            e.DrawEllipse(Pens.Black, dial);

            using (var detenttwoBrush = (Brush)new LinearGradientBrush(detent, Color.Black, Color.Silver, (float)-_CurrentAngle / 360))
            {
                e.FillEllipse(detenttwoBrush, detent);
            };
        }
        private bool HitTestPointer(MouseEventArgs e)
        {
            return this.detent.Contains(e.X, e.Y);
        }
        private Point LocatePointer()
        {
            double num = (this._CurrentAngle - 180.0) * Math.PI / 180.0;
            Point point = new Point
            {
                X = checked((int)Math.Round(unchecked((double)checked(this.KnobCenter.X) + Math.Cos(num) * ((double)checked(dial.Width-40) / 2.0)))),
                Y = checked((int)Math.Round(unchecked((double)checked(this.KnobCenter.Y) + Math.Sin(num) * ((double)checked(dial.Width-40) / 2.0))))
            };
            return point;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SetDimensions();
            DrawControl(e.Graphics);            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._IsRotating = false;
            this.Cursor = Cursors.Default;
            this.EncoderDirection = EncoderDirectionType.Zero;

            OnDirectionChanged(new DirectionChangedEventArgs(EncoderDirection));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._IsRotating)
            {
                this.Cursor = Cursors.Hand;
                this._CurrentAngle = Math.Atan2((double)checked(e.Y - this.KnobCenter.Y), (double)checked(e.X - this.KnobCenter.X)) * (180.0 / Math.PI) + 180.0;
              
                if (this._CurrentAngle > this._OldAngle)
                {
                    this.EncoderDirection = EncoderDirectionType.Positive;
                }              
                else if (this._CurrentAngle < this._OldAngle)
                {
                    this.EncoderDirection = EncoderDirectionType.Negative;
                }

                OnDirectionChanged(new DirectionChangedEventArgs(EncoderDirection));

                this._OldAngle = this._CurrentAngle;                
            }

            this.Refresh();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (HitTestPointer(e) == true))
            {
                this._IsRotating = true;
                this._CurrentAngle = Math.Atan2((double)checked(e.Y - this.KnobCenter.Y), (double)checked(e.X - this.KnobCenter.X)) * (180.0 / Math.PI) + 180.0;
                this._OldAngle = this._CurrentAngle;
            }
            this.Refresh();
        }

        public IlluminationColor GlowColor
        {
            get { return glowType; }
            set
            {
                glowType = value;

                redToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                blueToolStripMenuItem.Checked = false;
                purpleToolStripMenuItem.Checked = false;

                switch (value)
                {
                    case IlluminationColor.Red:
                        glowColor = Color.Red;
                        redToolStripMenuItem.Checked = true;
                        break;
                    case IlluminationColor.Orange:
                        glowColor = Color.Orange;
                        orangeToolStripMenuItem.Checked = true;
                        break;
                    case IlluminationColor.Yellow:
                        glowColor = Color.FromArgb(192, 192, 0);
                        yellowToolStripMenuItem.Checked = true;
                        break;
                    case IlluminationColor.Green:
                        glowColor = Color.LimeGreen;
                        greenToolStripMenuItem.Checked = true;
                        break;
                    case IlluminationColor.Blue:
                        blueToolStripMenuItem.Checked = true;
                        glowColor = Color.Blue;
                        break;
                    case IlluminationColor.Purple:
                        purpleToolStripMenuItem.Checked = true;
                        glowColor = Color.MediumPurple;
                        break;
                    default:
                        break;
                }
                this.Invalidate();
            }
        } 
        public bool ShowGlow
        {
            get { return _showGlow; }
            set
            {
                _showGlow = value;
                illuminiateDialToolStripMenuItem.Checked = value;
            }
        }
        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Red;
        }
        private void OrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Orange;
        }
        private void YellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Yellow;
        }
        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Green;
        }
        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Blue;
        }

        private void PurpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlowColor = IlluminationColor.Purple;
        }
        private void IlluminiateDialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGlow = !ShowGlow;           
        }

        public bool AllowStepChanges
        {
            get { return _AllowStepChanges; }
            set
            {
                _AllowStepChanges = value;
                adjustStepSizesToolStripMenuItem.Visible = value;
                toolStripMenuItem1.Visible = value;
            }
        }
        public bool UseAutoStep
        {
            get { return _autoStep; }
            set { _autoStep = value; }
        }
        public int CustomStep
        {
            get { return _stepSize; }
            set { _stepSize = value; }
        }

        private void adjustStepSizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepAdjustForm frm = new StepAdjustForm(this);
            frm.ShowDialog(this);
        }
    }    
}
