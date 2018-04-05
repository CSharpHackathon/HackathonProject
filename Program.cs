using System;


namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai Champloo = new Samurai("Champloo");
            Wizard Skeletor = new Wizard("Skeletor");
            Ninja Gotou = new Ninja("Gotou");
            Zombie Zombie1 = new Zombie("Zombie1");
            Zombie Zombie2 = new Zombie("Zombie2");
            Spider Spider1 = new Spider("Spider1");
            Human[] allies = {Champloo,Skeletor,Gotou};
            Enemy[] enemies = {Zombie1,Zombie2,Spider1};
            encounter(allies, enemies);
        }
        static void encounter(Human[] allies,Enemy[] enemies){
            Random rand = new Random();
            Console.WriteLine("Random encounter! Enemies appeared!");
            int totallength = allies.Length+enemies.Length;
            object[] turns = new object[totallength];
            int i = 0;
            foreach(Human ally in allies){
                turns[i] = ally;
                i++;
            }
            foreach(Enemy enemy in enemies){
                turns[i] = enemy;
                i++;
            }
            foreach(Enemy enemy in enemies){
                Console.WriteLine(enemy.name);
            }
            int turncount = 0; 
            while(true){
                Boolean allieswin = true;
                Boolean enemieswin = true;
                foreach(Enemy enemy in enemies){
                    if(enemy.health > 0){
                        allieswin = false;
                    }
                }
                foreach(Human ally in allies){
                    if(ally.health > 0){
                        enemieswin = false;
                    }
                }
                if(allieswin == true){
                    Console.WriteLine("You win! Commence victory theme!");
                    break;
                }
                if(enemieswin == true){
                    Console.WriteLine("The allied party has died. Now the sacred crystals will never be collected, and darkness will forever rule throughout the land. Game Over.");
                    break;
                }
                int myturn = turncount%totallength;
                Console.WriteLine(myturn);
                if(turns[myturn] is Enemy){
                    Enemy currenemy = turns[myturn] as Enemy;
                    if(currenemy.health == 0){
                        turncount += 1;
                        continue;
                    }
                    Console.WriteLine("{0}'s turn!",currenemy.name);
                    int mytarget = 0;
                    while(true){
                        mytarget = rand.Next(0,allies.Length);
                        if(allies[mytarget].health > 0){
                            currenemy.attack(allies[mytarget]);
                            break;
                        }
                    }
                    turns[myturn] = currenemy;
                }
                else if(turns[myturn] is Human){
                    string command = "default";
                    string target = "default";
                    Enemy mytarget = enemies[0];
                    if(turns[myturn] is Samurai){
                        Samurai turnplayer = turns[myturn] as Samurai;
                        if(turnplayer.health == 0){
                            turncount += 1;
                            continue;
                        }
                        while(true){
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?",turnplayer.name);
                            command = Console.ReadLine();
                            if(command != "attack" && command != "deathblow" && command != "meditate"){
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if(command != "meditate"){
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                                foreach(Enemy enemy in enemies){
                                    if(target == enemy.name){
                                        mytarget = enemy;
                                        found = true;
                                        break;
                                    }
                                }
                                if(found == false){
                                    Console.WriteLine("Invalid target.");
                                    continue;
                                }
                            }
                            if(command == "attack"){
                                turnplayer.attack(mytarget);
                                break;
                            }
                            else if(command == "deathblow"){
                                turnplayer.death_blow(mytarget);
                                break;
                            }
                            else if(command == "meditate"){
                                turnplayer.meditate();
                                break;
                            }
                        }
                    }
                    else if(turns[myturn] is Wizard){
                        Wizard turnplayer = turns[myturn] as Wizard;
                        if(turnplayer.health == 0){
                            turncount += 1;
                            continue;
                        }
                        while(true){
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?",turnplayer.name);
                            command = Console.ReadLine();
                            if(command != "attack" && command != "fireball" && command != "heal"){
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if(command != "heal"){
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                                foreach(Enemy enemy in enemies){
                                    if(target == enemy.name){
                                        mytarget = enemy;
                                        found = true;
                                        break;
                                    }
                                }
                                if(found == false){
                                    Console.WriteLine("Invalid target.");
                                    continue;
                                }
                            }
                            
                            
                            if(command == "attack"){
                                turnplayer.attack(mytarget);
                                break;
                            }
                            else if(command == "fireball"){
                                turnplayer.fireball(mytarget);
                                break;
                            }
                            else if(command == "heal"){
                                turnplayer.heal();
                                break;
                            }
                        }
                    }
                    else if(turns[myturn] is Ninja){
                        Ninja turnplayer = turns[myturn] as Ninja;
                        if(turnplayer.health == 0){
                            turncount += 1;
                            continue;
                        }
                        while(true){
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?",turnplayer.name);
                            command = Console.ReadLine();
                            if(command != "attack" && command != "steal" && command != "getaway"){
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            if(command != "getaway"){
                                Console.WriteLine("Targeting what?");
                                target = Console.ReadLine();
                            }
                            foreach(Enemy enemy in enemies){
                                if(target == enemy.name){
                                    mytarget = enemy;
                                    found = true;
                                    break;
                                }
                            }
                            if(found == false){
                                Console.WriteLine("Invalid target.");
                                continue;
                            }
                            if(command == "attack"){
                                turnplayer.attack(mytarget);
                                break;
                            }
                            else if(command == "steal"){
                                turnplayer.steal(mytarget);
                                break;
                            }
                            else if(command == "getaway"){
                                turnplayer.get_away();
                                Console.WriteLine("{} couldn't get away!",turnplayer.name);
                                break;
                            }
                        }
                    }
                    else{
                        Human turnplayer = turns[myturn] as Human;
                        if(turnplayer.health == 0){
                            turncount += 1;
                            continue;
                        }
                        while(true){
                            Boolean found = false;
                            Console.WriteLine("What will {0} do?",turnplayer.name);
                            command = Console.ReadLine();
                            if(command != "attack"){
                                Console.WriteLine("Invalid command.");
                                continue;
                            }
                            foreach(Enemy enemy in enemies){
                                if(target == enemy.name){
                                    mytarget = enemy;
                                    found = true;
                                    break;
                                }
                            }
                            if(found == false){
                                Console.WriteLine("Invalid target.");
                                continue;
                            }
                            if(command == "attack"){
                                turnplayer.attack(mytarget);
                                break;
                            }
                        }
                    }
                    
                }
                turncount += 1;
            }
        }
    }
}
