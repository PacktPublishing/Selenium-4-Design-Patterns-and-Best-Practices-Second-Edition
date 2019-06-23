using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataPreparationDemos.Configuration
{
    public class BrowserSettings
    {
        public int PageLoadTimeout { get; set; } = 30000;
        public int ScriptTimeout { get; set; } = 1000;
        public int ArtificialDelayBeforeAction { get; set; } = 0;
    }
}
