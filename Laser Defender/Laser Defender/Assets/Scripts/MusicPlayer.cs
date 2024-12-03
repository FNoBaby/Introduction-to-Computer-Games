using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake(){
        if(FindObjectsOfType<MusicPlayer>().Length > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
