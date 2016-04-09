/*
Source File Name: MeetTheGuaca.CSharp
Author's Name: Beymig Munoz Martinez
Last Modified by: Beymig Munoz Martinez
Date Last Modified: February 5th, 2016
Program Description: Guacamole! the Game has a Aguacate (avocado) main player 
who is trying to find her ingredients friends (tomato and onion) to make Guacamole!
Aguacate gets points each time he collides with his friends. Aguacate's enemies are
the evil clock and the evil flame because they have the power to rotten Aguacate 
and Guacamole!. Each time Aguacate collides with his enemies he losses lives.
Revision History: 
- Create Background with Scrolling Function (January 31th,2016)
- Create Aguacate/Player game object (January 31th, 2016)
- Create Onion and Tomato game object (January 31th,2016)
- Create Evil Clock and Evil Frame Prefabs (February 4th, 2016)
- Add Enemies as prefabs and create Game Controller (February 4th, 2016)
- Add Polygon Collider to Player, Friends and Enemies (February 4th, 2016)
- Add Collision and Audio features (February 4th, 2016)
- Add Scoreboard (February 4th, 2016)
- Add Game Over features and Restart Button (February 5th,2016)
- Add Internal Documentation (February 5th, 2016)
- Change EvilClock Controller and Game Controller to avoid interpolation. Adjust Game Over Scene GUI.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;
    private int _guacsValue;
    private Vector2 _evilClockPosition1;
    private Vector2 _evilClockPosition2;
    Vector2 _evilClockSize = new Vector2(122,122);


    //PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
            
        }
        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;

        }
    }
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }
        set
        {
            this._livesValue = value;
            if (this._livesValue <=0)
            {
                _endGame();
            }
            else
            { 
            this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }
    public int GuacsValue
    {
        get
        {
            return this._guacsValue;
        }
        set
        {
            this._guacsValue = value;
            if (this._guacsValue >= 5)
            {
                this.GuacsLabel.text = "Guacs: " + this._guacsValue + "/5";
                this.YourScoreLabel.text = "Your Score: " + this._scoreValue;
                this.FinishedLevelLabel.enabled = true;
                this.YourScoreLabel.enabled = true;
                this.aguacate.gameObject.SetActive(false);
                this.onion.gameObject.SetActive(false);
                this.tomato.gameObject.SetActive(false);
                this.ScoreLabel.enabled = false;
                this.RestartButton.gameObject.SetActive(true);
            }
            else
            {
                this.GuacsLabel.text = "Guacs: " + this._guacsValue + "/5";
            }
        }
    }


    //PUBLIC INSTANCE VARIABLES
    public int evilClockNumber = 4;
    public int evilFlameNumber = 2;
    public EvilClockController evilClock;
    public EvilFlameController evilFlame;
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text GuacsLabel;
    public Text FinishedLevelLabel;
    public AguacateController aguacate;
    public TomatoController tomato;
    public OnionControler onion;
    public Text YourScoreLabel;
    public AudioSource gameOverSound;
    public Button RestartButton;


    // Use this for initialization
    void Start () {
        this._initialize();
        //feature to instantiate the Evil Clocks
        for (int clockCount = 0; clockCount < this.evilClockNumber; clockCount++)
        {
            //to make sure the EvilClock prefabs won't be instantiaded in the same place
            if (clockCount == 0)
            {
                Instantiate(evilClock.gameObject);
                _evilClockPosition1 = evilClock._currentPosition;
                
            }
            else
            {
                
                _evilClockPosition2 = evilClock._currentPosition;
                if (((_evilClockPosition1.y - _evilClockPosition2.y) > 150 || (_evilClockPosition1.x - _evilClockPosition2.x) > 150))
                {
                    Instantiate(evilClock.gameObject);
                }
            }
            
        }

        //feature to instantiate the Evil Flames
        for (int flameCount = 0; flameCount < this.evilFlameNumber; flameCount++)
        {
            
            Instantiate(evilFlame.gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
	
	}

    //PRIVATE METHODS
    private void _initialize()
    {
        //keep the player score
        this.ScoreValue = 0;
        //keep the guacs score
        this.GuacsValue = 0;
        //keep the player's number of lives
        this.LivesValue = 5;
        //holds the game over label
        this.GameOverLabel.enabled = false;
        //holds the finished level label
        this.FinishedLevelLabel.enabled = false;
        //holds the final score
        this.YourScoreLabel.enabled = false;
        //button to restart the game 
        this.RestartButton.gameObject.SetActive(false);
    }

    private void _endGame()
    {
        this.YourScoreLabel.text = "Your Score: " + this._scoreValue;
        this.GameOverLabel.enabled = true;
        this.YourScoreLabel.enabled = true;
        this.aguacate.gameObject.SetActive(false);
        this.onion.gameObject.SetActive(false);
        this.tomato.gameObject.SetActive(false);
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.GuacsLabel.enabled = false;
        this.gameOverSound.Play();
        this.RestartButton.gameObject.SetActive(true);
       
    }

    //PUBLIC METHODS
    //Reloads the main scene que the restart button is clicked
    public void RestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

}


