using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScheduleNotification : MonoBehaviour {

    public void SetScheduleNotificationAndQuitApp()
    {
        LocalNotify.Instance.RegisterScheduleNotification(5, "This is test notification", "Test", "Android Ticker");
        Application.Quit();
    }
}
