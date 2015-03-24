using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class ProgrammingTest : MonoBehaviour {


	Queue<int> QueuedResult;
	public GameObject UIText;

	void Start () {


		System.Object[][] matrix = new System.Object[][]{
			new System.Object[]{1,2,3},
			new System.Object[]{4,5,6},
			new System.Object[]{7,8,9}
		};


		List<System.Object> result = MatrixDecomposition.DecomposeMatrix (matrix);
		result.ForEach (x=>Debug.Log (x));
		QueuedResult = new Queue<int>(result.Select(x=>(int)x));
		StartCoroutine (renderNext());
	}

	IEnumerator renderNext(){
		Text uiTextComponent = UIText.GetComponent<Text>();
		uiTextComponent.text = uiTextComponent.text + "\n";
		while(QueuedResult.Count>0){
			uiTextComponent.text = uiTextComponent.text + QueuedResult.Dequeue() + " ";
			yield return new WaitForSeconds(1f);
		}
	}

	void Update () {
		
	}
}
