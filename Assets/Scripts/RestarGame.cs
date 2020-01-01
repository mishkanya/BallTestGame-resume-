using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public abstract class RestarGame : MonoBehaviour
{
    private const string _gameID = "3413732";
    protected const string _adsContentType = "3413732";
    protected ShowAdPlacementContent ad;

    private PlayerScript _player;
    
    private void Start()
    {
        if(Monetization.isSupported && Monetization.isInitialized == false)
            Monetization.Initialize(_gameID,false);

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    protected void ReloadScene()
    {

        if(Monetization.IsReady(_adsContentType))
        {
            ShowAdCallbacks Options = new ShowAdCallbacks();
            ad = Monetization.GetPlacementContent(_adsContentType) as ShowAdPlacementContent;
            if(Random.value > 0.3f)
                ad.Show(Options);
        }
        if(Monetization.isInitialized == false || Monetization.isSupported == false || Monetization.IsReady(_adsContentType) == false){
            Reload();
        }
    }
    void Update()
    {
        if(ad != null && !ad.showing)
            Reload();
    }
    private void Reload(){
        PlayerPrefs.SetFloat("LastScore", _player.Score);
        if(PlayerPrefs.GetFloat("BestScore") < _player.Score)
            PlayerPrefs.SetFloat("BestScore",_player.Score);
        SceneManager.LoadScene(0);
    }
}
