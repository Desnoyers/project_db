using System;

namespace project_bazi.Services
{
    public class AppState
    {
        private static bool state = false;

        public AppState()
        {
            
        }
        public static bool State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
    }
}