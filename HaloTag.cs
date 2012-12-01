using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lethargy
{
    public class HaloTag
    {
        private int MetaOffsetString;
        private int MetaSizeString;
        private int IDString;
        private string Class1string;
        private string Class2string;
        private string Class3string;
        private string tagnamestring;
        private int nameoffsetstring;
        private int OffsetString;
        private int LoadOrderString;
        public int MetaOffset
        {
            get
            {
                return this.MetaOffsetString;
            }
            set
            {
                this.MetaOffsetString = value;
            }
        }
        public int MetaSize
        {
            get
            {
                return this.MetaSizeString;
            }
            set
            {
                this.MetaSizeString = value;
            }
        }
        public int ID
        {
            get
            {
                return this.IDString;
            }
            set
            {
                this.IDString = value;
            }
        }
        public string Class1
        {
            get
            {
                return this.Class1string;
            }
            set
            {
                this.Class1string = value;
            }
        }
        public string Class2
        {
            get
            {
                return this.Class2string;
            }
            set
            {
                this.Class2string = value;
            }
        }
        public string Class3
        {
            get
            {
                return this.Class3string;
            }
            set
            {
                this.Class3string = value;
            }
        }
        public string Name
        {
            get
            {
                return this.tagnamestring;
            }
            set
            {
                this.tagnamestring = value;
            }
        }
        public int NameOffset
        {
            get
            {
                return this.nameoffsetstring;
            }
            set
            {
                this.nameoffsetstring = value;
            }
        }
        public int Offset
        {
            get
            {
                return this.OffsetString;
            }
            set
            {
                this.OffsetString = value;
            }
        }
        public int LoadOrder
        {
            get
            {
                return this.LoadOrderString;
            }
            set
            {
                this.LoadOrderString = value;
            }
        }
        public HaloTag(int ID, int MetaOffset, int MetaSize, string Class1, string Class2, string Class3, string Name, int NameOffset, int Offset, int LoadOrder)
        {
            this.ID = ID;
            this.MetaOffset = MetaOffset;
            this.MetaSize = MetaSize;
            this.Class1 = Class1;
            this.Class2 = Class2;
            this.Class3 = Class3;
            this.Name = Name;
            this.NameOffset = NameOffset;
            this.Offset = Offset;
            this.LoadOrder = LoadOrder;
        }
    }
}
