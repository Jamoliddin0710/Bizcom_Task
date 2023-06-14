using Microsoft.AspNetCore.Http.HttpResults;
using SendGrid.Helpers.Errors.Model;
namespace Entities.Exceptions
{
    public class EntityNotFoundException<T> : NotFoundException  
    {
        public EntityNotFoundException() : base($"{typeof(T).Name} does not exist in database")
        {

        } 
    }
}
