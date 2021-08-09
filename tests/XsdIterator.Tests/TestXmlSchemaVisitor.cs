using System.Text;
using System.Xml.Schema;
using XsdIterator;

namespace XsdIteratorTests
{
    /// <summary>
    /// Simple visitor which only puts all xml schema elements names into one row
    /// </summary>
    public class TestXmlSchemaVisitor : XmlSchemaDefaultProcessor
    {
        public string AllElementsString => _sb.ToString();

        private readonly StringBuilder _sb = new();

        public override bool StartProcessing(XmlSchemaElement obj)
        {
            _sb.AppendFormat("{0},",obj.Name);
            return true;
        }
    }
}
