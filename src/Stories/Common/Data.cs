using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Model
{
    public class Data:Entity
    {
        protected Data() { }

        public Data(byte[] content)
        {
            this.Content = content;
        }
        public byte[] Content { get; set; }
    }
}
