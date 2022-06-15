using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    internal Text text;
    public Sprite[] spriteType = new Sprite[4];
    internal int ChangeType;
    internal int evaluateNumber;

    private void Awake()
    {
        if(CompareTag("Obstacle"))
        {
            evaluateNumber = -10;
        }
        else if (CompareTag("Doors"))
        {
            evaluateNumber = Random.Range(10, 40);
            evaluateNumber = Round(evaluateNumber);
            text = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
            GenerateType();
        }
    }

    static int Round(int n)
    {
        // Smaller multiple
        int a = (n / 10) * 10;
        // Larger multiple
        int b = a + 10;
        // Return of closest of two
        return (n - a > b - n) ? b : a;
    }

    public void GenerateType()
    {
        ChangeType = Random.Range(0, 3);
        switch (ChangeType)
        {
            case 0:
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteType[ChangeType];
                break;
            case 1:
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteType[ChangeType];
                evaluateNumber *= -1;
                break;
            case 2:
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteType[ChangeType];
                break;
            case 3:
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteType[ChangeType];
                evaluateNumber *= -1;
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("Obstacle"))
            {
                if (!other.GetComponent<EditMesh>().HeightDown(evaluateNumber))
                {
                    if (!other.GetComponent<EditMesh>().LengthDown(evaluateNumber))
                    {
                        Debug.Log("Game Over");
                    }
                }
            }
            else if(CompareTag("Doors"))
            {
                switch (ChangeType)
                {
                    case 0:
                        other.GetComponent<EditMesh>().HeightUp(evaluateNumber);
                        break;
                    case 1:
                        other.GetComponent<EditMesh>().HeightDown(evaluateNumber);
                        break;
                    case 2:
                        other.GetComponent<EditMesh>().LengthUp(evaluateNumber);
                        break;
                    case 3:
                        other.GetComponent<EditMesh>().LengthDown(evaluateNumber);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void Update()
    {
        // if this is door object
        if (text) {
            text.text = string.Concat(evaluateNumber.ToString("+#;-#;0"));
        }
    }
}
