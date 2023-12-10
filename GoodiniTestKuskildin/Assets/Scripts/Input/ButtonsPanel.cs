using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonsPanel : MonoBehaviour
{
    [SerializeField] private Button[] _houseButtons;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera[] _cinamechineCams;

    private CinemachineVirtualCamera _currentFocusedCamera;
    public void Initialize()
    {
        _houseButtons[0].onClick.AddListener(delegate { FocusOnCam(_cinamechineCams[0]);});
        _houseButtons[1].onClick.AddListener(delegate { FocusOnCam(_cinamechineCams[1]); });
        _houseButtons[2].onClick.AddListener(delegate { FocusOnCam(_cinamechineCams[2]); });
        _houseButtons[3].onClick.AddListener(delegate { FocusOnCam(_cinamechineCams[3]); });
        _currentFocusedCamera = _mainCamera;
    }

    private void FocusOnCam(CinemachineVirtualCamera camera)
    {
        if (_currentFocusedCamera != camera && _currentFocusedCamera != _mainCamera)
        {
            _currentFocusedCamera.Priority = 1;
        }

        _currentFocusedCamera = camera;

        if(_currentFocusedCamera.Priority == 1)
        {
            _currentFocusedCamera.Priority = 3;
        }
        else if(_currentFocusedCamera.Priority > 1)
        {           
            EndFocusCam();
        }
    }

    private void EndFocusCam()
    {
        _currentFocusedCamera.Priority = 1;
        _currentFocusedCamera = _mainCamera;
    }

}
