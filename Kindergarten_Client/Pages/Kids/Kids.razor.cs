using DataAccess.Data;
using Kindergarten_Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Client.Pages.Kids
{
    public partial class Kids
    {

        public List<Kid> KidList { get; set; } = new List<Kid>();
        [Inject]
        public IKidHttpRepository KidRepo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            KidList = await KidRepo.GetKids();
            //just for testing
            foreach (var kid in KidList)
            {
                Console.WriteLine(kid.FirstName);
            }
        }

    }
}
