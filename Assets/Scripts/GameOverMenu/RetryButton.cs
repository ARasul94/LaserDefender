namespace GameOverMenu
{
    public class RetryButton : BaseMenuButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(LevelObject.LoadGameScene);
        }
    }
}
