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

        public static XmlSchemaElement GetGlobalElementByName(this XmlSchemaSet schemaSet, XmlQualifiedName name)
        {
            var en = schemaSet.GlobalElements.Values.GetEnumerator();
            while (en.MoveNext())
            {
                var el = (XmlSchemaElement)en.Current;
                if (el.QualifiedName.Name == name.Name)
                {
                    return el;
                }
            }

            return null;
        }

        public static IEnumerable<XmlSchemaElement> GetSubstitutionGroupElements(this XmlSchemaSet schemaSet, XmlSchemaElement element)
        {
            var en = schemaSet.GlobalElements.Values.GetEnumerator();
            while (en.MoveNext())
            {
                var el = (XmlSchemaElement)en.Current;
                if (el.SubstitutionGroup.Name == element.QualifiedName.Name)
                {
                    yield return el;
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

        public static XmlSchemaType GetComplexType(this XmlSchemaSet schemaSet, XmlQualifiedName name)
        {
            var en = schemaSet.GlobalTypes.Values.GetEnumerator();
            while (en.MoveNext())
            {
                var currentAsComplex = en.Current as XmlSchemaComplexType;
                if (currentAsComplex != null)
                {
                    if (currentAsComplex.QualifiedName.Name == name.Name)
                    {
                        return currentAsComplex;
                    }
                }
                else
                {
                    var currentAsSimple = en.Current as XmlSchemaSimpleType;

                    if (currentAsSimple != null && currentAsSimple.QualifiedName.Name == name.Name)
                    {
                        return currentAsSimple;
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
                var doc = en.Current as XmlSchemaDocumentation;
                if (doc != null)
                {
                    if (doc.Source == source && doc.Language == lang)
                    {
                        return doc;
                    }
                }
            }

            return null;
        }

        public static XmlSchemaAppInfo GetAppinfo(this XmlSchemaAnnotated node, string source)
        {
            if (node.Annotation == null)
            {
                return null;
            }

            var en = node.Annotation.Items.GetEnumerator();

            while (en.MoveNext())
            {
                var ai = en.Current as XmlSchemaAppInfo;
                if (ai != null)
                {
                    if (ai.Source == source)
                    {
                        return ai;
                    }
                }
            }

            return null;
        }



        private static int GetMinMaxOccValue(XmlSchemaAnnotated element, string attributeName)
        {
            if (element.Annotation == null)
            {
                return -1;
            }

            var en = element.Annotation.Items.GetEnumerator();

            while (en.MoveNext())
            {
                if (en.Current is XmlSchemaAppInfo ai)
                {
                    if (ai.Source == "minOcc")
                    {
                        if (ai.Markup == null || !ai.Markup.Any())
                        {
                            return -1;
                        }

                        if (int.TryParse(ai.Markup[0].Value, out var rValue))
                        {
                            return rValue;
                        }
                    }
                }
            }

            return -1;
        }

        public static int MinOcc(this XmlSchemaAnnotated element)
        {
            return GetMinMaxOccValue(element, "minOcc");
        }

        public static int MaxOcc(this XmlSchemaAnnotated element)
        {
            return GetMinMaxOccValue(element, "maxOcc");
        }

        public static void AddAppinfo(this XmlSchemaElement element, XmlSchemaAppInfo ai)
        {
            var annotation = element.Annotation;

            if (annotation == null)
            {
                annotation = new XmlSchemaAnnotation();
                element.Annotation = annotation;
            }

            annotation.Items.Insert(0, ai);
        }

        public static (int min, int max) GetOccurrence(this XmlSchemaElement element)
        {
            var min = (int)element.MinOccurs;
            var max = element.MinOccurs < int.MaxValue ? (int)element.MaxOccurs : int.MaxValue;

            return (min, max);
        }

        public static (int min, int max) GetOccurrence(this XmlSchemaAttribute attribute)
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
