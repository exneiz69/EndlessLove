using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _rawImage;
    private float _imagePositionX;

    #region MonoBehaviour

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _imagePositionX = _rawImage.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;
        if (_imagePositionX >= 1)
        {
            _imagePositionX = 0;
        }

        _rawImage.uvRect = new Rect(_imagePositionX, _rawImage.uvRect.y, _rawImage.uvRect.width, _rawImage.uvRect.height);
    }

    #endregion
}
