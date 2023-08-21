using MyProtocolsApp_VolmarC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_VolmarC.ViewModels
{
    public class ProtocolViewModel : BaseViewModel
    {
        public Protocol MyProtocol { get; set; }
        public ProtocolViewModel() 
        {
            MyProtocol = new Protocol();
        }

        //funciones del vm
        public async Task<ObservableCollection<Protocol>> GetProtocolsAsync(int pUserID) 
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {

                ObservableCollection<Protocol> protocols = new ObservableCollection<Protocol>();

                MyProtocol.UserId = pUserID;

                protocols = await MyProtocol.GetProtocolListoByUserID();

                if(protocols == null)
                {
                    return null;
                }
                return protocols;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



    }
}
