using UnityEngine;

public class SpawnObjectOnMouse : MonoBehaviour
{
    public GameObject objectToSpawn; // префаб объекта, который вы хотите заспавнить

    public void SpawnObject(Vector3 mousePosition)
    {
        mousePosition.z = 0;
        Instantiate(objectToSpawn, mousePosition, Quaternion.identity);
    }
}