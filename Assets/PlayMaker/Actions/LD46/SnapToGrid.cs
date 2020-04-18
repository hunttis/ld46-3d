using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class SnapToGrid : FsmStateAction
	{
		[Tooltip("The GameObject to snap to grid.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;

		[UIHint(UIHint.Variable)]
		[Tooltip("The actual coordinates to be transformed")]
		public FsmVector3 actualCoordinates;

		[Tooltip("Lock Y Coordinate to value")]
		public FsmFloat lockYAxisToValue;

		[Tooltip("Grid Size in X coordinate")]
		public FsmFloat gridSizeX;
		
		[Tooltip("Grid Size in Z coordinate")]
		public FsmFloat gridSizeZ;
		
		[Tooltip("Grid offset in X coordinate")]
		public FsmFloat gridXOffset;
		
		[Tooltip("Grid offset in Z coordinate")]
		public FsmFloat gridZOffset;

		

		public override void OnEnter()
		{
			DoSnapToGrid();
			if (!everyFrame)
			{
				Finish();
			}
		}


		public override void OnUpdate()
		{
			DoSnapToGrid();
		}

		private void DoSnapToGrid()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				Debug.Log("Cursor is null?");
				return;
			}
			Debug.Log("Snapping");

			Vector3 snappedToGrid =
				new Vector3(
					Mathf.Ceil((actualCoordinates.Value.x - gridXOffset.Value) / gridSizeX.Value) * gridSizeX.Value - gridSizeX.Value / 2 + gridXOffset.Value, 
					lockYAxisToValue.Value, 
					Mathf.Ceil((actualCoordinates.Value.z - gridZOffset.Value) / gridSizeZ.Value) * gridSizeZ.Value - gridSizeZ.Value / 2 + gridZOffset.Value);

			go.transform.position = snappedToGrid;

		}

	}

}
