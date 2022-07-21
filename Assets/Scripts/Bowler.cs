using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bowler : MonoBehaviour
{
	private Button selectButton;
	private TMP_Text BowlerTextField;

	private void OnEnable()
	{
		selectButton = GetComponent<Button>();
		BowlerTextField =transform.Find("BowlerName").GetComponent<TMP_Text>();
		selectButton.onClick.RemoveAllListeners();
	}

	public void SetBowlerText(string name)
	{
		BowlerTextField.text = name;
	}

	public void DisableButton()
	{
		selectButton.interactable = false;
	}
	public void EnableButton()
	{
		selectButton.interactable = true;
	}
	public void OnItemClicked(int itemIndex, UnityAction<int> action)
	{
		selectButton.onClick.RemoveAllListeners();
		selectButton.onClick.AddListener(() => action.Invoke(itemIndex));
	}
}
