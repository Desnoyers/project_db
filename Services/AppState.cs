using System;
using System.Collections.Generic;
using project_bazi.DataAccess;

namespace project_bazi.Services
{
    public class AppState
    {
        private static bool authenticated = false;
        private static string userStateData = null;
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

        public static string UserStateData 
        { 
            get
            {
                return userStateData;
            }
            set
            {
                userStateData = value;
            } 
        }
    }
}