using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text outputText; 

    public float rangeSwipe;
    
    private string  _DirectionSwipe;
    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private bool _stopTouch = false;
    // Update is called once per frame
    void Update()
    {
        Swipe();
    }
    public void Swipe()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            _startPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
        {
            _currentPosition = Input.GetTouch(0).position;
            // Initialization distance swipe
            Vector2 Distance = _currentPosition - _startPosition; 
            // Check direction of swipe
                if(!_stopTouch)
                {
                    // Axis X
                    if(Distance.x > rangeSwipe)
                    {
                        _DirectionSwipe = "Right";
                    }
                    else if(Distance.x < -rangeSwipe)
                    {
                        _DirectionSwipe = "Left";
                    }
                    // Axis Y
                    else if(Distance.y > rangeSwipe)
                    {
                        _DirectionSwipe = "Up";
                    }
                    else if(Distance.y < -rangeSwipe)
                    {
                        _DirectionSwipe = "Down";
                    }
                    outputText.text = _DirectionSwipe;
                    _stopTouch = true;
                }
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended )
        {
            _stopTouch = false;
        }
    }
}
