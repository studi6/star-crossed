using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Sprite full, half, empty;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void setHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.EMPTY:
                heartImage.sprite = empty;
                break;

            case HeartStatus.HALF:
                heartImage.sprite = half;
                break;

            case HeartStatus.FULL:
                heartImage.sprite = full;
                break;
        }
    }
}

public enum HeartStatus
{
    EMPTY = 0,
    HALF = 1,
    FULL = 2
}
