using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public abstract class RestarGame : MonoBehaviour
{
    private const string _gameID = "3413732";
    protected const string _adsContentType = "rewardedVideo";
    protected ShowAdPlacementContent ad;
    
    private void Start()
    {
        if(Monetization.isSupported && Monetization.isInitialized == false)
            Monetization.Initialize(_gameID,true);
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
            SceneManager.LoadScene(0);
        }
    }
    void Update()
    {
        if(ad != null && !ad.showing)
            SceneManager.LoadScene(0);
    }
}
