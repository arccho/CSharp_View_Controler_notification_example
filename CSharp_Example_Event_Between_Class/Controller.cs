using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSharp_Example_Event_Between_Class
{
    class Controller
    {
        public event EventHandler<MyEventArgs> sendMessageToView;   //évènement qui retourne un objet MyEventArgs quand il se déclanche

        public void doSomething()
        {
            MyEventArgs myArgs = new MyEventArgs(); //Objet contenant des attributs envoyés à travers l'évènement

            for(int i=0; i < 10; i++)
            {
                myArgs.message = "message numero " + (i+1);   //écrit dans un attribut de l'objet renvoyé par l'évènement
                sendMessageToView(this, myArgs);    //déclanche l'évènement
            }
        }
    }

    public class MyEventArgs : EventArgs //Classe utilisée par l'évènement qui retournera un objet de cette classe
    {
        public string message { get; set; }
        public double autreattibut { get; set; }
    }
}
