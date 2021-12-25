using System.Xml;
using System.Xml.Schema;
using XsdIteratorTests;
using Xunit;

namespace XsdIterator.Tests
{
    /// <summary>
    /// Test behaviour of DefaultXmlSchemaIterator
    /// </summary>
    public class DefaultXmlIteratorTests
    {
        /// <summary>
        /// Check that iterator will walk through all elements
        /// </summary>
        [Fact]
        public void All_elements_walked_through()
        {
            var schemaSet = new XmlSchemaSet();
            using (var reader = new XmlTextReader("Samples\\sample.xsd"))
            {
                schemaSet.Add(XmlSchema.Read(reader, null));
            }
            schemaSet.Compile();

            var visitor = new TestXmlSchemaVisitor();
            var iterator = new DefaultXmlSchemaIterator(schemaSet, visitor);

            var enumerator = schemaSet.GlobalElements.Values.GetEnumerator();
            enumerator.MoveNext();
            var globalElement = enumerator.Current;
            globalElement.Accept(iterator);

            var result = visitor.AllElementsString;

            Assert.Contains("Document,CstmrCdtTrfInitn,GrpHdr,MsgId,CreDtTm,Authstn,Cd,Prtry,NbOfTxs,CtrlSum", result);
            Assert.Contains("Othr,Id,SchmeNm,Cd,Prtry,Issr,BrnchId,Id,Nm,PstlAdr,AdrTp,Dept,SubDept", result);
            Assert.Contains("FaxNb,EmailAdr,Othr,Invcee,Nm,PstlAdr,AdrTp,Dept,SubDept,StrtNm,BldgNb", result);
            Assert.Contains("Dt,RmtdAmt,FmlyMdclInsrncInd,MplyeeTermntnInd,AddtlRmtInf,SplmtryData,PlcAndNm,Envlp,SplmtryData,PlcAndNm,Envlp", result);
        }
    }
}
