using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: non
 * Content: enemy spawn pattern 
 **************************************/

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/SpawnPattern")]
public class EnemySpawnPatternScriptable : ScriptableObject
{
   
   [Tooltip("You can only input 1 character \n C = common \n R = runner \n T = Tanker \n S = Squirter")]
   public string[] pattern1;
   [Tooltip("You can only input 1 character \n C = common \n R = runner \n T = Tanker \n S = Squirter")]
   public string[] pattern2;
   [Tooltip("You can only input 1 character \n C = common \n R = runner \n T = Tanker \n S = Squirter")]
   public string[] pattern3;

   public string[] RandommizedPattern()
   {
      string[] chosen = null;

      int rand = Random.Range(0,10);

      if(rand <= 3)
      {
         chosen = pattern1;
      }
      else if(rand <= 5)
      {
         chosen = pattern2;
      }
      else if(rand <= 10)
      {
         chosen = pattern3;
      }

      return chosen;
   }
}
