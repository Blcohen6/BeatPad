using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatPad
{
    class loopEvent
    {
        private Int64 tickNum = -1;
        private System.Windows.Input.Key keyval;

        public loopEvent(Int64 tickNumarg, System.Windows.Input.Key keyvalarg)
        {
            this.tickNum = tickNumarg;
            this.keyval = keyvalarg;
        }

       public Int64 getTick()
       {
           return this.tickNum;
       }

       public System.Windows.Input.Key getKey()
       {
           return this.keyval;
       }
    }
}
