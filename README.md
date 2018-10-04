# Schedule local notification for Unity

*A simple schedule local push notification plugin for Unity (Android, iOS)*

**How to use:**

1 - Drag `Local Notification` prefab to your first scene

2 - Just call `LocalNotify.Instance.RegisterScheduleNotification()`. The notification that you registered will be fire when delay time reached (Notification only fire when app is in background or don't run)
 
 
**Notice:**

If you want to custom notification icon, create 2 PNG file `notify_icon_big.png`, `notify_icon_small.png` and copy to folder `Assets/Plugins/res/drawable` in your Unity project
 
 
**Customize Android Plugin:**

  If you change Android plugin source and rebuild AAR file, please open the AAR file with WinRar and delete all `drawable` and `res` folder inside AAR file
