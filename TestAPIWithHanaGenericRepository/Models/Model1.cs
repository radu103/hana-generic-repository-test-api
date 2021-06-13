using HanaGenericRepository.Attributes;
using System;

namespace TestAPIWithHanaGenericRepository.Models
{
    [HanaTableNamespace("testdb.database")]
    [HanaTableContext("data")]
    [HanaTableName("model1")]
    public class Model1
    {
        [HanaId]
        [HanaColumnName("id")]
        public Guid Id { get; set; }

        [HanaColumnName("name")]
        public String Name { get; set; } = string.Empty;

        [HanaColumnName("active")]
        public bool Active { get; set; }

        [HanaColumnName("value")]
        public int IntValue { get; set; } = 0;

        [HanaColumnName("datetime")]
        public DateTime DateTimeValue { get; set; } = DateTime.MinValue;

        [HanaColumnName("email")]
        [HanaDatabaseEncodedValue("seed")]
        public string Email { get; set; } = string.Empty;

        public string NotMappedProperty { get; set; }

        public double NotMappedProperty2 { get; set; }
    }
}
