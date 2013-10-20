using System.Collections.Generic;

namespace KatanaOwinBugTracker.Web.Model
{
    public class BugsRepository : IBugsRepository
    {
        private static readonly List<Bug> _repo;

        static BugsRepository()
        {
            _repo = new List<Bug>();

            //add some default values
            _repo.Add(new Bug { Id = 1, Title = "bug #1", Description = "first bug", State = "backlog"});
            _repo.Add(new Bug { Id = 2, Title = "bug #2", Description = "second bug", State = "working" });
            _repo.Add(new Bug { Id = 3, Title = "bug #3", Description = "third bug", State = "done" });
            _repo.Add(new Bug { Id = 4, Title = "bug #4", Description = "fourth bug", State = "backlog" });
            _repo.Add(new Bug { Id = 5, Title = "bug #5", Description = "fifth bug", State = "working" });
            _repo.Add(new Bug { Id = 6, Title = "bug #6", Description = "sixth bug", State = "done" });
            _repo.Add(new Bug { Id = 7, Title = "bug #7", Description = "seventh bug", State = "done" });
            _repo.Add(new Bug { Id = 8, Title = "bug #8", Description = "eighth bug", State = "backlog" });
            _repo.Add(new Bug { Id = 9, Title = "bug #9", Description = "nineth bug", State = "backlog" });
            _repo.Add(new Bug { Id = 10, Title = "bug #10", Description = "tenth bug", State = "working" });
        }

        public IEnumerable<Bug> GetBugs()
        {
            return _repo;
        }
    }
}