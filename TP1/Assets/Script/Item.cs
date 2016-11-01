using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour
{
	public enum ItemType {MINERAL, WATER, SEED}

    public ItemType type;

    public Sprite spriteNeutral;

    public Sprite spriteHighlighted;

    public int maxSize;
    
    public void Use()
    {
        switch(type)
        {
            case ItemType.WATER:
                break;
            case ItemType.MINERAL:
                break;
            case ItemType.SEED:
                break;

        }
    }

	public ItemType getType(){
		return type;
	}
}
