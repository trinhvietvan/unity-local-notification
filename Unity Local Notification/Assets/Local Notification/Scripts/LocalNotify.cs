using UnityEngine;

public class LocalNotify : MonoBehaviour
{
    public static LocalNotify Instance { get; private set; }

    private INotifyBridge pluginBridge;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

#if UNITY_EDITOR
        pluginBridge = new EditorNotifyBridge();
#elif UNITY_ANDROID
        pluginBridge = new AndroidNotifyBridge();
#elif UNITY_IOS
        pluginBridge = new IosNotifyBridge();
#endif

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        ClearAllNotifications();
        CancelAllNotifications();
    }

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            ClearAllNotifications();
            CancelAllNotifications();

            SetScheduleNotification();
        }
        else
        {
            ClearAllNotifications();
            CancelAllNotifications();
        }
    }

    void OnApplicationQuit()
    {
        SetScheduleNotification();
    }

    public void CancelAllNotifications()
    {
        pluginBridge.CancelAllNotifications();
    }

    public void ClearAllNotifications()
    {
        pluginBridge.ClearAllNotifications();
    }


    public void RegisterScheduleNotification(int delaySeconds, string content, string title = "New Message", string ticker = "Ting Ting!!!")
    {
        pluginBridge.RegisterScheduleNotification(delaySeconds, content, title, ticker);
    }

    private void SetScheduleNotification()
    {
        pluginBridge.SetScheduleNotification();
        PlayerPrefs.Save();
    }
}
