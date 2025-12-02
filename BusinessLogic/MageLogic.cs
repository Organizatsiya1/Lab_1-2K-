using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public class MageLogic : IMageManipulator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStandartizer _normalizer;

        public MageLogic(IUnitOfWork unitOfWork, IStandartizer standartizer)
        {
            _unitOfWork = unitOfWork;
            _normalizer = standartizer;
        }

        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Количество маны</param>
        /// <param name="School">Выбранная школа магии</param>
        public void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school)
        {
            _normalizer.StandartizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = _normalizer.ClampStat(mana, 0, 2000);

            var mage = new Mage(nName, nDisc, nHp, nStr, mana, school);
            _unitOfWork.Mages.Create(mage);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Изменение данных мага
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <param name="name">Имя</param>
        /// <param name="disc">Досье</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Мана</param>
        /// <param name="School">Тип магии</param>
        public void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school)
        {
            if (unit == null) return;

            _normalizer.StandartizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = _normalizer.ClampStat(mana, 0, 2000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
            unit.Mana = mana;
            unit.School = school;

            _unitOfWork.Mages.Update(unit);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(MagicSchools magic)
        {
            return _unitOfWork.Mages.ReadAll()
                .Where(f => f.School == magic)
                .Cast<Character>()
                .ToList();
        }
    }
}
