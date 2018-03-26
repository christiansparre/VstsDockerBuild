using System;

namespace VstsDockerBuild.Shared
{
    public class Foo
    {
        public string Bar() => DateTime.UtcNow.ToLongDateString();
    }
}
