using System.Collections.Generic;
using System.IO;
using Antlr4.StringTemplate;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using Template = NVelocity.Template;

namespace CodeUnion.CodeGenerator.Utility
{
    public static class TemplateUtility
    {
        public static string ParseStringTemplate(string content, IDictionary<string, object> parameters)
        {
            Antlr4.StringTemplate.Template template = new Antlr4.StringTemplate.Template(content);
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                template.Add(pair.Key, pair.Value);
            }
            return template.ToString();
        }

        public static string ParseStringTemplate(string path, string name, IDictionary<string, object> parameters)
        {
            Antlr4.StringTemplate.Template instanceOf = new TemplateGroup('T', 'E').GetInstanceOf(name);
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                instanceOf.Add(pair.Key, pair.Value);
            }
            return instanceOf.ToString();
        }

        public static string ParseVelocity(string content, IDictionary<string, object> parameters)
        {
            StringWriter writer = new StringWriter();
            VelocityEngine engine = new VelocityEngine();
            engine.Init();
            IContext context = new VelocityContext();
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                context.Put(pair.Key, pair.Value);
            }
            engine.Evaluate(context, writer, null, content);
            return writer.ToString();
        }

        public static string ParseVelocity(string path, string name, IDictionary<string, object> parameters)
        {
            StringWriter writer = new StringWriter();
            ExtendedProperties properties = new ExtendedProperties();
            properties.AddProperty("resource.loader", "file");
            properties.AddProperty("file.resource.loader.path", path);
            VelocityEngine engine = new VelocityEngine();
            engine.Init(properties);
            IContext context = new VelocityContext();
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                context.Put(pair.Key, pair.Value);
            }
            Template template = engine.GetTemplate(name);
            if (template != null)
            {
                template.Merge(context, writer);
            }
            return writer.ToString();
        }
    }
}

