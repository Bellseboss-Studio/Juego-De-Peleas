﻿public class Ejemplo1 : EstadisticasBase
{
    public override void Awake()
    {
        base.Awake();
        Vida += 50;
        Fuerza = 1;
        Speed = 2;
        SpeedJump = 10;
        SaltaAlDragonPunch = true;
    }
}
