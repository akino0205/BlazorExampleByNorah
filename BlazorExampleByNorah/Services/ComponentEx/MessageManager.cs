using System;

namespace BlazorExampleByNorah.Services
{
    public class MessageManager
    {
        private int count;
        public string Message { get; private set; }

        public event Action OnChange;

        public void ClickCompBtn()
        {
            Message = $"Click CompBtn : {++count}";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
