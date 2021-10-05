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
    static float m_startVolumeMaster = -15f;
    static float m_startVolumeBGM = -15f;
    static float m_startVolumeSE = -15f;
    //ゲームシーンにこのオブジェクトが存在するかを判定するもの
    public static AudioController m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            m_instance = this;
        }
    }
    private void Start()
    {
        SetMaster(m_startVolumeMaster);
        SetBGM(m_startVolumeBGM);
        SetSE(m_startVolumeSE);
    }

    private void Update()
    {
        if (Input.GetButtonDown(m_getButtonName))
        {
            m_canvas.gameObject.SetActive(!m_canvas.activeSelf);
        }
    }
    public void SetMaster(float volume)
    {
        m_audioMixer.SetFloat("Master", volume);
        m_startVolumeMaster = volume;
    }
    public void SetBGM(float volume)
    {
        m_audioMixer.SetFloat("BGM", volume);
        m_startVolumeBGM = volume;
    }
    public void SetSE(float volume)
    {
        m_audioMixer.SetFloat("SE", volume);
        m_startVolumeSE = volume;
    }
}
