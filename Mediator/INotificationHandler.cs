namespace Mediator
{
    public interface INotificationHandler<in TNOtification> where TNOtification : INotification
    { 
        Task Handle(TNOtification notification);
    }


}