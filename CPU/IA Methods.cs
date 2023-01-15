using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMD
{
    public static class IAM
    {
        public static int numberCardsOnField(Player player)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[player.Index, i] != null) count+=1;
            }
            return count;
        }
        public static int freePos(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[player.Index, i] == null) return i;
            }
            return -1;
        }
        public static Cards cardMaxAtk(Player player, int min = 1)
        {
            //selecciona la carta con mas ataque en el campo del player que se le pase, si no hay ninguna devuelve una carta predefinida para poder
            //trabajar con ella. Si se le pasa un -1 adicional en el llamado del metodo devuelve el de menor ataque
            Cards aux = new Cards("", new IncreaseAtk(""), "", "", 0, 0, 0);
            for (int i = 0; i < Game.Field.GetLength(1); i++)
            {
                if (Game.Field[player.Index, i] != null) 
                {
                    if (aux.Name == "") aux = Game.Field[player.Index, i];
                    else if ((aux.Attack * min) < (Game.Field[player.Index, i].Attack * min)) aux = Game.Field[player.Index, i];
                }
            }
            return aux;
        }
        public static int posCard(Cards card, Player player)
        {
            //Devuelve la posicion de la carta que le pases en el lado del campo del player que le pases. Si no la encuentra lanza excepcion
            int pos = player.Index;
            if (card.Type == "Course" || card.Type == "Spell" ) { pos = pos == 1 ? pos -1 : pos +1 ;}
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[pos, i] == card) return i;
            }
            throw new Exception("Esa carta no esta en el campo");
        }
        public static Cards handMaxAtk(Player player, int min = 1)
        {
            //Devuelve la carta con mas ataque de la mano del player que se le pase, si no hay ninguna devuelve una predefinida para poder trabajar con ella
            Cards aux = new Cards("", new IncreaseAtk(""), "", "", 0, 0, 0);
            for (int i = 0; i < player.Hand.Count; i++)
            {
                if (aux.Attack * min < player.Hand[i].Attack * min) aux = player.Hand[i];
            }
            return aux;
        }
        public static Cards card2ndMaxAtk(Player player, int min = 1)
        {
            //selecciona la 2da carta con mas ataque en el campo del player que se le pase, si no hay al menos 2 cartas devuelve una predefinida 
            //para poder trabajar con ella. Si se le pasa un -1 adicional en el llamado del metodo devuelve la 2da de menor ataque
            Cards aux = new Cards("", new IncreaseAtk(""), "", "", 0, 0, 0);
            Cards aux2 = new Cards("", new IncreaseAtk(""), "", "", 0, 0, 0);
            for (int i = 0; i < Game.Field.GetLength(1); i++)
            {
                if (Game.Field[player.Index, i] != null) 
                {
                    if (aux.Name == "") aux = Game.Field[player.Index, i];
                    else if ((aux.Attack * min) < (Game.Field[player.Index, i].Attack * min)) 
                    {
                        aux2 = aux;
                        aux = Game.Field[player.Index, i];
                    }
                }
            }
            return aux2;
        }
        public static Cards cardMaxMinManna(Player player, int min = 1)
        {
            Cards aux = new Cards("", new IncreaseAtk(""), "", "", 0, 0, 0);
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[player.Index, i] != null) 
                {
                    if (aux.Name == "") aux = Game.Field[player.Index, i];
                    else if ((aux.Energy * min) < (Game.Field[player.Index, i].Energy * min)) aux = Game.Field[player.Index, i];
                }
            }
            return aux;
        }
        public static bool AnyLowerCard(Cards card, Player player)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if(Game.Field[player.Index,i] != null)
                {
                    if(Game.Field[player.Index,i].Attack > card.Attack) count += 1;
                }
                else count += 1;
            }
            return count == 3 ? true : false;
        }
    }
}