using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CrystalPlaybackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayableDirector>().time = Random.Range(0, 166f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
