using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlHomeWork
{
   static class Pages
    {
        private static MainPage _mainPage = new MainPage();
        private static DealPage _dealPage = new DealPage();
        private static LoginPage _loginPage = new LoginPage();
        private static RegPage _regPage = new RegPage();

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

        public static DealPage DealPage
        {
            get
            {
                return _dealPage;
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                return _loginPage;
            }
        }

        public static RegPage RegPage
        {
            get
            {
                return _regPage;
            }
        }
    }
}
