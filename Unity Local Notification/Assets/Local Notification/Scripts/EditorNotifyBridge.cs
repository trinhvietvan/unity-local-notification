using UnityEngine;

/// <summary>
/// Just a fake implemention for editor
/// </summary>
public class EditorNotifyBridge : INotifyBridge
{
    public void ClearAllNotifications()
    {
        Debug.Log("Clear All Notifications");
    }

    public void CancelAllNotifications()
    {
        Debug.Log("Cancel All Notifications");
    }

    public void RegisterScheduleNotification(int delaySeconds, string content, string title = "", string ticker = "")
    {

        Debug.Log("Register Schedule Notification");
    }

    public void SetScheduleNotification()
    {
        Debug.Log("Setup Schedule Notification");
    }
}