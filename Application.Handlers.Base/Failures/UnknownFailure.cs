namespace Application.Handlers.Base.Failures
{
    public class UnknownFailure : Failure
    {
        public UnknownFailure(string failureReason)
            : base(failureReason)
        {
        }
    }
}