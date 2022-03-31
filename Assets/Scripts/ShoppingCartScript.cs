using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartScript : MonoBehaviour
{

    public Transform PlayerHoldingPosObj;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    private void OnMouseDown()
    {
        if (inRange == true)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.position = PlayerHoldingPosObj.position;
            this.transform.rotation = PlayerHoldingPosObj.rotation;
            this.transform.parent = PlayerHoldingPosObj.parent;
        }
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
