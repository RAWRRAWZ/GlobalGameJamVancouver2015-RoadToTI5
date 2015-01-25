using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour 
{
    private static SoundManager _instance;
	public SoundGroup[] SoundGroups;
	public Dictionary <string, SoundGroup> items;
 
	public SoundGroup currentMusic;
	
	public float SFXVolume=1;
	public float MusicVolume=1;
	
	bool NoSound=false;
	
    public static SoundManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();
 
				if(!_instance) {
					GameObject singleton = new GameObject();
					singleton.name="SoundManager";
					_instance = singleton.AddComponent<SoundManager>();
				}
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
 
            return _instance;
        }
    }
 
    void Awake() 
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this != _instance)
                Destroy(this.gameObject);
        }
        PickPlayerPrefsVolume();
        SoundGroups = null;
        SoundGroups = Resources.LoadAll<SoundGroup>("SoundGroups");
        
        if(GameObject.Find("NoSoundPlease")!=null)
    		NoSound=true;
    		
        items = new Dictionary<string, SoundGroup> ();
        
        for (int i = 0; i < SoundGroups.Length; i++) {
        	SoundGroup Snd;
        	if (items.TryGetValue(SoundGroups[i].gameObject.name, out Snd)) {
	        	//Debug.Log("Soundgroup already exists "+SoundGroups[i].gameObject.name);
        	} else {
        		items.Add (SoundGroups[i].gameObject.name,SoundGroups[i]);
	        	SoundGroups[i].CreatePool();
        	}
        }
        Play(Application.loadedLevelName);
    }
    
    void PickPlayerPrefsVolume() {
        MusicVolume = PlayerPrefs.GetFloat("music volume",1);
        SFXVolume = PlayerPrefs.GetFloat("sfx volume",1);
    }
    
    void OnLevelWasLoaded() {
        PickPlayerPrefsVolume();
    	for (int i = 0; i < SoundGroups.Length; i++) {
        	SoundGroups[i].CreatePool();
        }
        Play(Application.loadedLevelName);
    }
 
    public void Play(string sndName, Vector3 pos)
    {
    	if(NoSound)
    		return;
    	if(sndName==null)
    		return;
    	if(sndName.Length<1)
    		return;
    	SoundGroup SndToPlay = null;
    	if (items.TryGetValue(sndName, out SndToPlay)) {
    		SoundGroup thisSound = SndToPlay.Spawn(pos);
    		if(thisSound.Music) {
    			currentMusic=thisSound;
    			thisSound.name = "_Music_"+SndToPlay.name;
    		}
    		else {
    			thisSound.name = "_SFX_"+SndToPlay.name;
    		}
		} else {
			Debug.Log("SoundManagerGroup "+sndName+" was not found");
		}
    }
    
    public void Play(string sndName) {
    	Play(sndName,Vector3.zero);
    	return;
    }
    
    public void PlayMusic(string sndName) {
    	if(currentMusic)
    		currentMusic.ForceStop();
    	Play(sndName,Vector3.zero);
    	return;
    }
    
    public void Init() {
    	//Debug.Log("SoundManager Initialized");
    }

}