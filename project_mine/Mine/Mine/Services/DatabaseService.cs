﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using SQLite;

using Mine.Models;

namespace Mine.Services
{
    public class DatabaseService : IDataStore<ItemModel>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true; 
            }
        }

        /// <summary>
        /// code to insert data to the table in database 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.InsertAsync(item);
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public Task<bool> UpdateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Call to the ToListAsync method on Database with the Table called ItemModel
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            var result = await Database.Table<ItemModel>().ToListAsync();
            return result;
        }
    }
}
