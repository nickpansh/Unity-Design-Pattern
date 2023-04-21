public abstract class WindowBase : UIBase
{
    private int _priority;
    public int priority
    {
        get { return _priority; }
        set { _priority = value; }
    }

    public override void Pause()
    {
        SetCanvasGroupEnabled(false);
    }

    public override void Resume()
    {
        SetCanvasGroupEnabled(true);
    }

}