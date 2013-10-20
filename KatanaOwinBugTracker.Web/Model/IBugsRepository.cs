using System.Collections.Generic;

namespace KatanaOwinBugTracker.Web.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
    }
}