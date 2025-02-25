using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Example.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/example")]
    public class ExampleController : ControllerBase
    {
        private readonly ITransientExampleService _transientService;
        private readonly ITransientExampleService _transientService2;
        private readonly IScopedExampleService _scopedService; 
        private readonly IScopedExampleService _scopedService2;
        private readonly ISingletonExampleService _singletonService;

        public ExampleController(
            ITransientExampleService transientService,
            ITransientExampleService transientService2,
            IScopedExampleService scopedService,
            IScopedExampleService scopedService2,
            ISingletonExampleService singletonService)
        {
            _transientService = transientService;
            _transientService2 = transientService2;
            _scopedService2 = scopedService2;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        [HttpGet("instances")]
        public IActionResult GetInstances()
        {
            return Ok(new
            {
                Transient1 = _transientService.GetInstanceId(),
                Transient2 = _transientService2.GetInstanceId(),
                Scoped1 = _scopedService.GetInstanceId(),
                Scoped2 = _scopedService2.GetInstanceId(),
                Singleton = _singletonService.GetInstanceId()
                
            });
        }
    }
}