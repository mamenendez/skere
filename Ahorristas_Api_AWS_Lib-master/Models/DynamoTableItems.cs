using System.Collections.Generic;

namespace DynamoDB.libs.Models
{
    public class DynamoTableItems
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
