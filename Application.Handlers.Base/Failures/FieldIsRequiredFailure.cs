namespace Application.Handlers.Base.Failures
{
    public class FieldIsRequiredFailure : Failure
    {
        public FieldIsRequiredFailure(string failureReason)
            : base(failureReason)
        {
        }
    }
}