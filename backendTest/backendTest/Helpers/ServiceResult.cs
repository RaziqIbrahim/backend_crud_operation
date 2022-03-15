namespace backendTest.Helpers
{
    public enum ServiceStatus
    {
        Failed,
        Invalid,
        Success
    }

    public class ServiceResult<T>
    {
        public ServiceStatus Status { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
