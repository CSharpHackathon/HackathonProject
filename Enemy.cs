using System;
namespace Person{
    public class Enemy{
        public string name;
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        public int health;
        
        public Enemy(string myname){
            name = myname;
            strength = 3;
            dexterity = 3;
            intelligence = 3;
            health = 75;
        }

        public void attack(object enemy){
            if(enemy is Human){
                Human myenemy = enemy as Human;
                myenemy.health -= 5*this.strength;
                if(myenemy.health < 0){
                    myenemy.health = 0;
                }
                Console.WriteLine("{0} lost {1} hp! {2} remaining.",myenemy.name,5*this.strength,myenemy.health);
                enemy = myenemy;
            }
            else if(enemy is Enemy){
                Enemy myenemy = enemy as Enemy;
                myenemy.health -= 5*this.strength;
                if(myenemy.health < 0){
                    myenemy.health = 0;
                }
                Console.WriteLine("{0} lost {1} hp! {2} remaining.",myenemy.name,5*this.strength,myenemy.health);
                enemy = myenemy;  
            }
        }
    }

    public class Spider : Enemy{
        public Spider(string myname):base(myname){
            dexterity = 50;
            strength = 4;
            intelligence = 2;
        }
    }
    
    public class Zombie : Enemy{
        public Zombie(string myname):base(myname){
            dexterity = 2;
            intelligence = 1;
            strength = 6;
            health = 175;
        }
    }
}