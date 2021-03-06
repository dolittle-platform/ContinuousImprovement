/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using Concepts;
using Concepts.Improvables;
using Concepts.Improvements;
using Dolittle.IO;
using Dolittle.IO.Tenants;
using Dolittle.Queries;

namespace Read.Improvements
{
    /// <summary>
    /// Represents a query for getting a <see cref="StepRawLog"/> for a <see cref="Step"/>
    /// </summary>
    public class RawLogForStep : IQueryFor<StepRawLog>
    {
        readonly IFiles _fileSystem;

        /// <summary>
        /// Instantiates an instance of <see cref="RawLogForStep" />
        /// </summary>
        /// <param name="fileSystem"></param>
        public RawLogForStep(IFiles fileSystem)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// The improvable the step is improving
        /// </summary>
        public ImprovableId Improvable {  get; set; }

        /// <summary>
        /// The version of the improvement
        /// </summary>
        public Concepts.Version Version {  get; set; }

        /// <summary>
        /// The Step Number that the log message refers to
        /// </summary>
        public StepNumber Number {  get; set; }

        /// <inheritdoc/>
        public IQueryable<StepRawLog> Query
        {
            get
            {
                var log = new StepRawLog();

                var versionPath = Path.Combine(Improvable.Value.ToString(), Version);

                var stepsPath = Path.Combine(versionPath, "steps");
                var stepFilePath = Path.Combine(stepsPath,$"{Number}.log");
                if( _fileSystem.Exists(stepFilePath)) 
                {
                    log.Content = _fileSystem.ReadAllText(stepFilePath);
                }

                return new[] { log }.AsQueryable();
            }
        }
    }
}