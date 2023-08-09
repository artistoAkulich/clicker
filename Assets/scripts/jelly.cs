using TMPro;
using UnityEngine;

public class jelly : MonoBehaviour
{
    [SerializeField] private Data data; 

    [SerializeField] private TMP_Text jellyCoinText;
    [SerializeField] private TMP_Text goldCoinText;

    [SerializeField] private Animator animator;

    public void OnClick()
    {
        animator.SetTrigger("doTouch");
        data.goldCoin++;
    }

    private void Update()
    {
        jellyCoinText.text = data.jellyCoin.ToString();
        goldCoinText.text = data.goldCoin.ToString();
    }
}
