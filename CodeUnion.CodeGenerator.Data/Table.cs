using System;
using System.Collections.Generic;
using CodeUnion.CodeGenerator.Utility;

namespace CodeUnion.CodeGenerator.Data
{
    [Serializable]
    public class Table
    {
        private string alias;
        private string description;

        public string Alias
        {
            get
            {
                if (string.IsNullOrEmpty(this.alias))
                {
                    return this.Name.ToPascal();
                }
                return this.alias;
            }
            set
            {
                this.alias = value;
            }
        }

        public IList<Column> AllColumns
        {
            get; 
            set;
        }

        public string CamelAlias
        {
            get
            {
                return this.Alias.ToCamel();
            }
        }

        public IList<Column> Columns
        {
            get; 
            set;
        }

        public DateTime CreationTime
        {
            get; 
            set;
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(this.description))
                {
                    return this.Alias;
                }
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public IList<Column> Keys
        {
            get; 
            set;
        }

        public DateTime? ModificationTime
        {
            get; 
            set;
        }

        public string Name
        {
            get; 
            set;
        }

        public string Owner
        {
            get; 
            set;
        }
    }
}
