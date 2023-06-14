
namespace Entities.Exceptions
{
    public class EntityBadRequestException<T> : Exception
    {
        public EntityBadRequestException() : base($"{typeof(T)} object is null") { }
    }
}
