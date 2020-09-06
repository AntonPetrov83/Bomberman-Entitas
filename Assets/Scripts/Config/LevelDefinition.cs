using System;

[Serializable]
public class LevelDefinition
{
    public int wallsCount = 50;
    public PowerupType powerup;
    public Enemies enemies;

    [Serializable]
    public struct Enemies
    {
        public int valcom;
        public int oneal;
        public int dahl;
        public int minvo;
        public int ovape;
        public int doria;
        public int pass;
        public int pontan;
    }    
}