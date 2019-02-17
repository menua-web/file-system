using Domain.Entities;
using System;

namespace Domain.Extensions
{
    /// <summary>
    /// This class represents extensions methods for CRUD operations
    /// </summary>
    public static class EntityBaseExtension
    {
        /// <summary>
        /// Extension method for initialize of entity. 
        /// </summary>
        /// <typeparam name="TKey">Placeholder for ID of entity type.</typeparam>
        /// <param name="self">Self entity</param>
        public static void Create<TKey>(this EntityBase<TKey> self)
        {
            self.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Extension methd for logical delete of entity.
        /// </summary>
        /// <typeparam name="TKey">Placeholder for ID of entity type.</typeparam>
        /// <param name="self">Self entity</param>
        public static void Delete<TKey>(this EntityBase<TKey> self)
        {
            self.Deleted = true;
            self.ModifyDate = DateTime.Now;
        }

        /// <summary>
        /// Extension method for modify of entity.
        /// </summary>
        /// <typeparam name="TKey">Placeholder for ID of entity type.</typeparam>
        /// <param name="self">Self entity</param>
        public static void Modifay<TKey>(this EntityBase<TKey> self)
        {
            self.ModifyDate = DateTime.Now;
        }
    }
}
