using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lethargy
{
    public class BitMask
    {
        private int mask;
        public BitMask(int num)
        {
            this.mask = num;
        }
        public bool BitOn(int num)
        {
            return Conversions.ToBoolean(Interaction.IIf((this.mask & 1 << checked(32 - num)) > 0, true, false));
        }
        public void SetBit(int num)
        {
            this.mask |= 1 << checked(32 - num);
        }
        public void ToggleBit(int num)
        {
            checked
            {
                if ((this.mask & 1 << 32 - num) > 0)
                {
                    this.mask &= ~(1 << 32 - num);
                }
                else
                {
                    this.mask |= 1 << 32 - num;
                }
            }
        }
        public int ToInt()
        {
            return this.mask;
        }
    }
}
