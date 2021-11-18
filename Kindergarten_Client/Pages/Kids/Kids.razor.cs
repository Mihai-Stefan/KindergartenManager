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
        private IEnumerable<Kid> perPagKids = Enumerable.Empty<Kid>();

        //pagination
        private int pageIndex = 1;
        private int itemsPerPage = 5;
        private int totalPages = 1;

        [Inject]
        public IKidHttpRepository KidRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            KidList = await KidRepo.GetKids();

            //pagination
            if (KidList != null)
            {
                // Initialize the number of "totalPages"
                totalPages = (int)(KidList.Count() / itemsPerPage);

                perPagKids = KidList.Skip(0).Take(itemsPerPage);
            }
        }

        private void SelectedPage(int selectedPageIndex)
        {
            if (KidList != null)
            {
                pageIndex = selectedPageIndex;
                var skipCount = itemsPerPage * (pageIndex - 1);
                perPagKids = KidList.Skip(skipCount).Take(itemsPerPage);
            }
        }


        // filtering
        public string Filter { get; set; }

        // IsVisible
        public bool IsVisible(Kid kid)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;
            // search in names
            if (kid.FirstName.Contains(Filter, StringComparison.OrdinalIgnoreCase) || kid.LastName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            //search in details
            if (kid.Details.Contains(Filter, StringComparison.OrdinalIgnoreCase) || kid.LastName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        // sorting
        private bool isSortedAscending;
        private string activeSortColumn;

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                KidList = KidList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;
            }
            else
            {
                if (isSortedAscending)
                {
                    KidList = KidList.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    KidList = KidList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                isSortedAscending = !isSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (activeSortColumn != columnName)
            {
                return string.Empty;
            }
            if (isSortedAscending)
            {
                return "fa-sort-up";
            }
            else
            {
                return "fa-sort-down";
            }
        }

    }
}
