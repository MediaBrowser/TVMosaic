using System;
using System.Collections.Generic;
using System.Text;

namespace Emby.Plugins.TVMosaic
{
    public class TvMosaicProviderOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int StreamingPort { get; set; } = 9271;
        public int Version { get; set; } = 7;
    }
}
