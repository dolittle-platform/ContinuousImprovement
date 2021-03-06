﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using Concepts.SourceControl.GitHub;
using Machine.Specifications;

namespace Infrastructure.Services.Github.Webhooks.Handling.for_TenantMapper.when_getting_installations_for_a_tenant
{

    [Subject(typeof(IInstallationToTenantMapper), "GetInstallationsFor")]
    public class and_that_tenant_is_associated_with_multiple_installations : given.a_tenant_mapper
    {
        static IEnumerable<InstallationId> mapped_installations;
        Because of = () => mapped_installations = mapper.GetInstallationsFor(tenant_with_multiple_installations);

        It should_return_a_single_installation = () => mapped_installations.Count().ShouldEqual(2);
        It should_be_the_correct_installations = () => mapped_installations.ShouldContainOnly(new [] { (InstallationId) installation_two, (InstallationId) installation_three });
    }
}