using System;
using UnityEngine;
using Building;

[Serializable]
public class Command
{
	public CommandsEnum commandType;
	public Vector3 commandVectorValue;
	public BuildingInfo commandBuildingValue;

	public Command(CommandsEnum commandType, Vector3 commandVectorValue)
	{
		this.commandType = commandType;
		this.commandVectorValue = commandVectorValue;
	}

	public Command(CommandsEnum commandType, Vector3 commandVectorValue, BuildingInfo commandBuildingValue) : this(commandType, commandVectorValue)
	{
		this.commandBuildingValue = commandBuildingValue;
	}
}