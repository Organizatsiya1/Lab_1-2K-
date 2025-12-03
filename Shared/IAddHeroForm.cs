using Models;
using System;
using System.Windows.Forms;

namespace Shared
{
    public interface IAddHeroView
    {
        event Action SaveEvent;
        event Action CancelEvent;

        string HeroName { get; }
        string HeroDescription { get; }
        int HeroHP { get; }
        int HeroStrength { get; }
        bool IsFighter { get; }
        bool IsMage { get; }
        int HeroStamina { get; }
        int HeroMana { get; }
        Weapons SelectedWeapon { get; }
        MagicSchools SelectedSchool { get; }

        Character CreatedHero { get; }

        void LoadCharacter(Character c);
        void SetCreateMode();
        DialogResult ShowDialog();
        void Show();
        void Close();
    }
}
