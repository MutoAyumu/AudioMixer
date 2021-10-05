using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //音量設定を行うCanvasを入れる
    [SerializeField] GameObject m_canvas = default;
    //AudioMixerを設定
    [SerializeField] AudioMixer m_audioMixer = default;
    //どのボタンを押したときに設定画面を出すか
    [SerializeField] string m_getButtonName = " ";
    //ゲーム開始時の音量
    float m_startVolume = -15f;

    private void Start()
    {
        SetMaster(m_startVolume);
        SetBGM(m_startVolume);
        SetSE(m_startVolume);
    }

    private void Update()
    {
        if(Input.GetButtonDown(m_getButtonName))
        {
            m_canvas.gameObject.SetActive(!m_canvas.activeSelf);
        }
    }
    public void SetMaster(float volume)
    {
        m_audioMixer.SetFloat("Master", volume);
    }
    public void SetBGM(float volume)
    {
        m_audioMixer.SetFloat("BGM", volume);
    }
    public void SetSE(float volume)
    {
        m_audioMixer.SetFloat("SE", volume);
    }
}
