using KatanaOwinBugTracker.Web.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Microsoft.AspNet.SignalR;
using KatanaOwinBugTracker.Web.Hubs;

namespace KatanaOwinBugTracker.Web.Controllers
{
    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        IBugsRepository bugsRepository = new BugsRepository();

        private IHubContext hub;

        public BugsController()
        {
            hub = GlobalHost.ConnectionManager.GetHubContext<BugsHub>();
        }

        [Route("")]
        public IEnumerable<Bug> Get()
        {
            return bugsRepository.GetBugs();
        }

        [Route("backlog")]
        public Bug MoveToBacklog([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.Id == id);
            bug.State = "backlog";

            hub.Clients.All.moved(bug);
            
            return bug;
        }

        [Route("working")]
        public Bug MoveToWorking([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.Id == id);
            bug.State = "working";

            hub.Clients.All.moved(bug);

            return bug;
        }

        [Route("done")]
        public Bug MoveToDone([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.Id == id);
            bug.State = "done";

            hub.Clients.All.moved(bug);

            return bug;
        }
    }
}