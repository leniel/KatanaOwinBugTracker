﻿namespace KatanaOwinBugTracker.Web.Model
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}