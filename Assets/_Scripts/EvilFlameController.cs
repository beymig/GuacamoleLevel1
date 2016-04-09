using UnityEngine;
using System.Collections;

public class EvilFlameController : MonoBehaviour {

    public float minSpeed = 4f;
    public float maxSpeed = 8f;
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;
    // Use this for initialization
    void Start()
    {
        //Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();

        //Reset the evilFlame sprite to the beginning
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(Random.Range(this.minSpeed, this.maxSpeed),0);
        this._transform.position = this._currentPosition;
        if (this._currentPosition.x <= -640)
        {
            this.Reset();

        }

    }
    //reset the evil flame when it is out of the screen
    public void Reset()
    {
        float yPosition = Random.Range(-180f, 180f);
        this._transform.position = new Vector2(640f, yPosition);

    }
}
