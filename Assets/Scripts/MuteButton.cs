using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Sprite[] muteSprites;

    private bool _isMute = false;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        var spriteIndex = PlayerPrefs.GetInt("isMute", 0); // 0 is not muted
        _isMute = (spriteIndex == 1);
        _image.sprite = muteSprites[spriteIndex];
    }

    public void ChangeMuteStatus()
    {
        _isMute = !_isMute;
        var spriteIndex = _isMute ? 1 : 0;
        _image.sprite = muteSprites[spriteIndex];
        PlayerPrefs.SetInt("isMute", spriteIndex);
    }
}