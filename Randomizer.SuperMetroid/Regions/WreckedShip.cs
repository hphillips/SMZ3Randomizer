﻿using System.Collections.Generic;
using static Randomizer.SuperMetroid.ItemType;
using static Randomizer.SuperMetroid.Logic;

namespace Randomizer.SuperMetroid.Regions {

    class WreckedShip : Region {

        public override string Name => "Wrecked Ship";
        public override string Area => "Wrecked Ship";

        public WreckedShip(World world, Logic logic) : base(world, logic) {
            Locations = new List<Location> {
                new Location(this, "Missile (Wrecked Ship middle)", LocationType.Visible, 0x7C265),
                new Location(this, "Reserve Tank, Wrecked Ship", LocationType.Chozo, 0x7C2E9, Logic switch {
                    Casual => items => items.Has(SpeedBooster) && items.CanUsePowerBombs() &&
                        (items.Has(Grapple) || items.Has(SpaceJump) || items.Has(Varia) && items.HasEnergyReserves(2) || items.HasEnergyReserves(3)),
                    _ => new Requirement(items => items.CanUsePowerBombs() && items.Has(SpeedBooster) && (items.Has(Varia) || items.HasEnergyReserves(2)))
                }),
                new Location(this, "Missile (Gravity Suit)", LocationType.Visible, 0x7C2EF, Logic switch {
                    Casual => items => items.Has(Grapple) || items.Has(SpaceJump) || items.Has(Varia) && items.HasEnergyReserves(2) || items.HasEnergyReserves(3),
                    _ => new Requirement(items => items.Has(Varia) || items.HasEnergyReserves(1))
                }),
                new Location(this, "Missile (Wrecked Ship top)", LocationType.Visible, 0x7C319),
                new Location(this, "Energy Tank, Wrecked Ship", LocationType.Visible, 0x7C337, Logic switch {
                    Casual => items => items.Has(HiJump) || items.Has(SpaceJump) || items.Has(SpeedBooster) || items.Has(Gravity),
                    _ => new Requirement(items => items.Has(Bombs) || items.Has(PowerBomb) || items.CanSpringBallJump() ||
                        items.Has(HiJump) || items.Has(SpaceJump) || items.Has(SpeedBooster) || items.Has(Gravity))
                }),
                new Location(this, "Super Missile (Wrecked Ship left)", LocationType.Visible, 0x7C357),
                new Location(this, "Right Super, Wrecked Ship", LocationType.Visible, 0x7C365),
                new Location(this, "Gravity Suit", LocationType.Chozo, 0x7C36D, Logic switch {
                    Casual => items => items.Has(Grapple) || items.Has(SpaceJump) || items.Has(Varia) && items.HasEnergyReserves(2) || items.HasEnergyReserves(3),
                    _ => new Requirement(items => items.Has(Varia) || items.HasEnergyReserves(1))
                })
            };
        }

        public override bool CanEnter(List<Item> items) {
            return Logic switch {
                Casual =>
                    items.Has(Super) && items.CanUsePowerBombs() && (
                        items.Has(SpeedBooster) || items.Has(Grapple) || items.Has(SpaceJump) ||
                        items.Has(Gravity) && (items.CanFly() || items.Has(HiJump))),
                _ =>
                    items.Has(Super) && items.CanUsePowerBombs()
            };
        }

    }

}