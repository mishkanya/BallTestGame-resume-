using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : RestarGame, IPointerDownHandler
{
    public void OnPointerDown (PointerEventData eventData){
        ReloadScene();
    }
}
