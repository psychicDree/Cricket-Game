using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlLocationPanel : BasePanel
{
	public override void OnEnter()
	{
		gameObject.SetActive(true);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hit))
			{
				if (hit.collider.gameObject.name.Contains("Grid"))
				{
					uiManager.PushPanel(UIPanelType.Game);
					GameFacade.Instance.SetBallPosition(hit.point);
				}
			}
		}
	}

	public override void OnExit()
	{
		gameObject.SetActive(false);
	}
	public override void OnPause()
	{
		gameObject.SetActive(false);
	}
}
