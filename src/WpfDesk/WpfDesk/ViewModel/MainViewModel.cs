using System.Windows.Media;

namespace WpfDesk.ViewModel
{
    public class MainViewModel
    {
        public int RenderCapabilityValue
        {
            get
            {
                return RenderCapability.Tier >> 16;
            }
        }
    }
}
