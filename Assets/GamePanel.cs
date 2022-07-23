using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GamePanel : BasePanel
{
   private TMP_Text over;
   private TMP_Text balls;
   private TMP_Text TargetScore;
   private TMP_Text Batsmen;
   private TMP_Text myScore;
   private Transform HitTypeHolder;
   private GameObject hitObject;
   private List<HitType> hitTypes;
   private bool isResultDecleared;
   private int _leftballs;
   public override void OnEnter()
   {
      gameObject.SetActive(true);
      over = transform.Find("Over").GetComponent<TMP_Text>();
      balls = transform.Find("Balls").GetComponent<TMP_Text>();
      TargetScore = transform.Find("TargetScore").GetComponent<TMP_Text>();
      Batsmen = transform.Find("Batsmen").GetComponent<TMP_Text>();
      myScore = transform.Find("MyScore").GetComponent<TMP_Text>();
      HitTypeHolder = transform.Find("HitSelector").GetComponent<Transform>();
      hitObject = Resources.Load("Batsmen/HitType") as GameObject;
      SetUpGameScreen();
      base.OnEnter();
   }

   private bool isOverCompletd;
   private void Update()
   {
     
      Math.DivRem(GameFacade.Instance.GetGameData().TotalBalls, 6, out _leftballs);
      balls.text = _leftballs == 0 ? $"balls-6" : $"balls-{_leftballs}";         
      over.text = $"Over-{GameFacade.Instance.GetGameData().Over}";
      TargetScore.text = $"Target-{GameFacade.Instance.GetGameData().TargetScore}";
      myScore.text = $"My-{GameFacade.Instance.GetGameData().TotalScore}";
      Batsmen.text = $"Batsmen-{GameFacade.Instance.GetGameData().TotalBatsmen}";


      if (!isResultDecleared)
      {
         if (GameFacade.Instance.GetGameData().TotalBalls >= 0 )
         {
             return;
         }
         uiManager.PushPanel(UIPanelType.Result);
         isResultDecleared = true;
      }
      
   }

   private void SetUpGameScreen()
   {
      if(HitTypeHolder.transform.childCount > 0) return;
      for (int i = 0; i <= 4; i++)
      {
         HitType hit = Instantiate(hitObject, HitTypeHolder).GetComponent<HitType>();
         switch (i)
         {
            case 0:
               hit.SetupHit(0,90);
               break;
            case 1:
               hit.SetupHit(1,85);
               break;
            case 2:
               hit.SetupHit(2,60);
               break;
            case 3:
               hit.SetupHit(4,35);
               break;
            case 4:
               hit.SetupHit(6, 20);
               break;
         }
         hit.OnItemClicked(i,OnBatHit);
      }
   }

   private void OnBatHit(int index)
   {
      if(_leftballs==0)
      {
         GameFacade.Instance.GetGameData().Over--;
         over.text = $"Over-{GameFacade.Instance.GetGameData().Over}";
      }
      var hit = HitTypeHolder.GetChild(index).GetComponent<HitType>();
      var run = GameFacade.Instance.OnBatsmenHit(hit.HitScore, hit.HitChance);
      if (run == -1)
      {
         GameFacade.Instance.GetGameData().TotalBatsmen--;
         Batsmen.text = $"Batsmen-{GameFacade.Instance.GetGameData().TotalBatsmen.ToString()}";
      }
      else
      {
         GameFacade.Instance.GetGameData().TotalScore += run;
         myScore.text = $"My Score: {GameFacade.Instance.GetGameData().TargetScore.ToString()}";
      }

      Instantiate(Resources.Load("Bowler/BowlerCamera") as GameObject);
      var t = FindObjectOfType<BatsmenRequest>().transform.GetChild(0);
      t.gameObject.SetActive(false);
   }
   public override void OnExit()
   {
      Destroy(this.gameObject);
      base.OnExit();
   }
   
   public override void OnPause()
   {
      gameObject.SetActive(false);
      base.OnPause();
   }

   public override void OnResume()
   {
      base.OnResume();
   }
}
