using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

//Adapted from Tarodev's wonderful video tutorial "Drag and Drop in Unity - 2021 Tutorial"

public class SlideController : MonoBehaviour
{
    private float _yOffset;
    private float _zOffset;
    private Vector3 _dragOffset;

    private Camera _mainCam;


    private void Awake()
    {
        _yOffset = transform.position.y;
        _zOffset = transform.position.z;
        _mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        _dragOffset = transform.position - GetCursorHorizonPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetCursorHorizonPos() + _dragOffset;
    }

    //Gets Both X/Y position for mouse click move.
    Vector3 GetCursorPos()
    {
        Vector3 _cursorPos = _mainCam.ScreenToWorldPoint(Input.mousePosition); 
        _cursorPos.z = _zOffset;
        return _cursorPos;

    }

    //Uses the X axis position of the mouse to move the object.
    Vector3 GetCursorHorizonPos()
    {
        Vector3 _cursorPos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        _cursorPos.y = _yOffset; 
        _cursorPos.z = _zOffset;
        return _cursorPos;
    }
}
