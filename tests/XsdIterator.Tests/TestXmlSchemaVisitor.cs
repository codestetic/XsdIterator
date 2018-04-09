using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using XsdIterator;

namespace XsdIteratorTests
{
    /// <summary>
    /// Simple visitor which only puts all xml schema elements names into one row
    /// </summary>
    class TestXmlSchemaVisitor : XmlSchemaDefaultProcessor
    {
        public string AllElementsString => _sb.ToString();

        private StringBuilder _sb = new StringBuilder();

        public override bool StartProcessing(XmlSchemaElement obj)
        {
            _sb.AppendFormat("{0},",obj.Name);
            return true;
        }
    }
}
