using System;

namespace DependencyInjection.Example.AspNetCore.Interfaces
{
    public interface ITransientExampleService
    {
        Guid GetInstanceId();
    }

    public interface IScopedExampleService
    {
        Guid GetInstanceId();
    }

    public interface ISingletonExampleService
    {
        Guid GetInstanceId();
    }
}