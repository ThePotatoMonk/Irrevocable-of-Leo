using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite fullHeart, halfHeart, emptyHeart;
    Image heartImage;

    public void SetHearts(HeartStatus status)
    {
        switch (status)
        {

            //Using switch we can check the heart status and set it appropriately
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }
}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}