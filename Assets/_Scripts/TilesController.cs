using UnityEngine;
using System.Collections;

public class TilesController : MonoBehaviour {
    //PUBLIC INSTANCE VARIABLE
    public float speed = 4f;
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;
	// Use this for initialization
	void Start () {
        //Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform> ();

        //Reset the tiles sprite to the beginning
        this.Reset();
	}
	
	// Update is called once per frame
	void Update () {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2 (this.speed,0);
        this._transform.position = this._currentPosition;
        if(this._currentPosition.x <= -193)
        {
            this.Reset();

        }
	
	}
    //reset the tiles background when it is out of the screen
    public void Reset ()
    {
        this._transform.position = new Vector2(193f, 0);

    }
}
