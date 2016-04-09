using UnityEngine;
using System.Collections;

public class AguacateCollider : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private AudioSource[] _audioSources;
    private AudioSource _friendSound;
    private AudioSource _enemySound;
    private AudioSource _guacsSound;
  
    private int _onionCounter = 0;
    private int _tomatoCounter= 0;

    //PUBLIC INSTANCE VARIABLES
    public GameController gameContoller;

	// Use this for initialization
	void Start () {
        // Initialize the audioSources array
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._enemySound = this._audioSources[1];
        this._friendSound = this._audioSources[2];
        this._guacsSound = this._audioSources[3];


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Enables Player Collission with friends and enemies
    public void OnTriggerEnter2D (Collider2D other)
    {
        if ((other.gameObject.CompareTag("Onion")) || (other.gameObject.CompareTag("Tomato")))
        {
            
            this.gameContoller.ScoreValue += 100;
            if (other.gameObject.CompareTag("Onion"))
                {
                _onionCounter = 1;
                }
            if (other.gameObject.CompareTag("Tomato"))
            {
                _tomatoCounter = 1;
            }

            if ((_onionCounter > 0) && (_tomatoCounter > 0) && (_tomatoCounter == _onionCounter))
            {
                this._friendSound.Play();
                this.gameContoller.GuacsValue++;
                _tomatoCounter = 0;
                _onionCounter = 0;
            }

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            this._enemySound.Play();
            this.gameContoller.LivesValue -= 1;

        }
    }

}

