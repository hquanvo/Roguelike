using Roguelike.Core;
using RogueSharp.DiceNotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.System
{
    public class CommandSystem
    {
        // Return true if player was moved, false otherwise
        public bool MovePlayer(Direction direction)
        {
            int x = Game.Player.X;
            int y = Game.Player.Y;
            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Game.Player.Y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Game.Player.Y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Game.Player.X - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Game.Player.X + 1;
                        break;
                    }
                default: return false;
            }
            Monster monster = Game.DungeonMap.GetMonsterAt(x, y);

            if (monster != null)
            {
                Attack(Game.Player, monster);
                return true;
            }
            if (Game.DungeonMap.SetActorPosition(Game.Player, x, y)) return true;
            return false;
        }

        // Perform an attack move from attacker to defender
        public void Attack(Actor attacker, Actor defender)
        {

            int hitChance = Math.Min(Math.Max(50, attacker.Speed/defender.Speed * 100), 150);

            Game.MessageLog.AddLine($"{attacker.Name} attacks {defender.Name}!");

            bool landHit = ResolveHitChance(hitChance);
            ResolveDamage(attacker, defender, landHit);
            
            
        }
        
        // Calculate damage based on attacker's and defender's stats
        private void ResolveDamage(Actor attacker, Actor defender, bool landHit)
        {
            if (landHit)
            {
                int damage = attacker.Attack - defender.Defense;
                if (damage < 0) Game.MessageLog.AddLine($"{defender.Name} takes 0 damage!");
                else
                {
                    // Variation between -5% and 5% of base dmg
                    int damageVariation = (int)damage * (Dice.Roll("1d6") - Dice.Roll("1d6")) / 100;
                    int finalDamage = damage + damageVariation;
                    defender.Health = defender.Health - finalDamage;
                    Game.MessageLog.AddLine($"  {defender.Name} takes {finalDamage} damage");
                    if (defender.Health <= 0)
                    {
                        ResolveDeath(attacker, defender);
                    }
                }
                
            } else
            {
                Game.MessageLog.AddLine("The attack missed!");
            }
        }

        // Remove defender from map, add message on death
        private static void ResolveDeath(Actor attacker, Actor defender)
        {
            if (defender is Player)
            {
                Game.MessageLog.AddLine($"  {defender.Name} was killed. Game over!");
            }
            else if (defender is Monster)
            {
                Monster monster = defender as Monster;
                Player player = attacker as Player;
                Game.DungeonMap.RemoveMonster(monster);

                Game.MessageLog.AddLine($"  {monster.Name} died and dropped {monster.Gold} gold");
                Game.MessageLog.AddLine($"Gained {monster.ExpValue} Exp!");
                player.Exp = player.Exp + monster.ExpValue;
            }
        }

        // Calculate if a hit is successful based on hit chance by simulating a biased coin
        private static bool ResolveHitChance(int hitChance)
        {
           Random rand = new Random();
            int value = rand.Next(1, 101);
            if (value <= hitChance) return true;
            return false;
        }
    }
}
