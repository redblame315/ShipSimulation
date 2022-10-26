//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// A UI script that keeps an eye on the slot in character equipment.
/// </summary>

[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot
{
	public InvEquipment equipment;
	public InvBaseItem.Slot slot;

	override protected InvGameItem observedItem
	{
		get
		{
			return (equipment != null) ? equipment.GetItem(slot) : null;
		}
	}

	/// <summary>
	/// Replace the observed item with the specified value. Should return the item that was replaced.
	/// </summary>

	override protected InvGameItem Replace (InvGameItem item)
	{
		/*if (item == null)
		{
			int index = slot == InvBaseItem.Slot.Bracers ? 0 : 1;
			GameManager.instance.playerInfo.itemState[index] = 0;

			if (slot == InvBaseItem.Slot.Bracers)
				GameManager.instance.playerInfo.strength--;
			else
				GameManager.instance.playerInfo.dodge--;

			GameManager.instance.playerInfo.Save();
			MainScreen.instance.UpdatePlayerInfoUI();
		}*/
		return (equipment != null) ? equipment.Replace(slot, item) : item;
	}
}