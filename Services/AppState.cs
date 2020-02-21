using System;
using System.Collections.Generic;

namespace project_bazi.Services
{
    public class AppState
    {
        private static bool authenticated = false;
        public AppState()
        {
        }

        public static bool Authenticated
        {
            get
            {
                return authenticated;
            }
            set
            {
                authenticated = value;
            }
        }
    }
}