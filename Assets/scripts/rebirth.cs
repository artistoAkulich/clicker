using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class rebirth : MonoBehaviour
{
    public int price;

    public Image image;
    public TMP_Text priceText;
    public float boost;
    private jelly jelly;

    public Button button;
    public int ID;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        jelly = FindAnyObjectByType<jelly>();
        button.gameObject.SetActive(false);
    }
    public void GetLoad()
    {
        if (YandexGame.savesData.rebirth > ID)
        {
            Destroy(button.gameObject);
            image.color = Color.white;
        }
        else if (YandexGame.savesData.rebirth == ID)
        {
            Destroy(button.gameObject);
            jelly.boost = boost;
            image.color = Color.white;
            jelly.GetComponent<Image>().sprite = image.sprite;
        }
    }
    void Start()
    {
        priceText.text = price.ToString();
        
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }



    void Update()
    {
        if (price <= YG.YandexGame.savesData.goldCoin && YandexGame.savesData.rebirth == ID - 1)
        {
            image.color = Color.white;
            button.gameObject.SetActive(true);
            enabled = false;
        }
    }

    public void click()
    {
        Destroy(priceText.transform.parent.gameObject);
        jelly.boost = boost;
        jelly.GetComponent<Image>().sprite = image.sprite;
        YandexGame.savesData.goldCoin = 0;
        YandexGame.savesData.jellyCoin = 0;
        YandexGame.savesData.levelXclick = 0;
        YandexGame.savesData.levelAutoClick = 0;

        YandexGame.savesData.rebirth = ID;
    }

}
