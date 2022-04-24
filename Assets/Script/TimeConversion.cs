using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeConversion : MonoBehaviour
{
    [SerializeField]
    InputField InputText;

    [SerializeField]
    Text timeConverted;

    [SerializeField]
    GameObject errorObject;

    public void ConvertTime()
    {
        string InputString = InputText.text;

        if (CheckValidity(InputString))
        {
            errorObject.SetActive(false);
        }
        else
        {
            errorObject.SetActive(true);
            return;
        }

        char[] charTemp = InputString.ToCharArray();
        int hourTemp =
            (int)char.GetNumericValue(charTemp[0]) * 10 + (int)char.GetNumericValue(charTemp[1]);

        if (charTemp[8] == 'A' || charTemp[8] == 'a')
        {
            if (hourTemp == 12)
                hourTemp = 0;
        }
        else
        {
            if (hourTemp != 12)
                hourTemp += 12;
        }

        int tens = hourTemp / 10;
        charTemp[0] = (char)('0' + tens);
        charTemp[1] = (char)('0' + hourTemp - tens * 10);

        string newString = new string(charTemp, 0, 8);
        timeConverted.text = newString;
    }

    private bool CheckValidity(string InputString)
    {
        if (InputString.Length != 10)
            return false;

        for (int i = 0; i < 10; i++)
        {
            bool ValidChecker = false;
            char InputCharacter = InputString[i];

            switch (i)
            {
                case 0:
                    if (InputCharacter == '0' || InputCharacter == '1')
                        ValidChecker = true;
                    break;
                case 1:
                    if (InputString[0] == '0')
                    {
                        if (InputCharacter != '0')
                            ValidChecker = true;
                    }
                    else if (InputCharacter >= '0' && InputCharacter <= '2')
                        ValidChecker = true;
                    break;
                case 3:
                case 4:
                case 6:
                case 7:
                    if (InputCharacter >= '0' && InputCharacter <= '9')
                        ValidChecker = true;
                    break;
                case 2:
                case 5:
                    if (InputCharacter == ':')
                        ValidChecker = true;
                    break;
                case 8:
                    if (
                        InputCharacter == 'P'
                        || InputCharacter == 'p'
                        || InputCharacter == 'A'
                        || InputCharacter == 'a'
                    )
                        ValidChecker = true;
                    break;
                case 9:
                    if (InputCharacter == 'M' || InputCharacter == 'm')
                        ValidChecker = true;
                    break;
                default:
                    break;
            }

            if (!ValidChecker)
            {
                return false;
            }
        }

        return true;
    }
}
