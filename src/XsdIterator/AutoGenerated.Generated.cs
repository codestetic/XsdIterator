
using System.Xml.Schema;

namespace XsdIterator 
{
    /// <summary>
    /// Extension method for XmlSchema subtypes, which selects right method
    /// of IXmlSchemaIterator to be called for particular object
    /// </summary>
    public static class XmlSchemaVisitorExtension
    {
        public static void Accept(this object obj, IXmlSchemaIterator iterator)
        {
			var type = obj.GetType();
			switch(obj)
			{
				case XmlSchema item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaElement item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaComplexType item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaSimpleType item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaSequence item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaChoice item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaSet item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaGroup item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaGroupRef item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaAny item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaAttribute item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaComplexContentExtension item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaObjectCollection item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaSimpleContentExtension item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaType item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaAppInfo item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaDocumentation item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaAnnotation item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaParticle item:
					iterator.IterateThrough(item);
					break;
				case XmlSchemaObject item:
					iterator.IterateThrough(item);
					break;
			}
		}
    }

    /// <summary>
    /// Interface for xsd schema item processor
    /// </summary>
	public interface IXmlSchemaProcessor
    {
	    bool StartProcessing(XmlSchema obj);
        void EndProcessing(XmlSchema obj);		
	    bool StartProcessing(XmlSchemaElement obj);
        void EndProcessing(XmlSchemaElement obj);		
	    bool StartProcessing(XmlSchemaComplexType obj);
        void EndProcessing(XmlSchemaComplexType obj);		
	    bool StartProcessing(XmlSchemaSimpleType obj);
        void EndProcessing(XmlSchemaSimpleType obj);		
	    bool StartProcessing(XmlSchemaSequence obj);
        void EndProcessing(XmlSchemaSequence obj);		
	    bool StartProcessing(XmlSchemaChoice obj);
        void EndProcessing(XmlSchemaChoice obj);		
	    bool StartProcessing(XmlSchemaSet obj);
        void EndProcessing(XmlSchemaSet obj);		
	    bool StartProcessing(XmlSchemaGroup obj);
        void EndProcessing(XmlSchemaGroup obj);		
	    bool StartProcessing(XmlSchemaGroupRef obj);
        void EndProcessing(XmlSchemaGroupRef obj);		
	    bool StartProcessing(XmlSchemaAny obj);
        void EndProcessing(XmlSchemaAny obj);		
	    bool StartProcessing(XmlSchemaAttribute obj);
        void EndProcessing(XmlSchemaAttribute obj);		
	    bool StartProcessing(XmlSchemaComplexContentExtension obj);
        void EndProcessing(XmlSchemaComplexContentExtension obj);		
	    bool StartProcessing(XmlSchemaObjectCollection obj);
        void EndProcessing(XmlSchemaObjectCollection obj);		
	    bool StartProcessing(XmlSchemaSimpleContentExtension obj);
        void EndProcessing(XmlSchemaSimpleContentExtension obj);		
	    bool StartProcessing(XmlSchemaType obj);
        void EndProcessing(XmlSchemaType obj);		
	    bool StartProcessing(XmlSchemaAppInfo obj);
        void EndProcessing(XmlSchemaAppInfo obj);		
	    bool StartProcessing(XmlSchemaDocumentation obj);
        void EndProcessing(XmlSchemaDocumentation obj);		
	    bool StartProcessing(XmlSchemaAnnotation obj);
        void EndProcessing(XmlSchemaAnnotation obj);		
	    bool StartProcessing(XmlSchemaParticle obj);
        void EndProcessing(XmlSchemaParticle obj);		
	    bool StartProcessing(XmlSchemaObject obj);
        void EndProcessing(XmlSchemaObject obj);		
		
	    void StartProcessingChoiceBranch(int nOfBranch, XmlSchemaAnnotated obj);
	    void EndProcessingChoiceBranch(int nOfBranch);
	    void StartProcessingSubstitutionGroup(string name);
        void EndProcessingSubstitutionGroup(string name);
    }

