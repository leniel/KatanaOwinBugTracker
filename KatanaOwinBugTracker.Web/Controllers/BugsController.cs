using KatanaOwinBugTracker.Web.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace KatanaOwinBugTracker.Web.Controllers
{
    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        IBugsRepository bugsRepository = new BugsRepository();

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
            
            return bug;
        }

        [Route("working")]
        public Bug MoveToWorking([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.Id == id);
            bug.State = "working";
           
            return bug;
        }

        [Route("done")]
        public Bug MoveToDone([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.Id == id);
            bug.State = "done";
            
            return bug;
        }
    }
}