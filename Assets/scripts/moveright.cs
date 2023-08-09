using UnityEngine;

public class Nmoveright : MonoBehaviour
{
    [SerializeField] private int speed;

    [SerializeField] private Vector3 startPos;

    private void Start()
    {
        startPos.y = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("endmap")) 
        {
            Instantiate(gameObject, startPos, transform.rotation);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("endmap"))
        {
            Destroy(gameObject);
        }
    }
}
