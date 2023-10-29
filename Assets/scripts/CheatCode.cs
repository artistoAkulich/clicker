using UnityEngine;
using System.Collections.Generic;

public class CheatCode : MonoBehaviour
{
    public List<KeyCode> cheatCode;
    private List<KeyCode> currentKeys;
    private int index;

    private void Start()
    {
        currentKeys = new List<KeyCode>();
    }

    private void Update()
    {
        // ���� ���� ������ �����-���� �������
        if (Input.anyKeyDown)
        {
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
        YG.YandexGame.savesData.goldCoin += 10000;
        Debug.Log("������ �����������!");
    }
}
