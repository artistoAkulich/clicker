using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class volumechenger : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    [SerializeField] AudioSource m_AudioSource;
   
    private void Start()
    {
        m_Text.text = (100).ToString() + "%";
    }

    public void VolumeChanger(float value) 
    { 
        m_AudioSource.volume = value;
        m_Text.text = Mathf.Floor(value* 100).ToString()+"%";
    }
}
