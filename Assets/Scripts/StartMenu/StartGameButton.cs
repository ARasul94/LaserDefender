namespace StartMenu
{
    public class StartGameButton : BaseMenuButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(LevelObject.LoadGameScene);
        }
    }
}
