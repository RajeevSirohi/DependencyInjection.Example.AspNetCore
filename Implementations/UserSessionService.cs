using System;

namespace DependencyInjection.Example.AspNetCore.Implementations
{
    public class UserSessionService : IUserSessionService
    {
        private readonly string _sessionId;

        public UserSessionService()
        {
            _sessionId = Guid.NewGuid().ToString();
        }

        public string GetSessionId()
        {
            return _sessionId;
        }
    }
}