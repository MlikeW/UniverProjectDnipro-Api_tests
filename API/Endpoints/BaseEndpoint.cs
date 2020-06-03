using System.IO;

namespace API.Endpoints
{
    internal abstract class BaseEndpoint
    {
        protected abstract string MainPoint { get; }

        private string GetSingleChildPoint(string childPoint)
            => Path.Combine(MainPoint, childPoint);

        protected string GetChildPoint(params string[] childPoint)
            => GetSingleChildPoint(Path.Combine(childPoint));

        protected Sender.Sender Send;

        protected BaseEndpoint(Sender.Sender send) => Send = send;
    }
}