using UnityEngine;

public class NotifyAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeNotify(bool value)
    {
        animator.SetBool("notify", value);
    }
}