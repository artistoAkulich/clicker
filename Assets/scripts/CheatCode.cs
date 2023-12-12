using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public List<KeyCode> cheatCode;
    private List<KeyCode> currentKeys;
    private int index;

    private float lastTimeKey;

    private void Start()
    {
        currentKeys = new List<KeyCode>();
    }

    private void Update()
    {
        // ���� ���� ������ �����-���� �������
        if (Input.anyKeyDown)
        {
            lastTimeKey = Time.time;
            // ��������� ������ ������� � �������
            foreach (KeyCode key in cheatCode)
            {
                if (Input.GetKeyDown(key))
                {
                    currentKeys.Add(key);
                }
            }

            // ���� ������� ������ ������ ������������� �������
            if (IsMatchingCheatCode())
            {
                ExecuteCheat();
                currentKeys.Clear(); // �������� ������ ����� ���������� �������
            }
        }

        if (lastTimeKey + 3 < Time.time)
        {
            currentKeys.Clear();
        }
    }

    private bool IsMatchingCheatCode()
    {
        if (currentKeys.Count != cheatCode.Count)
            return false;

        for (int i = 0; i < currentKeys.Count; i++)
        {
            if (currentKeys[i] != cheatCode[i])
                return false;
        }
        return true;
    }

    private void ExecuteCheat()
    {
        YG.YandexGame.savesData.goldCoin += 10000000;
        Debug.Log("������ �����������!");
    }
}
