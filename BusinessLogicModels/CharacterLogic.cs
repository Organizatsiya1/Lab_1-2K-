using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public class CharacterLogic : ICharManipulator
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Character> GetUnits()
        {
            var fighters = _unitOfWork.Fighters.ReadAll().Cast<Character>();
            var mages = _unitOfWork.Mages.ReadAll().Cast<Character>();
            return fighters.Concat(mages).ToList();
        }

        public void DeleteUnit(Character unit)
        {
            if (unit == null) return;

            if (unit is Fighter f)
                _unitOfWork.Fighters.Delete(f);
            else if (unit is Mage m)
                _unitOfWork.Mages.Delete(m);

            _unitOfWork.SaveChanges();
        }

        public string ReadUnit(Character unit)
        {
            if (unit == null) return "";

            var info = new StringBuilder();
            var properties = unit.GetType().GetProperties();
            foreach (var property in properties)
            {
                info.AppendLine($"{property.Name}: {property.GetValue(unit)}");
            }

            if (unit is Mage)
            {
                info.AppendLine("Выносливость: 0");
                info.AppendLine($"Оружие: {Displays.WeaponsNames[Weapons.None]}");
            }
            else if (unit is Fighter)
            {
                info.AppendLine("Мана: 0");
                info.AppendLine("Школа магии: -");
            }

            return info.ToString();
        }

        public string Fight(Character char1, Character char2)
        {
            var mes = new StringBuilder();
            mes.AppendLine("\t\tПоединок");
            mes.AppendLine($"\n{char1.Name} (Здоровье: {char1.HP})  vs  {char2.Name} (Здоровье: {char2.HP})\n");

            int damageTo1 = char2.Strength;
            int damageTo2 = char1.Strength;

            mes.AppendLine($"{char1.Name} получает {damageTo1} урона");
            mes.AppendLine($"{char2.Name} получает {damageTo2} урона\n");

            char1.HP -= damageTo1;
            char2.HP -= damageTo2;

            if (char1.HP < 0) char1.HP = 0;
            if (char2.HP < 0) char2.HP = 0;

            mes.AppendLine($"Статусы после удара: {char1.Name}: {char1.HP} единиц здоровья, {char2.Name}: {char2.HP} единиц здоровья\n");

            if (char1.HP == 0 && char2.HP == 0)
            {
                DeleteUnit(char1);
                DeleteUnit(char2);
                mes.AppendLine("Оба бойца выбиты из группы.");
            }
            else if (char1.HP == 0)
            {
                DeleteUnit(char1);
                mes.AppendLine($"{char1.Name} выбывает из группы");
            }
            else if (char2.HP == 0)
            {
                DeleteUnit(char2);
                mes.AppendLine($"{char2.Name} выбывает из группы");
            }
            else
            {
                mes.AppendLine("Оба выжили. Поединок окончен");
                UpdateCharacter(char1);
                UpdateCharacter(char2);
                _unitOfWork.SaveChanges();
            }

            mes.AppendLine("\nПоединок завершён");
            return mes.ToString();
        }

        private void UpdateCharacter(Character character)
        {
            switch (character)
            {
                case Fighter f:
                    _unitOfWork.Fighters.Update(f);
                    break;
                case Mage m:
                    _unitOfWork.Mages.Update(m);
                    break;
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
