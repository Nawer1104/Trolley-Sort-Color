using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public List<GameObject> listTransform = new List<GameObject>();

    public List<Button> buttons = new List<Button>();

    public List<Car> cars = new List<Car>();

    public Transform startPos;

    private bool canStartTheGame;

    private Car currentCar;

    private int carIndex;
 
    private void Awake()
    {
        carIndex = 0;

        canStartTheGame = false;

        currentCar = cars[carIndex];

        MoveCurrentCarPos(startPos.position);
    }

    private void Start()
    {
        
    }

    private void MoveCurrentCarPos(Vector3 pos)
    {
        currentCar.transform.DOMove(pos, 1f).OnComplete(() => {
            canStartTheGame = true;
        });
    }

    public void ButtonClick(Vector3 pos)
    {
        if (!canStartTheGame)
            return;

        canStartTheGame = false;

        currentCar.transform.DOMove(pos, 1f).OnComplete(() => {
            currentCar.transform.DOMove(listTransform[carIndex].transform.position, 1f).OnComplete(() => {
                carIndex += 1;

                CheckCarIndex();

                if (carIndex < cars.Count)
                {
                    currentCar = cars[carIndex];

                    MoveCurrentCarPos(startPos.position);
                }
                else
                {
                    GameManager.Instance.CheckLevelUp();
                }
            });
        });
    }

    private void CheckCarIndex()
    {
        if (carIndex % 2 == 0)
        {
            cars[carIndex - 1].PlayVfx();
            cars[carIndex - 2].PlayVfx();
        }
    }
}
