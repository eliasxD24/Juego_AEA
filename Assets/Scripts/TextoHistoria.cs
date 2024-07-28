using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoHistoria : MonoBehaviour
{
    private Transform camara;

    void Start()
    {
        // Obtener la referencia de la c�mara principal (main camera)
        camara = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Hacer que el texto siga la posici�n de la c�mara
        if (camara != null)
        {
            transform.position = camara.position;
        }
    }
}
