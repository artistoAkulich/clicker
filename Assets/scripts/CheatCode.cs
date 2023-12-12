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
        // Если была нажата какая-либо клавиша
        if (Input.anyKeyDown)
        {
            lastTimeKey = Time.time;
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
        Debug.Log("Читкод активирован!");
    }
}
