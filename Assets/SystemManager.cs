using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject combatUI;
    public Slider bossHPBar;
    public GameObject player;
    private AudioSource gameMusic;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameMusic = GetComponent<AudioSource>();
        ChangeGameState(0);
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
        combatUI.SetActive(false);
        // Example: Play a different theme based on gameState
        switch (gameState)
        {
            case 0:
                gameMusic.PlayOneShot(themes[0]);
                break;
            case 1:
                gameMusic.PlayOneShot(themes[1]);
                gameMusic.volume = 0.5f;
                combatUI.SetActive(true);
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

    public void SetTotalHP(float health)
    {
        bossHPBar.maxValue = health;
    }

    public void AddHealth(float damage)
    {
        bossHPBar.value -= damage;
    }
}
