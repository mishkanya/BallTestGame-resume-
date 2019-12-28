using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider col){
        if(col.tag == "Player")
            SceneManager.LoadScene(0);
    }
}
