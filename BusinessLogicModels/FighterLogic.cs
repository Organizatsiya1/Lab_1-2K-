using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public class FighterLogic : IFighterManipulator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStandartizer _standartizer;

        public FighterLogic(IUnitOfWork unitOfWork, IStandartizer normalizer)
        {
            _unitOfWork = unitOfWork;
            _standartizer = normalizer;
        }

        public void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon)
        {
            _standartizer.StandartizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            stam = _standartizer.ClampStat(stam, 0, 1000);

            if (!Enum.IsDefined(typeof(Weapons), weapon))
                weapon = Weapons.None;

            var fighter = new Fighter(nName, nDisc, nHp, nStr, stam, weapon);
            _unitOfWork.Fighters.Create(fighter);
            _unitOfWork.SaveChanges();
        }

        public void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon)
        {
            if (unit == null) return;

            _standartizer.StandartizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            stam = _standartizer.ClampStat(stam, 0, 1000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
            unit.Weapon = weapon;
            unit.Stamina = stam;

            _unitOfWork.Fighters.Update(unit);
            _unitOfWork.SaveChanges();
        }

        public List<Character> ChooseMarked(Weapons weapon)
        {
            return _unitOfWork.Fighters.ReadAll()
                .Where(f => f.Weapon == weapon)
                .Cast<Character>()
                .ToList();
        }
    }

}

