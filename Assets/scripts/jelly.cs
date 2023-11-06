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

    private bool isCheater = false;
    private float lastClickTime = 0;
    private float minIntervalClickTime = 100;
    private SpawnObjectOnMouse spawnObject;

    private void Awake()
    {
        spawnObject = FindFirstObjectByType<SpawnObjectOnMouse>();
    }

    public void ChangeAntiClick()
    {
        isCheater = false;
    }
    public void OnClick()
    {
        AntiChit();
        AddGold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void AddGold(Vector3 pos)
    {
        if (isCheater == false)
        {
            if (YandexGame.savesData.levelXclick > 0)
            {
                spawnObject.SpawnObject(pos);
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
            isCheater = true;
        }
    }

    private void Update()
    {
        jellyCoinText.text = YandexGame.savesData.jellyCoin.ToString();
        goldCoinText.text = YandexGame.savesData.goldCoin.ToString();
    }
}
