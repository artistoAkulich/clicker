using System.Linq;
using TMPro;
using UnityEngine;
using YG;

public class autoClick : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip clickSound;

    [SerializeField] public InfoLevel[] levels;

    public TMP_Text priceText;

    private float delayAutoClick;
    private float lastTimeAddGold;


    void Start()
    {
        UpdateUI();
    }

    void Update()
    {

    }

    public void OnClicked() //обработчик-функция
    {

        if (YandexGame.savesData.levelAutoClick == levels.Count() - 1)
            return;

        float price = levels[YandexGame.savesData.levelAutoClick+1].price;

        if (YandexGame.savesData.goldCoin >= price)
        {
            YandexGame.savesData.goldCoin -= price;
            YandexGame.savesData.levelAutoClick += 1;

            m_AudioSource.PlayOneShot(clickSound);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        priceText.text = (levels[YandexGame.savesData.levelAutoClick + 1].price).ToString();
    }
}

[System.Serializable]
public class InfoLevel
{
    public float valueDelay;
    public int price;
}
