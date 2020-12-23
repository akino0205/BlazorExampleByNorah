using System;

namespace BlazorExampleByNorah.Services
{
    public class AppStateForComponent
    {
        public string SelectedColour { get; private set; }

        public event Action OnChange;

        public void SetColour(string colour)
        {
            SelectedColour = colour;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
