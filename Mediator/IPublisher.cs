namespace Mediator
{
    public interface IPublisher
    {
        Task Publish(INotification notification,CancellationToken cancellationToken);
    }

}