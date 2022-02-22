using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private GameObject selectedPlayer;
    private Plane planeOfMovement;
    private float selectedTime;

    private float MAX_SPEED = 100;
    private float MAX_TIME = 0.8F;
    // Start is called before the first frame update
    void Start()
    {
        selectedPlayer = null;
        setKeepersColor();
        GameObject field = GameObject.Find("Field");
        float playerHeight = GameObject.Find("Home0").transform.position.y;
        Vector3 pointOnPlane =  new Vector3(field.transform.position.x, playerHeight, field.transform.position.z);
        planeOfMovement = new Plane(Vector3.up, pointOnPlane);
    }

    void setKeepersColor(){
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", Color.yellow);
        List<GameObject> keepers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Keeper"));
        foreach(GameObject keeper in keepers)
        {
            keeper.gameObject.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0) )
                HandleTouch(Input.mousePosition, TouchPhase.Began);
            if (Input.GetMouseButton(0) )
                HandleTouch(Input.mousePosition, TouchPhase.Moved);
            if (Input.GetMouseButtonUp(0) )
                HandleTouch(Input.mousePosition, TouchPhase.Ended);
        }
        else
        {
            Touch touch = Input.GetTouch(0);
            HandleTouch(touch.position, touch.phase);
        }

        if(selectedPlayer != null)
            changeSelectedPlayerColor();
	}

    private void HandleTouch(Vector3 touchPosition, TouchPhase touchPhase)
    {
        switch(touchPhase)
        {
            case TouchPhase.Began:
                getSelectedPlayer(touchPosition);
                break;
            case TouchPhase.Moved:
                if(selectedPlayer == null)
                    getSelectedPlayer(touchPosition);
                break;
            case TouchPhase.Ended:
                if(selectedPlayer != null)
                {
                    moveSelectedPlayer(touchPosition);
                    resetSelectedPlayer();
                }
                break;
        }
    }

    private void getSelectedPlayer(Vector3 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay( touchPosition );
        RaycastHit hit;
        int playerMask = (1 << 6) ^ (1 << 8); // PlayerHome or KeeperHome
        if(Physics.Raycast(ray, out hit, 500, playerMask))
        {
            selectedPlayer = hit.transform.gameObject;
            selectedTime = Time.time;
        }
    }

    private void moveSelectedPlayer(Vector3 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay( touchPosition );
        float enter = 0.0f;
        if(planeOfMovement.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 velocityDirection = (hitPoint - selectedPlayer.transform.position).normalized;
            float deltaTime = Time.time - selectedTime;
            float velocityModulus = MAX_SPEED * (Mathf.Min(deltaTime, MAX_TIME) / MAX_TIME);
            Vector3 newVelocity = velocityModulus * velocityDirection;
            selectedPlayer.GetComponent<Rigidbody>().velocity = newVelocity;
        }
    }

    private void changeSelectedPlayerColor(){
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        float deltaTime = Time.time - selectedTime;
        Color newColor;
        if(selectedPlayer.gameObject.tag == "Keeper")
            newColor = Color.yellow + (Color.red - Color.yellow) * (Mathf.Min(deltaTime, MAX_TIME) / MAX_TIME);
        else
            newColor = Color.red * (Mathf.Min(deltaTime, MAX_TIME) / MAX_TIME);

        propertyBlock.SetColor("_Color", newColor);
        selectedPlayer.gameObject.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    }

    public void resetSelectedPlayer()
    {
        resetSelectedPlayerColor();
        selectedPlayer = null;
    }

    private void resetSelectedPlayerColor(){
        Color newColor = Color.black;
        if(selectedPlayer.tag == "Keeper")
            newColor = Color.yellow;
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", newColor);
        selectedPlayer.gameObject.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    }
}
