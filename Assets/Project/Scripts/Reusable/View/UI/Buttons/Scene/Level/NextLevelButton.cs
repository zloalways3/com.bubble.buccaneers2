public class NextLevelButton : ButtonListener
{
    protected override void Listen()
    {
        if (!Level.TryNext()) return;

        SceneLoad.Reload();
    }
}