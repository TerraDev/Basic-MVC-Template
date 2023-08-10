using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MVCtest.Application.Utility;
using MVCtest.Domain;
using MVCtest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Application
{
    public class ItemService
    {
        AppDbContext _ctx;
        private readonly FileService _fs;

        public ItemService(AppDbContext ctx, FileService fs)
        {
            _ctx = ctx;
            _fs = fs;
        }

        public async Task<List<Item>> GetAllItemsinPage(int PageSize, int PageNum, string? search = null)
        {

            return search != null 
                ?
                await _ctx.Items.Where(x => x.Name.Contains(search))
                .Include(x => x.User).Page(PageSize, PageNum).ToListAsync() 
                :
                await _ctx.Items.Include(x => x.User)/*.Page(PageSize, PageNum)*/.ToListAsync();
        }

        //If include doesn't work, use Microsoft.EntityFrameworkCore instead of System.Data.Entity
        public async Task<Item> GetItem(ulong id)
        {
            return await _ctx.Items.Include(u => u.User).SingleAsync(x => x.Id == id);
        }

        public async Task<bool> CreateItem(Item item, IFormFile file)
        {
            using (IDbContextTransaction tx = _ctx.Database.BeginTransaction())
            {
                item.createDate = DateTime.Now;
                _ctx.Items.Add(item);

                if (file != null)
                {
                    string fileName = await _fs.StoreFileAsync(file, "Images/Items");
                    item.ImageName = fileName;
                }

                if (await _ctx.SaveChangesAsync() > 0)
                {
                    await tx.CommitAsync();
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool>  updateItem(Item item, IFormFile file)
        {
            if(!_ctx.Items.Any(x => x.Id == item.Id))
            {
                throw new Exception("CANNOT update object that doesn't exist!");
            }

            using(IDbContextTransaction tx = _ctx.Database.BeginTransaction())
            {
                item.updateDate = DateTime.Now;
                _ctx.Items.Update(item);

                if (file != null)
                {
                    //TODO: if saved image name != existing image name of item
                    string fileName = await _fs.StoreFileAsync(file, "Images/Items");
                    item.ImageName = fileName;
                }

                if (await _ctx.SaveChangesAsync() > 0)
                {
                    await tx.CommitAsync();
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool> deleteItem(ulong id)
        {
            if (!_ctx.Items.Any(x => x.Id == id))
            {
                throw new Exception("CANNOT remove object that doesn't exist!");
            }

            Item item = _ctx.Items.AsTracking().Single(x => x.Id == id);
            item.isDeleted = true;

            _ctx.Entry<Item>(item).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> useItem(ulong id, string UserId)
        {
            if (!_ctx.Items.Any(x => x.Id == id))
            {
                throw new Exception("CANNOT use object that doesn't exist!");
            }

            Item item = _ctx.Items.AsTracking().Single(x => x.Id == id);
            item.UserId = UserId;

            _ctx.Entry<Item>(item).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }
    }
}
