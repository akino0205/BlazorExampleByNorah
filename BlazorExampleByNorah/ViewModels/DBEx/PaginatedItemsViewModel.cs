using System;
using System.Collections.Generic;

namespace BlazorExampleByNorah.ViewModels
{
    public class PaginatedItemsViewModel<TEntity> where TEntity : class
    {
        public int ActualPage { get; private set; }

        public int ItemsPerPage { get; private set; }

        public long TotalItems { get; private set; }

        public int TotalPages { get; set; }

        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedItemsViewModel(int actualPage, int itemsPerPage, long totalItems, IEnumerable<TEntity> data)
        {
            ActualPage = actualPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = itemsPerPage != 0 ? (int)Math.Ceiling(((decimal)totalItems / itemsPerPage)) : 0;
            Data = data;
        }
    }
}
