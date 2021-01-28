using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRSharp.TuningDial
{
    public class DirectionChangedEventArgs : EventArgs
    {
        public DirectionChangedEventArgs(EncoderDirectionType directionType)
        {
            EncoderDirection = directionType;
        }

        public EncoderDirectionType EncoderDirection{get; internal set;}
    }
}
