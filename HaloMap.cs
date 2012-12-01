using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lethargy
{
    public class HaloMap
    {
        private int IndexOffsetInt;
        private int MagicInt;
        private int TMSInt;
        private int TagCountInt;
        private string Pathstring;
        private string GameVersionstring;
        private string PlayerTypestring;
        private string namestring;
        public int IndexOffset
        {
            get
            {
                return this.IndexOffsetInt;
            }
            set
            {
                this.IndexOffsetInt = value;
            }
        }
        public int Magic
        {
            get
            {
                return this.MagicInt;
            }
            set
            {
                this.MagicInt = value;
            }
        }
        public int TotalMetaSize
        {
            get
            {
                return this.TMSInt;
            }
            set
            {
                this.TMSInt = value;
            }
        }
        public int TagCount
        {
            get
            {
                return this.TagCountInt;
            }
            set
            {
                this.TagCountInt = value;
            }
        }
        public string Path
        {
            get
            {
                return this.Pathstring;
            }
            set
            {
                this.Pathstring = value;
            }
        }
        public string GameVersion
        {
            get
            {
                return this.GameVersionstring;
            }
            set
            {
                this.GameVersionstring = value;
            }
        }
        public string PlayerType
        {
            get
            {
                return this.PlayerTypestring;
            }
            set
            {
                this.PlayerTypestring = value;
            }
        }
        public string Name
        {
            get
            {
                return this.namestring;
            }
            set
            {
                this.namestring = value;
            }
        }
    }
}
