using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICSVReader<T>
{

    List<T> GetList();

}
