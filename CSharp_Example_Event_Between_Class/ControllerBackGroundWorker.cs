using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_Example_Event_Between_Class
{
    //Cette classe permet d'implémenter un BackGroundWorker et d'abonner des méthodes depuis d'autres classes
    //Ainsi le controleur peut appeler des méthodes de classes dont il ne connait pas et rester indépendant
    class ControllerBackGroundWorker
    {
        private BackgroundWorker BGW;
        public ControllerBackGroundWorker()
        {
            BGW = new BackgroundWorker();
            BGW.WorkerReportsProgress = true; //active l'évènement ProgressChangedEventHandler
            BGW.WorkerSupportsCancellation = true; //active l'annulation du BGW
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork); //abonne la méthode BGW_DoWork à l'évènement DoWorkEventHandler du BGW
        }

        //permet d'executer le BGW
        public void RunBGW()
        {
            BGW.RunWorkerAsync();
        }

        //permet d'arrêter le BGW et d'annuler ses traitements & notifications
        public void CancelBGW()
        {
            BGW.CancelAsync();
        }

        //abonne la méthode en paramètre methodProgress à l'évenement ProgressChangedEventHandler du BackgroundWorker
        public void Subscribe_BackGroundWorker_ProgressChanged(ProgressChangedEventHandler methodProgress)
        {
            BGW.ProgressChanged += new ProgressChangedEventHandler(methodProgress);
        }

        //abonne la méthode en paramètre methodCompleted à l'évenement RunWorkerCompletedEventHandler du BackgroundWorker
        public void Subscribe_BackGroundWorker_Completed(RunWorkerCompletedEventHandler methodCompleted)
        {
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(methodCompleted);
        }

        //méthode abonnée à l'évènement DoWorkEventHandler
        //Il s'agit de la méthode s'occupant des calculs (elle est donc définie dans le controleur)
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            int max = new Random().Next(0, 300);

            //Tant que le traitement n'est pas terminé OU que l'on ne demande pas à d'annuler
            while (i < max && !BGW.CancellationPending)
            {
                //On attend quelques ms pour avoir un meilleur visuel :)
                Thread.Sleep(20);

                //Déclanche l'évènement ProgressChangedEventHandler, qui va notifier toutes les méthodes abonnée à cet évènement
                BGW.ReportProgress(i, "message numero " + (i + 1));//paramètre 1 renvoie un int et paramètre 2 un objet (ici cast en string)
                i++;
            }
        }
    }
}
