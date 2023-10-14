using TMPro;
using UnityEngine;

public class autoClick : MonoBehaviour
{
    private Data data;

    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip clickSound;

    public TMP_Text priceText;

    public float[] table;

    private float delayAutoClick;
    private float lastTimeAddGold;

    void Start()
    {
        data = FindFirstObjectByType<Data>();
        UpdateUI();
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        int xLevel = data.levelAutoClick; //Левел клика
        int price = xLevel * 200; //цена улучшения
        int playerGold = data.goldCoin;   //денюжки плеера

        if (playerGold >= price)
        {
            playerGold -= price;
            xLevel += 1;
            m_AudioSource.PlayOneShot(clickSound);

            data.goldCoin = playerGold;
            data.levelAutoClick = xLevel;
            UpdateUI();
        }
        else
        {

        }
    }
    private void UpdateUI()
    {
        priceText.text = (data.levelXclick * 100).ToString();
    }
}
