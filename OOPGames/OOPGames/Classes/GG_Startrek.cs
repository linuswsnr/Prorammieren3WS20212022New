﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public class GG_StartrekPainter : GG_IStartrekPainter
    {  
        List<GG_Meteo> _Meteos = new List<GG_Meteo>();  
        uint _aufrufe = 0;
        int _spawnspeed = 20; //Takt der Meteoerzeugung
        int _spawnnum = 2; //Anzahl der je Spawn erzeugten Meteos
        int _movespeed = 20; //Takt der Bewegung 
        bool _collision = false;


        bool GG_IStartrekPainter.Collison { get { return _collision; } }

        public string Name => throw new NotImplementedException();

        public void checkCollison()
        {
            throw new NotImplementedException();
        }

        public void spawnMeteos()
        {
            GG_Meteo meteo = new GG_Meteo();
            //Gegen Meteos an gleicher Posititon absichern
            while (meteo.PositionColum == _Meteos[_Meteos.Count].PositionColum)
            {
                meteo = new GG_Meteo();
            }
            _Meteos.Add(meteo);
        }

        public void moveMetos()
        {
            foreach (GG_Meteo meteo in _Meteos)
            {
                meteo.UpdatePos();
                //Wenn Meteo aus Spielfeld -> Löschen
                if(meteo.PositionRow > 6)
                {
                    _Meteos.Remove(meteo);
                }
            }
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            _aufrufe++;

            if((_aufrufe+_spawnspeed)%_spawnspeed == 0) //+spwanspeed dass bei Spielstart gleich gespawnd wird
            {   for(int i = 0; i<_spawnnum; i++)
                {
                    spawnMeteos();
                }
                
            }
            if(_aufrufe%_movespeed == 0)
            {
                moveMetos();
            }

        }
    }

    public class GG_Meteo : GG_IMeteo
    {
        private int _PositionRow;
        private int _PositionColum;
        public int PositionRow { get { return _PositionRow; } }

        public int PositionColum { get { return _PositionColum; } }

        public GG_Meteo()
        {   //Bei erstellen des Objekts wird der Meteo in einer zufälligen Spalte in Reihe
            //0 gesetzt
            Random rand = new Random();
            _PositionRow = 0;
            _PositionColum = rand.Next(0,5);
        }

        public void UpdatePos()
        {
            _PositionRow++;
        }
    }
}
