using System.Collections;
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

    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip audioclip;
    [SerializeField] TMP_Text info;
    [SerializeField] GameObject X2Button;

    private bool isCheater = false;
    private float lastClickTime = 0;
    private float minIntervalClickTime = 100;
    private SpawnObjectOnMouse spawnObject;

    [HideInInspector]
    public float boost = 1;

    [HideInInspector]
    public float boostADS = 1;

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
        if (isCheater == false) 
        {
            AudioSource.PlayOneShot(audioclip);
        } 
        AddGold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void BoostADS()
    {
        StartCoroutine(startADS());
    }

    IEnumerator startADS()
    {
        boostADS = 2;
        X2Button.SetActive(false);

        yield return new WaitForSeconds(30);
        boostADS = 1;
        X2Button.SetActive(true);
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
            YandexGame.savesData.goldCoin += YandexGame.savesData.levelXclick * boost * boostADS;
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
        info.text = "xclick: " + (YandexGame.savesData.levelXclick * boost * boostADS).ToString();
    }
}
