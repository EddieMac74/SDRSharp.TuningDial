using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.TuningDial
{
    public class TuningDialPlugin : ISharpPlugin, ISupportSettings
    {
        //Call order
        //1 - Initialize
        //2 - Loading Settings
        //3 - Loading GUI << Also called when loaded;
        //When SDR Closed
        //1 - Save Settings
        //2 - Close
                
        private ControlPanel gui;
        
        public UserControl Gui => (UserControl)gui;
        public string DisplayName => "Tuning Dial";
       
        public void Initialize(ISharpControl control)
        {
            gui = new ControlPanel(control);

            gui.FrequencyDial.AllowStepChanges = true;
            gui.FilterBandwidthDial.AllowStepChanges = true;
            gui.ZoomDial.AllowStepChanges = false;
            gui.VolumeDial.AllowStepChanges = false;
            gui.SquelchDial.AllowStepChanges = false;
        }
        public void Close()
        {
                      
        }

        public void LoadSettings()
        {
            gui.FrequencyDial.GlowColor = (IlluminationColor)Utils.GetIntSetting("TuningDial.FrequencyColor", 4);
            gui.VolumeDial.GlowColor = (IlluminationColor)Utils.GetIntSetting("TuningDial.VolumeColor", 4);
            gui.SquelchDial.GlowColor = (IlluminationColor)Utils.GetIntSetting("TuningDial.SquelchColor", 4);
            gui.FilterBandwidthDial.GlowColor = (IlluminationColor)Utils.GetIntSetting("TuningDial.FiterBandwidthColor", 4);
            gui.ZoomDial.GlowColor = (IlluminationColor)Utils.GetIntSetting("TuningDial.ZoomColor", 4);

            gui.FrequencyDial.ShowGlow = Utils.GetBooleanSetting("TuningDial.EnabelFrequencyGlow", true);
            gui.VolumeDial.ShowGlow = Utils.GetBooleanSetting("TuningDial.EnabelVolumeGlow", true);
            gui.SquelchDial.ShowGlow = Utils.GetBooleanSetting("TuningDial.EnabelSquelchGlow", true);
            gui.FilterBandwidthDial.ShowGlow = Utils.GetBooleanSetting("TuningDial.EnabelFilterGlow", true);
            gui.ZoomDial.ShowGlow = Utils.GetBooleanSetting("TuningDial.EnabelZoomGlow", true);

            gui.FrequencyDial.UseAutoStep = Utils.GetBooleanSetting("TuningDial.FrequencyAutoStep", true);
            gui.FrequencyDial.CustomStep = Utils.GetIntSetting("TuningDial.FrequencyStep", 1);

            gui.FilterBandwidthDial.UseAutoStep = Utils.GetBooleanSetting("TuningDial.FilterBandwidthAutoStep", true);
            gui.FilterBandwidthDial.CustomStep = Utils.GetIntSetting("TuningDial.FilterBandwidthStep", 1);
        }
        public void SaveSettings()
        {
            Utils.SaveSetting("TuningDial.FrequencyColor", (int) gui.FrequencyDial.GlowColor);
            Utils.SaveSetting("TuningDial.VolumeColor", (int)gui.VolumeDial.GlowColor);
            Utils.SaveSetting("TuningDial.SquelchColor",(int)gui.SquelchDial.GlowColor);
            Utils.SaveSetting("TuningDial.FiterBandwidthColor", (int)gui.FilterBandwidthDial.GlowColor);
            Utils.SaveSetting("TuningDial.ZoomColor", (int)gui.ZoomDial.GlowColor);

            Utils.SaveSetting("TuningDial.EnabelFrequencyGlow", gui.FrequencyDial.ShowGlow);
            Utils.SaveSetting("TuningDial.EnabelVolumeGlow", gui.VolumeDial.ShowGlow);
            Utils.SaveSetting("TuningDial.EnabelSquelchGlow", gui.SquelchDial.ShowGlow);
            Utils.SaveSetting("TuningDial.EnabelFilterGlow", gui.FilterBandwidthDial.ShowGlow);
            Utils.SaveSetting("TuningDial.EnabelZoomGlow", gui.ZoomDial.ShowGlow);

            Utils.SaveSetting("TuningDial.FrequencyAutoStep", gui.FrequencyDial.UseAutoStep);
            Utils.SaveSetting("TuningDial.FrequencyStep", gui.FrequencyDial.CustomStep);

            Utils.SaveSetting("TuningDial.FilterBandwidthAutoStep", gui.FilterBandwidthDial.UseAutoStep);
            Utils.SaveSetting("TuningDial.FilterBandwidthStep", gui.FilterBandwidthDial.CustomStep);
        }
    }
    
}
