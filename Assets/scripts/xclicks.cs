using TMPro;
using UnityEngine;
using YG;

public class xclicks : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip clickSound;
    public TMP_Text priceText;

    void Start()
    {
        UpdateUI();
    }
    public void OnClick()
    {
        float price = YandexGame.savesData.levelXclick * 100;

        if (YandexGame.savesData.goldCoin >= price)
        {
            YandexGame.savesData.goldCoin -= price;
            YandexGame.savesData.levelXclick += 1;

            m_AudioSource.PlayOneShot(clickSound);
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        priceText.text = (YandexGame.savesData.levelXclick * 100).ToString();
    }
}
