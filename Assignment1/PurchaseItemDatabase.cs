using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite;

namespace Assignment1
{
    public class PurchaseItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DBConstraints.DatabasePath, DBConstraints.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PurchaseItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        //method is responsible for checking if a table already exists for storing HistoryItem objects.This method automatically creates the table 
        //    if it doesn't exist.

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(HistoryItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(HistoryItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<HistoryItem>> GetItemsAsync()
        {
            return Database.Table<HistoryItem>().ToListAsync();
        }

        public Task<List<HistoryItem>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<HistoryItem>("SELECT * FROM [HistoryItem] WHERE [Done] = 0");
        }

        public Task<HistoryItem> GetItemAsync(int id)
        {
            return Database.Table<HistoryItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(HistoryItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(HistoryItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
