using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace KatanaOwinBugTracker.Web.Hubs
{
    [HubName("bugs")]
    public class BugsHub : Hub
    {

    }
}