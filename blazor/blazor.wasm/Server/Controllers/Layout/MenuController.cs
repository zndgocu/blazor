using blazor.wasm.EntityContext.Layout;
using Microsoft.AspNetCore.Mvc;
using ramfree.database.QueryManager.Interface;

namespace blazor.wasm.Server.Controllers.Layout
{
    [ApiController]
    [Route("menu")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IQueryManager _queryManager;

        public MenuController(ILogger<MenuController> logger, IQueryManager queryManager)
        {
            _logger = logger;
            _queryManager = queryManager;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Menu> Get()
        {
            string qry = $" select * " +
                         $"   from menu ";
            var result = _queryManager.ExcuteQuery<Menu>(qry);
            return result.Values;
        }
    }
}
