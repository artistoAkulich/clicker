using TMPro;
using UnityEngine;

public class jelly : MonoBehaviour
{
    [SerializeField] private Data data;

    [SerializeField] private TMP_Text jellyCoinText;
    [SerializeField] private TMP_Text goldCoinText;

    [SerializeField] private Animator animator;
    [SerializeField] float IntervalClickTimeAntiCheat;
    [SerializeField] Animator AnimatorAnticheat;

    private int AntiClick = 1;
    private float lastClickTime = 0;
    private float minIntervalClickTime = 100;
    private SpawnObjectOnMouse spawnObject;

    private void Awake()
    {
        spawnObject = FindFirstObjectByType<SpawnObjectOnMouse>();
    }

    public void ChangeAntiClick()
    {
        AntiClick = 1;
    }
    public void OnClick()
    {
        minIntervalClickTime = Time.time - lastClickTime;
        lastClickTime = Time.time;
        
        if (minIntervalClickTime < IntervalClickTimeAntiCheat)
        {
            AnimatorAnticheat.SetBool("notify", true);
            AntiClick = 0;
        }
    }

    public void AddGold()
    {
        if (AntiClick != 0)
        {
            spawnObject.SpawnObject();
            animator.SetTrigger("doTouch");
            data.goldCoin += data.levelXclick;
        }
    }

    private void Update()
    {
        jellyCoinText.text = data.jellyCoin.ToString();
        goldCoinText.text = data.goldCoin.ToString();
    }
}
