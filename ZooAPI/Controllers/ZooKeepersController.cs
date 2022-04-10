using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using ZooAPI.BusinessLogic.Commands.ZooKeeperCommands.Commands;
using ZooAPI.BusinessLogic.Queries.ZooKeeperQueries.Queries;
using ZooAPI.Domain.Models;
using ZooAPI.Extensions;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ZooKeepersController : Controller
    {

        private readonly IMediator mediator;
        private readonly IDistributedCache cache;
        public ZooKeepersController(IMediator mediator, IDistributedCache cache)
        {
            this.mediator = mediator;
            this.cache = cache;
        }
        [HttpGet]
        public async Task<ActionResult<List<ZooKeeper>>> Index()
        {
            string recordId = "zookeepers_" + DateTime.Now.ToString("yyyymmdd_hhmm");
            string message = "cache";

            var response = await cache.GetRecordAsync<List<ZooKeeper>>(recordId);

            if (response == null)
            {
                response = await mediator.Send(new GetAllZooKeepersCommand(new ZooKeeper()));
                await cache.SetRecordAsync(recordId, response);
                message = "DB";
            }

            return Ok(response);
        }

        // GET: ZooKeepersController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZooKeeper>> Details(int id)
        {
            return Ok(await mediator.Send(new GetZooKeeperByIDCommand(new ZooKeeper { Id = id} )));
        }

        // GET: ZooKeepersController/Create
        [HttpPost]
        public async Task<ActionResult<ZooKeeper>> Create(ZooKeeper zooKeeper)
        {
            return Ok(await mediator.Send(new AddZooKeeperCommand(zooKeeper)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ZooKeeper>> Edit(int id, ZooKeeper zooKeeper)
        {
            zooKeeper.Id = id;
            return Ok(await mediator.Send(new UpdateZooKeeperCommand(zooKeeper)));
        }

        // POST: ZooKeepersController/Edit/5
        

        // GET: ZooKeepersController/Delete/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
           return Ok(await mediator.Send(new DeleteZooKeeperCommand(new ZooKeeper { Id = id})));
        }

        // POST: ZooKeepersController/Delete/5
        
    }
}
