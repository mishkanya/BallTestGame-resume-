using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler
{
    private bool _pauseActive = false;
    private Image _buttonImage;
    
    void Start()
    {
        _buttonImage = GetComponent<Image>();
    }
    public void Paused(){
        if(_pauseActive == false)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;

        if(_pauseActive){
            _buttonImage.color = Color.white;
        }
        else
            _buttonImage.color = Color.gray;
        _pauseActive = !_pauseActive;
        if(_pauseActive){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Move();
        }
    }
    public void OnPointerDown (PointerEventData eventData){
        Paused();
    }
}
