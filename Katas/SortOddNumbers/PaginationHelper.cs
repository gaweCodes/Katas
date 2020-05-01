using System;
using System.Collections.Generic;

namespace Katas
{
    public class PaginationHelper<T>
    {
        private readonly IList<T> _list;
        private readonly int _itemsPerPage;
        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PaginationHelper(IList<T> collection, int itemsPerPage)
        {
            _list = collection;
            _itemsPerPage = itemsPerPage;
        }
        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount => _list.Count;
        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount => _list.Count / _itemsPerPage + 1;
        public int PageItemCount(int page)
        {
            if (page > PageCount-1 || page < 0) return -1;
            var prevCount = _itemsPerPage * page;
            var theoreticalMax = _itemsPerPage * (page + 1) - prevCount;
            return theoreticalMax + prevCount > _list.Count ? _itemsPerPage - Math.Abs(theoreticalMax + prevCount - _list.Count) : theoreticalMax;
        }
        public int PageIndex(int itemIndex)
        {
            if (itemIndex >= _list.Count || itemIndex < 0)
                return -1;
            var index = 0;
            while (_itemsPerPage <= itemIndex)
            {
                itemIndex -= _itemsPerPage;
                index++;
            }
            return index;
        }
    }
}