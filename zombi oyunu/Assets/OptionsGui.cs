using UnityEngine;

using UnityEngine;
using System.Collections;

public class OptionsGui : MonoBehaviour
{
    [SerializeField]
    GUISkin _guiSkin;

    [SerializeField]
    Texture2D _title;

    [SerializeField]
    Texture2D _ok;

    [SerializeField]
    Texture2D _titleDifficulty;

    [SerializeField]
    Texture2D[] _difficulties;

    [SerializeField]
    Texture2D _titleSound;

    static int _selectedDifficulty = 0;

    static float _soundVolume = 1.0f;

    static bool _isOpen = false;
    static public bool IsOpen { get { return _isOpen; } }

    static public void Open()
    {
        _isOpen = true;
    }
    void Start()
     { 
         _selectedDifficulty = PlayerPrefs.GetInt("Difficulty", 1); 
         _soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f); 
     }
void OnGUI()
    {
        if (!_isOpen)
        {
            return;
        }

        GUI.skin = _guiSkin;

        GUI.Box(new Rect(15, 15, Screen.width - 30, Screen.height - 30), "");

        GUI.DrawTexture(new Rect(20, 20, _title.width, _title.height), _title);

        

        GUI.DrawTexture(new Rect(50, 150, _titleDifficulty.width,
                         _titleDifficulty.height), _titleDifficulty);

        _selectedDifficulty = GUI.SelectionGrid(new Rect(100, 250, 280, 400),
                              _selectedDifficulty, _difficulties, 1);
        PlayerPrefs.SetInt("Difficulty", _selectedDifficulty);

        GUI.DrawTexture(new Rect(440, 150, _titleSound.width, _titleSound.
                         height), _titleSound);

        _soundVolume = GUI.HorizontalSlider(new Rect(490, 250, Screen.width - 490 -
                       50, 20), _soundVolume, 0.0f, 1.0f);
        PlayerPrefs.SetFloat("SoundVolume", _soundVolume);

        if (GUI.Button(new Rect(Screen.width - 30 - _ok.width - 10, Screen.height - 30 - _ok.height
             - 10, _ok.width, _ok.height), _ok))
        {
            Close();
        }
    }

    void Close()
    {
        _isOpen = false;
    }
}