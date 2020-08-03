using System.Threading.Tasks;
using DynamoDB.libs.Models;

namespace DynamoDB.libs.DynamoDB
{
    public interface IGetItem
    {
        Task<DynamoTableItems> GetItems(string email);
    }
}
