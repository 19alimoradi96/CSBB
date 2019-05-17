using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickPR {
    public BrickPR (Vector3 posrot) {
        this.posrot = posrot; //x and y: positions; z: rotation
        this.exist = false;
    }
    public BrickPR (Vector3 posrot, bool exist) {
        this.posrot = posrot; //x and y: positions; z: rotation
        this.exist = exist;
    }
    public Vector3 posrot;
    public bool exist;
}

// 	},{},{},{},{}};
public class GameInit : MonoBehaviour {
    public GameObject[] bricks = new GameObject[6];
    public GameObject[] rows = new GameObject[6];
    public GameObject ball;
    public Camera cam;
    public static int level = 1;
    public List<GameObject> balls;
    public int numberOfBricks = 0;
    public enum BallsState {
        inside = 0, outside = 1
    };
    public BallsState ballsState;
    public List<BrickPR[]> bricksPr = new List<BrickPR[]> ();
    private BrickPR[] row1bricksPr = new BrickPR[11] {
        new BrickPR (new Vector3 (5.1f, 0.47f, -86.734f)),
        new BrickPR (new Vector3 (3.94f, 3.23f, -54.004f)),
        new BrickPR (new Vector3 (1.43f, 4.88f, -17.903f)),
        new BrickPR (new Vector3 (1.43f, 4.88f, -17.903f)),
        new BrickPR (new Vector3 (-1.59f, 4.79f, 16.403f)),
        new BrickPR (new Vector3 (-4.07f, 3.05f, 48.689f)),
        new BrickPR (new Vector3 (-5.12f, 0.22f, 84.569f)),
        new BrickPR (new Vector3 (-4.34f, -2.69f, 120.197f)),
        new BrickPR (new Vector3 (-2f, -4.7f, 152.678f)),
        new BrickPR (new Vector3 (1.03f, -5f, 189.988f)),
        new BrickPR (new Vector3 (3.73f, -3.5f, 223.982f))
    };
    private BrickPR[] row2bricksPr = new BrickPR[10] {
        new BrickPR (new Vector3 (4.41f, 0.34f, -130.35f)),
        new BrickPR (new Vector3 (3.46f, 2.72f, -97.756f)),
        new BrickPR (new Vector3 (1.41f, 4.16f, -62.744f)),
        new BrickPR (new Vector3 (-1.11f, 4.21f, -29.547f)),
        new BrickPR (new Vector3 (-3.27f, 2.91f, 0.516f)),
        new BrickPR (new Vector3 (-4.38f, 0.66f, 35.382f)),
        new BrickPR (new Vector3 (-4.02f, -1.83f, 69.345f)),
        new BrickPR (new Vector3 (-2.34f, -3.74f, 100.869f)),
        new BrickPR (new Vector3 (0.13f, -4.41f, 138.044f)),
        new BrickPR (new Vector3 (2.54f, -3.58f, 169.515f))
    };
    private BrickPR[] row3bricksPr = new BrickPR[11] {
        new BrickPR (new Vector3 (3.69f, 0.32f, -99.396f)),
        new BrickPR (new Vector3 (2.97f, 2.19f, -68.736f)),
        new BrickPR (new Vector3 (1.41f, 3.41f, -36.725f)),
        new BrickPR (new Vector3 (-0.59f, 3.62f, -5.082f)),
        new BrickPR (new Vector3 (-2.44f, 2.74f, 24.346f)),
        new BrickPR (new Vector3 (-3.59f, 1.08f, 56.13f)),
        new BrickPR (new Vector3 (-3.61f, -0.92f, 92.47201f)),
        new BrickPR (new Vector3 (-2.57f, -2.67f, 122.185f)),
        new BrickPR (new Vector3 (-0.8f, -3.66f, 154.202f)),
        new BrickPR (new Vector3 (1.18f, -3.51f, 186.027f)),
        new BrickPR (new Vector3 (2.85f, -2.37f, 214.854f))
    };
    private BrickPR[] row4bricksPr = new BrickPR[12] {
        new BrickPR (new Vector3 (3.14f, 0.19f, -113.742f)),
        new BrickPR (new Vector3 (2.65f, 1.66f, -84.283f)),
        new BrickPR (new Vector3 (1.52f, 2.74f, -57.633f)),
        new BrickPR (new Vector3 (0.03f, 3.12f, -27.411f)),
        new BrickPR (new Vector3 (-1.46f, 2.71f, 0.175f)),
        new BrickPR (new Vector3 (-2.62f, 1.68f, 25.513f)),
        new BrickPR (new Vector3 (-3.18f, 0.26f, 53.847f)),
        new BrickPR (new Vector3 (-2.89f, -1.21f, 86.608f)),
        new BrickPR (new Vector3 (-1.97f, -2.42f, 113.22f)),
        new BrickPR (new Vector3 (-0.57f, -3.11f, 140.981f)),
        new BrickPR (new Vector3 (0.96f, -2.99f, 172.399f)),
        new BrickPR (new Vector3 (2.28f, -2.16f, 200.047f))
    };
    private BrickPR[] row5bricksPr = new BrickPR[14] {
        new BrickPR (new Vector3 (2.55f, 0.07f, -78.679f)),
        new BrickPR (new Vector3 (2.26f, 1.13f, -48.633f)),
        new BrickPR (new Vector3 (1.53f, 2.03f, -28.966f)),
        new BrickPR (new Vector3 (0.55f, 2.5f, -0.324f)),
        new BrickPR (new Vector3 (-0.56f, 2.44f, 25.687f)),
        new BrickPR (new Vector3 (-1.53f, 1.95f, 50.025f)),
        new BrickPR (new Vector3 (-2.27f, 1.11f, 69.148f)),
        new BrickPR (new Vector3 (-2.6f, 0.09f, 97.454f)),
        new BrickPR (new Vector3 (-2.38f, -0.98f, 128.057f)),
        new BrickPR (new Vector3 (-1.72f, -1.89f, 149.726f)),
        new BrickPR (new Vector3 (-0.76f, -2.45f, 174.443f)),
        new BrickPR (new Vector3 (0.36f, -2.56f, 198.695f)),
        new BrickPR (new Vector3 (1.42f, -2.15f, 224.437f)),
        new BrickPR (new Vector3 (2.18f, -1.35f, 251.717f))
    };
    private BrickPR[] row6bricksPr = new BrickPR[12] {
        new BrickPR (new Vector3 (1.88f, 0.22f, -75.396f)),
        new BrickPR (new Vector3 (1.53f, 1.06f, -39.933f)),
        new BrickPR (new Vector3 (0.81f, 1.7f, -16.325f)),
        new BrickPR (new Vector3 (-0.08f, 1.89f, 19.527f)),
        new BrickPR (new Vector3 (-0.99f, 1.54f, 46.057f)),
        new BrickPR (new Vector3 (-1.67f, 0.88f, 69.51601f)),
        new BrickPR (new Vector3 (-1.92f, -0.01f, 101.423f)),
        new BrickPR (new Vector3 (-1.69f, -0.9f, 139.393f)),
        new BrickPR (new Vector3 (-1f, -1.6f, 161.113f)),
        new BrickPR (new Vector3 (-0.05f, -1.89f, 190.291f)),
        new BrickPR (new Vector3 (1.6f, -1.07f, 250.518f)),
        new BrickPR (new Vector3 (0.91f, -1.69f, 215.651f))
    };
    void Start () {
        addRowsBrickToList ();
        genRows ();
        ballsState = BallsState.inside;
        balls = new List<GameObject>();
        addBall();
    }
    void Update () {
        if (Input.GetMouseButtonUp (0)) {
            // Debug.Log(Input.mousePosition);
            if(balls.Count == 0) return;
            if(ballsState == BallsState.outside) return;
            // for(int i=0; i<balls.Count; i++){
            // }
            StartCoroutine(shootBall(0, Input.mousePosition));
        }
    }
    IEnumerator shootBall(int i, Vector3 pos){
        while(i < balls.Count)//Or some other condition that will be true until you don't need it
        {
            yield return new WaitForSeconds(0.03f);
            // Debug.Log ("i: " + i + ", balls.Count:" + balls.Count);
            Vector3 direction = cam.ScreenToWorldPoint (pos);
            direction.z = 0;
            direction.Normalize();
            balls[i].GetComponent<Rigidbody2D> ().AddForce (direction * 700.0f);
            i++;
            yield return null;
        }
        Debug.Log ("i: " + i + ", balls.Count:" + balls.Count);
        yield break;
        yield return null;
    }
    void addRowsBrickToList () {
        bricksPr.Add (row1bricksPr);
        bricksPr.Add (row2bricksPr);
        bricksPr.Add (row3bricksPr);
        bricksPr.Add (row4bricksPr);
        bricksPr.Add (row5bricksPr);
        bricksPr.Add (row6bricksPr);
    }
    public void genRows () {
        System.Random rand = new System.Random ();
        int brickCount = 0;
        int ind = 0;
        int i=0;
        brickCount = calcBrickCount (i);
        for (int j = 0; j < brickCount; j++) {
            ind = rand.Next (0, bricksPr[i].Length);
            if(!bricksPr[i][ind].exist){
                InstantiateBrick (bricks[i], bricksPr[i][ind].posrot, rows[i].transform, i, ind);
                bricksPr[i][ind].exist = true;
                numberOfBricks++;
            }
        }
    }
    public void setBrickPrExs(int row, int col, bool exist){
        bricksPr[row][col].exist = exist;
    }
    void InstantiateBrick (GameObject brick, Vector3 posrot, Transform parent, int i, int ind) {
        GameObject go = Instantiate (brick);
        go.transform.parent = parent;
        go.transform.position = new Vector3 (posrot.x, posrot.y, 0);
        go.transform.rotation = Quaternion.Euler (0, 0, posrot.z);
        // set strength
        Brick brck = go.GetComponent<Brick>();
        brck.setRowCol(i, ind);
        brck.setStrength(level);
        //set color
        brck.sr.color = new Color32(255, 0, 0, 255);
        //set text
        // GameObject myText = new GameObject();
        // myText.transform.parent = go.transform;
        // myText.transform.position = new Vector3(0, 0, 0);
        // myText.name = "text";
        // TextMesh text = myText.AddComponent<TextMesh>();
        // text.color = Color.black;
        // text.text = System.Convert.ToString(level);
        // text.fontSize = 6;
    }
    int calcBrickCount (int i) {
        System.Random random = new System.Random ();
        int brickCount = 1;
        switch (i) {
            case 0:
                brickCount = random.Next (bricksPr[i].Length / 2, bricksPr[i].Length);
                break;
            case 1:
                brickCount = random.Next (bricksPr[i].Length / 6, bricksPr[i].Length / 2);
                break;
            case 2:
                brickCount = random.Next (2, bricksPr[i].Length / 4);
                break;
            case 3:
                brickCount = random.Next (1, bricksPr[i].Length / 4);
                break;
            case 4:
                brickCount = random.Next (0, 1);
                break;
            case 5:
                brickCount = 0;
                break;
            default:
                break;
        }
        return brickCount;
    }
    
    public void addBall(){
        GameObject bo = Instantiate (ball);
        bo.transform.position = Vector3.zero;
        bo.transform.rotation = Quaternion.Euler (Vector3.zero);
        balls.Add(bo);
    }
    public int getBallCount(){
        return balls.Count;
    }
    public void resetLevel(){
        Trap.trapped = 0;
        level++;
        Debug.Log ("balls enter to trap");
        ballsState = BallsState.inside;
        addBall();
        genRows();
        for(int i=0; i<balls.Count; i++){
            balls[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			balls[i].transform.position = Vector3.zero;
        }
    }
    
}