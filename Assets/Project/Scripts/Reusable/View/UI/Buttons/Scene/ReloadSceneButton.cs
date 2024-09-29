public class ReloadSceneButton : ButtonListener
{
    protected override void Listen()
    {
        SceneLoad.Reload();
    }
}