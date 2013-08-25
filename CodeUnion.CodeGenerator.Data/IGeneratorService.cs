using System.Collections.Generic;
using System.Data;

namespace CodeUnion.CodeGenerator.Data
{
    public interface IGeneratorService
    {
        void Generate(IList<Table> tables, IDictionary<string, object> parameters);
        IList<Column> GetColumns(string tableName);
        IList<string> GetPrimaryKeys(string tableName);
        DataTable GetSchema(string collectionName, string[] restrictionValues);
        IList<Table> GetTables(string schemaType);

        string ConnectionString { get; set; }

        string OutputPath { get; set; }

        string TemplatePath { get; set; }
    }
}
