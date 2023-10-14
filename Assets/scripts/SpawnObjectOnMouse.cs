using UnityEngine;

public class SpawnObjectOnMouse : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ �������, ������� �� ������ ����������

    public void SpawnObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(objectToSpawn, mousePosition, Quaternion.identity);
    }


}