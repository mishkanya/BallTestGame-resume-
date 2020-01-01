using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public class SceneRestarter : RestarGame
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player"){
            ReloadScene();
        }
    }
}
