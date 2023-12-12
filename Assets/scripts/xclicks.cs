using TMPro;
using UnityEngine;
using YG;

public class xclicks : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] TMP_Text info;
    [SerializeField] AudioClip clickSound;
    public TMP_Text priceText;

    private void Update()
    {
        UpdateUI();
    }
    void Start()
    {
        UpdateUI();
    }
    public void OnClick()
    {
        float price = YandexGame.savesData.levelXclick * 150;

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
        if (YandexGame.savesData.levelXclick != 0)
        {
            info.gameObject.SetActive(true);
            
        }
        priceText.text = (YandexGame.savesData.levelXclick * 150).ToString();
    }
}
