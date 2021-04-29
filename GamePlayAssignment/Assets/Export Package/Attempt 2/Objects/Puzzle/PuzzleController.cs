using Attempt_2.Objects.Doors;
using UnityEngine;

namespace Export_Package.Attempt_2.Objects.Puzzle
{
    public class PuzzleController : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject[] puzzleRings;
        public GameObject[] puzzleLevers;
    
        public GameObject[] lights;

        public float debugAngles;

        public float rotationSpeed;
    
        public float timer;
        public float ringCompleteTimer;
    
        private SwitchScript switchScript;
        private SwitchScript switchScript1;
        private SwitchScript switchScript2;
    
        public bool puzzleRing1Solved;
        public bool puzzleRing2Solved;
        public bool puzzleRing3Solved;

        public bool puzzleComplete;

        void Start()
        {
            switchScript2 = puzzleLevers[2].GetComponent<SwitchScript>();
            switchScript1 = puzzleLevers[1].GetComponent<SwitchScript>();
            switchScript  = puzzleLevers[0].GetComponent<SwitchScript>();
        }

        // Update is called once per frame
        void Update()
        {
            debugAngles = puzzleRings[2].transform.rotation.eulerAngles.normalized.x;

            SwitchController();
            RingRotationCheck();
            LightController();
        
        }

        private void SwitchController()
        {
            if (!puzzleComplete)
            {
                if (switchScript.pressed)
                {
                    puzzleRings[0].transform.Rotate(transform.right, rotationSpeed);
                }

                if (switchScript1.pressed)
                {
                    puzzleRings[1].transform.Rotate(transform.right, rotationSpeed);
                }

                if (switchScript2.pressed)
                {
                    puzzleRings[2].transform.Rotate(transform.right, rotationSpeed);
                }
            }
        }

        private void LightController()
        {
            if (puzzleRing1Solved)
            {
                lights[0].SetActive(!enabled);
                lights[1].SetActive(enabled);
            }
            else
            {
                lights[0].SetActive(enabled);
                lights[1].SetActive(!enabled);
            }

            if (puzzleRing2Solved)
            {
                lights[2].SetActive(!enabled);
                lights[3].SetActive(enabled);
            }
            else
            {
                lights[2].SetActive(enabled);
                lights[3].SetActive(!enabled);
            }

            if (puzzleRing3Solved)
            {
                lights[4].SetActive(!enabled);
                lights[5].SetActive(enabled);
            }
            else
            {
                lights[4].SetActive(enabled);
                lights[5].SetActive(!enabled);
            }
        }

        private void RingRotationCheck()
        {
            if (puzzleRings[0].transform.rotation.eulerAngles.normalized.x > 0.8205374 &&
                puzzleRings[0].transform.rotation.eulerAngles.normalized.x < 0.8382709)
            {
                //Debug.Log("Puzzle Ring 1 Dinged!");
                puzzleRing1Solved = true;
            }
            else
            {
                puzzleRing1Solved = false;
            }

            if (puzzleRings[1].transform.rotation.eulerAngles.normalized.x > 0.8227422 &&
                puzzleRings[1].transform.rotation.eulerAngles.normalized.x < 0.8433119)
            {
                puzzleRing2Solved = true;
            }
            else
            {
                puzzleRing2Solved = false;
            }

            if (puzzleRings[2].transform.rotation.eulerAngles.normalized.x > 0.8233325 &&
                puzzleRings[2].transform.rotation.eulerAngles.normalized.x < 0.8449384)
            {
                puzzleRing3Solved = true;
            }
            else
            {
                puzzleRing3Solved = false;
            }

        
            if (puzzleRing1Solved &&
                puzzleRing2Solved &&
                puzzleRing3Solved)
            {
                //Debug.Log("Puzzle Ring Close!");
            
                if (timer >= ringCompleteTimer)
                {
                    gameObject.GetComponent<SwitchScript>().pressed = true;
                    puzzleComplete = true;
                    //Debug.Log("Puzzle Ring Complete!");
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
            else
            {
                timer = 0;
                gameObject.GetComponent<SwitchScript>().pressed = false;
            }
        }
    }
}
