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

    private int gameState = 0; //noncombat, combat, cutscene(disabled movement)
    [SerializeField] private AudioClip[] themes;
    private AudioSource gameMusic;

    private void Start()
    {
        gameMusic = GetComponent<AudioSource>(); // Assuming gameMusic AudioSource is attached to the same GameObject
        gameMusic.PlayOneShot(themes[gameState]);
    }

    public int GameState
    {
        get { return gameState; }
        set
        {
            gameState = value;
            HandleGameStateChange();
        }
    }

    private void HandleGameStateChange()
    {
        // Perform actions based on the gameState change
        Debug.Log("GameState changed to: " + gameState);
        gameMusic.Stop();
        // Example: Play a different theme based on gameState
        switch (gameState)
        {
            case 0:
                gameMusic.PlayOneShot(themes[0]);
                break;
            case 1:
                gameMusic.PlayOneShot(themes[1]);
                gameMusic.volume = 0.5f;
                break;
            case 2:
                gameMusic.PlayOneShot(themes[2]);
                gameMusic.volume = 0.5f;
                break;
            default:
                gameMusic.PlayOneShot(themes[1]);
                break;
        }
    }

    public void ChangeGameState(int state)
    {
        GameState = state;
    }
}
