using UnityEngine;
using System.Collections;

//Aguacate is avocado in spanish
public class AguacateController : MonoBehaviour {
    //PUBLIC INSTANCE VARIABLES
    public float speed = 4f;


    //PRIVATE INSTANCE VARIABLE
    private float _playerInput;
    private Transform _transform;
    private Vector2 _currentPosition;
    // Use this for initialization
    void Start () {

        this._transform = gameObject.GetComponent<Transform> ();
	}

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._playerInput = Input.GetAxis("Vertical");

        //if input is positive move up
        if (this._playerInput > 0)
        {
            this._currentPosition += new Vector2(0, this.speed);

        }

        //if input is negative move down
        if (this._playerInput < 0)
        {
            this._currentPosition -= new Vector2(0, this.speed);

        }

        this._checkBounds();
        this._transform.position = this._currentPosition;
    }


        //PRIVATE METHODS

        //check if the Aguacate is going out of bounds and keep it within the tiles

        private void _checkBounds()
    { 
        if (this._currentPosition.y < -170)
        {
            this._currentPosition.y = -170;
        }

        if (this._currentPosition.y > 170)
        {
            this._currentPosition.y = 170;
        }
    }
}

