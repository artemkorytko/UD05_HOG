using System;

namespace HOG
{
    public class WinPanel : BasePanelWithButton
    {
        public event Action NextLevl;
        
        protected override void OnButtonClick()
        {
            NextLevl?.Invoke();
        }
        
    }
}