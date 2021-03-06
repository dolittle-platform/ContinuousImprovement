/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts;
using Concepts.Improvables;
using Concepts.Improvements;
using Dolittle.Collections;
using Dolittle.IO;
using Dolittle.IO.Tenants;
using Dolittle.Queries;
using Dolittle.Serialization.Json;

namespace Read.Improvements
{
    /// <summary>
    /// Gets the steps for an improvement
    /// </summary>
    public class StepsForImprovement : IQueryFor<Step>
    {
        readonly IFiles _fileSystem;
        readonly ISerializer _serializer;

        /// <summary>
        /// Instantiates an instance of <see cref="StepsForImprovement" />
        /// </summary>
        /// <param name="fileSystem">A file system wrapper</param>
        /// <param name="serializer"><see cref="ISerializer">Json Serializer</see></param>
        public StepsForImprovement(IFiles fileSystem, ISerializer serializer)
        {
            _fileSystem = fileSystem;
            _serializer = serializer;
        }

        /// <summary>
        /// The improvable being improved
        /// </summary>
        public ImprovableId Improvable { get; set; }

        /// <summary>
        /// The version associated with the improvement
        /// </summary>
        public Concepts.Version Version { get; set; }

        /// <inheritdoc />
        public IQueryable<Step> Query
        {
            get 
            {
                var versionPath = Path.Combine(Improvable.Value.ToString(),Version);
                var stepsFile = Path.Combine(versionPath,"steps.json");
                var stepsAsJson = _fileSystem.ReadAllText(stepsFile);
                var steps = _serializer.FromJson<IEnumerable<Step>>(stepsAsJson).ToArray();

                return steps.AsQueryable();
            }
        }
    }
}