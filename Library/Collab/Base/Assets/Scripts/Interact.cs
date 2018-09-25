using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public List<GameObject> inventory;
    public GameObject interactable;
    public GameObject canvas;
    /*public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;*/


    /*
    private Component slot1Img;
    private Component slot2Img;
    private Component slot3Img;
    private Component slot4Img;
    private Component slot5Img;*/

    protected void Start () {
        inventory = new List<GameObject>();
        interactable = null;
        canvas = GameObject.Find("Canvas");

        /*
        slot1Img = slot1.GetComponent<Image>();
        slot2Img = slot2.GetComponent<Image>();
        slot3Img = slot3.GetComponent<Image>();
        slot4Img = slot4.GetComponent<Image>();
        slot5Img = slot5.GetComponent<Image>();*/


        //Debug.Log(GameObject.Find("Canvas").GetChild(0));
        /*
        slots = GameObject.Find("Canvas").GetComponentsInChildren<Slot>();
        foreach (Transform child in GameObject.Find("Canvas").GetChild(0)) {
            Debug.Log(child);
        }
        */
    }

    protected void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && interactable != null)
        {
            if (Utils.isItem(interactable.tag))
            {
                inventory.Add(interactable);
                if (interactable.CompareTag(Utils.Device))
                {
                    canvas.transform.GetChild(1).gameObject.SetActive(true);
                } else if (interactable.CompareTag(Utils.DNA)) {
                    canvas.transform.GetChild(2).gameObject.SetActive(true);
                } else if (interactable.CompareTag(Utils.Key)) {
                    canvas.transform.GetChild(3).gameObject.SetActive(true);
                }
                interactable.SetActive(false);
                interactable = null;
            }
            else if (interactable.CompareTag(Utils.Door) && Utils.isPlayer(gameObject.tag))
            {
                int keyIndex = Utils.containsItem(inventory, Utils.Key);
                if (keyIndex != -1) {
                    inventory.RemoveAt(keyIndex);
                    canvas.transform.GetChild(5).gameObject.SetActive(true);
                } else {
                    canvas.transform.GetChild(4).gameObject.SetActive(true);
                }
            }
            else if (Utils.isClone(interactable.tag) && Utils.isPlayer(gameObject.tag))
            {
                Debug.Log("Clone and Player");
                Interact cloneScript = interactable.GetComponent<Interact>();
                Debug.Log(cloneScript);
                List<GameObject> cloneInventory = cloneScript.inventory;
                for (int i = 0; i < cloneInventory.Count; i++) {
                    inventory.Add(cloneInventory[i]);
                }
                cloneScript.inventory = new List<GameObject>();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactable = null;
    }
}
