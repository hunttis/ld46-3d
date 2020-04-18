using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class CreateObjectsInGrid : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The GameObject to create.")]
		public FsmGameObject gameObject;
		
		[RequiredField]
		[Tooltip("Grid Size in X coordinate")]
		public FsmFloat gridSizeX;
		
		[RequiredField]
		[Tooltip("Grid Size in Z coordinate")]
		public FsmFloat gridSizeZ;
		
		[RequiredField]
		[Tooltip("Count of objects in X coordinate")]
		public FsmInt countX;
		
		[RequiredField]
		[Tooltip("Count of objects Z coordinate")]
		public FsmInt countZ;

		

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			DoCreateObjectsInGrid();
			Finish();
		}

		private void DoCreateObjectsInGrid()
		{
			for (int z = 0; z < countZ.Value; z++)
			{
				for (int x = 0; x < countX.Value; x++)
				{
					float xAxisOffset = gridSizeX.Value * countX.Value / 2 - 1;
					float zAxisOffset = gridSizeZ.Value * countZ.Value / 2 - 1;
					Vector3 spawnLocation = new Vector3(-x * gridSizeX.Value + xAxisOffset, 0f, -z * gridSizeZ.Value + zAxisOffset);
					Object.Instantiate(gameObject.Value, spawnLocation, Quaternion.identity);
				}
			}
		}
	}

}
