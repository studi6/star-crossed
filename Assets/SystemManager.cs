using UnityEngine;

public class SystemManager : MonoBehaviour
{
    #region Singleton
    public static SystemManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int gameState; //noncombat, combat, cutscene(disabled movement)

    public void ChangeGameState(int state)
    {
        gameState = state;
    }
}
