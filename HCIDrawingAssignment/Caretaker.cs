using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIDrawingAssignment
{
    class Caretaker
    {
        List<Momento> actionList;
        List<Momento> undoneList;
        int firstUndo;

        public Caretaker()
        {
            actionList = new List<Momento>();
            undoneList = new List<Momento>();
            firstUndo = 0;
        }

        public void add(Momento action)
        {
            actionList.Add(action);
        }



        public Momento undo(Momento currentScreen)
        {
            Momento tempMomento = actionList.Last();
            //undoneList.Add(tempMomento);
            if (firstUndo == 0)
            {
                undoneList.Clear();
                undoneList.Add(currentScreen);
                firstUndo = 1;
            }
           
            actionList.Remove(tempMomento);
            return tempMomento;
        }

        public Momento redo()
        {
            firstUndo = 0;
            Momento tempMomento = undoneList.Last();
            actionList.Add(tempMomento);
            undoneList.Remove(tempMomento);
            return tempMomento;
        }

        public bool checkIfCanUndo()
        {
            return actionList.Any();
        }
        public bool checkIfCanRedo()
        {
            return undoneList.Any();
        }
    }
}
