using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //音量設定を行うCanvasを入れる
    [SerializeField] GameObject _canvas = default;
    //AudioMixerを設定
    [SerializeField] AudioMixer _audioMixer = default;
    //どのボタンを押したときに設定画面を出すか
    [SerializeField] string _getButtonName = " ";
    //ゲーム開始時の音量
<<<<<<< HEAD
    float _startVolumeMaster = -15f;
    float _startVolumeBGM = -15f;
    float _startVolumeSE = -15f;
=======
    static float m_startVolumeMaster = -15f;
    static float m_startVolumeBGM = -15f;
    static float m_startVolumeSE = -15f;
>>>>>>> cc71c2b1aae7f91e3b554ba19029e1c6d0cc0cf6
    //ゲームシーンにこのオブジェクトが存在するかを判定するもの
    public static AudioController _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }
    private void Start()
    {
        SetMaster(_startVolumeMaster);
        SetBGM(_startVolumeBGM);
        SetSE(_startVolumeSE);
    }

    private void Update()
    {
        if (Input.GetButtonDown(_getButtonName))
        {
            _canvas.gameObject.SetActive(!_canvas.activeSelf);
        }
    }
    public void SetMaster(float volume)
    {
        _audioMixer.SetFloat("Master", volume);
        _startVolumeMaster = volume;
    }
    public void SetBGM(float volume)
    {
        _audioMixer.SetFloat("BGM", volume);
        _startVolumeBGM = volume;
    }
    public void SetSE(float volume)
    {
        _audioMixer.SetFloat("SE", volume);
        _startVolumeSE = volume;
    }
}
