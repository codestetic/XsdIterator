using System.IO;
using System.Xml.Schema;
using XsdIterator;
using Xunit;

namespace XsdIteratorTests
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
            using (var reader = new StreamReader("Samples\\sample.xsd"))
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

            Assert.True(result.Contains("Document,CstmrCdtTrfInitn,GrpHdr,MsgId,CreDtTm,Authstn,Cd,Prtry,NbOfTxs,CtrlSum"));
            Assert.True(result.Contains("Othr,Id,SchmeNm,Cd,Prtry,Issr,BrnchId,Id,Nm,PstlAdr,AdrTp,Dept,SubDept"));
            Assert.True(result.Contains("FaxNb,EmailAdr,Othr,Invcee,Nm,PstlAdr,AdrTp,Dept,SubDept,StrtNm,BldgNb"));
            Assert.True(result.Contains("Dt,RmtdAmt,FmlyMdclInsrncInd,MplyeeTermntnInd,AddtlRmtInf,SplmtryData,PlcAndNm,Envlp,SplmtryData,PlcAndNm,Envlp"));
        }
    }
}
