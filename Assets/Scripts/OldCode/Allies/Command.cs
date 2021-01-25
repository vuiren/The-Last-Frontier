using System;
using UnityEngine;

[Serializable]
public class Command
{
	public CommandsEnum CommandType { get; }
	public Vector3 CommandVectorValue { get; }

	public Command(CommandsEnum commandType, Vector3 commandVectorValue)
	{
		this.CommandType = commandType;
		this.CommandVectorValue = commandVectorValue;
	}
}
