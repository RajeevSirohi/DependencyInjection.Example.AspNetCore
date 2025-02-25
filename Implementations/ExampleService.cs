using System;

namespace DependencyInjection.Example.AspNetCore.Implementations
{
    public class TransientExampleService : ITransientExampleService
    {
        private readonly Guid _instanceId = Guid.NewGuid();

        public Guid GetInstanceId() => _instanceId;
    }

    public class ScopedExampleService : IScopedExampleService
    {
        private readonly Guid _instanceId = Guid.NewGuid();

        public Guid GetInstanceId() => _instanceId;
    }

    public class SingletonExampleService : ISingletonExampleService
    {
        private readonly Guid _instanceId = Guid.NewGuid();

        public Guid GetInstanceId() => _instanceId;
    }
}