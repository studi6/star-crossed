using UnityEngine;
using UnityEngine.UI;

public class SystemManager : MonoBehaviour
{
    #region Singleton
    public static SystemManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    public int gameState = 0; //noncombat, combat, cutscene(disabled movement)
    [SerializeField] private AudioClip[] themes;
    [SerializeField] private GameObject combatUI;
    [SerializeField] private GameObject kbAttack;
    public Slider bossHPBar;
    public GameObject bossHPBarObj;
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
        kbAttack.SetActive(false);
        player.transform.Find("WeaponHandler").gameObject.SetActive(false);
        // Example: Play a different theme based on gameState
        switch (gameState)
        {
            case 0:
                gameMusic.PlayOneShot(themes[0]);
                break;
            case 1:
                gameMusic.PlayOneShot(themes[1]);
                gameMusic.volume = 0.5f;
                player.transform.Find("WeaponHandler").gameObject.SetActive(true);
                combatUI.SetActive(true);
                kbAttack.SetActive(true);
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

    public void SetBossHealthBar(float health)
    {
        bossHPBar.maxValue = health;
    }

    public void DamageBossHealthBar(float damage)
    {
        bossHPBar.value -= damage;
    }

    public void DoCameraShake(float duration, float magnitude)
    {
        StartCoroutine(CameraShake.instance.Shake(Camera.main, duration, magnitude));
    }

    public void DoHealthBarShake(float duration, float magnitude)
    {
        StartCoroutine(HealthBarShake.instance.Shake(bossHPBar.gameObject, duration, magnitude));
    }

    // Test Camera Shake
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DoCameraShake(0.5f, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DoHealthBarShake(0.1f, 0.06f);
        }
    }
}
