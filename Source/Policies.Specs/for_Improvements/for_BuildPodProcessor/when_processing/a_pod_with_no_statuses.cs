/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using Policies.Improvements;
using Policies.Improvements.Tracking;
using It = Machine.Specifications.It;

namespace Policies.Specs.for_Improvements.for_BuildPodProcessor.when_processing
{
    [Subject(typeof(IBuildPodProcessor),"Process")]
    public class a_pod_with_no_statuses : given.a_build_pod_processor
    {
        static Mock<IPod> pod;

        Establish context = () => 
        {
            pod = new Mock<IPod>();
            pod.SetupGet(_ => _.Metadata).Returns(metadata);
        };

        Because of = () => processor.Process(pod.Object);

        It should_log_that_the_pod_has_no_statuses = () => VerifyLoggedInformationMessageContains("no statuses");
        It should_not_process_any_steps = () => handle_build_steps.Verify(_ => _.Handle(metadata,Moq.It.IsAny<IEnumerable<TrackedStepStatuses>>()), Times.Never);
    }
}