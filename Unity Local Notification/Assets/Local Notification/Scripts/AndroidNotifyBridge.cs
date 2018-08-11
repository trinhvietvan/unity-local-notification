#if UNITY_ANDROID && !UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;

class AndroidNotifyBridge : INotifyBridge
{
    private AndroidJavaClass pluginClass;
    private AndroidJavaObject activity;
    private List<AndroidNotifyContent> scheduleNotifications;

    public AndroidNotifyBridge()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        pluginClass = new AndroidJavaClass("van.nzt.UnityLocalNotification");

        scheduleNotifications = new List<AndroidNotifyContent>();
    }

    public void ClearAllNotifications()
    {
        pluginClass.CallStatic("ClearAllNotifications", activity);
    }

    public void CancelAllNotifications()
    {
        int scheduledNotify = PlayerPrefs.GetInt("local_notifications", 0);

        for (int i = 0; i < scheduledNotify; i++)
        {
            pluginClass.CallStatic("CancelNotification", activity, i);
        }
    }

    public void RegisterScheduleNotification(int delaySeconds, string content, string title = "", string ticker = "")
    {
        scheduleNotifications.Add(new AndroidNotifyContent(delaySeconds, title, content, ticker));
    }

    public void SetScheduleNotification()
    {
        for (int i = 0; i < scheduleNotifications.Count; i++)
        {
            int id = i;
            int delaySeconds = scheduleNotifications[i].delaySeconds;
            string title = scheduleNotifications[i].title;
            string content = scheduleNotifications[i].content;
            string ticker = scheduleNotifications[i].ticker;

            pluginClass.CallStatic("ScheduleNotification", activity, id, delaySeconds, title, content, ticker);
        }

        PlayerPrefs.SetInt("local_notifications", scheduleNotifications.Count);

        scheduleNotifications.Clear();
    }
}

#endif