namespace Application.Handlers.Base.Failures
{
    public class NotFoundFailure : Failure
    {
        public NotFoundFailure(string failureReason)
            : base(failureReason)
        {
        }
    }
}