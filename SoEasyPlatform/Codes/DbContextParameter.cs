using System.Collections.Generic;
using SqlSugar;

namespace SugarCodeGeneration
{
    public class DbContextParameter
    {
        public string ConnectionString { get; set; }
        public DbType DbType { get; set; }
        public List<string> Tables { get; set; }
        public string ClassNamespace { get;  set; }

        public string ConnKey { get; set; }
        public string DbContextName { get; set; }
    }
}