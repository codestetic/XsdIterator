using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace XsdIterator
{
    /// <summary>
    /// Extension methods for XmlSchema subtypes
    /// </summary>
    public static class XmlSchemaExtensions
    {
        public static IEnumerable<XmlSchemaElement> Iterator(this XmlSchemaObjectTable table)
        {
            var en = table.Values.GetEnumerator();
            while (en.MoveNext())
            {
                yield return (XmlSchemaElement)en.Current;
            }
        }

        /// <summary>
        /// Returns a global element with a specified name
        /// </summary>
        public static XmlSchemaElement GetGlobalElementByName(this XmlSchemaSet schemaSet, XmlQualifiedName name)
        {
            var enumerator = schemaSet.GlobalElements.Values.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is XmlSchemaElement element
                    && element.QualifiedName.Name == name.Name)
                {
                    return element;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns IEnumerable of all elements that form a substitution group for a given element
        /// </summary>
        public static IEnumerable<XmlSchemaElement> GetSubstitutionGroupElements(this XmlSchemaSet schemaSet, XmlSchemaElement element)
        {
            var en = schemaSet.GlobalElements.Values.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Current is XmlSchemaElement substitutionGroupElement 
                    && substitutionGroupElement.SubstitutionGroup.Name == element.QualifiedName.Name)
                {
                    yield return substitutionGroupElement;
                }
            }
        }

        public static XmlSchemaGroup GetGroup(this XmlSchemaSet schemaSet, XmlQualifiedName name)
        {
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                foreach (XmlSchemaGroup group in schema.Groups.Values)
                {
                    if (group.QualifiedName.Name == name.Name)
                    {
                        return group;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns complex or simple type with a specified name
        /// </summary>
        public static XmlSchemaType GetType(this XmlSchemaSet schemaSet, XmlQualifiedName name)
        {
            var en = schemaSet.GlobalTypes.Values.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Current is XmlSchemaComplexType complexType)
                {
                    if (complexType.QualifiedName.Name == name.Name)
                    {
                        return complexType;
                    }
                }
                else
                {
                    if (en.Current is XmlSchemaSimpleType simpleType 
                        && simpleType.QualifiedName.Name == name.Name)
                    {
                        return simpleType;
                    }
                }
            }

            return null;
        }

        public static XmlSchemaDocumentation GetDocumentation(this XmlSchemaAnnotated node, string source, string lang)
        {
            if (node.Annotation == null)
            {
                return null;
            }

            var en = node.Annotation.Items.GetEnumerator();

            while (en.MoveNext())
            {
                if (en.Current is XmlSchemaDocumentation doc
                    && doc.Source == source && doc.Language == lang)
                {
                    return doc;
                }
            }

            return null;
        }

        public static XmlSchemaAppInfo GetAppInfo(this XmlSchemaAnnotated node, string source)
        {
            if (node.Annotation == null)
            {
                return null;
            }

            var en = node.Annotation.Items.GetEnumerator();

            while (en.MoveNext())
            {
                if (en.Current is XmlSchemaAppInfo ai
                    && ai.Source == source)
                {
                    return ai;
                }
            }

            return null;
        }

        public static void AddAppInfo(this XmlSchemaElement element, XmlSchemaAppInfo appInfo)
        {
            var annotation = element.Annotation;

            if (annotation == null)
            {
                annotation = new XmlSchemaAnnotation();
                element.Annotation = annotation;
            }

            annotation.Items.Insert(0, appInfo);
        }

        public static (int Min, int Max) GetOccurrence(this XmlSchemaElement element)
        {
            var min = (int)element.MinOccurs;
            var max = element.MaxOccurs < int.MaxValue ? (int)element.MaxOccurs : int.MaxValue;

            return (min, max);
        }

        public static (int Min, int Max) GetOccurrence(this XmlSchemaAttribute attribute)
        {
            var min = 1;
            var max = 1;

            switch (attribute.Use)
            {
                case XmlSchemaUse.None:
                    break;
                case XmlSchemaUse.Optional:
                    min = 0;
                    break;
                case XmlSchemaUse.Prohibited:
                    break;
                case XmlSchemaUse.Required:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (min, max);
        }
    }
}
