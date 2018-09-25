using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClones : Interact {

	public GameObject bird;
	public float cloneLifeSpan = 100;
    public int numInventorySlots = 5;
    public Sprite emptySlotSprite;

    private List<Image> inventorySlotImages;

	new void Start() {
        base.Start();
        inventorySlotImages = new List<Image>();
        
        for (int i = 0; i < 5; i++) {
			inventorySlotImages.Add(GameObject.Find("Canvas")
			                        .transform.GetChild(0).GetChild(i).GetComponent<Image>());
        }
	}

	// Update is called once per frame
	new void Update () {
		base.Update();

        // Spawn a birb
		if (Input.GetKeyDown(KeyCode.Alpha1)
        && Utils.containsItem(inventory, Utils.DNA) != -1
		&& Utils.containsItem(inventory, Utils.Device) != -1) {
			inventory.RemoveAt(Utils.containsItem(inventory, Utils.DNA));
			GameObject birb = Instantiate(bird, transform.position, Quaternion.identity);
			Destroy(birb, cloneLifeSpan);
            updateInventoryGUI();
		}
        updateInventoryGUI();
	}

    protected void updateInventoryGUI()
    {
        for (int i = 0; i < numInventorySlots; i++)
        {
            if (i < inventory.Count) {
                inventorySlotImages[i].sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;
            } else {
                inventorySlotImages[i].sprite = emptySlotSprite;
            }

        }

    }

}
