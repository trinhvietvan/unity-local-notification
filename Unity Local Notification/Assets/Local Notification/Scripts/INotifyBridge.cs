interface INotifyBridge
{
    void ClearAllNotifications();
    void CancelAllNotifications();
    void RegisterScheduleNotification(int delaySeconds, string content, string title = "", string ticker = "");
    void SetScheduleNotification();
}