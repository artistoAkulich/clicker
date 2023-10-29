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
        // Если была нажата какая-либо клавиша
        if (Input.anyKeyDown)
        {
            // Проверяем каждую клавишу в читкоде
            foreach (KeyCode key in cheatCode)
            {
                if (Input.GetKeyDown(key))
                {
                    currentKeys.Add(key);
                }
            }

            // Если текущий список клавиш соответствует читкоду
            if (IsMatchingCheatCode())
            {
                ExecuteCheat();
                currentKeys.Clear(); // очистите список после выполнения функции
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
        Debug.Log("Читкод активирован!");
    }
}
