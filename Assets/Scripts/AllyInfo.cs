using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ally Info", menuName = "Allies", order = 52)]
public class AllyInfo : ScriptableObject
{
	public string AllyName;
	public Sprite AllyImage;
	public GameObject AllyPrefab;
	public List<CommandsEnum> AvailableCommand = new List<CommandsEnum>() { CommandsEnum.GoTo };
	public Cost AllyCost;
}
