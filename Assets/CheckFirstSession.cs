using UnityEngine;
using YG;

public class CheckFirstSession : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;


    public GameObject firstPanel;
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    public void GetLoad()
    {
        if (YandexGame.savesData.isFirstSession == true)
        {
            firstPanel.SetActive(true);
        }
    }
}
