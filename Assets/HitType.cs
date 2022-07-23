using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HitType : MonoBehaviour
{
 public int HitScore{ get; set; }   
 public int HitChance{ get; set; }
 private int run;
 public int Run => run;
 private TMP_Text hitText;
 private TMP_Text hitChanceText;
 private Button hitButton;
 private void Start()
 {
  Init();
 }

 void Init()
 {
  hitText = transform.Find("HitScore").GetComponent<TMP_Text>();
  hitChanceText = transform.Find("HitChance").GetComponent<TMP_Text>();
  hitButton = GetComponent<Button>();
 }
 public void SetupHit(int hitScore, int hitChance)
 {
  if (hitText == null || hitChanceText == null || hitButton == null) Init();
  this.HitScore = hitScore;
  this.HitChance = hitChance;
  hitText.text = hitScore.ToString();
  hitChanceText.text = $"{hitChance}%";
 }
 public void OnItemClicked(int itemIndex, UnityAction<int> action)
 {
  run = 0;
  hitButton.onClick.RemoveAllListeners();
  hitButton.onClick.AddListener(() => action.Invoke(itemIndex));
 }
}