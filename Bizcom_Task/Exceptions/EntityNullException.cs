namespace Bizcom_Task.Exceptions
{
    public class EntityNullException<T> : Exception
    {
        public EntityNullException() : base($"{typeof(T)} object is null") { }

    }
}

