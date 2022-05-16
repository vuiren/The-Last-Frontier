using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using Units;
using UnityEngine;

namespace Controllers
{
    public class UnitsController : MonoBehaviour
    {
        [SerializeField] private List<Unit> units;

        private readonly Dictionary<int, Unit> _units = new Dictionary<int, Unit>();

        private void Awake()
        {
            units = FindObjectsOfType<Unit>().ToList();

            foreach (var unit in units)
            {
                RegisterUnit(unit);
            }
        }

        [Command("units.printAll")]
        private void PrintAll()
        {
            foreach (var unit in units)
            {
                Debug.Log($"Unit name: {unit.name} id: {unit.ID}");
            }
        }

        [Command("units.goRight")]
        public void GoRight(int id)
        {
            var unit = GetUnit(id);
            if (unit == null) return;

            var mover = unit.GetComponentInChildren<UnitMover>();

            if (!mover)
            {
                Debug.LogWarning("Unit got no mover");
                return;
            }

            PlayAnimation(id, "Walk");
            mover.GoRight();
        }

        [Command("units.goLeft")]
        public void GoLeft(int id)
        {
            var unit = GetUnit(id);
            if (unit == null)
                return;

            var mover = unit.GetComponentInChildren<UnitMover>();

            if (!mover)
            {
                Debug.LogWarning("Unit got no mover");
                return;
            }

            PlayAnimation(id, "Walk");
            mover.GoLeft();
        }

        [Command("units.stop")]
        public void StopUnit(int id)
        {
            var unit = GetUnit(id);
            if (unit == null)
                return;

            var mover = unit.GetComponentInChildren<UnitMover>();

            if (!mover)
            {
                Debug.LogWarning("Unit got no mover");
                return;
            }

            mover.Stop();
        }

        [Command("units.getMoveVector")]
        public Vector2 GetMoveVector(int id)
        {
            var unit = GetUnit(id);
            if (unit == null)
                return Vector2.zero;

            var mover = unit.GetComponentInChildren<UnitMover>();

            if (mover)
                return mover.moveVector;

            Debug.LogWarning("Unit got no mover");
            return Vector2.zero;
        }

        [Command("units.alertUnit")]
        public void AlertUnit(int id)
        {
            var unit = GetUnit(id);
            if (unit == null)
                return;

            StopUnit(unit.ID);
            StartAttack(unit.ID);
            PlayAnimation(unit.ID, "Attack");
            Debug.Log($"Unit {unit.name} is alerted");
        }

        [Command("units.relaxUnit")]
        public void RelaxUnit(int id)
        {
            var unit = GetUnit(id);
            if (unit == null)
                return;

            StopAttacking(unit.ID);

            var moveVector = GetMoveVector(id);
            PlayAnimation(unit.ID, Mathf.Approximately(moveVector.magnitude, 0) ? "Idle" : "Walk");
            Debug.Log($"Unit {unit.name} is relaxing");
        }

        [Command("units.attack")]
        public void StartAttack(int id)
        {
            var unit = GetUnit(id);
            if (!unit) return;

            var attackController = unit.GetComponentInChildren<UnitAttackController>();
            if (!attackController)
            {
                Debug.LogWarning($"No attack controller on {unit.name}");
                return;
            }

            attackController.StartAttacking();
        }

        [Command("units.stopAttacking")]
        public void StopAttacking(int id)
        {
            var unit = GetUnit(id);
            if (!unit) return;

            var attackController = unit.GetComponentInChildren<UnitAttackController>();
            if (!attackController)
            {
                Debug.LogWarning($"No attack controller on {unit.name}");
                return;
            }

            attackController.StopAttacking();
        }

        [Command("units.playAnimation")]
        public void PlayAnimation(int id, string animationName)
        {
            var unit = GetUnit(id);
            if (!unit)
                return;

            var animator = unit.GetComponentInChildren<UnitAnimator>();
            animator.PlayAnimation(animationName);
        }

        
        [Command("units.selectUnit")]
        public void SelectUnit(int id)
        {
            var unit = GetUnit(id);
            if (!unit)
                return;

            var selector = unit.GetComponentInChildren<UnitSelecting>();
            selector.Select();
        }
        
        [Command("units.deselectUnit")]
        public void DeselectUnit(int id)
        {
            var unit = GetUnit(id);
            if (!unit)
                return;

            var selector = unit.GetComponentInChildren<UnitSelecting>();
            selector.Deselect();
        }

        private Unit GetUnit(int id)
        {
            if (_units.ContainsKey(id)) return _units[id];
            Debug.LogWarning($"No unit with id {id}");
            return null;
        }
        
        public void RegisterUnit(Unit unit)
        {
            _units.Add(unit.ID, unit);
            Debug.Log($"Registered unit {unit.name} with ID {unit.ID}");
        }
    }
}