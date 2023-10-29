using TMPro;
using UnityEngine;
using YG;

public class jelly : MonoBehaviour
{
    [SerializeField] private TMP_Text jellyCoinText;
    [SerializeField] private TMP_Text goldCoinText;

    [SerializeField] private Animator animator;
    [SerializeField] float IntervalClickTimeAntiCheat;
    [SerializeField] Animator AnimatorAnticheat;

    private bool AntiClick = false;
    private float lastClickTime = 0;
    private float minIntervalClickTime = 100;
    private SpawnObjectOnMouse spawnObject;

    private void Awake()
    {
        spawnObject = FindFirstObjectByType<SpawnObjectOnMouse>();
    }

    public void ChangeAntiClick()
    {
        AntiClick = true;
    }
    public void OnClick()
    {
        AntiChit();
        AddGold();
    }

    public void AddGold()
    {
        if (AntiClick == false)
        {
            if (YandexGame.savesData.levelXclick > 0)
            {
                spawnObject.SpawnObject();
            }

            animator.SetTrigger("doTouch");
            YandexGame.savesData.goldCoin += YandexGame.savesData.levelXclick;
        }
    }

    private void AntiChit()
    {
        minIntervalClickTime = Time.time - lastClickTime;
        lastClickTime = Time.time;

        if (minIntervalClickTime < IntervalClickTimeAntiCheat)
        {
            AnimatorAnticheat.SetBool("notify", true);
            AntiClick = true;
        }
    }

    private void Update()
    {
        jellyCoinText.text = YandexGame.savesData.jellyCoin.ToString();
        goldCoinText.text = YandexGame.savesData.goldCoin.ToString();
    }
}
