using System;
using UnityEngine;

public class CommandWorkerEventsProxy : MonoBehaviour
{
	public Action<Command> OnGoToCommand { get; set; }
	public Action OnCommandEnd { get; set; }
	public Action<Command> OnBuildCommand { get; set; }
}
