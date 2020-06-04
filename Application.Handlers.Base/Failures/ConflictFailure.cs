namespace Application.Handlers.Base.Failures
{
    public class ConflictFailure : Failure
    {
        public ConflictFailure(string failureReason)
            : base(failureReason)
        {
        }
    }
}