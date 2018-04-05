using System;
namespace Person{
    public class Human{
        public string name;
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        public int health;
        
        public Human(string myname){
            name = myname;
            strength = 3;
            dexterity = 3;
            intelligence = 3;
            health = 100;
        }
        public Human(string myname, int str, int dex, int intel, int hp){
            name = myname;
            strength = str;
            dexterity = dex;
            intelligence = intel;
            health = hp;
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
    public class Wizard : Human{
        Random rand = new Random();
        public Wizard(string myname):base(myname){
            intelligence = 25;
            health = 50;
            
        }

        public void heal(){
            if(this.health < 50){
                this.health+=10*this.intelligence;
                if(this.health > 50){
                    this.health = 50;
                }
                Console.WriteLine("Healed for {0}, going up to {1} hp!",10*this.intelligence,this.health);
            }
            else{
                Console.WriteLine("{} was already at full health, so the healing did nothing!",this.name);
            }
        }

        public void fireball(object enemy){
            if(enemy is Human){
                Human myenemy = enemy as Human;
                int damage = rand.Next(20,51);
                myenemy.health -= damage;
                if(myenemy.health < 0){
                    myenemy.health = 0;
                }
                Console.WriteLine("{0} lost {1} hp! {2} remaining.",myenemy.name,damage,myenemy.health);
                enemy = myenemy;
            }
            else if(enemy is Enemy){
                Enemy myenemy = enemy as Enemy;
                int damage = rand.Next(20,51);
                myenemy.health -= damage;
                if(myenemy.health < 0){
                    myenemy.health = 0;
                }
                Console.WriteLine("{0} lost {1} hp! {2} remaining.",myenemy.name,damage,myenemy.health);
                enemy = myenemy;
            }
        }
    }

    public class Ninja : Human{
        public Ninja(string myname):base(myname){
            dexterity = 175;
        }
        
        public void steal(object enemy){
            if(enemy is Human){
                Human myenemy = enemy as Human;
                this.attack(myenemy);
                this.health+=10;
                Console.WriteLine("{0} gained 10 health, going up to {1}!",this.name,this.health);
            }
            else if(enemy is Enemy){
                Enemy myenemy = enemy as Enemy;
                this.attack(myenemy);
                this.health+=10;
                Console.WriteLine("{0} gained 10 health, going up to {1}!",this.name,this.health);
            }
        }

        public void get_away(){
            this.health -= 15;
            if(this.health < 0){
                this.health = 0;
            }
        }
    }
    public class Samurai : Human{
        private static int numsams;
        public Samurai(string myname):base(myname){
            health = 200;
            numsams+=1;
        }
        public void death_blow(object enemy){
            if(enemy is Human){
                Human myenemy = enemy as Human;
                if(myenemy.health < 50){
                    Console.WriteLine("{0} has received a death blow! Hp is now 0!",myenemy.name);
                    myenemy.health = 0;
                }
                else{
                    this.attack(myenemy);
                }
                enemy = myenemy;
            }
            else if(enemy is Enemy){
                Enemy myenemy = enemy as Enemy;
                Console.WriteLine(myenemy.health);
                if(myenemy.health < 50){
                    Console.WriteLine("{0} has received a death blow! Hp is now 0!",myenemy.name);
                    myenemy.health = 0;
                }
                else{
                    this.attack(myenemy);
                }
                enemy = myenemy;
            }
        }
        public void meditate(){
            this.health = 200;
            Console.WriteLine("{0} meditated, regaining all missing health!",this.name);
        }

        public void how_many(){
            Console.WriteLine("There are {0} samurai!",numsams);
        }
    }
}