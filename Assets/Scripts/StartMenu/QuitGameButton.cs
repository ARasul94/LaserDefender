namespace StartMenu
{
    public class QuitGameButton : BaseMenuButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(LevelObject.QuitGame);
        }
    }
}
