#if UNITY_IOS && !UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEngine.iOS;

public class IosNotifyBridge : INotifyBridge
{
    private List<LocalNotification> scheduleNotifications;

    public IosNotifyBridge()
    {
        NotificationServices.RegisterForNotifications(NotificationType.Alert | NotificationType.Badge | NotificationType.Sound);
        scheduleNotifications = new List<LocalNotification>();
    }

    public void ClearAllNotifications()
    {
        NotificationServices.ClearLocalNotifications();
        NotificationServices.ClearRemoteNotifications();
    }

    public void CancelAllNotifications()
    {
        NotificationServices.CancelAllLocalNotifications();
    }

    public void RegisterScheduleNotification(int delaySeconds, string content, string title = "", string ticker = "")
    {
        LocalNotification notify = new LocalNotification();
        notify.fireDate = DateTime.Now.AddSeconds(delaySeconds);
        notify.alertBody = content;

        scheduleNotifications.Add(notify);
    }

    public void SetScheduleNotification()
    {
        for (int i = 0; i < scheduleNotifications.Count; i++)
        {
            NotificationServices.ScheduleLocalNotification(scheduleNotifications[i]);
        }

        scheduleNotifications.Clear();
    }
}

#endif