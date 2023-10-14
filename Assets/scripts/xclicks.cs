using TMPro;
using UnityEngine;

public class xclicks : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip clickSound;
    private Data data;
    public TMP_Text priceText;


    // Start is called before the first frame update
    void Start()
    {
        data = FindFirstObjectByType<Data>();
        UpdateUI();
    }
    public void Onclick()
    {
        int xLevelClick = data.levelXclick; //Левел клика
        int price = xLevelClick * 100; //цена улучшения
        int playerGold = data.goldCoin;   //денюжки плеера

        if (playerGold >= price)
        {
            playerGold -= price;
            xLevelClick += 1;
            m_AudioSource.PlayOneShot(clickSound);

            data.goldCoin = playerGold;
            data.levelXclick = xLevelClick;
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
