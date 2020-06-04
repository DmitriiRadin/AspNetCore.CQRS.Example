﻿using Application.Handlers.Base.Failures;

namespace Application.Handlers.Base
{
    public abstract class Failure
    {
        public string FailureReason { get; set; }

        protected Failure(string failureReason)
        {
            FailureReason = failureReason;
        }

        public static ConflictFailure Conflict(string failureReason = null) => new ConflictFailure(failureReason);

        public static NotFoundFailure NotFound(string failureReason = null) => new NotFoundFailure(failureReason);
    }
}