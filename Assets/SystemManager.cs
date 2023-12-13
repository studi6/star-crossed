using System.Collections;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemyList; //dont need yet

    #region Singleton
    public static SystemManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        player = GameObject.FindWithTag("Player");
    }
    #endregion

}
