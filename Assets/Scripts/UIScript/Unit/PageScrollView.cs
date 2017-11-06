using UnityEngine;

public class PageScrollView : MonoBehaviour
{
    private Camera _camera;
    private RectTransform _contentParent;
    private float[] _contentPosXArray;
    private float _clickStartPosX = 0;
    private int _currentContentIndex = 0;
    private Vector2 _targetVector;
    private float clickMinDistanceToScroll = 0.5f;
    private float _contentSizePosX = 0;
    private bool isMoved = false;
    private bool isLerp = false;

    private float _contentsDistance;
    private int _contentCount;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _contentSizePosX = _camera.ScreenToWorldPoint(Input.mousePosition).x - _contentParent.localPosition.x ;
            _clickStartPosX = _camera.ScreenToWorldPoint(Input.mousePosition).x;
            isMoved = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isMoved)
            {
                SetEndPosition();
                isLerp = true;
            }

            isMoved = false;
        }

        if (isMoved)
        {
            MoveContent();
        }
        else if (isLerp)
        {
            LerpContent();
        }
    }

    public void Init(int Distance, int count)
    {
        _contentsDistance = Distance;
        _contentCount = count;

        _contentParent = transform.GetChild(0).GetComponent<RectTransform>();
        _contentPosXArray = new float[_contentCount];

        LocationContents();
        _camera = UIManager.i.UICamera;
    }

    private void LocationContents()
    {
        float posX = 0;
        for (int i = 0; i < _contentCount; i++)
        {
            _contentPosXArray[i] = -posX;
            _contentParent.GetChild(i).localPosition = new Vector2(posX, 0);

            posX += _contentsDistance;
        }
    }

    private void SetEndPosition()
    {
        if ((_clickStartPosX - _camera.ScreenToWorldPoint(Input.mousePosition).x) < -clickMinDistanceToScroll)
        {
            if (_currentContentIndex > 0)
                _currentContentIndex--;
        }
        else if ((_clickStartPosX - _camera.ScreenToWorldPoint(Input.mousePosition).x) > clickMinDistanceToScroll)
        {
            if (_currentContentIndex < _contentCount-1)
                _currentContentIndex++;
        }

        _targetVector.x = _contentPosXArray[_currentContentIndex];
    }

    private void MoveContent()
    {
        Vector2 targetPos = new Vector2();

        targetPos.x = _camera.ScreenToWorldPoint(Input.mousePosition).x - _contentSizePosX;
       _contentParent.localPosition = targetPos;
    }

    private void LerpContent()
    {
        Vector2 targetPos = new Vector2();

        targetPos.x = Mathf.Lerp(_contentParent.localPosition.x, _targetVector.x, Time.deltaTime + 0.05f);

        _contentParent.localPosition = targetPos;

        if (Mathf.Abs(_targetVector.x - _contentParent.localPosition.x) < 1)
        {
            isLerp = false;
            _contentParent.localPosition = _targetVector;
        }

    }
}
