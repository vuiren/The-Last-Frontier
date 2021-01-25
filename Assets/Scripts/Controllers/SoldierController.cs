using FrontierComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrontierControllers
{
    public class SoldierController : Controller
    {
        UnitMover unitMover;

        public override void AddComponents()
        {
            unitMover= gameObject.AddComponent<UnitMover>();
        }

        public override void InitializeComponents()
        {
            unitMover.InitComponent(gameObject);
        }

        protected override void RunController()
        {
            throw new System.NotImplementedException();
        }
    }
}