	public interface IXmlSchemaIterator
    {
		void IterateThrough(XmlSchema obj);		
		void IterateThrough(XmlSchemaElement obj);		
		void IterateThrough(XmlSchemaComplexType obj);		
		void IterateThrough(XmlSchemaSimpleType obj);		
		void IterateThrough(XmlSchemaSequence obj);		
		void IterateThrough(XmlSchemaChoice obj);		
		void IterateThrough(XmlSchemaSet obj);		
		void IterateThrough(XmlSchemaGroup obj);		
		void IterateThrough(XmlSchemaGroupRef obj);		
		void IterateThrough(XmlSchemaAny obj);		
		void IterateThrough(XmlSchemaAttribute obj);		
		void IterateThrough(XmlSchemaComplexContentExtension obj);		
		void IterateThrough(XmlSchemaObjectCollection obj);		
		void IterateThrough(XmlSchemaSimpleContentExtension obj);		
		void IterateThrough(XmlSchemaType obj);		
		void IterateThrough(XmlSchemaAppInfo obj);		
		void IterateThrough(XmlSchemaDocumentation obj);		
		void IterateThrough(XmlSchemaAnnotation obj);		
		void IterateThrough(XmlSchemaParticle obj);		
		void IterateThrough(XmlSchemaObject obj);		
	               
    }

	/// <summary>
    /// Default implementation of IXmlSchemaProcessor which does nothing. In most cases
    /// you'll need to inherit your processor from this class and override only required
    /// methods
    /// </summary>
	public class XmlSchemaDefaultProcessor : IXmlSchemaProcessor
	{
		public virtual bool StartProcessing(XmlSchema obj){return true;}
		public virtual void EndProcessing(XmlSchema obj){}
		public virtual bool StartProcessing(XmlSchemaElement obj){return true;}
		public virtual void EndProcessing(XmlSchemaElement obj){}
		public virtual bool StartProcessing(XmlSchemaComplexType obj){return true;}
		public virtual void EndProcessing(XmlSchemaComplexType obj){}
		public virtual bool StartProcessing(XmlSchemaSimpleType obj){return true;}
		public virtual void EndProcessing(XmlSchemaSimpleType obj){}
		public virtual bool StartProcessing(XmlSchemaSequence obj){return true;}
		public virtual void EndProcessing(XmlSchemaSequence obj){}
		public virtual bool StartProcessing(XmlSchemaChoice obj){return true;}
		public virtual void EndProcessing(XmlSchemaChoice obj){}
		public virtual bool StartProcessing(XmlSchemaSet obj){return true;}
		public virtual void EndProcessing(XmlSchemaSet obj){}
		public virtual bool StartProcessing(XmlSchemaGroup obj){return true;}
		public virtual void EndProcessing(XmlSchemaGroup obj){}
		public virtual bool StartProcessing(XmlSchemaGroupRef obj){return true;}
		public virtual void EndProcessing(XmlSchemaGroupRef obj){}
		public virtual bool StartProcessing(XmlSchemaAny obj){return true;}
		public virtual void EndProcessing(XmlSchemaAny obj){}
		public virtual bool StartProcessing(XmlSchemaAttribute obj){return true;}
		public virtual void EndProcessing(XmlSchemaAttribute obj){}
		public virtual bool StartProcessing(XmlSchemaComplexContentExtension obj){return true;}
		public virtual void EndProcessing(XmlSchemaComplexContentExtension obj){}
		public virtual bool StartProcessing(XmlSchemaObjectCollection obj){return true;}
		public virtual void EndProcessing(XmlSchemaObjectCollection obj){}
		public virtual bool StartProcessing(XmlSchemaSimpleContentExtension obj){return true;}
		public virtual void EndProcessing(XmlSchemaSimpleContentExtension obj){}
		public virtual bool StartProcessing(XmlSchemaType obj){return true;}
		public virtual void EndProcessing(XmlSchemaType obj){}
		public virtual bool StartProcessing(XmlSchemaAppInfo obj){return true;}
		public virtual void EndProcessing(XmlSchemaAppInfo obj){}
		public virtual bool StartProcessing(XmlSchemaDocumentation obj){return true;}
		public virtual void EndProcessing(XmlSchemaDocumentation obj){}
		public virtual bool StartProcessing(XmlSchemaAnnotation obj){return true;}
		public virtual void EndProcessing(XmlSchemaAnnotation obj){}
		public virtual bool StartProcessing(XmlSchemaParticle obj){return true;}
		public virtual void EndProcessing(XmlSchemaParticle obj){}
		public virtual bool StartProcessing(XmlSchemaObject obj){return true;}
		public virtual void EndProcessing(XmlSchemaObject obj){}
	    public virtual void StartProcessingChoiceBranch(int nOfBranch, XmlSchemaAnnotated obj){}
		public virtual void EndProcessingChoiceBranch(int nOfBranch){}
	    public virtual void StartProcessingSubstitutionGroup(string name){}
        public virtual void EndProcessingSubstitutionGroup(string name){}
	}

}
