using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace XsdIterator
{
    /// <summary>
    /// Default implementation of IXmlSchemaIterator. It will fit most of your needs, but you can 
    /// inherit your own and customize
    /// </summary>
    public class DefaultXmlSchemaIterator : IXmlSchemaIterator
    {
        #region Fields

        /// <summary>
        /// A final visitor, which does actual work for each schema particle
        /// </summary>
        private readonly IXmlSchemaProcessor _functionalVisitor;

        /// <summary>
        /// XmlSchemaSet which wi iterate through
        /// </summary>
        private readonly XmlSchemaSet _schemaSet;

        #endregion

        #region .ctor

        public DefaultXmlSchemaIterator(XmlSchemaSet schemaSet, IXmlSchemaProcessor functionalVisitor)
        {
            _functionalVisitor = functionalVisitor;
            _schemaSet = schemaSet;
        }

        #endregion

        #region Implementation of IXmlSchemaIterator

        public void IterateThrough(XmlSchemaSet obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                foreach (XmlSchema schema in obj.Schemas())
                {
                    schema.Accept(this);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaObject obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            { }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchema obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                var en = obj.Elements.Values.GetEnumerator();
                while (en.MoveNext())
                {
                    en.Current.Accept(this);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaParticle obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            { }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaElement obj)
        {
            if (obj.RefName.IsEmpty)
            {
                var sg = XmlSchemaExtensions.GetSubstitutionGroupElements(_schemaSet, obj);

                if (obj.IsAbstract && sg.Any())
                {
                    List<XmlSchemaElement> sgList;

                    if (obj.IsAbstract)
                    {
                        sgList = sg.ToList();
                    }
                    else
                    {
                        sgList = sg.ToList();
                        sgList.Add(obj);
                    }

                    _functionalVisitor.StartProcessingSubstitutionGroup(obj.Name);
                    foreach (var element in sgList)
                    {
                        element.Accept(this);
                    }

                    _functionalVisitor.EndProcessingSubstitutionGroup(obj.Name);
                }

                else
                {
                    if (_functionalVisitor.StartProcessing(obj))
                    {
                        obj.Annotation?.Accept(this);

                        if (obj.SchemaTypeName.Namespace != XmlSchema.Namespace)
                        {
                            obj.ElementSchemaType.Accept(this);
                        }
                    }

                    _functionalVisitor.EndProcessing(obj);
                }
            }
            else
            {
                var refElement = XmlSchemaExtensions.GetGlobalElementByName(_schemaSet, obj.RefName);
                if (_functionalVisitor.StartProcessing(obj))
                {
                    refElement.Accept(this);
                }
                _functionalVisitor.EndProcessing(obj);
            }

        }

        public void IterateThrough(XmlSchemaSequence obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                var en = obj.Items.GetEnumerator();
                while (en.MoveNext())
                {
                    en.Current.Accept(this);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaChoice obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {

                var en = obj.Items.GetEnumerator();
                var branch = 0;
                while (en.MoveNext())
                {
                    _functionalVisitor.StartProcessingChoiceBranch(++branch, en.Current as XmlSchemaAnnotated);
                    en.Current.Accept(this);
                    _functionalVisitor.EndProcessingChoiceBranch(branch);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaComplexType obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {

                if (obj.Attributes != null)
                {
                    var en = obj.Attributes.GetEnumerator();
                    while (en.MoveNext())
                    {
                        en.Current.Accept(this);
                    }
                }

                if (obj.ContentModel != null)
                {
                    var complexContent = obj.ContentModel.Content as XmlSchemaComplexContentExtension;
                    if (complexContent != null)
                    {
                        if (complexContent.Attributes != null)
                        {
                            var en = complexContent.Attributes.GetEnumerator();
                            while (en.MoveNext())
                            {
                                en.Current.Accept(this);
                            }
                        }

                        var baseType = XmlSchemaExtensions.GetComplexType(_schemaSet, complexContent.BaseTypeName);
                        baseType.Accept(this);
                        complexContent.Accept(this);
                    }

                    var simpleContent = obj.ContentModel.Content as XmlSchemaSimpleContentExtension;
                    simpleContent?.Accept(this);
                }
                else if (obj.Particle != null)
                {
                    obj.Particle.Accept(this);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaSimpleType obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            { }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaGroup obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                obj.Particle.Accept(this);
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaGroupRef obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                var group = XmlSchemaExtensions.GetGroup(_schemaSet, obj.RefName);

                @group?.Accept(this);
            }

            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaAny obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaAttribute obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                obj.AttributeSchemaType?.Accept(this);
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaComplexContentExtension obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                obj.Attributes?.Accept(this);
                obj.Particle?.Accept(this);
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaObjectCollection obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaSimpleContentExtension obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {

                if (obj.Attributes != null)
                {
                    var en = obj.Attributes.GetEnumerator();
                    while (en.MoveNext())
                    {
                        en.Current.Accept(this);
                    }
                }

                var baseType = XmlSchemaExtensions.GetComplexType(_schemaSet, obj.BaseTypeName);

                if (baseType != null && obj.BaseTypeName.Namespace != XmlSchema.Namespace)
                {
                    baseType.Accept(this);
                }
            }

            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaType obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaAppInfo obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            { }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaDocumentation obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
            }
            _functionalVisitor.EndProcessing(obj);
        }

        public void IterateThrough(XmlSchemaAnnotation obj)
        {
            if (_functionalVisitor.StartProcessing(obj))
            {
                var en = obj.Items.GetEnumerator();
                while (en.MoveNext())
                {
                    en.Current.Accept(this);
                }
            }
            _functionalVisitor.EndProcessing(obj);
        }

        #endregion
    }


}
