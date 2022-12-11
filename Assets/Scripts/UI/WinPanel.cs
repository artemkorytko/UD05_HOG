using System;

namespace HOG
{
    public class WinPanel : BaseUiPanelWithButton
    {
        public event Action NextLevl;

        
        protected override void OnButtonClick()
        {
            NextLevl?.Invoke();
        }
        
    }
}