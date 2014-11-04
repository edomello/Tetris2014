using UnityEngine;
using System.Collections;
using System.Timers;

public class TableController : MonoBehaviour {
	private GameObject[,] table;
	public const int rows = 10;
	public const int cols = 11;
	private GameObject activeBlock;
	System.Timers.Timer timer;
	// Use this for initialization
	void Start () {
		//initializing table and cells
		table = new GameObject[rows,cols];
		Vector3 myPosition = this.transform.localPosition;
			for (int row = 0; row < rows; row++) {
				for (int col = 0; col < cols; col++) {
				Vector3 cellPosition = new Vector3(((float)col),((float)row),0) + myPosition;
				table[row,col] =(GameObject) Instantiate(Resources.Load<GameObject>("Cell"),cellPosition,Quaternion.identity);

				}
			}
		//initializing first block
		activeBlock = (GameObject) Instantiate((Resources.Load("Blocks/Block")),table[9,5].transform.localPosition,Quaternion.identity);

		//Inizializzo il timer
		timer = new System.Timers.Timer (1000);
		timer.Enabled = true;
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
	}
	
	// Update is called once per frame
	void Update () {

	}
	//Tick del timer di gioco
	private static void OnTimedEvent(object source, ElapsedEventArgs e){
		Debug.Log ("Tick!");
	}
	//TODO: creare il controller per i cell con un boolean che dice se è libero o no, spostare i blocchi, creare la classe per i blocchi del tetris.
}