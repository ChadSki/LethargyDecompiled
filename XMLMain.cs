using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lethargy
{
    public class XMLMain
    {
        public struct TAG_STRUCT
        {
            public string name;
            public int size;
            public XMLMain.VALUE_STRUCT[] values;
        }
        public struct VALUE_STRUCT
        {
            public string name;
            public int offset;
            public string type;
            public object data;
            public int count;
            public XMLMain.OFFSET_OPTIONS[] offset_options;
        }
        public struct OFFSET_OPTIONS
        {
            public int op_value;
            public string op_name;
        }
        private bool handled;
        private HaloTag TagInp;
        public HaloTag Tag
        {
            get
            {
                return this.TagInp;
            }
            set
            {
                this.TagInp = value;
            }
        }
        public XMLMain(HaloTag tag)
        {
            this.Tag = tag;
        }
    }
}
