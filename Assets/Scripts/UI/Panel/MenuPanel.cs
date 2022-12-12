using System;

namespace HOG
{
    public class MenuPanel : BasePanelWithButton
    {
        public event Action Play;

        protected override void OnButtonClick()
        {
            Play?.Invoke();
        }
    }
}