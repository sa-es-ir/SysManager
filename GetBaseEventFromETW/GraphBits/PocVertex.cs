using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GetBaseEventFromETW
{
    /// <summary>
    /// A simple identifiable vertex.
    /// </summary>
    [DebuggerDisplay("{ID}-{IsMale}")]
    public class PocVertex
    {
        public string ID { get; private set; }
        public bool IsMale { get; private set; }

        public PocVertex(string id, bool isMale,string tooltip=null)
        {
            ID = id;
            IsMale = isMale;
            ToolTipText = tooltip;
        }
        public string ToolTipText { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", ID, IsMale);
        }
    }
}
