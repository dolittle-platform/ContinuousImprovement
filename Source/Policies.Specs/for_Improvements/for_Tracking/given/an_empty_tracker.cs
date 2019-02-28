using Machine.Specifications;
using Policies.Improvements.Tracking;

namespace Policies.Specs.for_Improvements.for_Tracking.given
{
    public class an_empty_tracker
    {
        protected static IBuildStepsStatusTracker tracker;
        Establish context = () => tracker = new BuildStepsStatusTracker();
    }
}