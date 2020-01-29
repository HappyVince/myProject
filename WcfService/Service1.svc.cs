using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string somme(int value1, int value2)
        {
            return string.Format("{0} + {1} = {2}", value1, value2, value1+value2);
        }


        public void create(string clef, string contenu)
        {
            var model = new Model1();
            var messages = model.Messages;

            Message message = new Message(clef, contenu);
            messages.Add(message);
            model.SaveChanges();
        }


        public string read(string clef)
        {
            var model = new Model1();
            var messages = model.Messages;
            string str = null;
            if (messages.Find(clef) != null)
            {
                str = messages.Find(clef).Contenu;
            }
            return str;
        }

        public void remove(string clef)
        {
            var model = new Model1();
            var messages = model.Messages;
            messages.Remove(messages.Find(clef));
            model.SaveChanges();
        }
    }
}
