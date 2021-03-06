﻿using System;
using System.Runtime.Serialization;

namespace Domain.Improvements
{
    /// <summary>
    /// Captures the situation where an Improvement that is already initialized is initialized again
    /// </summary>
    [Serializable]
    public class ImprovementAlreadyFailed : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the ImprovementAlreadyFailed custom exception
        /// </summary>
        public ImprovementAlreadyFailed()
        {}

        /// <summary>
        ///     Initializes a new instance of the ImprovementAlreadyFailed custom exception
        /// </summary>
        /// <param name="message">A message describing the exception</param>
        public ImprovementAlreadyFailed(string message)
            : base(message)
        {}

        /// <summary>
        ///     Initializes a new instance of the ImprovementAlreadyFailed custom exception
        /// </summary>
        /// <param name="message">A message describing the exception</param>
        /// <param name="innerException">An inner exception that is the original source of the error</param>
        public ImprovementAlreadyFailed(string message, Exception innerException)
            : base(message, innerException)
        {}

        /// <summary>
        ///     Initializes a new instance of the ImprovementAlreadyFailed custom exception
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the object data of the exception</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination</param>
        protected ImprovementAlreadyFailed(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {}
    }
}

