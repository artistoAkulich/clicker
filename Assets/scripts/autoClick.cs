using System.Linq;
using TMPro;
using UnityEngine;
using YG;

public class autoClick : MonoBehaviour
{
    [SerializeField] TMP_Text info;  
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip clickSound;

    [SerializeField] public InfoLevel[] levels;
    private jelly jelly;

    public TMP_Text priceText;

    private float lastTimeAddGold;

    void Start()
    {
        UpdateUI();
        jelly = FindFirstObjectByType<jelly>();
    }

    void Update()
    {
        float delay = levels[YandexGame.savesData.levelAutoClick].valueDelay;

        if (delay > 0 && lastTimeAddGold + delay < Time.time)
        {
            lastTimeAddGold = Time.time;
            jelly.AddGold(jelly.transform.position);
        }
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

        if (YandexGame.savesData.levelAutoClick != 0)
        {
            info.text = "AutoClick Delay: " + levels[YandexGame.savesData.levelAutoClick].valueDelay.ToString();
            info.gameObject.SetActive(true);
        }
    }
}

[System.Serializable]
public class InfoLevel
{
    public float valueDelay;
    public int price;
}
