using System;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.1f;

    private Camera _cam;
    private Material _material;
    private Vector3 _startPos;
    private bool _canScroll = true;

    private void Start()
    {
        _cam = Camera.main;
        _material = GetComponent<Renderer>().material;
    }


    private void Update()
    {
        if (!_canScroll) return;
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                _startPos = _cam.ScreenToWorldPoint(touch.position);
                _startPos.z = 0;
                break;
            case TouchPhase.Moved:
            {
                var pos = _cam.ScreenToWorldPoint(touch.position);
                pos.z = 0;
                var verticalDiff = _startPos.y - pos.y;
                _material.mainTextureOffset += new Vector2(0, verticalDiff * scrollSpeed);
                _startPos = pos;
                break;
            }
        }
    }

    public void SetCanScroll(bool canScroll)
    {
        _canScroll = canScroll;
    }
}