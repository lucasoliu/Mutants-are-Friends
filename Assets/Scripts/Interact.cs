using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour {

    public List<GameObject> inventory;
    public GameObject interactable;
    public GameObject canvas;

    // Audio Sources
    private AudioSource keyPickup;
    private AudioSource doorClose;
    private AudioSource lowkeyItemPickup;

    // Amount of time text stays on screen
    private WaitForSeconds textDuration = new WaitForSeconds(2f);

    // Amount of time for door close audio to play
    private WaitForSeconds doorCloseDuration = new WaitForSeconds(1.7f);

    private bool currentlyDisplayingText;

    protected void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        keyPickup = audioSources[0];
        doorClose = audioSources[1];
        lowkeyItemPickup = audioSources[2];

        currentlyDisplayingText = false;
        inventory = new List<GameObject>();
        interactable = null;
        canvas = GameObject.Find("Canvas");
    }

    protected void Update () {
        if (interactable != null && !currentlyDisplayingText
            && !(Utils.isClone(interactable.tag)
                 && interactable.GetComponent<Interact>().inventory.Count == 0
                 && Utils.isPlayer(gameObject.tag))
            && !(Utils.isClone(gameObject.tag) && inventory.Count == 0
                 && Utils.isPlayer(interactable.tag))) {
            // Activate prompt to interact with item
            canvas.transform.GetChild(6).gameObject.SetActive(true);
        } else {
            canvas.transform.GetChild(6).gameObject.SetActive(false);
        }
        if (inventory.Count != 0 && !gameObject.CompareTag(Utils.Player)) {
            canvas.transform.GetChild(7).gameObject.SetActive(true);
        } else {
            canvas.transform.GetChild(7).gameObject.SetActive(false);
        }

		if (Input.GetKeyDown(KeyCode.Space) && interactable != null)
        {
            if (Utils.isItem(interactable.tag))
            {
                inventory.Add(interactable);
                if (interactable.CompareTag(Utils.Device))
                {
                    StartCoroutine(displayText(canvas.transform.GetChild(1).gameObject));
                    lowkeyItemPickup.Play();
                } else if (interactable.CompareTag(Utils.DNA)) {
                    StartCoroutine(displayText(canvas.transform.GetChild(2).gameObject));
                    lowkeyItemPickup.Play();
                } else if (interactable.CompareTag(Utils.Key)) {
                    StartCoroutine(displayText(canvas.transform.GetChild(3).gameObject));
                    keyPickup.Play();
                }
                interactable.SetActive(false);
                interactable = null;
            }
            else if (interactable.CompareTag(Utils.Door) && Utils.isPlayer(gameObject.tag))
            {
                int keyIndex = Utils.containsItem(inventory, Utils.Key);
                if (keyIndex != -1) {
                    inventory.RemoveAt(keyIndex);
                    StartCoroutine(finishLevel());
                    StartCoroutine(displayText(canvas.transform.GetChild(5).gameObject));
                } else {
                    StartCoroutine(displayText(canvas.transform.GetChild(4).gameObject));
                }
            }
            else if (Utils.isClone(interactable.tag) && Utils.isPlayer(gameObject.tag))
            {
                Interact cloneScript = interactable.GetComponent<Interact>();
                List<GameObject> cloneInventory = cloneScript.inventory;
                if (cloneInventory.Count != 0) {
                    for (int i = 0; i < cloneInventory.Count; i++)
                    {
                        inventory.Add(cloneInventory[i]);
                    }
                    Destroy(interactable.gameObject);
                }
                //cloneScript.inventory = new List<GameObject>();
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

    private IEnumerator finishLevel()
    {
        doorClose.Play();
        yield return doorCloseDuration;

        // If we're going to the end screen, destroy musicPlayer
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            Destroy(GameObject.Find("MusicPlayer").gameObject);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator displayText(GameObject text)
    {
        text.SetActive(true);
        currentlyDisplayingText = true;
        yield return textDuration;
        text.SetActive(false);
        currentlyDisplayingText = false;
    }
}
