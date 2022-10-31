using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
    /*Interfaces are like templates
     *Classes can only inherit from a single class
     *Interfaces allow you to inherit from many things
     */

    public void Collect();
}
