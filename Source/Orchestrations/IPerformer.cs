/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;

namespace Orchestrations
{
    /// <summary>
    /// Defines a performer in an orchestra
    /// </summary>
    public interface IPerformer<T>
    {
        /// <summary>
        /// The method that gets called when the performer should perform
        /// </summary>
        /// <param name="score">The score</param>
        Task Perform(T score);
    }
}