using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
	#region Variables
	public int baseValue;   // Starting value

	// Keep a list of all the modifiers on this stat
	private List<int> modifiers = new List<int>();
	#endregion

	#region Methods
	public int GetValue()
	{
		int finalValue = baseValue;
		modifiers.ForEach(x => finalValue += x);
		return finalValue;
	}

	// Add a new modifier to the list
	public void AddModifier(int modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	// Remove a modifier from the list
	public void RemoveModifier(int modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}


	#endregion
}
