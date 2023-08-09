using TMPro;
using UnityEngine;

public class volumechenger : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    [SerializeField] AudioSource m_AudioSource;
    public void VolumeChanger(float value) 
    { 
        m_AudioSource.volume = value;
        m_Text.text = (value*100).ToString()+"%";
    }
}
