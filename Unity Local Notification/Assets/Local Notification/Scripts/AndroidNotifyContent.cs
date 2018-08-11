public class AndroidNotifyContent
{
    public int delaySeconds;
    public string title;
    public string content;
    public string ticker;

    public AndroidNotifyContent(int delaySeconds, string title, string content, string ticker)
    {
        this.delaySeconds = delaySeconds;
        this.title = title;
        this.content = content;
        this.ticker = ticker;
    }
}