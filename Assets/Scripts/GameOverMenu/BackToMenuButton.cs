namespace GameOverMenu
{
    public class BackToMenuButton : BaseMenuButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(LevelObject.LoadStartMenuScene);
        }
    }
}
