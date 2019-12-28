using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankSpawner : MonoBehaviour
{
    public GameObject[] Chancks;
    public GameObject StartChank;
    private List<GameObject> _sceneChanks = new List<GameObject>();
    private const float _distanceForSpawnAndRemoveChanks = 7;
    private void Start()
    {
        _sceneChanks.Add(StartChank);
    }

    private void Update()
    {
        if(transform.position.z + _distanceForSpawnAndRemoveChanks > _sceneChanks[_sceneChanks.Count - 1].transform.position.z){
            SpawnChanck();
        }
    }
    private void SpawnChanck()
    {
        GameObject newChanck = Instantiate(Chancks[Random.Range(0,Chancks.Length)]);
        newChanck.transform.position = _sceneChanks[_sceneChanks.Count - 1].transform.FindChild("ChankEnd").position - newChanck.transform.FindChild("ChankStart").transform.position;
        _sceneChanks.Add(newChanck);
        DeleteChanck();
    } 
    private void DeleteChanck()
    {
        if(_sceneChanks[0].transform.position.z + _distanceForSpawnAndRemoveChanks < transform.position.z ){
            Destroy(_sceneChanks[0]);
            _sceneChanks.RemoveAt(0);
        }
    } 
     
}
