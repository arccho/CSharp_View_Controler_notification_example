using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Example_Event_Between_Class
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();
        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        ControllerBackGroundWorker controllerBGW = new ControllerBackGroundWorker();
        private bool _etat = false;

        public Form1()
        {
            InitializeComponent();

            //abonne les méthodes aux évènements du BackGroundWorker
            controllerBGW.Subscribe_BackGroundWorker_ProgressChanged(bwProgress_ProgressChanged);
            controllerBGW.Subscribe_BackGroundWorker_Completed(bwProgress_RunWorkerCompleted);
        }

        private void Btn_Go_Click(object sender, EventArgs e)
        {
            controller.sendMessageToView += eventReceived; //Abonne eventReceived à l'évènement sendMessageToView
            controller.doSomething();
        }

        //Méthode abonné à l'évenement
        private void eventReceived(object sender, MyEventArgs e)
        {
            // Ici, on vient ajouter le message à la vue, mettre à jour le pourcentage, etc ....
            Rich_Tbx.AppendText(e.message + "\n");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////     PARTIE BACKGROUNDWORKER       //////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Btn_BackGroundWorker_Click(object sender, EventArgs e)
        {
            //Boutton qui lance le BackGroundWorker ou l'arrête si en cours de traitement
            if (!_etat)//lance
            {
                Rich_Tbx.Clear();
                controllerBGW.RunBGW();
                Btn_BackGroundWorker.Text = "Annuler BGW";
            }
            else//arrête/annule
            {
                controllerBGW.CancelBGW();
                Btn_BackGroundWorker.Text = "Démarrer BGW";
            }

            _etat = !_etat;
        }

        //méthode abonnée au BackGroundWorker du controleur (voir constructeur Form1)
        //Ce déclanche lorque BGW.ReportProgress est executé (dans BGW_DoWork du controleur)
        private void bwProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Rich_Tbx.AppendText(e.UserState.ToString() + "\n");
            Rich_Tbx.ScrollToCaret();
        }

        //méthode abonnée au BackGroundWorker du controleur (voir constructeur Form1)
        //Ce déclanche lorsque le BGW a terminé
        private void bwProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _etat = false;
            Btn_BackGroundWorker.Text = "Démarrer BGW";
            MessageBox.Show("Le BackgroundWorker a terminé");
        }
    }
}
