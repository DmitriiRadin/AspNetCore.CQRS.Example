namespace Application.Handlers.Base
{
    public class CommandResponse<T>
    {
        private CommandResponse(Failure failure) => Failure = failure;
        private CommandResponse(T payload) => Payload = payload;

        public T Payload { get; set; }
        public Failure Failure { get; set; }

        public bool IsSuccess => Failure == null;

        public static CommandResponse<T> Fail(Failure failure) => new CommandResponse<T>(failure);
        public static CommandResponse<T> Success(T payload) => new CommandResponse<T>(payload);

        public static implicit operator bool(CommandResponse<T> response) => response.IsSuccess;
    }
}
