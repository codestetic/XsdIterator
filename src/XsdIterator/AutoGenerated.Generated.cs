
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace XsdIterator 
{
    /// <summary>
    /// Extension method for XmlSchema subtypes, which selects right method
    /// of IXmlSchemaIterator to be called for particular object
    /// </summary>
    public static class XsdSchemaObjectVisitorExtension
    {
        public static void Accept(this object obj, IXmlSchemaIterator iterator)
        {
			var type = obj.GetType();				
										
			if(type == typeof(XmlSchemaElement))
			{
				var typedObj = obj as XmlSchemaElement;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaComplexType))
			{
				var typedObj = obj as XmlSchemaComplexType;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaSimpleType))
			{
				var typedObj = obj as XmlSchemaSimpleType;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaSequence))
			{
				var typedObj = obj as XmlSchemaSequence;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaChoice))
			{
				var typedObj = obj as XmlSchemaChoice;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaSet))
			{
				var typedObj = obj as XmlSchemaSet;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaObject))
			{
				var typedObj = obj as XmlSchemaObject;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchema))
			{
				var typedObj = obj as XmlSchema;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaParticle))
			{
				var typedObj = obj as XmlSchemaParticle;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaGroup))
			{
				var typedObj = obj as XmlSchemaGroup;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaGroupRef))
			{
				var typedObj = obj as XmlSchemaGroupRef;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaAny))
			{
				var typedObj = obj as XmlSchemaAny;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaAttribute))
			{
				var typedObj = obj as XmlSchemaAttribute;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaComplexContentExtension))
			{
				var typedObj = obj as XmlSchemaComplexContentExtension;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaObjectCollection))
			{
				var typedObj = obj as XmlSchemaObjectCollection;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaSimpleContentExtension))
			{
				var typedObj = obj as XmlSchemaSimpleContentExtension;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaType))
			{
				var typedObj = obj as XmlSchemaType;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaAppInfo))
			{
				var typedObj = obj as XmlSchemaAppInfo;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaDocumentation))
			{
				var typedObj = obj as XmlSchemaDocumentation;
				iterator.IterateThrough(typedObj);
				return;
			}
							
			if(type == typeof(XmlSchemaAnnotation))
			{
				var typedObj = obj as XmlSchemaAnnotation;
				iterator.IterateThrough(typedObj);
				return;
			}
        }
    }

    /// <summary>
    /// Interface for xsd schema item processor
    /// </summary>
	public interface IXmlSchemaProcessor
    {
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
	    bool StartProcessing(XmlSchemaObject obj);
        void EndProcessing(XmlSchemaObject obj);		
	    bool StartProcessing(XmlSchema obj);
        void EndProcessing(XmlSchema obj);		
	    bool StartProcessing(XmlSchemaParticle obj);
        void EndProcessing(XmlSchemaParticle obj);		
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
		
	    void StartProcessingChoiceBranch(int nOfBranch, XmlSchemaAnnotated obj);
	    void EndProcessingChoiceBranch(int nOfBranch);
	    void StartProcessingSubstitutionGroup(string name);
        void EndProcessingSubstitutionGroup(string name);
    }

	public interface IXmlSchemaIterator
    {
		void IterateThrough(XmlSchemaElement obj);		
		void IterateThrough(XmlSchemaComplexType obj);		
		void IterateThrough(XmlSchemaSimpleType obj);		
		void IterateThrough(XmlSchemaSequence obj);		
		void IterateThrough(XmlSchemaChoice obj);		
		void IterateThrough(XmlSchemaSet obj);		
		void IterateThrough(XmlSchemaObject obj);		
		void IterateThrough(XmlSchema obj);		
		void IterateThrough(XmlSchemaParticle obj);		
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
	               
    }

	/// <summary>
    /// Default implementation of IXmlSchemaProcessor which does nothing. In most cases
    /// you'll need to inherit your processor from this class and override only required
    /// methods
    /// </summary>
	public class XmlSchemaDefaultProcessor : IXmlSchemaProcessor
	{
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
		public virtual bool StartProcessing(XmlSchemaObject obj){return true;}
		public virtual void EndProcessing(XmlSchemaObject obj){}
		public virtual bool StartProcessing(XmlSchema obj){return true;}
		public virtual void EndProcessing(XmlSchema obj){}
		public virtual bool StartProcessing(XmlSchemaParticle obj){return true;}
		public virtual void EndProcessing(XmlSchemaParticle obj){}
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
	    public virtual void StartProcessingChoiceBranch(int nOfBranch, XmlSchemaAnnotated obj){}
		public virtual void EndProcessingChoiceBranch(int nOfBranch){}
	    public virtual void StartProcessingSubstitutionGroup(string name){}
        public virtual void EndProcessingSubstitutionGroup(string name){}
	}

}
