using Models;
using System;

namespace Shared
{
    public interface IAddHeroView
    {
        event Action SaveEvent;
        event Action CancelEvent;
        event Action TypeChangedEvent;

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

        void Show();
        void Close();
        object DialogResult { get; set; }
    }
}
