using UnityEngine;
using System.Collections;

public class EvilClockController : MonoBehaviour {

    //PUBLIC INSTANCE VARIABLES
    public float minSpeed = 8f;
    public float maxSpeed = 12f;
    public Vector2 _currentPosition;
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    
    
    // Use this for initialization
    void Start()
    {
        //Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();

        //Reset the evilClock sprite to the beginning
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(Random.Range(this.minSpeed, this.maxSpeed), 0);
        this._transform.position = this._currentPosition;
        if (this._currentPosition.x <= -940)
        {
            this.Reset();

        }

    }
    //reset the evil clock when it is out of the screen
    public void Reset()
    {
        float yPosition = Random.Range(-180f, 180f);
        this._transform.position = new Vector2(940f, yPosition);

    }
}
