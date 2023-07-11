using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using EToch = UnityEngine.InputSystem.EnhancedTouch;

public class Player : MonoBehaviour
{

    public static Action playerEnterArea;

    [SerializeField] private Camera mainCamera;

    private float borders = 2;
    [SerializeField]private int numberOfCubs = 1;
    private float scale = 0.2f;

    private string spawnTag = "Spawn";
    private string pickUpTag = "PickUp";
    private string wall = "Wall";

    private Finger currentFinger;

    private int NumberOfCubs
    {
        get { return numberOfCubs; }
        set 
        { 
            if(value <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                numberOfCubs = value;
            }
        }
    }


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        EToch.Touch.onFingerDown += OnFingerDown;
        EToch.Touch.onFingerMove += OnFingerMove;
        EToch.Touch.onFingerUp += OnFingerUp;
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Enable();
        EToch.Touch.onFingerDown -= OnFingerDown;
        EToch.Touch.onFingerMove -= OnFingerMove;
        EToch.Touch.onFingerUp -= OnFingerUp;
    }

    private void OnFingerDown(Finger finger)
    {
        if (currentFinger == null)
            currentFinger = finger;
    }

    private void OnFingerMove(Finger finger)
    {
        if(currentFinger == finger)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(finger.screenPosition.x,finger.screenPosition.y,10));
            float yPos = transform.position.y;
            float zPos = transform.position.z;
            float xPos = worldPosition.x;

            if (xPos <= borders && xPos >= -borders)
                transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    private void OnFingerUp(Finger finger)
    {
        if (finger == currentFinger)
            currentFinger = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(spawnTag))
        {
            playerEnterArea?.Invoke();
        }
        else if(other.gameObject.CompareTag(pickUpTag))
        {
            Destroy(other.gameObject);
            NumberOfCubs++;
        }
        else if(other.gameObject.CompareTag(wall))
        {
            NumberOfCubs -= (int)(other.gameObject.transform.localScale.y / scale);
        }
    }
}
