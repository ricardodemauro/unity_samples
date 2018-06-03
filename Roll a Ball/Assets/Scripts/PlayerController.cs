using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const string VERTICAL_AXIS = "Vertical";
    private const string HORIZONTAL_AXIS = "Horizontal";

    private const string PICK_UP_TAG = "Pick Up";

    private const float Y_FORCE_DEFAULT = 0.0f;
    private Rigidbody _rigidBody;

    public float Speed;

    private int _count;

    public Text CountText;
    public Text WinText;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = "";
    }

    private void FixedUpdate()
    {
        if (_rigidBody == null)
            return;

        float moveHorizontal = Input.GetAxis(HORIZONTAL_AXIS);
        float moveVertical = Input.GetAxis(VERTICAL_AXIS);

        Vector3 movement = new Vector3(moveHorizontal, Y_FORCE_DEFAULT, moveVertical);

        _rigidBody.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag(PICK_UP_TAG))
        {
            other.gameObject.SetActive(false);
            _count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        CountText.text = "Count: " + _count.ToString();
        if(_count >= 12)
        {
            WinText.text = "You win";
        }
    }
}
